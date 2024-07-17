using ParamTriplePlus.Params.AviUtl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamTriplePlus.Params.CharacterBone
{
    public class Character : AviutlMediaObject
    {
        public Character() {
            Name = "キャラクター";
            cbfile.options = new List<string>()
            {
                "CharacterBoneファイル|*.cbau"
            };
        }

        public Param<string> cbfile = new Param<string>(ParamType.File, "キャラクターファイル");
        public Param<int> frameOffset = new Param<int>(0, 9999, 0, true, "時間ずれ");
        public Param<int> eye = new Param<int>(0, 9999, 0, true, "目");
        public Param<int> mouth = new Param<int>(0, 9999, 0, true, "口");
        public Param<int> eyebrow = new Param<int>(0, 9999, 0, true, "眉");
        public Param<bool> diseff = new Param<bool>("エフェクト間引き");
        public Param<bool> noblink = new Param<bool>("まばたき無し");
        public Param<int> dynamiclevel = new Param<int>(2, 2, 0, false, "動的レベル");


    }
}
