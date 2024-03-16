using ParamTriplePlus.Params.AviUtl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamTriplePlus.Params.NotAviUtl
{
    #region 装飾
    public class EFFlatShadow : AviutlEffect
    {
        public EFFlatShadow() { Name = "伸びる影"; }

        public Param<float> length = new Param<float>(10, 9999, 0, true, "長さ");
        public Param<float> angle = new Param<float>(0, 9999, -9999, true, "角度");
        public Param<float> alpha = new Param<float>(100, 100, 0, false, "不透明度");
        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
    }

    public class EFInnerShadow : AviutlEffect
    {
        public EFInnerShadow() { Name = "内側シャドー"; }

        public Param<Vector2> pos = new Param<Vector2>(new Vector2(), "位置");
        public Param<float> blur = new Param<float>(10, 9999, 0, true, "ぼかし");
        public Param<float> alpha = new Param<float>(100, 100, 0, false, "不透明度");
        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
    }

    public class EFOutline : AviutlEffect
    {
        public EFOutline() { Name = "内側抜き縁取り"; }

        public Param<float> width = new Param<float>(3, 9999, 0, true, "太さ");
        public Param<float> blur = new Param<float>(10, 9999, 0, true, "ぼかし");
        public Param<float> alpha = new Param<float>(100, 100, 0, false, "不透明度");
        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
    }

    public class EFWorm : AviutlEffect
    {
        public EFWorm() { Name = "腐食"; }

        public Param<float> width = new Param<float>(3, 9999, 0, true, "太さ");
        public Param<float> blur = new Param<float>(10, 9999, 0, true, "ぼかし");
        public Param<float> alpha = new Param<float>(100, 100, 0, false, "不透明度");
    }
    #endregion

    #region 色変更
    public class EFAlphaContrast : AviutlEffect
    {
        public EFAlphaContrast() { Name = "透明度コントラスト"; }

        public Param<float> contrast = new Param<float>(100, 200, 0, false, "コントラスト");
        public Param<float> threshold = new Param<float>(128, 255, 0, false, "閾値");
    }
    #endregion
}
