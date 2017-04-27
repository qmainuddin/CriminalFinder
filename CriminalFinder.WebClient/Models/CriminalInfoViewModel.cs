using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CriminalFinder.WebClient.CriminalFinderService;

namespace CriminalFinder.WebClient.Models
{
    public class CriminalInfoViewModel
    {
        public List<CriminalInfo> Criminals { get; set; }
        public CriminalSearchCriteria SearchCriteria { get; set; }
    }
}