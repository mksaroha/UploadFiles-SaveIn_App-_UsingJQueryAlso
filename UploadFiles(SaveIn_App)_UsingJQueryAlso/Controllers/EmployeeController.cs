using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UploadFiles_SaveIn_App__UsingJQueryAlso.Models;

namespace UploadFiles_SaveIn_App__UsingJQueryAlso.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveEmployee()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult SaveEmployee(HttpPostedFileBase file)
        //{
        //    //var file1 = Request.Files[0];
        //    string path = Server.MapPath("~/App_Data/File");
        //    string fileName = Path.GetFileName(file.FileName);
        //    string fullPath = Path.Combine(path, fileName);
        //    file.SaveAs(fullPath);
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult SaveEmployee(Employee model)
        //{
        //    string fileName = Path.GetFileName(model.file.FileName);
        //    string path = Server.MapPath("~/App_Data/UploadedFiles");
        //    string fullPath = Path.Combine(path, fileName);
        //    model.file.SaveAs(fullPath);
        //    return View();
        //}

        
        [HttpPost]    
        public ActionResult SaveEmployee(Employee model)
        {
            // Checking no of files injected in Request object  
            //if (Request.Files.Count > 0)
            //{
            //    try
            //    {
            //        //  Get all files from Request object  
            //        HttpFileCollectionBase files = Request.Files;
            //        for (int i = 0; i < files.Count; i++)
            //        {
            //            //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
            //            //string filename = Path.GetFileName(Request.Files[i].FileName);  

            //            HttpPostedFileBase file = files[i];
            //            string fname;

            //            // Checking for Internet Explorer  
            //            if (Request.Browser.Browser.ToUpper() == "Chrome" || Request.Browser.Browser.ToUpper() == "Google Chrome")
            //            {
            //                string[] testfiles = file.FileName.Split(new char[] { '\\' });
            //                fname = testfiles[testfiles.Length - 1];
            //            }
            //            else
            //            {
            //                fname = file.FileName;
            //            }

            //            // Get the complete folder path and store the file inside it.  
            //            fname = Path.Combine(Server.MapPath("~/UploadedFiles/"), fname);
            //            file.SaveAs(fname);
            //        }
            //        // Returns message that successfully uploaded  
            //        return Json("File Uploaded Successfully!");
            //    }
            //    catch (Exception ex)
            //    {
            //        return Json("Error occurred. Error details: " + ex.Message);
            //    }
            //}
            //else
            //{
            //    return Json("No files selected.");
            //}

            string path = Server.MapPath("~/App_Data/UploadedFiles");
            HttpFileCollectionBase files = Request.Files;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                file.SaveAs(path + file.FileName);
            }
            return Json(files.Count + " Files Uploaded!");
        }

        public ActionResult UploadFiles(HttpPostedFileBase[] files)
        {
            //Ensure model state is valid  
            if (ModelState.IsValid)
            {   //iterating through multiple file collection   
                foreach (HttpPostedFileBase file in files)
                {
                    //Checking file is available to save.  
                    if (file != null)
                    {
                        var InputFileName = Path.GetFileName(file.FileName);
                        var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedFiles/") + InputFileName);
                        //Save file to server folder  
                        file.SaveAs(ServerSavePath);
                        //assigning file uploaded status to ViewBag for showing message to user.  
                        ViewBag.UploadStatus = files.Count().ToString() + " files uploaded successfully.";
                    }

                }
            }
            return View();
        }
    }
}