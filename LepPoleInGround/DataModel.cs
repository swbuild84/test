using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LepPoleInGround
{
    [Serializable]
    public class DataModel
    {
        public string SupportType="";
        public string PoleDiameter { get; set; } = "";

        public DataModel()
        {
        }

        public void Load(string file)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataModel));
                FileStream fileStream = new FileStream(file, FileMode.Open);
                DataModel dm = (DataModel)xmlSerializer.Deserialize(fileStream);
                //read all locals
                this.SupportType = dm.SupportType;
                this.PoleDiameter = dm.PoleDiameter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Save(string path)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataModel));
                StreamWriter writer = new StreamWriter(path);
                xmlSerializer.Serialize(writer, this);
                writer.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
