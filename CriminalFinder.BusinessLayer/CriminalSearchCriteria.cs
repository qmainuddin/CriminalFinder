using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CriminalFinder.BusinessLayer
{
    public class CriminalSearchCriteria
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public String Gender { get; set; }

        [DataMember]
        public int MinAge { get; set; }

        [DataMember]
        public int MaxAge { get; set; }

        [DataMember]
        public float MinHeight { get; set; }
        [DataMember]
        public float MaxHeight { get; set; }

        [DataMember]
        public float MinWeight { get; set; }

        [DataMember]
        public float MaxWeight { get; set; }

        [DataMember]
        public String Nationality { get; set; }
    }
}
