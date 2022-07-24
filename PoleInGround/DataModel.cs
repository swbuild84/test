using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PoleInGround
{
    [Serializable]
    public class DataModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        

        public DataModel()
        {
        }

        private double _PoleDiameter;
        public double PoleDiameter
        {
            get
            {
                return this._PoleDiameter;
            }
            set
            {
                if (value != this._PoleDiameter)
                {
                    this._PoleDiameter = value;
                    NotifyPropertyChanged("PoleDiameter");
                }
            }
        }

        private Int32 _SupportType;
        public Int32 SupportType
        {
                get
                {
                    return this._SupportType;
                }
                set
                {
                    if (value != this._SupportType)
                    {
                        this._SupportType = value;
                        NotifyPropertyChanged("SupportType");
                    }
                }            
        }

        private EType _type;
        public EType Type
        {
            get
            {
                return this._type;
            }
            set
            {
                if (value != this._type)
                {
                    this._type = value;
                    NotifyPropertyChanged("Type");
                }
            }
        }
        

        protected void NotifyPropertyChanged(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Load(string file)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataModel));
                FileStream fileStream = new FileStream(file, FileMode.Open);
                DataModel dm = (DataModel)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                //read all locals
                this.SupportType = dm.SupportType;
                this.PoleDiameter = dm.PoleDiameter;
                this.Type = dm.Type;
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

        public enum EType : byte
        {
            SVERL=1,
            SVERL_VERHNIY_RIGEL,
            KOPAN_VERHNIY_RIGEL,
            KOPAN_VERHNIY_NIZNIY_RIGEL,
            SVERL_VERHNIY_RIGEL_BANKETKA,
            KOPAN_VERHNIY_BANKETKA_NIZNIY_RIGEL
        }
    }
}
