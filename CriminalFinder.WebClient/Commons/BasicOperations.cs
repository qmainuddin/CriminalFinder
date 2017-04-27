using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CriminalFinder.WebClient.Models;
using CriminalFinder.WebClient.CriminalFinderService;

namespace CriminalFinder.WebClient.Commons
{
    public class BasicOperations
    {
        public static CriminalInfo ConvertModal(CriminalModal modal)
        {
            CriminalInfo tableValue = new CriminalInfo
            {
                Id = modal.Id,
                Age = modal.Age,
                Gender = modal.Gender,
                Height = modal.Height,
                Name = modal.Name,
                Nationality = modal.Nationality,
                Weight = modal.Weight,
            };
            return tableValue;
        }
        public static CriminalModal ConvertModal(CriminalInfo tableValue)
        {
            CriminalModal modal = new CriminalModal
            {
                Id = tableValue.Id,
                Age = tableValue.Age,
                Gender = tableValue.Gender,
                Height = (float)tableValue.Height,
                Name = tableValue.Name,
                Nationality = tableValue.Nationality,
                Weight = (float)tableValue.Weight,
            };
            return modal;
        }
        //public static CriminalModal ConvertModal(CriminalInfo tableValue)
        //{
        //    CriminalModal modal = new CriminalModal
        //    {
        //        Id = tableValue.Id,
        //        Age = tableValue.Age,
        //        Gender = tableValue.Gender,
        //        Height = (float)tableValue.Height,
        //        Name = tableValue.Name,
        //        Nationality = tableValue.Nationality,
        //        Weight = (float)tableValue.Weight,
        //    };
        //    return modal;
        //}
    }
}