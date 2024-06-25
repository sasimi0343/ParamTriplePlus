using ParamTriplePlus.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParamTriplePlus.CustomComponent
{
    public struct TrackBarStruct
    {
        public string Name;
        public float Minimum;
        public float Maximum;
        public int DecimalPlace;
    }

    public class AviUtlLua
    {
        public AviUtlLuaFile parent;
        public string Content { get; set; }
        public string Name { get; set; }

        public string FullName { get => Name + parent.Name; }
    }

    public class AviUtlLuaFile
    {
        public ScriptType LuaType { get; set; }
        public string LuaPath { get; set; }
        public string Name { get; set; }
        public List<AviUtlLua> luaList = new List<AviUtlLua>();

        public static AviUtlLuaFile Load(string path)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path)) return null;
            var ismulti = true; //Path.GetFileName(path).StartsWith('@');
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var file = Parse(File.ReadAllText(path, Encoding.GetEncoding("shift-jis")), ismulti);
            var ext = Path.GetExtension(path);
            switch (ext)
            {
                case ".anm":
                    file.LuaType = ScriptType.Animation;
                    break;
                case ".obj":
                    file.LuaType = ScriptType.CustomObject;
                    break;
                case ".cam":
                    file.LuaType = ScriptType.CameraControl;
                    break;
                case ".scn":
                    file.LuaType = ScriptType.SceneTransition;
                    break;
                case ".tra":
                    file.LuaType = ScriptType.Transion;
                    break;
                default:
                    break;
            }
            file.LuaPath = path;
            file.Name = Path.GetFileName(path);
            return file;
        }

        public static AviUtlLuaFile Parse(string content, bool IsMulti)
        {
            var luafile = new AviUtlLuaFile();
            var current = new AviUtlLua();
            current.parent = luafile;
            var list = new List<AviUtlLua>();
            var lines = content.Split("\n");
            foreach (var item in lines)
            {
                if (item.StartsWith('@') && IsMulti)
                {
                    if (!string.IsNullOrEmpty(current.Content))
                    {
                        current.Content = current.Content.Substring(0, current.Content.Length - 1);
                        list.Add(current);
                    }
                    current = new AviUtlLua();
                    current.Name = item[1..].TrimEnd();
                    current.parent = luafile;
                    continue;
                }
                else if (item.StartsWith("--"))
                {

                }

                current.Content += item + "\n";
            }
            if (!string.IsNullOrEmpty(current.Content))
            {
                current.Content = current.Content.Substring(0, current.Content.Length - 1);
                list.Add(current);
            }

            luafile.luaList = list;
            return luafile;
        }


        public static List<AviUtlLuaFile> files = new List<AviUtlLuaFile>();
        public static void LoadFolder(string path, bool excludeSub = false)
        {
            var filelist = Directory.GetFiles(path);
            foreach (var item in filelist)
            {
                if (supportExt.Contains(Path.GetExtension(item)))
                files.Add(Load(item));
            }

            if (excludeSub) return;

            var folderlist = Directory.GetDirectories(path);
            foreach (var item in folderlist)
            {
                LoadFolder(item);
            }
        }

        public static readonly List<string> supportExt = new List<string>{ ".anm", ".obj", ".cam", ".tra", ".scn" };
    }

    public enum ScriptType
    {
        Animation,
        CustomObject,
        CameraControl,
        SceneTransition,
        Transion
    }
}
