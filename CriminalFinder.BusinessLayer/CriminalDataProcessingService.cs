using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalFinder.BusinessLayer
{
    public class CriminalDataProcessingService
    {
        private CriminalDataClassesDataContext context;
        public CriminalDataProcessingService()
        {
            context = new CriminalDataClassesDataContext();
        }
        public List<CriminalInfo> GetCriminals()
        {
            try
            {
                var result = from r in this.context.CriminalInfoTables select r;
                return Util.ConvertCriminalCriminalInfo(result.ToList());
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public List<CriminalInfo> SearchCriminals(CriminalSearchCriteria searchCriteria)
        {
            try
            {
                var result = (from r in context.CriminalInfoTables
                              where r.Name.Equals(searchCriteria.Name)
                              || r.Nationality.Equals(searchCriteria.Nationality)
                              || r.Gender.Equals(searchCriteria.Gender)
                              || ((searchCriteria.MinAge > 0 && searchCriteria.MaxAge > 0) && 
                              (r.Age >= searchCriteria.MinAge && r.Age < searchCriteria.MaxAge))
                              || ((searchCriteria.MinHeight > 0 && searchCriteria.MaxHeight > 0) && 
                              (r.Height >= searchCriteria.MinHeight && r.Age < searchCriteria.MaxHeight))
                              || ((searchCriteria.MinWeight > 0 && searchCriteria.MaxWeight > 0) && 
                              (r.Weight >= searchCriteria.MinWeight && r.Age < searchCriteria.MaxWeight))
                              select r);
                if (result == null || result.Count() <= 0) return null;
                return Util.ConvertCriminalCriminalInfo(result.ToList());
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public List<CriminalInfo> GetSelectedCriminal(String name)
        {
            var result = (from r in context.CriminalInfoTables
                          where r.Name.Equals(name)
                          select r);
            return Util.ConvertCriminalCriminalInfo(result.ToList());
        }
        public CriminalInfo GetSelectedCriminal(long id)
        {
            var result = (from r in context.CriminalInfoTables
                          where r.Id == id
                          select r).First();
            return Util.ConvertCriminalCriminalInfo(result);
        }
        public bool AddCriminal(CriminalInfoTable criminalInfo)
        {
            try
            {
                context.CriminalInfoTables.InsertOnSubmit(criminalInfo);
                context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool AddCriminals(List<CriminalInfoTable> criminals)
        {
            try
            {
                context.CriminalInfoTables.InsertAllOnSubmit(criminals);
                context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateCriminal(CriminalInfoTable criminal)
        {
            try
            {
                CriminalInfoTable selectedCriminal = (from r in context.CriminalInfoTables
                 where r.Id.Equals(criminal.Id)
                 select r).First();
                selectedCriminal.Name = criminal.Name;
                selectedCriminal.Nationality = criminal.Nationality;
                selectedCriminal.Height = criminal.Height;
                selectedCriminal.Weight = criminal.Weight;
                selectedCriminal.Age = criminal.Age;
                selectedCriminal.Gender = criminal.Gender;
                context.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCriminal(long id)
        {
            try
            {
                CriminalInfoTable obj = (from r in context.CriminalInfoTables
                                         where r.Id.Equals(id)
                                         select r).First();
                if (obj != null)
                {
                    context.CriminalInfoTables.DeleteOnSubmit(obj);
                    context.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCriminals(List<CriminalInfoTable> criminals)
        {
            try
            {
                if (criminals != null && criminals.Count > 0)
                {
                    context.CriminalInfoTables.DeleteAllOnSubmit(criminals);
                    context.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
