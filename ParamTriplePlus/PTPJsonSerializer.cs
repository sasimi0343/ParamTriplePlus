using ParamTriplePlus.ExoGenerator;
using ParamTriplePlus.Params;
using ParamTriplePlus.Params.AviUtl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParamTriplePlus
{
    public static class PTPJsonSerializer
    {
        #region シリアライザーって意外と作るの大変なんだね
        public static string ToJson(List<AviutlMediaObject> objects)
        {
            var kansei = "[";

            foreach (var item in objects)
            {
                kansei += JsonTypeClass(item) + ",";
            }

            if (objects.Count > 0) kansei = kansei.Substring(0, kansei.Length - 1);
            kansei += "]";
            return kansei;
        }

        public static string ToJson(object obj)
        {
            return JsonType(obj);
        }

        public static string ToJson(Dictionary<string, object> dic)
        {
            return JsonType(dic);
        }

        private static string JsonType(Dictionary<string, object> dic)
        {
            var kansei = "{";
            foreach (var item in dic)
            {
                kansei += AddProperty(item.Key, item.Value);
            }
            if (dic.Count > 0) kansei = kansei.Substring(0, kansei.Length - 1);
            kansei += "}";
            return kansei;
        }

        private static string JsonTypeClass(object value)
        {
            var fields = value.GetType().GetFields();
            var propeties = value.GetType().GetProperties();

            var kansei = "{";
            kansei += AddProperty("_type", value.GetType().FullName);
            foreach (var field in fields)
            {
                var ignore = false;
                foreach (var item in field.CustomAttributes)
                {
                    if (item.AttributeType == typeof(JsonIgnoreAttribute))
                    {
                        ignore = true;
                        break;
                    }
                }
                if (ignore) continue;

                var val = value != null ? field.GetValue(value) : null;
                kansei += AddProperty(field.Name, val);
            }

            foreach (var field in propeties)
            {
                var ignore = false;
                foreach (var item in field.CustomAttributes)
                {
                    if (item.AttributeType == typeof(JsonIgnoreAttribute))
                    {
                        ignore = true;
                        break;
                    }
                }
                if (ignore) continue;

                var val = value != null ? field.GetValue(value) : null;
                kansei += AddProperty(field.Name, val);
            }

            kansei = kansei.Substring(0, kansei.Length - 1);
            kansei += "}";
            return kansei;
        }

        private static string AddProperty(string key, object value)
        {
            return "\"" + key + "\":" + JsonType(value) + ",";
        }

        private static string JsonType(object value)
        {
            if (value == null)
            {
                return "null";
            }
            if (value is int)
            {
                return ((int)value).ToString();
            }
            if (value is float)
            {
                return ((float)value).ToString();
            }
            if (value is bool)
            {
                return ((bool)value).ToString();
            }
            if (value is Vector2)
            {
                var vec = (Vector2)value;
                return "{\"x\":" + vec.x + ",\"y\":" + vec.y + "}";
            }
            if (value is Vector3)
            {
                var vec = (Vector3)value;
                return "{\"x\":" + vec.x + ",\"y\":" + vec.y + ",\"z\":" + vec.z + "}";
            }
            if (value is Params.Color)
            {
                var col = (Params.Color)value;
                return "{\"r\":" + col.r + ",\"g\":" + col.g + ",\"b\":" + col.b + "}";
            }
            var type = value.GetType();
            if (type.IsEnum)
            {
                return ((int)value).ToString();
            }
            if (value is string)
            {
                return "\"" + ((string)value).Replace("\"", "\\\"") + "\"";
            }
            if (type.IsArray)
            {
                var kansei = "[";
                foreach (var item in (Array)value)
                {
                    kansei += JsonType(item) + ",";
                }
                if (((Array)value).Length > 0) kansei = kansei.Substring(0, kansei.Length - 1);
                kansei += "]";
                return kansei;
            }
            if (type.Name == typeof(List<object>).Name)
            {
                var kansei = "[";
                var array = (Array)type.GetMethod("ToArray").Invoke(value, new object[0]);
                foreach (var item in array)
                {
                    kansei += JsonType(item) + ",";
                }
                if (array.Length > 0) kansei = kansei.Substring(0, kansei.Length - 1);
                kansei += "]";
                return kansei;
            }
            if (type.Name == typeof(Dictionary<string, string>).Name)
            {
                var kansei = "{";
                if (type.GenericTypeArguments[0].Name == typeof(string).Name)
                {
                    var en = value.GetType().GetMethod("GetEnumerator").Invoke(value, []);
                    var count = (int)ClassUtil.GetProperty(value, "Count");
                    for (var i = 0;i < count;i++)
                    {
                        ClassUtil.InvokeMethod(en, "MoveNext");
                        var prop = ClassUtil.GetProperty(en, "Current");
                        Trace.WriteLine("Key: " + ClassUtil.GetProperty(prop, "Key") + ", Value: " + ClassUtil.GetProperty(prop, "Value"));
                        kansei += "\"" + ClassUtil.GetProperty(prop, "Key") + "\":" + JsonType(ClassUtil.GetProperty(prop, "Value")) + ",";
                    }
                    if (count > 0) kansei = kansei.Substring(0, kansei.Length - 1);
                    kansei += "}";
                    return kansei;

                }
                var listtype = Type.GetType("System.Collections.Generic.List`1[[" + type.GenericTypeArguments[0].FullName + ", " + type.GenericTypeArguments[0].Assembly.FullName + "]]");
                var array = (Array)(listtype.GetMethod("ToArray").Invoke(listtype.GetConstructors()[0].Invoke(new object[] { ClassUtil.GetProperty(value, "Count") }), new object[0]));
                ClassUtil.InvokeMethod(ClassUtil.GetProperty(value, "Keys"), "CopyTo", [array, 0]);
                foreach (var key in array)
                {
                    var item = type.GetProperty("Item").GetValue(value, new object[] { key });
                    kansei += JsonType(key) + ":" + JsonType(item) + ",";
                }
                if (array.Length > 0) kansei = kansei.Substring(0, kansei.Length - 1);
                kansei += "}";
                return kansei;
            }
            return JsonTypeClass(value);
        }

        #endregion

        #region デシリアライザー

        public static List<AviutlMediaObject> FromJSON(string str)
        {
            var obj = (List<object>)Generate(str);
            var list = new List<AviutlMediaObject>();
            foreach (var item in obj)
            {
                if (item is AviutlMediaObject)
                list.Add((AviutlMediaObject)item);
            }
            return list;
        }

        public static T FromJSON<T>(string str)
        {
            return (T)Generate(str);
        }

        private static Type ReturnBaseType(Type t)
        {
            return (t.BaseType == null || t.BaseType == typeof(object)) ? t : ReturnBaseType(t.BaseType);
        }

        private static object Generate(string str)
        {
            if (float.TryParse(str, out var a))
            {
                return a;
            }
            if (str.ToLower() == "true")
            {
                return true;
            }
            else if (str.ToLower() == "false")
            {
                return false;
            }
            else if (str.ToLower() == "null")
            {
                return null;
            }
            if (str.StartsWith("\"") && str.EndsWith("\""))
            {
                return str.Substring(1, str.Length - 2);
            }
            if (str.StartsWith("[") && str.EndsWith("]"))
            {
                var list = PerseList(str);
                var kansei = new List<object>();
                foreach (var item in list)
                {
                    var obj = Generate(item);
                    if (obj == null)
                    {
                        kansei.Add(null);
                        continue;
                    }
                    Trace.WriteLine("> " + obj.GetType().Name);
                    kansei.Add(obj);
                }
                return kansei;
            }
            var dic = Generate(Perse(str));
            if (dic.ContainsKey("_type"))
            {
                var type = Type.GetType((string)dic["_type"]);
                if (type == null)
                {
                    Trace.WriteLine("Class not found: " + (string)dic["_type"]);
                    return null;
                }
                var basetype = ReturnBaseType(type);

                if (
                    basetype == typeof(ParamList) ||
                    basetype.Name == typeof(Param<object>).Name ||
                    basetype.Name == typeof(Transion<object>).Name ||
                    basetype.Name == typeof(TransionSection<object>).Name ||
                    basetype == typeof(Condition) ||
                    basetype == typeof(ExoSettings) ||
                    basetype == typeof(ExoSettingSection) ||
                    basetype.Name == typeof(SimpleParam).Name
                    )
                {
                    var cons = type.GetConstructors();
                    if (cons.Length <= 0) return null;
                    var obj = cons[0].Invoke(new object[0]);
                    foreach (var item in dic)
                    {
                        if (type.GetField(item.Key) == null)
                        {
                            if (type.GetProperty(item.Key) == null)
                            {
                                continue;
                            }
                            ClassUtil.SetProperty(obj, item.Key, item.Value, true);
                            continue;
                        }
                        ClassUtil.SetField(obj, item.Key, item.Value, true);
                    }
                    return obj;
                }
                else
                {
                    Trace.WriteLine("Unsupported class: " + (string)dic["_type"] + " (" + basetype.Name + ")");
                }

                //var obj_con = type.GetConstructors();
                //if (obj_con.Length <= 0) return null;
                //var obj = obj_con[0].Invoke(new object[0]);
            }
            else
            {
                if (dic.ContainsKey("x") && dic.ContainsKey("y"))
                {
                    if (dic.ContainsKey("z"))
                    {
                        return new Vector3((float)dic["x"], (float)dic["y"], (float)dic["z"]);
                    }
                    else
                    {
                        return new Vector2((float)dic["x"], (float)dic["y"]);
                    }
                }
                if (dic.ContainsKey("r") && dic.ContainsKey("g") && dic.ContainsKey("b"))
                {
                    return new Params.Color((float)dic["r"], (float)dic["g"], (float)dic["b"]);
                }
            }
            return str;
        }

        private static Dictionary<string, object> Generate(Dictionary<string, string> strdic)
        {
            var pair = new Dictionary<string, object>();

            foreach (var item in strdic)
            {
                var obj = Generate(item.Value);
                Trace.WriteLine("| " + item.Key + " = " + obj);
                pair.Add(item.Key, obj);
            }

            return pair;
        }

        private static Dictionary<string, string> Perse(string param)
        {
            var pair = new Dictionary<string, string>();
            var itizi = "";
            var isvalue = false;
            var itizi2 = "";
            var iskakko = false;

            var level = 0;
            var prev = ' ';
            if (param.StartsWith("{") || param.StartsWith("["))
            {
                param = param.Substring(1);
            }
            if (param.EndsWith("}") || param.EndsWith("]"))
            {
                param = param.Substring(0, param.Length-1);
            }
            foreach (var c in param)
            {
                //Trace.WriteLine(c);
                if (level == 0 && !isvalue && !iskakko && c == '\"')
                {
                    //Trace.WriteLine("Kakko");
                    iskakko = true;
                }
                else if (level == 0 && !isvalue && iskakko && c == '\"')
                {
                    //Trace.WriteLine("KakkoEnd");
                    iskakko = false;
                    isvalue = true;
                    itizi2 = itizi;
                    itizi = "";
                }
                else if (level == 0 && isvalue && !iskakko && c == ':')
                {
                }
                else if (level == 0 && isvalue && !iskakko && c == ',')
                {
                    //Trace.WriteLine(itizi2 + " = " + itizi);
                    pair.Add(itizi2, itizi);
                    isvalue = false;
                    itizi2 = "";
                    itizi = "";
                }
                else if (!iskakko && (c == '{' || c == '['))
                {
                    level++;
                    //Trace.WriteLine("Level: " + level);
                    itizi += c;
                }
                else if (!iskakko && (c == '}' || c == ']'))
                {
                    level--;
                    //Trace.WriteLine("Level: " + level);
                    itizi += c;
                }
                else if (!iskakko && c == '"')
                {
                    //Trace.WriteLine("Kakko2");
                    iskakko = true;
                    if (isvalue) itizi += c;
                }
                else if (iskakko && c == '"' && prev != '\\')
                {
                    //Trace.WriteLine("KakkoEnd2");
                    iskakko = false;
                    if (isvalue) itizi += c;
                }
                else
                {
                    itizi += c;
                }
                prev = c;
            }

            if (!string.IsNullOrEmpty(itizi2) && !string.IsNullOrEmpty(itizi))
            {
                pair.Add(itizi2, itizi);
            }

            return pair;
        }

        private static List<string> PerseList(string param)
        {
            var pair = new List<string>();
            var itizi = "";
            var iskakko = false;

            var level = 0;
            var prev = ' ';
            if (param.StartsWith("{") || param.StartsWith("["))
            {
                param = param.Substring(1);
            }
            if (param.EndsWith("}") || param.EndsWith("]"))
            {
                param = param.Substring(0, param.Length - 1);
            }
            foreach (var c in param)
            {
                if (level == 0 && !iskakko && c == ',')
                {
                    pair.Add(itizi);
                    itizi = "";
                }
                else if (!iskakko && (c == '{' || c == '['))
                {
                    level++;
                    itizi += c;
                }
                else if (!iskakko && (c == '}' || c == ']'))
                {
                    level--;
                    itizi += c;
                }
                else if (!iskakko && c == '"')
                {
                    iskakko = true;
                    itizi += c;
                }
                else if (iskakko && c == '"' && prev != '\\')
                {
                    iskakko = false;
                    itizi += c;
                }
                else
                {
                    itizi += c;
                }
                prev = c;
            }

            if (!string.IsNullOrEmpty(itizi))
            {
                pair.Add(itizi);
            }

            return pair;
        }

        #endregion

        //メズマライザーはないです
    }

    public static class ClassUtil
    {
        public static object ConvertList(Type type, object list)
        {
            if (type.IsEnum || type == typeof(int))
            {
                return (int)Math.Floor((float)list);
            }
            if (list.GetType().Name == typeof(List<object>).Name)
            {
                if (type.IsArray)
                {
                    MethodInfo setvalue = null;
                    var newlist = type.GetConstructors()[0].Invoke(new object[] { ((List<object>)list).Count });
                    var methods = newlist.GetType().GetMethods(BindingFlags.Public);
                    foreach (var item in methods)
                    {
                        var param = item.GetParameters();
                        if (item.Name == "SetValue" && param.Length == 2 && param[0].ParameterType == typeof(object) && param[1].ParameterType == typeof(int))
                        {
                            setvalue = item;
                            break;
                        }
                    }
                    var i = 0;
                    foreach (var item in (List<object>)list)
                    {
                        //newlist.GetType().GetMethod("SetValue", System.Reflection.BindingFlags.Public).Invoke(newlist, new object[] { item, i });
                        setvalue.Invoke(newlist, new object[] { item, i });
                        i++;
                    }

                    return newlist;
                }
                else
                {
                    var newlist = type.GetConstructors()[0].Invoke(new object[0]);
                    foreach (var item in (List<object>)list)
                    {
                        type.GetMethod("Add").Invoke(newlist, new object[] { item });
                    }

                    return newlist;
                }
            }
            return list;
        }

        public static void SetField(object obj, string name, object value, bool safe = false)
        {
            if (safe && value == null) return;
            var field = obj.GetType().GetField(name);
            if (field == null) return;
            field.SetValue(obj, ConvertList(field.FieldType, value));
        }

        public static object GetField(object obj, string name)
        {
            var field = obj.GetType().GetField(name);
            if (field == null) return null;
            return field.GetValue(obj);
        }

        public static T GetField<T>(object obj, string name)
        {
            var field = obj.GetType().GetField(name);
            if (field == null) return default;
            return (T)field.GetValue(obj);
        }


        public static void SetProperty(object obj, string name, object value, bool safe = false)
        {
            if (safe && value == null) return;
            var property = obj.GetType().GetProperty(name);
            if (property == null) return;
            property.SetValue(obj, ConvertList(property.PropertyType, value));
        }

        public static object GetProperty(object obj, string name)
        {
            var property = obj.GetType().GetProperty(name);
            if (property == null) return null;
            return property.GetValue(obj);
        }

        public static T GetProperty<T>(object obj, string name)
        {
            var property = obj.GetType().GetProperty(name);
            if (property == null) return default;
            return (T)property.GetValue(obj);
        }

        public static void InvokeMethod(object obj, string name, object[] param = null)
        {
            var method = obj.GetType().GetMethod(name);
            if (method != null) return;
            method.Invoke(obj, param);
        }
    }
}
