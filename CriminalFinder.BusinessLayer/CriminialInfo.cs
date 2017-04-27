using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CriminalFinder.BusinessLayer
{
    [DataContract]
    public class CriminalInfo
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public String Gender { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public float Height { get; set; }

        [DataMember]
        public float Weight { get; set; }

        [DataMember]
        public String Nationality { get; set; }
    }
}
