using ParamTriplePlus.Params.AviUtl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamTriplePlus.Params.NotAviUtl
{
    public class Path : AviutlMediaObject
    {

    }

    public class Cross : AviutlMediaObject
    {
        public Cross()
        {
            Name = "十字";
        }

        public Param<float> size = new Param<float>(100, 9999, 0, "サイズ");
        public Param<float> aspect = new Param<float>(0, 100, -100, "縦横比");
        public Param<float> border = new Param<float>(25, 100, 0, "幅%");
        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
    }

    public class Box : AviutlMediaObject
    {
        public Box()
        {
            Name = "箱";
        }

        public Param<float> size = new Param<float>(100, 9999, 0, "サイズ");
        public Param<float> aspect = new Param<float>(0, 100, -100, "縦横比");
        public Param<float> border = new Param<float>(5, 9999, 0, "枠幅");
        public Param<float> border_in = new Param<float>(5, 9999, 0, "線幅");
        public Param<float> angle = new Param<float>(0, 360, -360, "角度");
        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
        public Param<bool> additionalline = new Param<bool>("垂直な線を追加");
    }

    public class StopSign : AviutlMediaObject
    {
        public StopSign()
        {
            Name = "停止マーク";
        }

        public Param<float> size = new Param<float>(100, 9999, 0, "サイズ");
        public Param<float> aspect = new Param<float>(0, 100, -100, "縦横比");
        public Param<float> border = new Param<float>(5, 9999, 0, "枠幅");
        public Param<float> border_in = new Param<float>(5, 9999, 0, "線幅");
        public Param<float> angle = new Param<float>(0, 360, -360, "角度");
        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
        public Param<bool> additionalline = new Param<bool>("垂直な線を追加");
    }

    public class Arrow1 : AviutlMediaObject
    {
        public Arrow1()
        {
            Name = "矢印 (タイプ1)";
        }

        public Param<float> size = new Param<float>(100, 9999, 0, "サイズ");
        public Param<float> aspect = new Param<float>(-10, 100, -100, "縦横比");
        public Param<float> border = new Param<float>(80, 100, 0, "へこみ%");
        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
    }

    public class Arrow2 : AviutlMediaObject
    {
        public Arrow2()
        {
            Name = "矢印 (タイプ2)";
        }

        public Param<float> size = new Param<float>(100, 9999, 0, "サイズ");
        public Param<float> aspect = new Param<float>(0, 100, -100, "縦横比");
        public Param<float> border = new Param<float>(80, 100, 0, "へこみ%");
        public Param<float> umblength = new Param<float>(0, 100, 0, "傘%");
        public Param<float> width = new Param<float>(25, 100, 0, "太さ%");
        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
    }

    public class CheckPattern : AviutlMediaObject
    {
        public CheckPattern()
        {
            Name = "模様";
        }

        public Param<float> size = new Param<float>(100, 9999, 0, "サイズ");
        public Param<float> aspect = new Param<float>(0, 100, -100, "縦横比");
        public Param<float> border = new Param<float>(4000, 9999, 0, "枠幅");
        public Param<Color> color1 = new Param<Color>(new Color(255, 255, 255), "色1");
        public Param<Color> color2 = new Param<Color>(new Color(255, 255, 255), "色2");
    }

    public class TriPoly : AviutlMediaObject
    {
        public TriPoly()
        {
            Name = "複合三角形";
        }

        public Param<float> size = new Param<float>(100, 9999, 0, "サイズ");
        public Param<float> aspect = new Param<float>(0, 100, -100, "縦横比");
        public Param<float> polycount = new Param<float>(2, 999, 0, "三角形の数");
        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
    }

    public class QuadPoly : AviutlMediaObject
    {
        public QuadPoly()
        {
            Name = "複合四角形";
        }

        public Param<float> size = new Param<float>(100, 9999, 0, "サイズ");
        public Param<float> aspect = new Param<float>(0, 100, -100, "縦横比");
        public Param<float> polycount = new Param<float>(2, 999, 0, "四角形の数");
        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
        public Param<bool> sharp = new Param<bool>("鋭利化");
    }

    public class Octagon : AviutlMediaObject
    {
        public Octagon()
        {
            Name = "八角形";
        }

        public Param<float> width = new Param<float>(100, 9999, 0, "横幅");
        public Param<float> height = new Param<float>(100, 9999, 0, "縦幅");
        public Param<float> bias = new Param<float>(50, 100, 0, "偏り%");
        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
    }

    public class RandomShapes : AviutlMediaObject
    {
        public RandomShapes()
        {
            Name = "ランダム図形";
        }

        public Param<float> size = new Param<float>(100, 9999, 0, "単位あたりのサイズ");
        public Param<int> width = new Param<int>(3, 9999, 0, "横");
        public Param<int> height = new Param<int>(3, 9999, 0, "縦");
        public Param<float> seed = new Param<float>(1, 9999, 1, "シード値");
        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
        public Param<bool> eachobject = new Param<bool>("個別オブジェクト化");
        public Param<bool> randomposition = new Param<bool>("ランダム配置");
        public Param<float> range = new Param<float>(1000, 9999, 0, "範囲");
    }
}
