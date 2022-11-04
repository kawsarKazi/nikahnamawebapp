using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NikahMetromoniApp.Controllers
{
    public class UtilitesController : Controller
    {
        // GET: Utilites
        [HttpPost]
        public ActionResult Upload()
        {
            string identity = Request["identity"];
            HttpFileCollectionBase files = Request.Files;
            long count = 0;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                string fname;
                // Checking for Internet Explorer      
                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                {
                    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                    fname = testfiles[testfiles.Length - 1];
                }
                else
                {
                    fname = file.FileName;
                }
                // Get the complete folder path and store the file inside it.      
                fname = Path.Combine(Server.MapPath("~/FileUploads/"), identity+".pdf");
                file.SaveAs(fname);

            }
            return Json("Hi, " + identity + ". Your files uploaded successfully", JsonRequestBehavior.AllowGet);
        }
    }
}