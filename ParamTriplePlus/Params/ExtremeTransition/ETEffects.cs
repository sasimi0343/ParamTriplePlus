using ParamTriplePlus.Params.AviUtl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamTriplePlus.Params.ExtremeTransition
{
    public class ETEffect : AviutlEffect
    {
        public ETEffect() { Name = "[ET]"; }

        public Param<bool> isexit = new Param<bool>("退場する");
        public Param<int> delay = new Param<int>(1, 9999, 0, true, "ディレイ");
        public Param<int> globaldelay = new Param<int>(0, 9999, 0, true, "全体の遅延");
    }

    public class ETTimeEffect : ETEffect
    {
        public ETTimeEffect() { Name = "[ET]"; }

        public Param<int> time = new Param<int>(10, 9999, 0, true, "時間");
    }

    public class ETNumberEffect : ETTimeEffect
    {
        public ETNumberEffect() { Name = "[ET]"; }

        public Param<int> easing = new Param<int>(-23, 999, -99, true, "イージング");
    }

    public class ETShowDelayed : ETEffect
    {
        public ETShowDelayed() { Name = "[ET] 表示ディレイ"; }
    }

    public enum ReverseMode
    {
        None,
        Swap, //交互

    }

    public class ETMove : ETNumberEffect
    {
        public ETMove() { Name = "[ET] 移動"; }

        public Param<Vector3> startpos = new Param<Vector3>(new Vector3(), "開始位置");
        public Param<Vector3> endpos = new Param<Vector3>(new Vector3(), "終了位置");
        public Param<bool> iscenterMovement = new Param<bool>("中心位置を移動");
        public Param<ReverseMode> reversemode = new Param<ReverseMode>(ReverseMode.None, "反転モード");
    }

    public class ETRotate : ETNumberEffect
    {
        public ETRotate() { Name = "[ET] 回転"; }

        public Param<Vector3> startrot = new Param<Vector3>(new Vector3(), "開始回転");
        public Param<Vector3> endrot = new Param<Vector3>(new Vector3(), "終了回転");
        public Param<ReverseMode> reversemode = new Param<ReverseMode>(ReverseMode.None, "反転モード");
    }

    public class ETZoom : ETNumberEffect
    {
        public ETZoom() { Name = "[ET] 拡大縮小"; }

        public Param<float> startZoom = new Param<float>(1, 9999, 0, true, "開始拡大率");
        public Param<float> endZoom = new Param<float>(0, 9999, 0, true, "終了拡大率");

        public Param<float> startAspect = new Param<float>(0, 100, -100, false, "開始比率");
        public Param<float> endAspect = new Param<float>(0, 100, -100, false, "終了比率");
    }

    public class ETBlink : ETTimeEffect
    {
        public ETBlink() { Name = "[ET] 点滅"; }

        public Param<float> alpha = new Param<float>(0, 100, 0, false, "消灯透明度");
        public Param<bool> isedgedetect = new Param<bool>("エッジ抽出");
    }


}
