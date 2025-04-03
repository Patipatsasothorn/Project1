using System.Diagnostics;
using System.Globalization;
using BPI_TransBill.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BPI_TransBill.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BpigContext _pigContext;
        private readonly BpiTrpaymentContext _bpiTrpaymentContext;

        public HomeController(ILogger<HomeController> logger, BpigContext pigContext, BpiTrpaymentContext bpiTrpaymentContext)
        {
            _logger = logger;
            _pigContext = pigContext;
            _bpiTrpaymentContext = bpiTrpaymentContext; 
        }

        public IActionResult Index(string company, string username)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(company) || string.IsNullOrWhiteSpace(username))
                {
                    return Redirect("https://webapp.bpi-concretepile.co.th:9020/Account/Login"); // กลับไปที่หน้าล็อกอิน
                }

                HttpContext.Session.SetString("Company", company);
                HttpContext.Session.SetString("Username", username);

                return RedirectToAction("RenderLoadingScreen");
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }

        public IActionResult RenderLoadingScreen()
        {
            // ดึงค่าจาก Session
            var company = HttpContext.Session.GetString("Company");
            var user = HttpContext.Session.GetString("Username");

            // ตรวจสอบว่าข้อมูลใน Session ถูกต้อง
            if (string.IsNullOrWhiteSpace(company) || string.IsNullOrWhiteSpace(user))
            {
                return Redirect("https://webapp.bpi-concretepile.co.th:9020/#/authen");
            }

            ViewBag.Company = company;
            ViewBag.Username = user;

            //ViewData["Company"] = company;
            //ViewData["User"] = user;

            return View("Index");
        }

        [HttpGet]
        public IActionResult SearchInvoice(string startDate, string endDate, string vehicleType, string status)
        {
            try
            {
                var company = HttpContext.Session.GetString("Company");

                string fromDate = DateOnly.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyyMMdd");
                string toDate = DateOnly.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("yyyyMMdd");

                vehicleType = string.IsNullOrEmpty(vehicleType) ? "" : vehicleType;
                status = string.IsNullOrEmpty(status) ? "" : status;

                var result = _bpiTrpaymentContext.BillingNoteViewModels
                    .FromSqlInterpolated($"EXEC BPI_TransBill_GetData {company}, {fromDate}, {toDate}, {vehicleType}, {status}")/**/
                    .ToList();

                if (result.Count > 0)
                {
                    return Json(new { success = true, result });
                }
                else
                {
                    return Json(new { success = false, message = "ไม่พบข้อมูล" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "เกิดข้อผิดพลาด: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult SaveBillNoToSession(string BillNo)
        {
            try
            {
                // บันทึกข้อมูล BillNo ใน Session
                HttpContext.Session.SetString("BillNo", BillNo);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
