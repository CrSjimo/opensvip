using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using OpenSvip.Framework;
using OpenSvip.Model;
using FlutyDeer.MidiPlugin.Stream;

namespace FlutyDeer.MidiPlugin
{
    public static class Test
    {
        public static void Main(string[] args)
        {
            //Midi2Json();
            Json2Midi();
        }

        private static void Midi2Json()
        {
            var project = new MidiConverter().Load(@"D:\编曲学习\不直白动物\不直白动物.mid", new ConverterOptions(new Dictionary<string, string>()));
            var stream = new FileStream(
                @"D:\编曲学习\不直白动物\不直白动物.json",
                FileMode.Create,
                FileAccess.Write);
            var writer = new StreamWriter(stream, new UTF8Encoding(false));
            writer.Write(JsonConvert.SerializeObject(project));
            writer.Flush();
            stream.Flush();
            writer.Close();
            stream.Close();
        }
        private static void Json2Midi()
        {
            var stream = new FileStream(
                @"D:\测试\分割线（带词midi）.json",
                FileMode.Open,
                FileAccess.Read);
            var reader = new StreamReader(stream, Encoding.UTF8);
            var project = JsonConvert.DeserializeObject<Project>(reader.ReadToEnd());
            stream.Close();
            reader.Close();
            new MidiConverter().Save(@"D:\测试\分割线（带词midi）.mid", project, new ConverterOptions(new Dictionary<string, string>()));
        }
    }
}
