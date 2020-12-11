using Microsoft.Reporting.WebForms;
using Stone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stone.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Reports(string ReportType)
        {
            using(StoreEntities db = new StoreEntities())
            {
                LocalReport localreport = new LocalReport();
                localreport.ReportPath = Server.MapPath("~/Reports/ProductReport.rdlc");

                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "ProductDataSet";
                reportDataSource.Value = db.Product.ToList();
                localreport.DataSources.Add(reportDataSource);
                string reportType = ReportType;

                string mimeType;
                string encording;
                string fileNameExtension;
                if(reportType == "Excel")
                {
                    fileNameExtension = "xlsx";
                }
                else if (reportType == "Word")
                {
                    fileNameExtension = "doc";
                }
                else if (reportType == "PDF")
                {
                    fileNameExtension = "pdf";
                }
                else
                {
                    fileNameExtension = "jpg";
                }
                string[] streams;
                Warning[] warnings;
                byte[] renderedByte;
                renderedByte = localreport.Render(reportType, "", out mimeType, out encording, out fileNameExtension, out streams, out warnings);
                Response.AddHeader("content-disposition", "attachment : filename = product_report" + fileNameExtension);
                return File(renderedByte, fileNameExtension);

                
            }
        }
        public ActionResult ProductList()
        {
            using(StoreEntities db = new StoreEntities())
            {
                return View(db.Product.ToList());
            }
        }
    }
}