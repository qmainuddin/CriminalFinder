using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalFinder.BusinessLayer
{
    public class Util
    {
        public static CriminalInfo ConvertCriminalCriminalInfo(CriminalInfoTable criminalInfoDB)
        {
            if (criminalInfoDB == null) return null;
            CriminalInfo criminalInfoBean = new CriminalInfo()
            {
                Id = criminalInfoDB.Id,
                Name = criminalInfoDB.Name,
                Age = criminalInfoDB.Age,
                Gender = criminalInfoDB.Gender,
                Height = (float)criminalInfoDB.Height,
                Nationality = criminalInfoDB.Nationality,
                Weight = (float)criminalInfoDB.Weight,
            };
            return criminalInfoBean;
        }

        public static CriminalInfoTable ConvertCriminalCriminalInfo(CriminalInfo criminalInfoBean)
        {
            if (criminalInfoBean == null) return null;
            CriminalInfoTable criminalInfoDB = new CriminalInfoTable()
            {
                Id = criminalInfoBean.Id,
                Name = criminalInfoBean.Name,
                Age = criminalInfoBean.Age,
                Gender = criminalInfoBean.Gender,
                Height = (float)criminalInfoBean.Height,
                Nationality = criminalInfoBean.Nationality,
                Weight = (float)criminalInfoBean.Weight,
            };
            return criminalInfoDB;
        }

        public static List<CriminalInfoTable> ConvertCriminalCriminalInfo(List<CriminalInfo> criminalInfoBeanList)
        {
            if (criminalInfoBeanList == null && criminalInfoBeanList.Count > 0) return null;
            List<CriminalInfoTable> criminalInfoDBList = new List<CriminalInfoTable>();
            foreach(CriminalInfo beanData in criminalInfoBeanList)
            {
                criminalInfoDBList.Add(ConvertCriminalCriminalInfo(beanData));
            }
            return criminalInfoDBList;
        }

        public static List<CriminalInfo> ConvertCriminalCriminalInfo(List<CriminalInfoTable> criminalInfoDBList)
        {
            if (criminalInfoDBList == null && criminalInfoDBList.Count > 0) return null;
            List<CriminalInfo> criminalInfoBeanList = new List<CriminalInfo>();
            foreach(CriminalInfoTable tableData in criminalInfoDBList)
            {
                criminalInfoBeanList.Add(ConvertCriminalCriminalInfo(tableData));
            }
            return criminalInfoBeanList;
        }
    }
}
