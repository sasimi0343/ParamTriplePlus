using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamTriplePlus.Params.AviUtl
{
    #region 装飾
    public class EFBorder : AviutlEffect
    {
        public EFBorder() { Name = "縁取り"; }

        public Param<float> width = new Param<float>(3, 9999, 0, true, "太さ");
        public Param<float> blur = new Param<float>(10, 9999, 0, true, "ぼかし");
        public Param<float> alpha = new Param<float>(100, 100, 0, false, "不透明度");
        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
    }

    public class EFShadow : AviutlEffect
    {
        public EFShadow() { Name = "シャドー"; }

        public Param<Vector2> pos = new Param<Vector2>(new Vector2(), "位置");
        public Param<float> blur = new Param<float>(10, 9999, 0, true, "ぼかし");
        public Param<float> alpha = new Param<float>(100, 100, 0, false, "不透明度");
        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
    }
    #endregion

    #region ぼかし
    public class EFBlur : AviutlEffect
    {
        public EFBlur() { Name = "ぼかし"; }

        public Param<float> blur = new Param<float>(20, 9999, 0, true, "ぼかし");
        public Param<float> aspect = new Param<float>(0, 100, -100, false, "縦横比");
        public Param<int> light = new Param<int>(0, 60, 0, false, "光の強さ");
        public Param<bool> constantSize = new Param<bool>("サイズ固定");
    }

    public class EFBorderBlur : AviutlEffect
    {
        public EFBorderBlur() { Name = "境界ぼかし"; }

        public Param<float> blur = new Param<float>(20, 9999, 0, true, "ぼかし");
        public Param<float> aspect = new Param<float>(0, 100, -100, false, "縦横比");
        public Param<bool> alphaBorder = new Param<bool>("透明度の境界をぼかす");
    }

    public class EFRadioBlur : AviutlEffect
    {
        public EFRadioBlur() { Name = "放射ブラー"; }

        public Param<float> blur = new Param<float>(20, 9999, 0, true, "範囲");
        public Param<Vector2> pos = new Param<Vector2>(new Vector2(), "位置");
        public Param<bool> constantSize = new Param<bool>("サイズ固定");
    }

    public class EFLineBlur : AviutlEffect
    {
        public EFLineBlur() { Name = "方向ブラー"; }

        public Param<float> blur = new Param<float>(20, 9999, 0, true, "範囲");
        public Param<float> angle = new Param<float>(0, 9999, -9999, true, "角度");
        public Param<bool> constantSize = new Param<bool>("サイズ固定");
    }

    #endregion

    #region 切り抜き
    public class EFClipping : AviutlEffect
    {
        public EFClipping() { Name = "クリッピング"; }

        public Param<float> top = new Param<float>(0, 9999, 0, true, "上");
        public Param<float> bottom = new Param<float>(0, 9999, 0, true, "下");
        public Param<float> left = new Param<float>(0, 9999, 0, true, "左");
        public Param<float> right = new Param<float>(0, 9999, 0, true, "右");
    }

    public class EFTendClipping : AviutlEffect
    {
        public EFTendClipping() { Name = "斜めクリッピング"; }

        public Param<Vector2> pos = new Param<Vector2>(new Vector2(), "位置");
        public Param<float> angle = new Param<float>(0, 9999, -9999, true, "角度");
        public Param<float> blur = new Param<float>(0, 9999, 0, true, "ぼかし");
        public Param<float> width = new Param<float>(0, 9999, 0, true, "幅");
    }

    public class EFMask : AviutlEffect
    {
        public EFMask() { Name = "マスク"; }

        public Param<Vector2> pos = new Param<Vector2>(new Vector2(), "位置");
        public Param<float> angle = new Param<float>(0, 9999, -9999, true, "角度");
        public Param<float> size = new Param<float>(100, 9999, 0, true, "サイズ");
        public Param<float> aspect = new Param<float>(0, 100, -100, false, "縦横比");
        public Param<float> blur = new Param<float>(0, 9999, 0, true, "ぼかし");
        public Param<Figure> figure = new Param<Figure>(Figure.Square, "マスクの種類");
        public Param<bool> flipMask = new Param<bool>("マスクの反転");
        public Param<bool> adjustSize = new Param<bool>("元のサイズに合わせる");
    }
    #endregion

    #region 色変更
    public class EFGradient : AviutlEffect
    {
        public EFGradient() { Name = "グラデーション"; }

        public Param<Vector2> pos = new Param<Vector2>(new Vector2(), "位置");
        public Param<float> blur = new Param<float>(100, 9999, 0, true, "ぼかし");
        public Param<float> alpha = new Param<float>(100, 100, 0, false, "強さ");
        public Param<float> angle = new Param<float>(0, 9999, -9999, true, "角度");
        public Param<Color> color1 = new Param<Color>(new Color(255, 255, 255), "色 (開始)");
        public Param<Color> color2 = new Param<Color>(new Color(0, 0, 0), "色 (終了)");
    }

    public class EFAdjustColor : AviutlEffect
    {
        public EFAdjustColor() { Name = "色調補正"; }

        public Param<float> brightness = new Param<float>(100, 200, 0, false, "明るさ");
        public Param<float> contrast = new Param<float>(100, 200, 0, false, "コントラスト");
        public Param<float> hue = new Param<float>(0, 9999, -9999, true, "色相");
        public Param<float> value = new Param<float>(100, 200, 0, false, "輝度");
        public Param<float> satuation = new Param<float>(100, 200, 0, false, "彩度");
    }

    public class EFColorlize : AviutlEffect
    {
        public EFColorlize() { Name = "単色化"; }

        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
        public Param<float> alpha = new Param<float>(100, 100, 0, false, "強さ");
        public Param<bool> holdValue = new Param<bool>(true, "輝度を保持する");
    }

    public class EFNoise : AviutlEffect
    {
        public EFNoise() { Name = "ノイズ"; }

        public Param<float> alpha = new Param<float>(100, 200, 0, false, "強さ");
        public Param<Vector2> velocity = new Param<Vector2>(new Vector2(), "速度");
        public Param<float> speed = new Param<float>(0, 9999, 0, true, "変化速度");
        public Param<Vector2> hz = new Param<Vector2>(new Vector2(1, 1), "周期");
        public Param<float> threshold = new Param<float>(0, 100, 0, false, "しきい値");
        public Param<int> seed = new Param<int>(0, 9999, 0, true, "シード値");
        public Param<Mode> mode = new Param<Mode>(Mode.アルファ値と乗算, "合成モード");
        public Param<NoiseType> type = new Param<NoiseType>(NoiseType.Type1, "ノイズの種類");

        public enum Mode
        {
            アルファ値と乗算,
            輝度と乗算
        }

        public enum NoiseType
        {
            Type1,
            Type2,
            Type3,
            Type4,
            Type5,
            Type6,
        }
    }

    public class EFChromaKey : AviutlEffect
    {
        public EFChromaKey() { Name = "クロマキー"; }

        public Param<Color> color = new Param<Color>(new Color(255, 255, 255), "色");
        public Param<int> thres_hue = new Param<int>(0, 255, 0, false, "色相範囲");
        public Param<int> thres_sat = new Param<int>(96, 255, 0, false, "彩度範囲");
        public Param<int> border = new Param<int>(1, 5, 0, false, "境界補正");
        public Param<Calibration> type = new Param<Calibration>(Calibration.補正無し, "補正オプション");

        public enum Calibration
        {
            補正無し,
            色彩補正,
            色彩補正_透過補正
        }
    }
    #endregion

    #region 変形
    public class EFRaster : AviutlEffect
    {
        public EFRaster() { Name = "ラスター"; }

        public Param<float> width = new Param<float>(100, 9999, 0, true, "横幅");
        public Param<float> height = new Param<float>(100, 9999, 0, true, "高さ");
        public Param<float> hz = new Param<float>(1, 40, -40, false, "周期");
        public Param<bool> vertical = new Param<bool>(false, "縦ラスター");
        public Param<bool> randomizedHz = new Param<bool>(false, "ランダム周期");
    }
    public class EFPolarCoordinateTransform : AviutlEffect
    {
        public EFPolarCoordinateTransform() { Name = "極座標変換"; }

        public Param<float> padding = new Param<float>(0, 9999, 0, true, "中心幅");
        public Param<float> zoom = new Param<float>(100, 9999, 100, false, "拡大率");
        public Param<float> rotation = new Param<float>(0, 9999, -9999, true, "回転");
        public Param<float> swirl = new Param<float>(0, 8, -8, false, "渦巻");
    }
    public class EFDisplacementMap : AviutlEffect
    {
        public EFDisplacementMap() { Name = "ディスプレイスメントマップ"; }

        public Param<Vector2> delta = new Param<Vector2>(new Vector2(), "変形");
        public Param<Vector2> pos = new Param<Vector2>(new Vector2(), "位置");
        public Param<float> angle = new Param<float>(0, 9999, -9999, true, "角度");
        public Param<float> size = new Param<float>(100, 9999, 0, true, "サイズ");
        public Param<float> aspect = new Param<float>(0, 100, -100, false, "縦横比");
        public Param<float> blur = new Param<float>(0, 9999, 0, true, "ぼかし");
        public Param<bool> adjustSize = new Param<bool>(false, "元のサイズに合わせる");
        public Param<Figure> figure = new Param<Figure>(Figure.Square, "マップの種類");
        public Param<Mode> mode = new Param<Mode>(Mode.移動変形, "変形方法");

        public enum Mode
        {
            移動変形,
            回転変形,
            拡大変形
        }
    }
    #endregion

    public class EFScript : AviutlEffect
    {
        public EFScript() { Name = "スクリプト制御"; }

        public Param<string> script = new Param<string>(ParamType.MultiLine, "スクリプト");
    }

    public class EFAnimation : AviutlEffect
    {
        public EFAnimation() { Name = "アニメーション効果"; }

        public void SetAnimation(string name)
        {
            Name = name;
            AnimationName = name;
        }

        public string AnimationName;
    }

    public class EFLoopImage : AviutlEffect
    {
        public EFLoopImage() { Name = "画像ループ"; }

        public Param<int> width = new Param<int>(1, 60, 1, true, "横");
        public Param<int> height = new Param<int>(1, 60, 1, true, "縦");

        public Param<Sort> mode = new Param<Sort>(Sort.Normal, "インデックスの順番");
        public Param<int> setting = new Param<int>(0, 60, 0, true, "設定値");

        public enum Sort
        {
            Normal, //左上基準から右、端まで来たら一段下
            CenterClockWise, //中央から時計回り
            CenterCounterClockWise, //中央から半時計回り
            CenterSpread, //中央から広がるように
            Random, //ランダム

        }
    }

    #region 基本効果

    public class EFPosition : AviutlEffect
    {
        public EFPosition() { Name = "座標"; }

        public Param<Vector3> pos = new Param<Vector3>(new Vector3(), "座標");
    }

    public class EFRotation : AviutlEffect
    {
        public EFRotation() { Name = "回転"; }

        public Param<Vector3> rotation = new Param<Vector3>(new Vector3(), "回転");
    }

    public class EFZoom : AviutlEffect
    {
        public EFZoom() { Name = "拡大率"; }

        public Param<float> zoom = new Param<float>(100, 9999, 0, true, "拡大率");
        public Param<float> x = new Param<float>(100, 9999, 0, true, "X");
        public Param<float> y = new Param<float>(100, 9999, 0, true, "Y");
    }

    public class EFAlpha : AviutlEffect
    {
        public EFAlpha() { Name = "不透明度"; }

        public Param<float> alpha = new Param<float>(100, 100, 0, false, "不当明度");
    }

    public class EFExtend : AviutlEffect
    {
        public EFExtend() { Name = "領域拡張"; }

        public Param<int> top = new Param<int>(0, 9999, 0, false, "上");
        public Param<int> bottom = new Param<int>(0, 9999, 0, false, "下");
        public Param<int> left = new Param<int>(0, 9999, 0, false, "左");
        public Param<int> right = new Param<int>(0, 9999, 0, false, "右");
    }

    #endregion
}
