using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CriminalFinder.BusinessLayer;

namespace CriminalFinder.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICriminalService" in both code and config file together.
    [ServiceContract]
    public interface ICriminalService
    {
        [OperationContract]
        CriminalServiceResponse GetCriminals();
        [OperationContract]
        CriminalServiceResponse SearchCriminals(CriminalSearchCriteria searchCriteria);
        [OperationContract]
        CriminalServiceResponse GetCriminal(long id);
        [OperationContract]
        CriminalServiceResponse UpdateCriminal(CriminalInfo criminal);
        [OperationContract]
        CriminalServiceResponse CreateCriminal(CriminalInfo criminal);
        [OperationContract]
        CriminalServiceResponse DeleteCriminal(long id);
        [OperationContract]
        CriminalServiceResponse DeleteCriminals(List<CriminalInfo> criminalList);
        [OperationContract]
        CriminalServiceResponse QuickSearchCriminalsByName(String searchCriteria);
    }
}
