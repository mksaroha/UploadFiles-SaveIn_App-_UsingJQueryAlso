using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UploadFiles_SaveIn_App__UsingJQueryAlso.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public HttpPostedFileBase file { get; set; }
        ////public IEnumerable<HttpPostedFileBase> file { get; set; }
        //public HttpPostedFileBase[] file { get; set; }
    }
}