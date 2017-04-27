using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CriminalFinder.WebClient.Controllers;
using CriminalFinder.WebClient.CriminalFinderService;
using System.Web.Mvc;

namespace CriminalFinder.WebClient.UnitTest
{
    [TestClass]
    public class CriminalControllerUnitTest
    {
        CriminalInfo criminal1 = null;
        CriminalInfo criminal2 = null;
        CriminalInfo criminal3 = null;
        CriminalInfo criminal4 = null;

        List<CriminalInfo> criminalList = null;
        CriminalController controller = null;

        public CriminalControllerUnitTest()
        {
            criminal1 = new CriminalInfo { Id = 1, Name = "Saun", Age = 27, Gender = "Male", Height = (float)1.5, Nationality = "India", Weight = (float)67.8000030517578 }; 
            criminal2 = new CriminalInfo { Id = 2, Name = "Srabon", Age = 27, Gender = "Male", Height = (float)1.55999994277954, Nationality = "bangladeshi", Weight = (float)89.5599975585938 };
            criminal3 = new CriminalInfo { Id = 3, Name = "Asodna", Age = 43, Gender = "Male", Height = (float)1.23000001907349, Nationality = "Indian", Weight = (float)53.4500007629395 };
            criminal4 = new CriminalInfo { Id = 5, Name = "Jakir", Age = 34, Gender = "Other", Height = (float)1.12000000476837, Nationality = "American", Weight = (float)54.2299995422363 };

            criminalList = new List<CriminalInfo> { criminal1, criminal2 };

            controller = new CriminalController();
        }

        [TestMethod]
        public void GetCriminalsTestMethod()
        {
            ViewResult result = controller.GetCriminals() as ViewResult;

            var model = (List<CriminalInfo>)result.ViewData.Model;

            CollectionAssert.Contains(model, criminal1);
            CollectionAssert.Contains(model, criminal2);
            CollectionAssert.Contains(model, criminal3);
            CollectionAssert.Contains(model, criminal4);
        }
        [TestMethod]
        public void CreateCriminalTestMethod()
        {
            CriminalInfo criminalLocal = new CriminalInfo { Name = "Jakira", Age = 24, Gender = "Male", Height = (float)1.12, Nationality = "Bangladesh", Weight = (float)54.0 };
            controller.CreateCriminal(criminalLocal);

            ViewResult result = controller.GetCriminals() as ViewResult;
            var model = (List<CriminalInfo>)result.ViewData.Model;
            CollectionAssert.Contains(model, criminalLocal);
        }

        [TestMethod]
        public void UpdateCriminalTestMethod()
        {
            CriminalInfo criminalLocal = new CriminalInfo { Id = 5, Name = "Aslam", Age = 34, Gender = "Other", Height = (float)1.12000000476837, Nationality = "American", Weight = (float)54.2299995422363 };
            controller.UpdateCriminal(criminalLocal);

            ViewResult result = controller.GetCriminals() as ViewResult;

            var model = (List<CriminalInfo>)result.ViewData.Model;
            
            CollectionAssert.Contains(model, criminalLocal);
        }

        [TestMethod]
        public void DeleteCriminalTestMethod()
        {
            CriminalInfo criminalLocal = new CriminalInfo { Id = 5, Name = "Aslam", Age = 34, Gender = "Other", Height = (float)1.12000000476837, Nationality = "American", Weight = (float)54.2299995422363 };
            controller.DeleteCriminal(criminalLocal);

            ViewResult result = controller.GetCriminals() as ViewResult;

            var model = (List<CriminalInfo>)result.ViewData.Model;
            
            CollectionAssert.DoesNotContain(model, criminalLocal);
        }
    }
}
