using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using FlutyDeer.VogenPlugin.Stream;
using Newtonsoft.Json;
using OpenSvip.Framework;
using OpenSvip.Model;

namespace FlutyDeer.VogenPlugin
{
    public static class Test
    {
        public static void Main(string[] args)
        {
            //Vogen2Json();
            Json2Vogen();
        }

        private static void Vogen2Json()
        {
            var project = new VogenConverter().Load(@"D:\����ѧϰ\��ֱ�׶���\��ֱ�׶���.mid", new ConverterOptions(new Dictionary<string, string>()));
            var stream = new FileStream(
                @"D:\����ѧϰ\��ֱ�׶���\��ֱ�׶���.json",
                FileMode.Create,
                FileAccess.Write);
            var writer = new StreamWriter(stream, new UTF8Encoding(false));
            writer.Write(JsonConvert.SerializeObject(project));
            writer.Flush();
            stream.Flush();
            writer.Close();
            stream.Close();
        }
        private static void Json2Vogen()
        {
            var stream = new FileStream(
                @"D:\����\ɶ��1.json",
                FileMode.Open,
                FileAccess.Read);
            var reader = new StreamReader(stream, Encoding.UTF8);
            var project = JsonConvert.DeserializeObject<Project>(reader.ReadToEnd());
            stream.Close();
            reader.Close();
            new VogenConverter().Save(@"D:\����\ɶ��1.vog", project, new ConverterOptions(new Dictionary<string, string>()));
        }
    }
}
