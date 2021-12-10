using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ZastitaInformacija17235
{
   public class SerializeSupport
    {
        public SerializeSupport() { }
        public static void Serialize(object obj, string filename)
        {
            Type objType = obj.GetType();
            XmlSerializer sr = new XmlSerializer(objType);
            StreamWriter wr = new StreamWriter(filename,true);
            sr.Serialize(wr, obj);
            wr.Close();

        }
        public static object Deserialize(string filename, Type f)
        {
            XmlSerializer sr = new XmlSerializer(f);
            FileStream fs = new FileStream(filename, FileMode.Open);
            TextReader reader = new StreamReader(fs,true);
            return sr.Deserialize(reader);

        }
    }
}
