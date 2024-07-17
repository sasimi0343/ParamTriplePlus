using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ParamTriplePlus.Params
{
    public class Param<T>
    {
        public T minimum;
        public T maximum;
        public Transion<T> Value { get; set; }
        public ParamType paramtype;
        public string NativeValue;
        public bool AllowOver;

        public string label;
        public List<string> options;
        public bool DisableTransion;

        public void Init()
        {
            if (typeof(T) == typeof(string))
            {
                paramtype = ParamType.String;
            }
            else if (typeof(T) == typeof(int))
            {
                paramtype = ParamType.Int;
            }
            else if (typeof(T) == typeof(float))
            {
                paramtype = ParamType.Float;
            }
            else if (typeof(T) == typeof(Vector2))
            {
                paramtype = ParamType.Vector2;
            }
            else if (typeof(T) == typeof(Vector3))
            {
                paramtype = ParamType.Vector3;
            }
            else if (typeof(T) == typeof(bool))
            {
                paramtype = ParamType.Boolean;
            }
            else if (typeof(T) == typeof(Color))
            {
                paramtype = ParamType.Color;
            }
            else if (typeof(T).IsEnum)
            {
                paramtype = ParamType.Combo;
                var values = Enum.GetValues(typeof(T));
                options = new List<string>();
                foreach (var item in values)
                {
                    options.Add(item.ToString());
                }
            }
            else if (typeof(T).Name == typeof(List<object>).Name)
            {
                paramtype = ParamType.List;
            }
        }

        public Param()
        {
            Value = new Transion<T>(this);
            Init();
        }

        public Param(string label = "")
        {
            this.label = label;
            Value = new Transion<T>(this);
            Init();
        }

        public Param(T initial, string label = "")
        {
            this.label = label;
            Value = new Transion<T>(this);
            Init();
            Value.initialValue = initial;
        }

        public Param(T initial, T max, T min, string label = "")
        {
            this.label = label;
            Value = new Transion<T>(this);
            Init();
            Value.initialValue = initial;
            maximum = max;
            minimum = min;
        }

        public Param(T initial, T max, T min, bool allowover, string label = "")
        {
            this.label = label;
            Value = new Transion<T>(this);
            Init();
            Value.initialValue = initial;
            maximum = max;
            minimum = min;
            AllowOver = allowover;
        }

        public Param(ParamType param, string label = "")
        {
            this.label = label;
            Value = new Transion<T>(this);
            paramtype = param;
        }

        public Param(ParamType param, T initial, string label = "")
        {
            this.label = label;
            Value = new Transion<T>(this);
            paramtype = param;
            Value.initialValue = initial;
        }

        public void SetInitial(T value)
        {
            Value.initialValue = value;
        }
    }

    public class ParamList //超大事
    {
        public ParamList() { } //コンストラクターはデシリアライズの過程で必要になるのでこれを継承する時は絶対つけろよな！

        public static List<object> GetParams(ParamList T)
        {
            var fields = T.GetType().GetFields();
            var list = new List<object>();
            foreach (var item in fields)
            {
                //Trace.WriteLine(item.FieldType.Name);
                if (!item.FieldType.IsGenericType || item.FieldType.Name != typeof(Param<object>).Name) continue;
                list.Add(item.GetValue(T));
            }

            return list;
        }

        public static T GetField<T>(object any, string n)
        {
            if (any.GetType().GetField(n) == null) return default;
            return (T)any.GetType().GetField(n).GetValue(any);
        }

        public static T GetProperty<T>(object any, string n)
        {
            if (any.GetType().GetProperty(n) == null) return default;
            return (T)any.GetType().GetProperty(n).GetValue(any);
        }

        public static T GetValueField<T>(object any, string n)
        {
            if (any.GetType().GetProperty("Value") == null) return default;
            var value = any.GetType().GetProperty("Value").GetValue(any);
            if (value.GetType().GetField(n) == null) return default;
            return (T)(value.GetType().GetField(n).GetValue(value));
        }

        public static T GetValueProperty<T>(object any, string n)
        {
            if (any.GetType().GetProperty("Value") == null) return default;
            var value = any.GetType().GetProperty("Value").GetValue(any);
            if (value.GetType().GetProperty(n) == null) return default;
            return (T)(value.GetType().GetProperty(n).GetValue(value));
        }

        public static void SetField(object any, string n, object a)
        {
            if (any.GetType().GetField(n) == null) return;
            any.GetType().GetField(n).SetValue(any, a);
        }

        public static void SetField(object any, string n, object a, string instead)
        {
            if (any.GetType().GetField(n) == null)
            {
                if (any.GetType().GetField(instead) == null) return;
                any.GetType().GetField(instead).SetValue(any, a);
                return;
            }
            any.GetType().GetField(n).SetValue(any, a);
        }

        public static void SetProperty(object any, string n, object a, string instead)
        {
            if (any.GetType().GetProperty(n) == null)
            {
                if (any.GetType().GetProperty(instead) == null) return;
                any.GetType().GetProperty(instead).SetValue(any, a);
                return;
            }
            any.GetType().GetProperty(n).SetValue(any, a);
        }

        public static void SetValue(object any, object a)
        {
            if (any.GetType().GetProperty("Value") == null) return;
            var value = any.GetType().GetProperty("Value").GetValue(any);
            if (value.GetType().GetProperty("initialValue") == null) return;
            value.GetType().GetProperty("initialValue").SetValue(value, a);
        }

        public static void SetSectionValue(object any, int index, object a)
        {
            if (any.GetType().GetProperty("Value") == null) return;
            var value = any.GetType().GetProperty("Value").GetValue(any);
            if (value.GetType().GetField("sections") == null) return;
            var list = value.GetType().GetMethod("SetSectionValue");
            list.Invoke(value, new object[] { index, a });
        }

        public static object GetSectionValue(object any, int index)
        {
            if (any.GetType().GetProperty("Value") == null) return default;
            var value = any.GetType().GetProperty("Value").GetValue(any);
            if (value.GetType().GetField("sections") == null) return default;
            var list = value.GetType().GetMethod("GetSectionValue");
            return list.Invoke(value, new object[] { index });
        }

        public List<object> GetParams()
        {
            return GetParams(this);
        }

        public static object CreateParam(ParamType paramtype, string label, object initialValue)
        {
            var type = GetParamTypeType(paramtype);

            if (type.Name == typeof(decimal).Name)
            {
                return new Param<decimal>(paramtype, label);
            }
            else if (type.Name == typeof(float).Name)
            {
                return new Param<float>(paramtype, label);
            }
            else if (type.Name == typeof(int).Name)
            {
                return new Param<int>(paramtype, label);
            }
            else if (type.Name == typeof(string).Name)
            {
                return new Param<string>(paramtype, label);
            }

            var typename = "ParamTriplePlus.Params.Param`1[[" + type.FullName + ", " + type.Assembly.FullName + "]]";

            var t = Type.GetType(typename);
            var sec = t.GetConstructors()[1].Invoke(new object[] { paramtype, initialValue, label });
            return sec;
        }

        public static Type GetParamTypeType(ParamType type)
        {
            switch (type)
            {
                case ParamType.Number:
                    return typeof(decimal);
                case ParamType.Float:
                    return typeof(float);
                case ParamType.Int:
                    return typeof(int);
                case ParamType.String:
                    return typeof(string);
                case ParamType.File:
                    return typeof(string);
                case ParamType.Folder:
                    return typeof(string);
                case ParamType.MultiLine:
                    return typeof(string);
                case ParamType.Font:
                    return typeof(string);
                case ParamType.Color:
                    return typeof(Color);
                case ParamType.Point:
                    return typeof(Vector2);
                case ParamType.List:
                    break;
                case ParamType.Combo:
                    break;
                case ParamType.Boolean:
                    return typeof(bool);
                case ParamType.Text:
                    return typeof(string);
                case ParamType.Vector2:
                    return typeof(Vector2);
                case ParamType.Vector3:
                    return typeof(Vector3);
                case ParamType.Dialog:
                    break;
                case ParamType.Button:
                    break;
                default:
                    break;
            }

            return null;
        }
    }

    public class Transion<T>
    {
        public Transion()
        {

        }
        public Transion(Param<T> parent)
        {
            this.parent = parent;
        }
        [JsonIgnore]
        public Param<T> parent { get; private set; }
        public List<TransionSection<T>> sections = new List<TransionSection<T>>();
        public T initialValue { get; set; }

        public void SetSectionValue(int index, object a)
        {
            sections[index].value = (T)a;
        }

        public T GetSectionValue(int index)
        {
            return sections[index].value;
        }
    }

    public class TransionSection<T>
    {
        public TransionSection()
        {

        }
        public TransionSection(T value)
        {
            this.value = value;
        }
        public T value;
        public int frame;
        public float FrameDrop;
        public BaseTransionType baseTransionType { get; set; } = BaseTransionType.None;
        public LoopType loopType = LoopType.None;

        public static object Create(object value)
        {
            if (value is float)
            {
                var sec = new FloatSection((float)value);
                return sec;
            }
            else if (value is int)
            {
                var sec = new FloatSection((int)value);
                return sec;
            }
            else if (value is string)
            {
                var sec = new TextSection((string)value);
                return sec;
            }
            else if (value is Vector3)
            {
                var sec = new Vector3Section((Vector3)value);
                return sec;
            }
            else if (value is Vector2)
            {
                var sec = new Vector2Section((Vector2)value);
                return sec;
            }
            else if (value.GetType().IsEnum)
            {
                var typename = "ParamTriplePlus.Params.TransionSection`1[[" + value.GetType().FullName + ", " + value.GetType().Assembly.FullName + "]]";
                
                var type = Type.GetType(typename);
                var sec = type.GetConstructors()[1].Invoke(new object[] { value });
                return sec;
            }
            return new TransionSection<object>(value);
        }

        public static object Default(Type type)
        {
            if (type == typeof(float)) return 0f;
            if (type == typeof(decimal)) return (decimal)0;
            if (type == typeof(int)) return 0;
            if (type == typeof(string)) return "";
            if (type == typeof(Color)) return new Color(255, 255, 255);
            if (type == typeof(Vector2)) return new Vector2(0, 0);
            if (type == typeof(Vector3)) return new Vector3(0, 0, 0);
            if (type.IsEnum) return Enum.ToObject(type, 0);
            var cons = type.GetConstructors();
            if (cons.Length > 0) return cons[0].Invoke(new object[0]);
            return type.TypeInitializer.Invoke(new object[0]);
        }



        public static string GetLoopTypeName(LoopType type)
        {
            switch (type)
            {
                case LoopType.ConstBeat:
                    return "固定拍ループ";
                case LoopType.VariableBeat:
                    return "変動拍ループ";
                case LoopType.None:
                default:
                    return "ループ無し";
            }
        }

        public static string GetTransionTypeName(BaseTransionType type)
        {
            switch (type)
            {
                case BaseTransionType.Random:
                    return "ランダム";
                case BaseTransionType.None:
                default:
                    return "移動無し (瞬間移動)";
            }
        }

        public static string GetTransionTypeShortName(BaseTransionType type)
        {
            switch (type)
            {
                case BaseTransionType.Random:
                    return "ランダム";
                case BaseTransionType.None:
                default:
                    return "移動無し";
            }
        }
    }

    public enum LoopType
    {
        None,
        ConstBeat = 1,
        VariableBeat = 2
    }

    public enum BaseTransionType
    {
        None = 0,
        Random = 105,
    }

    public class FloatSection : TransionSection<float>
    {
        public FloatSection() : base()
        {

        }
        public FloatSection(float value) : base(value)
        {

        }

        public enum TransionType
        {
            None = 0,
            Linear = 1,
            Easing = 2,
            CurveEditor = 3,
            Code = 4,
            
            Add = 100,
            Multiple = 101,
            Sin = 102,
            Cos = 103,
            Tan = 104, //使う奴変態
            Random = 105,
        }

        public static string GetTransionTypeName(TransionType type)
        {
            switch (type)
            {
                case TransionType.Linear:
                    return "直線移動";
                case TransionType.Easing:
                    return "イージング";
                case TransionType.CurveEditor:
                    return "Curve Editor";
                case TransionType.Code:
                    return "スクリプト";
                case TransionType.Add:
                    return "移動量指定 (加算)";
                case TransionType.Multiple:
                    return "移動量指定 (乗算)";
                case TransionType.Sin:
                    return "反復移動 (サイン)";
                case TransionType.Cos:
                    return "反復移動 (コサイン)";
                case TransionType.Tan:
                    return "反復移動 (タンジェント)";
                case TransionType.Random:
                    return "ランダム";
                case TransionType.None:
                default:
                    return "移動無し (瞬間移動)";
            }
        }

        public static string GetTransionTypeShortName(TransionType type)
        {
            switch (type)
            {
                case TransionType.Linear:
                    return "直線";
                case TransionType.Easing:
                    return "イージング";
                case TransionType.CurveEditor:
                    return "Curve";
                case TransionType.Code:
                    return "スクリプト";
                case TransionType.Add:
                    return "移動(加)";
                case TransionType.Multiple:
                    return "移動(乗)";
                case TransionType.Sin:
                    return "反復(sin)";
                case TransionType.Cos:
                    return "反復(cos)";
                case TransionType.Tan:
                    return "反復(tan)";
                case TransionType.Random:
                    return "ランダム";
                case TransionType.None:
                default:
                    return "移動無し";
            }
        }

        //public LoopType loopType = LoopType.None;
        public TransionType _transiontype = TransionType.None;
        [JsonIgnore]
        public TransionType transiontype
        {
            get => _transiontype;
            set
            {
                var prev = _transiontype;
                _transiontype = value;
                if (prev != _transiontype || transionParams == null)
                {
                    transionParams = GetParamTypes(_transiontype);
                }
                if (transionParams.Count > 0)
                {
                    var po = new PortableDialog(transionParams.ToArray());
                    po.ShowDialog();
                }
            }
        }

        public List<SimpleParam> transionParams;
        public List<SimpleParam> loopParams;

        public static List<SimpleParam> GetParamTypes(TransionType transiontype)
        {
            switch (transiontype)
            {
                case TransionType.None:
                    return new List<SimpleParam>();
                case TransionType.Linear:
                    return new List<SimpleParam>();
                case TransionType.Easing:
                    return [new SimpleParam(ParamType.Int, "番号")]; //番号
                case TransionType.CurveEditor:
                    return [new SimpleParam(ParamType.Int, "番号")]; //番号
                case TransionType.Code:
                    return [new SimpleParam(ParamType.MultiLine, "コード")]; //コード
                case TransionType.Add:
                    return new List<SimpleParam>();
                case TransionType.Multiple:
                    return new List<SimpleParam>();
                case TransionType.Sin:
                    return [new SimpleParam(ParamType.Number, "周期")]; //周期
                case TransionType.Cos:
                    return [new SimpleParam(ParamType.Number, "周期")]; //周期
                case TransionType.Tan:
                    return [new SimpleParam(ParamType.Number, "周期")]; //周期
                case TransionType.Random:
                    return [new SimpleParam(ParamType.Number, "シード"), new SimpleParam(ParamType.Number, "周期")]; //シード、周期
                default:
                    break;
            }
            return new List<SimpleParam>();
        }

        public SimpleParam[] GetLoopParams()
        {
            switch (loopType)
            {
                case LoopType.None:
                    return new SimpleParam[0];
                case LoopType.ConstBeat:
                    return [new SimpleParam(ParamType.Float, "BPM"), new SimpleParam(ParamType.Number, "周期")]; //BPM、拍
                case LoopType.VariableBeat:
                    return [new SimpleParamList<string>("リスト")];
                default:
                    break;
            }
            return new SimpleParam[0];
        }
    }

    public class TextSection : TransionSection<string>
    {

        public enum TransionType
        {
            None = 0,
            Linear = 1,
            Easing = 2,
            CurveEditor = 3,
            Code = 4,

            Random = 5,
            Convert = 6,
        }

        public TransionType _transiontype = TransionType.None;
        [JsonIgnore]
        public TransionType transiontype
        {
            get => _transiontype;
            set
            {
                var prev = _transiontype;
                _transiontype = value;
                if (prev != _transiontype || transionParams == null)
                {
                    transionParams = GetParamTypes(_transiontype);
                }
                if (transionParams.Count > 0)
                {
                    var po = new PortableDialog(transionParams.ToArray());
                    po.ShowDialog();
                }
            }
        }

        public List<SimpleParam> transionParams;
        public List<SimpleParam> loopParams;

        public static string GetTransionTypeName(TransionType type)
        {
            switch (type)
            {
                case TransionType.Linear:
                    return "直線移動";
                case TransionType.Easing:
                    return "イージング";
                case TransionType.CurveEditor:
                    return "Curve Editor";
                case TransionType.Code:
                    return "スクリプト";
                case TransionType.Random:
                    return "ランダム";
                case TransionType.None:
                default:
                    return "移動無し (瞬間移動)";
            }
        }

        public static string GetTransionTypeShortName(TransionType type)
        {
            switch (type)
            {
                case TransionType.Linear:
                    return "直線";
                case TransionType.Easing:
                    return "イージング";
                case TransionType.CurveEditor:
                    return "Curve";
                case TransionType.Code:
                    return "スクリプト";
                case TransionType.Random:
                    return "ランダム";
                case TransionType.None:
                default:
                    return "移動無し";
            }
        }

        public static List<SimpleParam> GetParamTypes(TransionType transiontype)
        {
            switch (transiontype)
            {
                case TransionType.None:
                    return new List<SimpleParam>();
                case TransionType.Linear:
                    return new List<SimpleParam>();
                case TransionType.Easing:
                    return [new SimpleParam(ParamType.Int, "番号")]; //番号
                case TransionType.CurveEditor:
                    return [new SimpleParam(ParamType.Int, "番号")]; //番号
                case TransionType.Code:
                    return [new SimpleParam(ParamType.MultiLine, "コード")]; //コード
                default:
                    break;
            }
            return new List<SimpleParam>();
        }

        public TextSection() : base()
        {

        }

        public TextSection(string value) : base(value)
        {

        }
    }

    public class Vector3Section : TransionSection<Vector3>
    {

        public FloatSection.TransionType _transiontype = FloatSection.TransionType.None;
        [JsonIgnore]
        public FloatSection.TransionType transiontype
        {
            get => _transiontype;
            set
            {
                var prev = _transiontype;
                _transiontype = value;
                if (prev != _transiontype || transionParams == null)
                {
                    transionParams = FloatSection.GetParamTypes(_transiontype);
                }
                if (transionParams.Count > 0)
                {
                    var po = new PortableDialog(transionParams.ToArray());
                    po.ShowDialog();
                }
            }
        }


        public List<SimpleParam> transionParams;
        public List<SimpleParam> loopParams;

        //public LoopType loopType = LoopType.None;

        public Vector3Section() : base()
        {

        }

        public Vector3Section(Vector3 value) : base(value)
        {

        }
    }

    public class Vector2Section : TransionSection<Vector2>
    {
        public FloatSection.TransionType transiontype;

        //public LoopType loopType = LoopType.None;

        public Vector2Section() : base()
        {

        }

        public Vector2Section(Vector2 value) : base(value)
        {

        }
    }

    public class SimpleParam
    {
        public ParamType paramtype;
        public object value;
        public string label;

        public float maxValue;
        public float minValue;

        public List<string> options;

        public SimpleParam()
        {

        }

        public SimpleParam(ParamType paramtype, string label = "")
        {
            this.paramtype = paramtype;
            this.label = label;
            this.value = TransionSection<object>.Default(GetParamType(this.paramtype));
        }

        public SimpleParam(ParamType paramtype, float maxvalue, float minvalue, string label = "")
        {
            this.paramtype = paramtype;
            this.label = label;
            maxValue = maxvalue;
            minValue = minvalue;
            this.value = TransionSection<object>.Default(GetParamType(this.paramtype));
        }

        public SimpleParam(ParamType paramtype, List<string> options, string label = "")
        {
            this.paramtype = paramtype;
            this.options = options;
            this.label = label;
            this.value = TransionSection<object>.Default(GetParamType(this.paramtype));
        }

        public static Type GetParamType(ParamType type)
        {
            switch (type)
            {
                case ParamType.Number:
                    return typeof(float);
                case ParamType.Float:
                    return typeof(float);
                case ParamType.Int:
                    return typeof(int);
                case ParamType.String:
                    return typeof(string);
                case ParamType.File:
                    return typeof(string);
                case ParamType.Folder:
                    return typeof(string);
                case ParamType.MultiLine:
                    return typeof(string);
                case ParamType.Font:
                    return typeof(string);
                case ParamType.Color:
                    return typeof(Color);
                case ParamType.Point:
                    return typeof(Vector2);
                case ParamType.List:
                    return typeof(List<object>);
                case ParamType.Combo:
                    return typeof(Enum);
                case ParamType.Boolean:
                    return typeof(bool);
                case ParamType.Text:
                    return typeof(string);
                case ParamType.Vector2:
                    return typeof(Vector2);
                case ParamType.Vector3:
                    return typeof(Vector3);
                case ParamType.Dialog:
                    return null;
                case ParamType.Button:
                    return null;
                default:
                    return null;
            }
        }
    }

    public class SimpleParamList<T> : SimpleParam
    {
        public SimpleParamList(string label = "") : base(ParamType.List, label)
        {
            value = new List<T>();
        }

        public SimpleParamList() : base(ParamType.List)
        {

        }
    }

    public class SimpleParamDialog : SimpleParam
    {
        public SimpleParamDialog(ParamList paramlist, string label = "") : base(ParamType.Dialog, label)
        {
            value = paramlist;
        }

        public SimpleParamDialog() : base(ParamType.Dialog)
        {

        }
    }

    public enum ParamType
    {
        Number = 0,
        Float = 1,
        Int = 2,

        String = 3,
        File = 4,
        Folder = 5,
        MultiLine = 6,
        Font = 7,

        Color = 8,
        Point = 9,
        List = 10,
        Combo = 11,
        Boolean = 12,
        Text = 13,
        Vector2 = 14,
        Vector3 = 15,
        Dialog = 16,
        Button = 17,
    }

    public struct Vector2
    {
        public float x;
        public float y;

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public struct Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
    public struct Color
    {
        public float r;
        public float g;
        public float b;

        public Color(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public Color(System.Drawing.Color another)
        {
            r = another.R;
            g = another.G;
            b = another.B;
        }

        public void SetHSV(float h, float s, float v)
        {
            var r = 0f;
            var g = 0f;
            var b = 0f;

            if (h < 60)
            {
                r = 1;
                g = (h / 60);
            }
            else if (h < 120)
            {
                r = 1 - ((h - 60) / 60);
                g = 1;
            }
            else if (h < 180)
            {
                g = 1;
                b = ((h-120) / 60);
            }
            else if (h < 240)
            {
                g = 1 - ((h - 180) / 60);
                b = 1;
            }
            else if (h < 300)
            {
                b = 1;
                r = ((h - 240) / 60);
            }
            else
            {
                b = 1 - ((h - 300) / 60);
                r = 1;
            }

            var maxH = MathF.Max(r, MathF.Max(g, b));
            var minH = MathF.Min(r, MathF.Min(g, b));

            r = ((maxH - r) * s) + r;
            g = ((maxH - g) * s) + g;
            b = ((maxH - b) * s) + b;

            r *= v;
            g *= v;
            b *= v;

        }

        public float h { 
            get
            {
                if (r == g && g == b)
                {
                    return 0;
                }
                float maxV = MathF.Max(r, MathF.Max(g, b));
                float minV = MathF.Min(r, MathF.Min(g, b));

                if (r == maxV)
                {
                    return (((g - b) / (maxV - minV)) / 6);
                }
                else if (g == maxV)
                {
                    return (((b - r) / (maxV - minV)) / 6) + (1 / 3);
                }
                else if (b == maxV)
                {
                    return (((r - g) / (maxV - minV)) / 6) + (2 / 3);
                }

                return 0;
            }
            set
            {
                SetHSV(value, s, v);
            }
        }
        public float s
        {
            get
            {
                float maxV = MathF.Max(r, MathF.Max(g, b));
                float minV = MathF.Min(r, MathF.Min(g, b));
                return (maxV - minV) / maxV;
            }
        }
        public float v
        {
            get
            {
                return MathF.Max(r, MathF.Max(g, b));
            }
        }
    }
}
