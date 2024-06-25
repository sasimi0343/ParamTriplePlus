using ParamTriplePlus.Params.AviUtl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamTriplePlus.Params.MoreShapes3D
{
    public class MS3D_Object : AviutlMediaObject
    {
        public MS3D_Object() { Name = "[MS3D]"; }

        public Param<bool> render = new Param<bool>(true, "Render効果をつける");
        public Param<bool> omit_out_of_screen = new Param<bool>(true, "可能なら画面外にいるときにレンダリングをしない");
        public Param<MS3D_RenderingType> rendertype = new Param<MS3D_RenderingType>(MS3D_RenderingType.Light, "レンダータイプ");

        public Param<Vector3> scale = new Param<Vector3>(new Vector3(1, 1, 1), "スケール");

    }

    public enum MS3D_RenderingType
    {
        NoLight,
        Light
    }

    public class MS3D_Box : MS3D_Object
    {
        public MS3D_Box() { Name = "[MS3D] キューブ"; }

        public Param<Vector3> size = new Param<Vector3>(new Vector3(100, 100, 100), "サイズ");
    }

    public class MS3D_Sphere : MS3D_Object
    {
        public MS3D_Sphere() { Name = "[MS3D] 球"; }

        public Param<float> radius = new Param<float>(200, 9999, 0, true, "半径");
        public Param<float> polygons = new Param<float>(28, 9999, 0, true, "ポリゴン数");
    }

    public class MS3D_Corn : MS3D_Object
    {
        public MS3D_Corn() { Name = "[MS3D] コーン"; }

        public Param<float> radius = new Param<float>(100, 9999, 0, true, "底面の半径");
        public Param<float> height = new Param<float>(100, 9999, 0, true, "高さ");
        public Param<float> polygons = new Param<float>(180, 9999, 0, true, "ポリゴン数");
    }

    public class MS3D_Ring : MS3D_Object
    {
        public MS3D_Ring() { Name = "[MS3D] リング"; }

        public Param<float> radius = new Param<float>(300, 9999, 0, true, "半径");
        public Param<float> height = new Param<float>(50, 9999, 0, true, "太さ");
        public Param<float> polygons = new Param<float>(4, 9999, 0, true, "ポリゴン数");
    }

    public class MS3D_Pillar : MS3D_Object
    {
        public MS3D_Pillar() { Name = "[MS3D] 多面柱"; }

        public Param<float> radius = new Param<float>(100, 9999, 0, true, "底面の半径");
        public Param<float> height = new Param<float>(100, 9999, 0, true, "高さ");
        public Param<float> polygons = new Param<float>(180, 9999, 0, true, "ポリゴン数");
    }
}
