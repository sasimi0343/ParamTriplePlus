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
        public Param<bool> centerTo = new Param<bool>("中心位置を変更");
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

    #region 便利系

    public class EFSaveImage : AviutlEffect
    {
        public EFSaveImage() { Name = "イメージを保存"; }

        public Param<int> ID = new Param<int>(0, 9999, 0, true, "ID");
        public Param<bool> dontdraw = new Param<bool>("このイメージを描画しない");
    }

    public class EFLoadImage : AviutlEffect
    {
        public EFLoadImage() { Name = "イメージを読み込み"; }

        public Param<int> ID = new Param<int>(0, 9999, 0, true, "ID");
        public Param<Vector3> position = new Param<Vector3>(new Vector3(), "位置");
        public Param<Vector3> rotation = new Param<Vector3>(new Vector3(), "回転");
        public Param<float> zoom = new Param<float>(100, 1600, 0, true, "拡大率");
        public Param<float> alpha = new Param<float>(100, 100, 0, "不透明度");
        public Param<BlendMode> blend = new Param<BlendMode>(BlendMode.Normal, "合成モード");
        public Param<bool> background = new Param<bool>("元のイメージの後ろに描画");

    }

    #endregion
}
