using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CriminalFinder.BusinessLayer;

namespace CriminalFinder.WebService
{
    public class CriminalServiceResponse
    {
        public List<CriminalInfo> criminals { get; set; }
        public bool operationStatus { get; set; }
        public String ServiceErrorMsg { get; set; }

    }
}