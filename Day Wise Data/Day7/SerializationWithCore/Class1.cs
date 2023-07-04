using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationWithCore
{
    [Serializable]
    public class Class1  //:ISerializable
    {
        private int private_data;
        public int i;
        [XmlElement]
        public string P1
        {
            get;
            set;
        }
        private int mP2;
        [XmlAttribute]
        public int P2
        {
            get { return mP2; }
            set { mP2 = value; }
        }




        public Class1()
        {

        }


        //public Class1(SerializationInfo info, StreamingContext context)
        //{
        //    this.i = (int)info.GetValue("i", typeof(int));
        //    private_data = (int)info.GetValue("private_data", typeof(int));
        //}

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //    info.AddValue("i", this.i);
        //    info.AddValue("private_data", private_data);

        //}
    }
}
