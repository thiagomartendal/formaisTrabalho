using System;
using System.IO;
using System.Xml.Serialization;

namespace Trabalho1
{
    public class Crud
    {
        private string Path;
        public Crud(string P)
        {
            Path = "/" + P + ".xml";
        }

        public void Store<T> (T c)
        {
            if (File.Exists(Path))
                File.Delete(Path);
            using (Stream stream = File.OpenWrite(Environment.CurrentDirectory + Path))
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(T));

                xmlSer.Serialize(stream, c);
            }
        }

        public void Load<T> (T c)
        {
            using (Stream stream = File.OpenRead(Environment.CurrentDirectory + Path))
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(T));

                xmlSer.Deserialize(stream);
            }
        }
    }
}
