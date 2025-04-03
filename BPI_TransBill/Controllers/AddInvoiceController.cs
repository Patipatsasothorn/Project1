using System.Data;
using System.Globalization;
using APInv.Models;
using BPI_TransBill.Models;
using BPI_TransBill.Models.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BPI_TransBill.Controllers
{
    public class AddInvoiceController : Controller
    {
        private readonly BpiLiveContext _bpiLiveContext;
        private readonly BpiTrpaymentContext _bpiTrpaymentContext;
        private readonly BpigContext _pigContext;
        private readonly BpiUat2Context _uat2Context;
        private readonly APInvtableContext _aPInvtableContext;

        public AddInvoiceController(BpiLiveContext bpiLiveContext, BpiTrpaymentContext bpiTrpaymentContext, BpigContext bpigContext, BpiUat2Context uat2Context,APInvtableContext aPInvtableContext)
        { 
            _bpiLiveContext = bpiLiveContext;
            _bpiTrpaymentContext = bpiTrpaymentContext;
            _pigContext = bpigContext;
            _uat2Context = uat2Context;
            _aPInvtableContext = aPInvtableContext;
        }

        public IActionResult Index()
        {
            try
            {
                var company = HttpContext.Session.GetString("Company");
                var username = HttpContext.Session.GetString("Username");

                if (string.IsNullOrWhiteSpace(company) || string.IsNullOrWhiteSpace(username))
                {
                    return Redirect("https://webapp.bpi-concretepile.co.th:9020/Account/Login");
                }

                var billNo = HttpContext.Session.GetString("BillNo");

                ViewBag.BillNo = billNo;

                ViewBag.Company = company;
                ViewBag.Username = username;

                return View();
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }

        [HttpGet]
        public IActionResult GetVendors(string vendorCode)
        {
            try
            {
                var company = HttpContext.Session.GetString("Company");

                var resultVendors = _bpiLiveContext.Ud100s
                    .Where(v => v.Company == company && v.Key4.StartsWith("S"))
                    .Select(v => new
                    {
                        v.Character02,
                        v.Character03
                    })
                    .GroupBy(v => new { v.Character02, v.Character03 })
                    .Select(g => new
                    {
                        Character02 = g.Key.Character02,
                        Character03 = g.Key.Character03,
                        Count = g.Count()
                    })
                    .ToList();

                string defaultVendor = null;

                if (!string.IsNullOrEmpty(vendorCode))
                {
                    var match = resultVendors.FirstOrDefault(v => v.Character02 == vendorCode);
                    if (match != null)
                    {
                        defaultVendor = match.Character02;
                    }
                }

                return Json(new { success = true, resultVendors, defaultVendor });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message});
            }
        }

        [HttpGet]
        public IActionResult GetPaidName(string paidName)
        {
            try
            {
                var company = HttpContext.Session.GetString("Company");

                var paidCode = _uat2Context.Vendors1
                    .Where(v => v.Company == company && v.CheckBox01 == true)
                    .Select(v => new
                    {
                        v.VendorId,
                        v.Name
                    });

                string defaultPaidName = null;

                if (!string.IsNullOrEmpty(paidName))
                {
                    var match = paidCode.FirstOrDefault(v => v.VendorId == paidName);
                    if (match != null)
                    {
                        defaultPaidName = match.VendorId;
                    }
                }

                return Json(new { success = true, paidCode, defaultPaidName });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetEmployeeName(string startDate, string endDate, string driverName)
        {
            try
            {
                var company = HttpContext.Session.GetString("Company");
                var culture = new CultureInfo("en-US");

                string formattedStartDate = DateTime.ParseExact(startDate, "dd/MM/yyyy", culture).ToString("yyyy-MM-dd");
                string formattedEndDate = DateTime.ParseExact(endDate, "dd/MM/yyyy", culture).ToString("yyyy-MM-dd");

                var resultEmpName = _bpiLiveContext.Ud27s
               .Where(x => x.Company == company
                           && !string.IsNullOrEmpty(x.ShortChar12) // เปลี่ยนจาก ShortChar15 -> ShortChar12
                           && x.Date01 >= DateOnly.Parse(formattedStartDate)
                           && x.Date01 <= DateOnly.Parse(formattedEndDate))
               .Select(x => x.ShortChar12)
               .Distinct() // ป้องกันค่าซ้ำ
               .ToList();

                string defaultDriverName = resultEmpName.Contains(driverName) ? driverName : null;

                return Json(new { success = true, resultEmpName, defaultDriverName });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpGet]
        public IActionResult GetEmpBasic()
        {
            try
            {
                var company = HttpContext.Session.GetString("Company");

                var resultEmpBasic = _uat2Context.EmpBasics
                    .Where(e => e.Company == company && e.Jcdept == "B102")
                    .Select(e => new
                    {
                        e.EmpId,
                        e.Name
                    })
                    .ToList();

                return Json(new { success = true, resultEmpBasic });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult SaveForm([FromBody] AddInvoiceModel m)
        {
            try
            {
                var company = HttpContext.Session.GetString("Company");
                var user = HttpContext.Session.GetString("Username");

                var getId = _pigContext.UserRights
                   .Where(u => u.UserName == user)
                   .Select(u => u.UserId)
                   .SingleOrDefault();

                string prefix = company switch
                {
                    "BPI" => "B",
                    "SAC" => "S",
                    "S145" => "W"
                };

                string billNo;

                var checkBillId = _bpiTrpaymentContext.BillingNoteHs
                    .FirstOrDefault(h => h.BillNo == m.InvNo);

                var culture = new CultureInfo("en-US");
                var format = "dd/MM/yyyy";

                if (checkBillId != null)
                {
                    if (checkBillId.DocStatus == 0)
                    {
                        checkBillId.BillDate = DateTime.ParseExact(m.BillDate, format, culture);
                        checkBillId.FromDate = DateTime.ParseExact(m.FromDate, format, culture);
                        checkBillId.ToDate = DateTime.ParseExact(m.ToDate, format, culture);
                        checkBillId.CarType = m.CarType;
                        checkBillId.VendorCode = m.VendorCode;
                        checkBillId.PaidCode = m.PaidName;
                        checkBillId.PaidName = m.PaidName;
                        checkBillId.DriverName = m.DriverName;
                        checkBillId.EmpId = m.EmpId;
                        checkBillId.StaffId = m.StaffId;
                        checkBillId.StaffGen = m.StaffGen;
                        checkBillId.UpdateDate = DateTime.Now;
                        checkBillId.UpdateBy = getId.ToString();

                        _bpiTrpaymentContext.BillingNoteHs.Update(checkBillId);
                        _bpiTrpaymentContext.SaveChanges();

                        return Json(new { success = true, updateTable = "Yes" });
                    }
                }

                using (var conn = _bpiTrpaymentContext.Database.GetDbConnection())
                {
                    conn.Open();
                    using (var cm = conn.CreateCommand())
                    {
                        cm.CommandText = "BPI_TransBillGenerateBillNo";
                        cm.CommandType = CommandType.StoredProcedure;

                        var companyParam = new SqlParameter("@CompanyCode", SqlDbType.Char, 1) { Value = prefix };
                        var billNoParam = new SqlParameter("@BillNo", SqlDbType.VarChar, 20) { Direction = ParameterDirection.Output };

                        cm.Parameters.Add(companyParam);
                        cm.Parameters.Add(billNoParam);

                        cm.ExecuteNonQuery();
                        billNo = billNoParam.Value.ToString();
                    }

                    var data = new BillingNoteH
                    {
                        Company = company,
                        BillNo = billNo,
                        BillDate = DateTime.ParseExact(m.BillDate, format, culture),
                        FromDate = DateTime.ParseExact(m.FromDate, format, culture),
                        ToDate = DateTime.ParseExact(m.ToDate, format, culture),
                        CarType = m.CarType,
                        VendorCode = m.VendorCode,
                        PaidCode = m.PaidName,
                        PaidName = m.PaidName,
                        DriverName = m.DriverName,
                        EmpId = m.EmpId,
                        StaffId = m.StaffId,
                        StaffGen = m.StaffGen,
                        DocStatus = 0,
                        CreateDate = DateTime.Now,
                        CreateBy = getId.ToString()

                    };

                    _bpiTrpaymentContext.BillingNoteHs.Add(data);
                    _bpiTrpaymentContext.SaveChanges();

                    string docStatus = data.DocStatus.ToString();

                    return Json(new { success = true, billNo, docStatus });
                }  
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "เกิดข้อผิดพลาด: " + ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetDataToModal(string fromDateM, string toDateM, string carNumM)
        {
            try
            {
                var company = HttpContext.Session.GetString("Company");

                var culture = new CultureInfo("en-US");
                string startDate = DateOnly.ParseExact(fromDateM, "dd/MM/yyyy", culture).ToString("yyyyMMdd");
                string endDate = DateOnly.ParseExact(toDateM, "dd/MM/yyyy", culture).ToString("yyyyMMdd");

                var result = _bpiTrpaymentContext.Invoices
                    .FromSqlInterpolated($"EXEC BPI_TransBill_GetUD27 {company}, {startDate}, {endDate}, {carNumM}")
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
        public IActionResult SaveCheckedData([FromBody] AddInvoiceModel model)
        {
            try
            {
                var company = HttpContext.Session.GetString("Company");
                var user = HttpContext.Session.GetString("Username");

                var culture = new CultureInfo("en-US");
                var format = "dd/MM/yyyy";

                var getId = _pigContext.UserRights
                   .Where(u => u.UserName == user)
                   .Select(u => u.UserId)
                   .SingleOrDefault();

                var getBillId = _bpiTrpaymentContext.BillingNoteHs
                    .Where(h => h.Company == company && h.BillNo == model.InvNo)
                    .Select(h => h.BillId)
                    .SingleOrDefault();

                string currentYYMM = DateTime.Now.ToString("yyMM"); // ดึงปี+เดือน (เช่น 2403)
                string newShipSet = "";

                if (model.deliveryInfos[0].ShipSet == true)
                {
                    var checkShipSet = _bpiTrpaymentContext.BillingNoteDs
                        .Where(d => EF.Functions.DateDiffDay(d.CreateDate, DateTime.Now) == 0)
                        .Select(d => d.ShipSet)
                        .Where(s => !string.IsNullOrEmpty(s))
                        .ToList();

                    if (checkShipSet.Any())
                    {
                        // หาเลขรันสูงสุด
                        int lastRunning = checkShipSet
                            .Select(s =>
                            {
                                if (s.Length >= 4 && int.TryParse(s[^4..], out int r))
                                    return r;
                                return 0;
                            })
                            .Max();

                        newShipSet = $"{company}{currentYYMM}{(lastRunning + 1):D4}";
                    }
                    else
                    {
                        newShipSet = $"{company}{currentYYMM}0001";
                    }
                }

                foreach (var invoice in model.deliveryInfos)
                {
                    var netWeight = _uat2Context.Parts
                        .Where(p => p.Company == company && p.PartNum == invoice.PartNum)
                        .Select(p => p.NetWeight)
                        .FirstOrDefault();

                    decimal partWeight = (netWeight * invoice.ShipQty) / 100;

                    var newRecord = new BillingNoteD
                    {
                        BillId = getBillId,
                        ShipNum = invoice.InvNum,
                        ShipDate = DateTime.ParseExact(invoice.InvDate, format, culture),
                        CarNo = invoice.CarNum,
                        ShipViaCode = invoice.ShipViaCode,
                        ProjectId = invoice.ProjectId,
                        Partnum = invoice.PartNum,
                        ShipQty = invoice.ShipQty,
                        CustNum = invoice.CustNum,
                        ShipToNum = invoice.ShipToNum,
                        Fuel = double.TryParse(invoice.FuelPrice, out double fuelValue) ? fuelValue : 0,
                        StaffAmt = double.TryParse(invoice.ShipCost, out double shipAmt) ? shipAmt : 0,
                        NetWeight = double.Parse(invoice.NetWeight.ToString()),
                        ExtCompany = invoice.ExtCompany,
                        DetailStatus = 0,
                        CreateDate = DateTime.Now,
                        CreateBy = getId.ToString(),
                        DeliveryRoudNo = invoice.DeliveryRoundNo,
                        DeliveryNo = invoice.DeliveryNo,
                        StaffId = invoice.StaffId,
                        StaffGen = invoice.Gender,
                        ShipSet = newShipSet

                    };

                    _bpiTrpaymentContext.BillingNoteDs.Add(newRecord);
                }

                _bpiTrpaymentContext.SaveChanges();

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "เกิดข้อผิดพลาด: " + ex.Message });
            }
        }

        [HttpGet]
        public IActionResult CheckGroup(string invNo)
        {
            var company = HttpContext.Session.GetString("Company");

            if (string.IsNullOrEmpty(invNo))
            {
                return Json(new { success = true });
            }

            var getBillId = _bpiTrpaymentContext.BillingNoteHs
                .FirstOrDefault(h => h.Company == company && h.BillNo == invNo);


            var checkBillDetail = _bpiTrpaymentContext.BillingNoteDs
                .Where(b => b.BillId == getBillId.BillId)
                .ToList();

            if (checkBillDetail.Count == 0)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false , message = "ไม่สามารถเปลี่ยนประเภทรถได้ เนื่องจากมีข้อมูลใบส่งของแล้ว"});
            }

        }

        [HttpGet]
        public IActionResult SearchInvoice(string invNo)
        {
            var company = HttpContext.Session.GetString("Company");

            var invoice = _bpiTrpaymentContext.BillingNoteHs
                .Where(h => h.Company == company && h.BillNo == invNo)
                .Select(h => new
                {
                    BillDate = h.BillDate.HasValue ? h.BillDate.Value.ToString("dd/MM/yyyy") : "",
                    FromDate = h.FromDate.HasValue ? h.FromDate.Value.ToString("dd/MM/yyyy") : "",
                    ToDate = h.ToDate.HasValue ? h.ToDate.Value.ToString("dd/MM/yyyy") : "",
                    h.DocStatus,
                    h.CarType,
                    h.VendorCode,
                    h.PaidName,
                    h.BillId,
                    h.DriverName,
                    h.EmpId,
                    h.StaffGen,
                    h.StaffId

                })
                .ToList();

            if (!invoice.Any())
            {
                return Json(new { success = false, message = "ไม่พบข้อมูลใบแจ้งหนี้" });
            }

            var billId = invoice[0].BillId;

            var invoiceBill = _bpiTrpaymentContext.BillingNoteDViewModels
                .FromSqlInterpolated($"EXEC BPI_TransBill_GetBillingNoteD {billId}")
                .ToList();

            if (!invoiceBill.Any())
            {
                return Json(new { success = true, invoices = invoice, invoiceBill = new List<object>() });
            }

            return Json(new { success = true, invoices = invoice, invoiceBill, /*driverName*/ });
        } 

        [HttpPost]
        public IActionResult DeleteInvoice(long billId, string shipNum)
        {
            try
            {
                var company = HttpContext.Session.GetString("Company");

                var invoiceDetail = _bpiTrpaymentContext.BillingNoteDs
                    .FirstOrDefault(d => d.BillId == billId && d.ShipNum == shipNum);

                if (invoiceDetail.DetailStatus != 0)
                {
                    return Json(new { success = false, message = "ใบส่งของชั่วคราวนี้ทำการตั้งหนี้ไปแล้ว ไม่อนุญาตให้ลบข้อมูล" });
                }

                _bpiTrpaymentContext.BillingNoteDs.Remove(invoiceDetail);
                _bpiTrpaymentContext.SaveChanges();

                return Json(new { success = true, message = "ลบข้อมูลเรียบร้อยแล้ว" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "เกิดข้อผิดพลาด: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult SendApprove([FromBody] AddInvoiceModel model)
        {
            try
            {
                var company = HttpContext.Session.GetString("Company");
                var user = HttpContext.Session.GetString("Username");

                var getIdNoApproval = _pigContext.UserRights
                    .Where(u => u.UserName == user)
                    .Select(u => u.UserId)
                    .FirstOrDefault();

                var billHeads = _bpiTrpaymentContext.BillingNoteHs.FirstOrDefault(d => d.BillNo == model.InvNo);

                //if (billHeads.DocStatus != 0)
                //{
                //    return Json(new { success = false, message = "สถานะไม่ใช่ 0 กรุณาติดต่อฝ่ายไอที" });
                //}

                var billDetails = _bpiTrpaymentContext.BillingNoteDs.Where(h => h.BillId == billHeads.BillId && h.DetailStatus == 0).ToList();

                if (billDetails.Any(d => d.DetailStatus != 0))
                {
                    return Json(new { success = false, message = "สถานะไม่ใช่ 0 กรุณาติดต่อฝ่ายไอที" });
                }

                billHeads.DocStatus = 1;
                billHeads.UpdateDate = DateTime.Now;
                billHeads.UpdateBy = getIdNoApproval.ToString();

                //billDetails.ForEach(item =>
                //{
                //    item.DetailStatus = 1;
                //    item.UpdateDate = DateTime.Now;
                //    item.UpdateBy = getIdNoApproval.ToString();
                //});


                _bpiTrpaymentContext.SaveChanges();

                return Json(new { success = true, message = "ส่งข้อมูลให้บัญชีเรียบร้อย" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"เกิดข้อผิดพลาด: {ex.Message}" });
            }
        }

        [HttpPost]
        public IActionResult Canceled([FromBody] AddInvoiceModel model)
        {
            try
            {
                var company = HttpContext.Session.GetString("Company");
                var user = HttpContext.Session.GetString("Username");

                var getIdNoApproval = _pigContext.UserRights
                    .Where(u => u.UserName == user)
                    .Select(u => u.UserId)
                    .FirstOrDefault();

                var billHead = _bpiTrpaymentContext.BillingNoteHs.FirstOrDefault(d => d.BillNo == model.InvNo);

                if (billHead.DocStatus != 0)
                {
                    return Json(new { success = false, message = "สถานะไม่ใช่ 0 กรุณาติดต่อฝ่ายไอที" });
                }

                var billDetails = _bpiTrpaymentContext.BillingNoteDs.Where(h => h.BillId == billHead.BillId).ToList();

                if (billDetails.Any(d => d.DetailStatus != 0))
                {
                    return Json(new { success = false, message = "สถานะไม่ใช่ 0 กรุณาติดต่อฝ่ายไอที" });
                }

                billHead.DocStatus = 9;
                billHead.UpdateDate = DateTime.Now;
                billHead.UpdateBy = getIdNoApproval.ToString();

                //billDetails.ForEach(item =>
                //{
                //    item.DetailStatus = 9;
                //    item.UpdateDate = DateTime.Now;
                //    item.UpdateBy = getIdNoApproval.ToString();
                //});

                _bpiTrpaymentContext.SaveChanges();

                return Json(new { success = true, message = "ยกเลิกใบวางบิลเรียบร้อย" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"เกิดข้อผิดพลาด: {ex.Message}" });
            }
        }

    }
}