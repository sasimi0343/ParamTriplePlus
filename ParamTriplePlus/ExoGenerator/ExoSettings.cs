using ParamTriplePlus.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ParamTriplePlus.ExoGenerator
{
    public class ExoSettings
    {
        public ExoSettings() { }

        public List<ExoSettingSection> settings = new List<ExoSettingSection>();

        public string PTPPath;
        public string SettingName;

        public void Save()
        {
            var text = PTPJsonSerializer.ToJson(this);
            if (!Directory.Exists("./ExoGenerators"))
            {
                Directory.CreateDirectory("./ExoGenerators");
            }

            File.WriteAllText("./ExoGenerators/" + SettingName + ".exoptp", text);
            if (!files.Contains(this))
            {
                files.Add(this);
            }
        }

        public void Save(string name)
        {
            SettingName = name;
            Save();
        }

        [JsonIgnore]
        public static List<ExoSettings> files = new List<ExoSettings>();
        public static void LoadExoSettings()
        {
            if (!Directory.Exists("./ExoGenerators"))
            {
                Directory.CreateDirectory("./ExoGenerators");
                return;
            }
            var fils = Directory.GetFiles("./ExoGenerators");
            foreach (var item in fils)
            {
                if (Path.GetExtension(item) == ".exoptp")
                {
                    var text = File.ReadAllText(item);
                    var kansei = PTPJsonSerializer.FromJSON<ExoSettings>(text);

                    files.Add(kansei);
                }
            }
        }
    }

    public class ExoSettingSection
    {
        public ExoSettingSection() { }

        public string VariableName;
        public string Label;
        public ParamType paramtype;
        public object initial;

        public float maxvalue;
        public float minvalue;
    }
}
