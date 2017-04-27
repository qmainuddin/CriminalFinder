using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CriminalFinder.WebClient.CriminalFinderService;
using CriminalFinder.WebClient.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;
using MvcRazorToPdf;
using CriminalFinder.WebClient.Commons;

namespace CriminalFinder.WebClient.Controllers
{
    public class CriminalController : Controller
    {
        private CriminalServiceClient ServiceClient;
        public CriminalController()
        {
            this.ServiceClient = new CriminalServiceClient();
        }
        // GET: Search
        [HttpGet]
        public ActionResult GetCriminals()
        {
            CriminalServiceResponse resp = ServiceClient.GetCriminals();
            List<CriminalModal> criminalModels = new List<CriminalModal>();
            if (resp.operationStatus)
            {
                //List<CriminalInfo> criminals = resp.criminals.ToList();
                //foreach (CriminalInfo criminal in criminals)
                //{
                //    criminalModels.Add(Commons.BasicOperations.
                //        ConvertModal(criminal));
                //}
                CriminalInfoViewModel CurrentViewModel = new CriminalInfoViewModel();
                CurrentViewModel.Criminals = resp.criminals.ToList();
                //return View(resp.criminals);
                return View(CurrentViewModel);
            }
            else
            {
                return View("Error");
            }
        }
        [HttpGet]
        public ActionResult SearchCriminals()
        {
            return RedirectToAction("GetCriminals");
        }

        [HttpPost]
        public ActionResult SearchCriminals(String c_name, String c_Gender, String c_Age, String c_Nationality, String c_heightRange, String c_weightRange)
        {
            CriminalSearchCriteria searchCriteria = new CriminalSearchCriteria();
            searchCriteria.Name = c_name;
            searchCriteria.Gender = c_Gender;
            searchCriteria.Nationality = c_Nationality;
            if (c_Age != null && !c_Age.Equals("0"))
            {
                String[] ages = c_Age.Split('_');
                searchCriteria.MinAge = Util.toInt(ages[0]);
                searchCriteria.MaxAge = Util.toInt(ages[1]);
            }
            if (c_heightRange != null && !c_heightRange.Equals("0"))
            {
                String[] heights = c_heightRange.Split('_');
                searchCriteria.MinHeight = Util.toInt(heights[0]);
                searchCriteria.MaxHeight = Util.toInt(heights[1]);
            }
            if (c_weightRange != null && !c_weightRange.Equals("0"))
            {
                String[] weights = c_weightRange.Split('_');
                searchCriteria.MinWeight = Util.toInt(weights[0]);
                searchCriteria.MaxWeight = Util.toInt(weights[1]);
            }
            CriminalServiceResponse resp = ServiceClient.SearchCriminals(searchCriteria);
            if (resp.operationStatus)
            {
                CriminalInfoViewModel CurrentViewModel = new CriminalInfoViewModel();
                CurrentViewModel.Criminals = resp.criminals.ToList();
                return View("GetCriminals", CurrentViewModel);
            }
            else
            {
                return View("GetCriminals", null);
            }
        }

        [HttpGet]
        public ActionResult QuickSearchCriminals()
        {
            return RedirectToAction("GetCriminals");
        }
        [HttpPost]
        public ActionResult QuickSearchCriminals(String c_name)
        {   
            CriminalServiceResponse resp = ServiceClient.QuickSearchCriminalsByName(c_name);
            if (resp.operationStatus)
            {
                CriminalInfoViewModel CurrentViewModel = new CriminalInfoViewModel();
                CurrentViewModel.Criminals = resp.criminals.ToList();
                //return View("GetCriminals", CurrentViewModel);
                return Json(CurrentViewModel.Criminals.ToArray());
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        public ActionResult CreateCriminal()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCriminal(CriminalInfo objCriminal)
        {
            if (ModelState.IsValid) //checking model is valid or not
            {
                CriminalServiceResponse resp = null;
                try
                {
                    resp = this.ServiceClient.CreateCriminal(objCriminal);
                }
                catch (Exception e) { }
                if (resp!=null && resp.operationStatus)
                {
                    string result = "Data added successfully";
                    ViewData["result"] = result;
                    ModelState.Clear(); //clearing model
                    //return View();
                    return RedirectToAction("Sent", "Home", ViewData);
                }
                else
                {
                    ModelState.AddModelError("", "Error in saving data");
                    ModelState.Clear(); //clearing model
                    return View("Error");
                }
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult UpdateCriminal(long Id)
        {
            try
            {
                return View(this.ServiceClient.GetCriminal(Id).criminals[0]);
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult DeleteCriminal(long Id)
        {
            try
            {
                return View(this.ServiceClient.GetCriminal(Id).criminals[0]);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult UpdateCriminal(CriminalInfo objCriminal)
        {
            if (ModelState.IsValid) //checking model is valid or not
            {
                CriminalServiceResponse resp = null;
                try
                {
                    resp = this.ServiceClient.UpdateCriminal(objCriminal);
                }
                catch (Exception e) { }
                if (resp != null && resp.operationStatus)
                {
                    string result = "Data updated successfully";
                    ViewData["result"] = result;
                    ModelState.Clear(); //clearing model
                    //return View();
                    return RedirectToAction("Sent", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error in saving data");
                    ModelState.Clear(); //clearing model
                    return View("Error");
                }
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult DeleteCriminal(CriminalInfo objCriminal)
        {
            if (ModelState.IsValid) //checking model is valid or not
            {
                CriminalServiceResponse resp = null;
                try
                {
                    resp = this.ServiceClient.DeleteCriminal(objCriminal.Id);
                }
                catch (Exception e) { }
                if (resp != null && resp.operationStatus)
                {
                    string result = "Data deleted successfully";
                    ViewData["result"] = result;
                    ModelState.Clear(); //clearing model
                    //return View();
                    return RedirectToAction("Sent", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error in saving data");
                    ModelState.Clear(); //clearing model
                    //return View();
                    return View("Error");
                }
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View("Error");
            }
        }

        public ActionResult PrintCriminal(long Id)
        {
            CriminalInfo criminal = this.ServiceClient.GetCriminal(Id).criminals[0];
            return new PdfActionResult(criminal, (writer, document) =>
            {
                document.SetPageSize(new Rectangle(500f, 500f, 90));
                document.NewPage();
            })
            {
                FileDownloadName = criminal.Name + "_" + DateTime.Now.Ticks + ".pdf"
            };
        }
        private MemoryStream createPDF(string html)
        {
            MemoryStream msOutput = new MemoryStream();
            TextReader reader = new StringReader(html);

            // step 1: creation of a document-object
            Document document = new Document(PageSize.A4, 30, 30, 30, 30);

            // step 2:
            // we create a writer that listens to the document
            // and directs a XML-stream to a file
            PdfWriter writer = PdfWriter.GetInstance(document, msOutput);

            // step 3: we create a worker parse the document
            HTMLWorker worker = new HTMLWorker(document);

            // step 4: we open document and start the worker on the document
            document.Open();
            worker.StartDocument();

            // step 5: parse the html into the document
            worker.Parse(reader);

            // step 6: close the document and the worker
            worker.EndDocument();
            worker.Close();
            document.Close();

            return msOutput;
        }
    }
}