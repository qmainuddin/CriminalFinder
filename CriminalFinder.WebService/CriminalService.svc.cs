using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CriminalFinder.BusinessLayer;

namespace CriminalFinder.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CriminalService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CriminalService.svc or CriminalService.svc.cs at the Solution Explorer and start debugging.
    public class CriminalService : ICriminalService
    {
        private CriminalDataProcessingService DataProcressingService;
        public CriminalService()
        {
            if(DataProcressingService == null)
            {
                DataProcressingService = new CriminalDataProcessingService();
            }
        }
        public CriminalServiceResponse CreateCriminal(CriminalInfo criminal)
        {
            CriminalServiceResponse response = new CriminalServiceResponse();
            if(criminal == null)
            {
                response = getFailedResponse();
                response.ServiceErrorMsg = Defs.ERROR_PARAMETER_CONTAINS_NULL;
            }
            else
            {
                try
                {
                    if (DataProcressingService.AddCriminal(Util.ConvertCriminalCriminalInfo(criminal)))
                    {
                        response = getSuccessResponse();
                        response.criminals = new List<CriminalInfo>();
                        response.criminals.Add(criminal);
                    }
                    else
                    {
                        response = getFailedResponse();
                        response.ServiceErrorMsg = Defs.ERROR_CREATE_OPERATION_IS_FAILED;
                    }
                }
                catch (Exception e)
                {
                    response = getFailedResponse();
                    response.ServiceErrorMsg = Defs.ERROR_DATABASE_IS_DOWN;
                }
            }
            return response;
        }
        public CriminalServiceResponse DeleteCriminal(long id)
        {
            CriminalServiceResponse response = new CriminalServiceResponse();
            if (id <= 0)
            {
                response = getFailedResponse();
                response.ServiceErrorMsg = Defs.ERROR_PARAMETER_CONTAINS_NULL;
            }
            else
            {
                try
                {
                    if (DataProcressingService.DeleteCriminal(id))
                    {
                        response = getSuccessResponse();
                        response.criminals = GetCriminal(id).criminals;
                    }
                    else
                    {
                        response = getFailedResponse();
                        response.ServiceErrorMsg = Defs.ERROR_DELETE_OPERATION_IS_FAILED;
                    }
                }
                catch (Exception e)
                {
                    response = getFailedResponse();
                    response.ServiceErrorMsg = Defs.ERROR_DATABASE_IS_DOWN;
                }
            }
            return response;
        }
        public CriminalServiceResponse DeleteCriminals(List<CriminalInfo> criminalList)
        {
            CriminalServiceResponse response = new CriminalServiceResponse();
            if (criminalList == null)
            {
                response = getFailedResponse();
                response.ServiceErrorMsg = Defs.ERROR_PARAMETER_CONTAINS_NULL;
            }
            else
            {
                try
                {
                    if (DataProcressingService.DeleteCriminals(Util.ConvertCriminalCriminalInfo(criminalList)))
                    {
                        response = getSuccessResponse();
                        response.criminals = criminalList;
                    }
                    else
                    {
                        response = getFailedResponse();
                        response.ServiceErrorMsg = Defs.ERROR_DELETE_OPERATION_IS_FAILED;
                    }
                }
                catch (Exception e)
                {
                    response = getFailedResponse();
                    response.ServiceErrorMsg = Defs.ERROR_DATABASE_IS_DOWN;
                }
            }
            return response;
        }
        public CriminalServiceResponse GetCriminal(long id)
        {
            CriminalServiceResponse response = new CriminalServiceResponse();
            if (id == 0)
            {
                response = getFailedResponse();
                response.ServiceErrorMsg = Defs.ERROR_PARAMETER_CONTAINS_NULL;
            }
            else
            {
                try
                {
                    CriminalInfo criminalDetail = DataProcressingService.GetSelectedCriminal(id);
                    if (criminalDetail != null)
                    {
                        response = getSuccessResponse();
                        response.criminals = new List<CriminalInfo>();
                        response.criminals.Add(criminalDetail);
                    }
                    else
                    {
                        response = getFailedResponse();
                        response.ServiceErrorMsg = Defs.ERROR_OPERATION_IS_FAILED;
                    }
                }
                catch (Exception e)
                {
                    response = getFailedResponse();
                    response.ServiceErrorMsg = Defs.ERROR_DATABASE_IS_DOWN;
                }
            }
            return response;
        }
        public CriminalServiceResponse GetCriminals()
        {
            CriminalServiceResponse response = new CriminalServiceResponse();
            try
            {
                List<CriminalInfo> criminalList =  DataProcressingService.GetCriminals();
                if(criminalList == null)
                {
                    response = getFailedResponse();
                    response.ServiceErrorMsg = Defs.ERROR_DATA_NOT_FOUND;
                }
                else
                {
                    response = getSuccessResponse();
                    response.criminals = criminalList;
                }
            }
            catch (Exception e)
            {
                response = getFailedResponse();
                response.ServiceErrorMsg = Defs.ERROR_DATABASE_IS_DOWN;
            }
            return response;
        }
        public CriminalServiceResponse QuickSearchCriminalsByName(String searchCriteria)
        {
            CriminalServiceResponse response = new CriminalServiceResponse();
            if (searchCriteria == null || searchCriteria.Equals(String.Empty))
            {
                return GetCriminals();
            }
            else
            {
                try
                {
                    List<CriminalInfo> criminalDetail = DataProcressingService.GetSelectedCriminal(searchCriteria);
                    if (criminalDetail != null)
                    {
                        response = getSuccessResponse();
                        response.criminals = criminalDetail;
                    }
                    else
                    {
                        response = getFailedResponse();
                        response.ServiceErrorMsg = Defs.ERROR_OPERATION_IS_FAILED;
                    }
                }
                catch (Exception e)
                {
                    response = getFailedResponse();
                    response.ServiceErrorMsg = Defs.ERROR_DATABASE_IS_DOWN;
                }
            }
            return response;
        }
        public CriminalServiceResponse SearchCriminals(CriminalSearchCriteria searchCriteria)
        {
            CriminalServiceResponse response = new CriminalServiceResponse();
            if (searchCriteria == null)
            {
                return GetCriminals();
            }
            else
            {
                try
                {
                    List<CriminalInfo> criminalInfoList = DataProcressingService.SearchCriminals(searchCriteria);
                    if (criminalInfoList==null || criminalInfoList.Count <= 0)
                    {
                        response = getFailedResponse();
                        response.ServiceErrorMsg = Defs.ERROR_DATA_NOT_FOUND;
                    }
                    else
                    {
                        response = getSuccessResponse();
                        response.criminals = criminalInfoList;
                    }
                }
                catch (Exception e)
                {
                    response = getFailedResponse();
                    response.ServiceErrorMsg = Defs.ERROR_DATABASE_IS_DOWN;
                }
            }
            return response;
        }
        public CriminalServiceResponse UpdateCriminal(CriminalInfo criminal)
        {
            CriminalServiceResponse response = new CriminalServiceResponse();
            if (criminal == null)
            {
                response = getFailedResponse();
                response.ServiceErrorMsg = Defs.ERROR_PARAMETER_CONTAINS_NULL;
            }
            else
            {
                try
                {
                    if (DataProcressingService.UpdateCriminal(Util.ConvertCriminalCriminalInfo(criminal)))
                    {
                        response = getSuccessResponse();
                        response.criminals = new List<CriminalInfo>();
                        response.criminals.Add(criminal);
                    }
                    else
                    {
                        response = getFailedResponse();
                        response.ServiceErrorMsg = Defs.ERROR_UPDATE_OPERATION_IS_FAILED;
                    }
                }
                catch (Exception e)
                {
                    response = getFailedResponse();
                    response.ServiceErrorMsg = Defs.ERROR_DATABASE_IS_DOWN;
                }
            }
            return response;
        }
        private CriminalServiceResponse getSuccessResponse()
        {
            CriminalServiceResponse response = new CriminalServiceResponse();
            response.ServiceErrorMsg = null;
            response.operationStatus = true;

            return response;
        }
        private CriminalServiceResponse getFailedResponse()
        {
            CriminalServiceResponse response = new CriminalServiceResponse();
            response.criminals = null;
            response.operationStatus = false;

            return response;
        }
    }
}
