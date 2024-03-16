using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ParamTriplePlus.Params.AviUtl
{
    public class AviutlMediaObject : ParamList
    {
        public AviutlMediaObject() { startFrame.DisableTransion = true; length.DisableTransion = true; }

        [JsonIgnore]
        private GroupObject parent;
        [JsonIgnore]
        public GroupObject Parent
        {
            get
            {
                return parent;
            }
            set
            {
                if (parent != null)
                {
                    parent.children.Remove(this);
                    parent.Sort();
                }
                else
                {
                    mainwindow.objects.Remove(this);
                }
                parent = value;
                if (parent != null)
                {
                    index = parent.children.Count;
                    parent.children.Add(this);
                    parent.Sort();
                }
                else
                {
                    mainwindow.objects.Add(this);
                }
            }
        }
        [JsonIgnore]
        public List<AviutlMediaObject> ParentList
        {
            get => parent == null ? mainwindow.objects : parent.children;
        }

        public Param<int> startFrame = new Param<int>(0, 9999, 0, true, "開始フレーム");
        public Param<int> length = new Param<int>(0, 9999, 0, true, "長さ");
        public string Name { get; protected set; }
        public int index;
        public bool IsEnabled = true;
        public Param<Vector3> position = new Param<Vector3>(new Vector3(), "位置");
        public Param<Vector3> rotation = new Param<Vector3>(new Vector3(), "回転");
        public Param<float> zoom = new Param<float>(100, 1600, 0, true, "拡大率");
        public Param<float> alpha = new Param<float>(100, 100, 0, "不透明度");
        public Param<Vector3> center = new Param<Vector3>(new Vector3(), "中心位置");
        public Param<BlendMode> blend = new Param<BlendMode>(BlendMode.Normal, "合成モード");
        public Param<ClipMode> clipaboveobj = new Param<ClipMode>(ClipMode.なし, "上のオブジェクトにクリッピング");

        public List<AviutlEffect> effects = new List<AviutlEffect>();
        [JsonIgnore]
        public MainWindow mainwindow;
    }

    public class AviutlEffect : ParamList
    {
        public AviutlEffect() { }
        public bool IsEnabled;
        public int index;

        public string Name { get; protected set; }

        public Condition condition = new Condition();

        [JsonIgnore]
        public GroupBox groupbox;

        [JsonIgnore]
        public AviutlMediaObject parent;
    }

    public enum BlendMode
    {
        Normal = 0,
        Add = 1,
        Sub = 2,
        Multiple = 3,
        Screen = 4,
        Overlay = 5,
        Compare_Light = 6,
        Compare_Dark = 7,
        Luminance = 8,
        Difference_Hue = 9,

        Alpha_Add = 100,
        Alpha_Add2 = 103,
        Alpha_Max = 101,
        Alpha_Sub = 102,
    }

    public enum ClipMode
    {
        なし,
        クリッピングのみ,
        クリッピングして元のオブジェクトを描画しない,
        交差
    }

    public enum Figure
    {
        Background,
        Circle,
        Square,
        Triangle
    }

    public class FigureObject : AviutlMediaObject
    {
        public FigureObject()
        {
            Name = "図形";
        }
        public Param<Figure> figure = new Param<Figure>(Figure.Circle, "図形の種類");
        public Param<float> size = new Param<float>(100, 9999, 0, "サイズ");
        public Param<float> border = new Param<float>(4000, 9999, 0, "幅");
        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
    }

    public class TextObject : AviutlMediaObject
    {
        public TextObject()
        {
            Name = "テキスト";
        }

        public Param<float> size = new Param<float>(100, 9999, 0, "サイズ");
        public Param<string> font = new Param<string>(ParamType.Font, "フォント");
        public Param<string> text = new Param<string>(ParamType.MultiLine, "テキスト");
        public Param<bool> eachobject = new Param<bool>("個別オブジェクト");
        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
    }

    public class ImageObject : AviutlMediaObject
    {
        public ImageObject()
        {
            Name = "画像";
            image.options = new List<string>()
            {
                "画像ファイル|*.png;*.jpg;*.jpeg;*.bmp;*.gif",
                "全てのファイル|*.*"
            };
        }

        public Param<string> image = new Param<string>(ParamType.File, "画像ファイル");
    }

    public class VideoObject : AviutlMediaObject
    {
        public VideoObject()
        {
            Name = "動画";
            video.options = new List<string>()
            {
                "動画ファイル|*.avi;*.mp4",
                "アニメーション画像|*.gif;*.jpeg;*.jpg",
                "連番画像|*.png",
                "全てのファイル|*.*"
            };
        }

        public Param<string> video = new Param<string>(ParamType.File, "動画ファイル");
        public Param<int> frame = new Param<int>(0, 9999, 0, true, "再生位置");
        public Param<int> speed = new Param<int>(100, 9999, 0, true, "再生速度");
    }

    public class FrameBufferObject : AviutlMediaObject
    {
        public FrameBufferObject()
        {
            Name = "フレームバッファ";
        }
    }

    public class GroupObject : AviutlMediaObject
    {
        public GroupObject()
        {
            Name = "グループ制御 (合成)";
        }

        public List<AviutlMediaObject> children = new List<AviutlMediaObject>();
        public void Sort()
        {
            children.Sort((a, b) => (a.index - b.index));
            for (var i = 0; i < children.Count; i++)
            {
                var item = children[i];
                item.index = i;
            }
        }
    }
}
