using APInv.Models;
using BPI_TransBill.Models.Data;
using BPI_TransBill.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;

namespace BPI_TransBill.Controllers
{
    public class DraftDeliveryController : Controller
    {
        private readonly APInvtableContext _aPInvtableContext;
        private readonly allcarContext _allcarContext;
        private readonly BpiTrpaymentContext _BpiTrpaymentContext;
        private readonly OildebtContext _oildebtContext;
        private readonly dmgebtContext _dmgebtContext;
        private readonly companycarContext _companycarContext;
        private readonly string _connectionString;
        private readonly BpigContext _pigContext;

        public DraftDeliveryController(APInvtableContext aPInvtableContext, allcarContext allcarContext,
            BpiTrpaymentContext bpiTrpaymentContext, dmgebtContext dmgebtContext, OildebtContext oildebtContext,
            BpigContext bpigContext, companycarContext companycarContext, IConfiguration configuration)
        {

            _aPInvtableContext = aPInvtableContext;
            _allcarContext = allcarContext;
            _BpiTrpaymentContext = bpiTrpaymentContext;
            _connectionString = configuration.GetConnectionString("BpiTRConnection");
            _oildebtContext = oildebtContext;
            _dmgebtContext = dmgebtContext;
            _pigContext = bpigContext;
            _companycarContext = companycarContext;

        }
        public IActionResult Index()
        {
            var company = HttpContext.Session.GetString("Company");
            var username = HttpContext.Session.GetString("Username");

            if (string.IsNullOrWhiteSpace(company) || string.IsNullOrWhiteSpace(username))
            {
                return Redirect("https://webapp.bpi-concretepile.co.th:9020/Account/Login");
            }

            ViewBag.Company = company;
            ViewBag.Username = username;

            return View();
        }
        [HttpGet]
        public IActionResult APInv(string status, string startDate, string endDate)
        {
            var culture = new CultureInfo("en-US");

            // ใช้ DateOnly แทน DateTime
            DateOnly parsedStartDate;
            DateOnly parsedEndDate;

            // แปลง string เป็น DateOnly ด้วย TryParseExact
            if (DateOnly.TryParseExact(startDate, "dd/MM/yyyy", culture, DateTimeStyles.None, out parsedStartDate) &&
                DateOnly.TryParseExact(endDate, "dd/MM/yyyy", culture, DateTimeStyles.None, out parsedEndDate))
            {
                // แปลง DateOnly เป็นรูปแบบที่ SQL Server รองรับ
                string formattedStartDate = parsedStartDate.ToString("yyyy-MM-dd");
                string formattedEndDate = parsedEndDate.ToString("yyyy-MM-dd");

                // เรียกใช้ stored procedure พร้อมพารามิเตอร์
                var query = _aPInvtableContext.APInvModels
                             .FromSqlInterpolated($"EXEC APInv @Status = {status}, @StartDate = {formattedStartDate}, @EndDate = {formattedEndDate}")
                             .ToList();

                return Json(query);
            }
            else
            {
                // ถ้าไม่สามารถแปลงวันที่ได้ ส่งข้อความผิดพลาด
                return Json(new { error = "Invalid date format." });
            }
        }


        [HttpGet]
        public IActionResult ALLCAR(string detailID,string contractorDebtNo, int offset, int limit)
        {
            var company = HttpContext.Session.GetString("Company");
            //แปลงค่าnull
            contractorDebtNo ??= "";

            var query = _allcarContext.allcarModels
                        .FromSqlInterpolated($"EXEC ALLCAR {detailID},{company},{contractorDebtNo}")
                        .ToList();

            return Json(query);
        }
        public IActionResult companycar(string detailID)
        {
            var company = HttpContext.Session.GetString("Company");

            var query = _companycarContext.companycarModels
                        .FromSqlInterpolated($"EXEC companycar {detailID},{company}")
                        .ToList();

            return Json(query);
        }
        [HttpGet]
        public IActionResult Oildebt(string vendorCode, string Fromdate)
        {
            var company = HttpContext.Session.GetString("Company");

            var query = _oildebtContext.OildebtModels
                        .FromSqlInterpolated($"EXEC Oildebt {company},{vendorCode},{Fromdate}")
                        .ToList();

            return Json(query);
        }
        [HttpGet]
        public IActionResult dmgebt(string vendorCode, string Fromdate)
        {
            var company = HttpContext.Session.GetString("Company");

            var query = _dmgebtContext.dmgebtModels
                        .FromSqlInterpolated($"EXEC dmgebt {company},{vendorCode},{Fromdate}")
                        .ToList();

            return Json(query);
        }
        [HttpPost]
        public IActionResult SaveCsvToServer([FromBody] CsvRequest data)
        {
            if (data == null || string.IsNullOrEmpty(data.CsvData) || string.IsNullOrEmpty(data.FileName))
            {
                return BadRequest("Invalid data");
            }

            //string directoryPath = @"\\192.168.10.2\ERPAutoDMT\UAT2\BPI ReturnMisc\Input";
            // กำหนดเส้นทางไฟล์
            string directoryPath = @"\\192.168.10.2\ERPAutoDMT\Live\BPI APInvCombine\Input";
            //string directoryPath = @"C:\Users\USER069\Desktop\ทดสอบ_savecsv";

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(data.FileName);
            string fileExtension = Path.GetExtension(data.FileName);
            int fileIndex = 1;

            string filePath = Path.Combine(directoryPath, data.FileName);

            // ถ้าไฟล์มีอยู่แล้ว ให้เพิ่ม (1), (2), ... ที่ชื่อไฟล์
            while (System.IO.File.Exists(filePath))
            {
                string newFileName = $"{fileNameWithoutExtension}({fileIndex}){fileExtension}";
                filePath = Path.Combine(directoryPath, newFileName);
                fileIndex++;
            }

            try
            {
                // ตรวจสอบอีกครั้งก่อนเขียนไฟล์
                if (!System.IO.File.Exists(filePath))
                {
                    System.IO.File.WriteAllText(filePath, data.CsvData);
                }
                else
                {
                    return Conflict(new { message = "File already exists after name check." });
                }

                return Ok(new { message = "File saved successfully!", filePath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error saving file: {ex.Message}");
            }
        }
        [HttpGet]
        public IActionResult CheckAPInvHeadVendor(string APInvID)
        {
            try
            {
                // สร้าง connection string สำหรับการเชื่อมต่อฐานข้อมูล
                string connectionString = _connectionString; // แทนที่ด้วย connection string ของคุณ

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // สร้าง SQL Query ที่ใช้ในการตรวจสอบ
                    string query = "SELECT COUNT(*) AS SUM FROM dbo.APInvHeadVendor WHERE APInvNO = @APInvID";

                    // สร้าง SqlCommand
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // เพิ่มพารามิเตอร์ APInvID
                        cmd.Parameters.AddWithValue("@APInvID", APInvID);

                        // รันคำสั่ง SQL และรับค่าผลลัพธ์
                        int rowCount = (int)cmd.ExecuteScalar();

                        // ส่งผลลัพธ์กลับไปว่าเจอข้อมูลหรือไม่
                        return Json(new { exists = rowCount > 0 });
                    }
                }
            }
            catch (Exception ex)
            {
                // จัดการข้อผิดพลาดหากเกิดขึ้น
                return StatusCode(500, new { message = "เกิดข้อผิดพลาดในการตรวจสอบข้อมูล" });
            }
        }

     

        [HttpPost]
        public IActionResult SaveDocument([FromBody] DocumentModel model)
        {
            var company = HttpContext.Session.GetString("Company");
            var user = HttpContext.Session.GetString("Username");

            var comCheck = company switch
            {
                "BPI" => "BAPV",
                "SAC" => "SAPV",
                "S145" => "WAPV"
            };
            var getId = _pigContext.UserRights
                       .Where(u => u.UserName == user)
                       .Select(u => u.UserId)
                       .SingleOrDefault();
            DateTime nowDate = DateTime.Now;
            var convDate = nowDate.ToString("yyMM", CultureInfo.InvariantCulture);
            var connectionString = _connectionString; // ใช้ค่าจาก appsettings.json

            string docId;
            string GroupID;
            var latestDocId = _BpiTrpaymentContext.ApinvHeadVendors
                .Where(d => d.Company == company && d.CreateDate.Year == nowDate.Year && d.CreateDate.Month == nowDate.Month)
                .OrderByDescending(d => d.ApinvNo)
                .Select(d => d.ApinvNo)
                .FirstOrDefault();


            int running = 1;
            if (latestDocId != null)
            {
                var latestRunning = latestDocId.Substring(9); // แก้จาก 6 เป็น 9
                running = int.Parse(latestRunning) + 1;
            }

            docId = comCheck + convDate + running.ToString("D5"); // ใช้ D4 แทน D5
            GroupID = convDate + running.ToString("D3"); // ใช้ D4 แทน D5


            string insertApinvHeadQuery = @"
        INSERT INTO dbo.APInvHeadVendor (ApinvNo, Company, ApinvDate, BillId, ApinvAmt, WHTAmt, 
                                                         CustIDFuel,CustIDFuelBal, CustIDDamage, CustIDDamageBal, FuelAmt, DamageAmt, 
                                                         PayDay, APInvStatus, CreateBy, CreateDate,FiscalYear,FiscalPeriod,VendorCode)

        VALUES(@ApinvNo, @Company, @ApinvDate, @BillId, @ApinvAmt, @WHTAmt, 
                     @CusIDFuel, @CusIDFuelBal, @CusIDDamange, @CusIDDamangeBal, 
                     @FuelAmt, @DmgAmt, @PayDate, @APInvStatus, @Username, @CreateDate,@FiscalYear,@FiscalPeriod,@VendorCode);
        ";

            string insertApinvDetailsQuery = @"
        INSERT INTO dbo.APInvDetailVendor (Company, Apinvid, DetailID, 
                                                        NetWeight,ShipRateType, ShipRate,ShipAmt,Distance,Compensate,ShipViaCode,
                                                        OilPrice,DiffPrice,Remark,DetailStatus,CreateDate,CreateBy)

        VALUES (@Company, @Apinvid,  @DetaiID, @NetWeight, @RateType,
                @ShipRate,@ShipAmt,@Distance,@Compensate,@ShipViaCode,@OilPrice,@DiffPrice,@Remark,@DetailStatus,@CreateDate,@CreateBy);
    ";
            string updateBillingNoteDQuery = @"
            UPDATE dbo.BillingNoteD
            SET DetailStatus = 1
            WHERE DetailID = @DetailID;
        ";

            // ตรวจสอบว่า BillID ใน BillingNoteD ยังมีแถวที่ DetailStatus != 1 หรือไม่
            string checkRemainingDetailsQuery = @"
            SELECT COUNT(*) 
            FROM dbo.BillingNoteD
            WHERE BillID = @BillID AND DetailStatus != 1;
        ";

            // อัปเดต BillingNoteH.Status เป็น 1 หรือ 2 ตามเงื่อนไข
            string updateBillingNoteHQuery = @"
            UPDATE dbo.BillingNoteH
            SET DocStatus = @NewStatus
            WHERE BillID = @BillID;
        ";
            int apinvId = 0; // ประกาศตัวแปรที่จุดเริ่มต้น
            int FiscalYear = 0;
            int FiscalPeriod = 0;
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Insert ลง APInvHead

                    using (var command = new SqlCommand(insertApinvHeadQuery + " SELECT SCOPE_IDENTITY();", connection))
                    {
                        command.Parameters.AddWithValue("@ApinvNo", docId);
                        command.Parameters.AddWithValue("@Company", company);
                        command.Parameters.AddWithValue("@ApinvDate", model.ContractorBillingDate);
                        command.Parameters.AddWithValue("@BillId", model.BillID);
                        command.Parameters.AddWithValue("@CarType", model.Cartype);
                        command.Parameters.AddWithValue("@ApinvAmt", model.Input10);
                        command.Parameters.AddWithValue("@WHTAmt", model.Input7);
                        command.Parameters.AddWithValue("@CusIDFuel", model.CustID);
                        command.Parameters.AddWithValue("@CusIDFuelBal", model.Oildebt);
                        command.Parameters.AddWithValue("@FuelAmt", model.Input8);
                        command.Parameters.AddWithValue("@CusIDDamange", model.CustIDdmg);
                        command.Parameters.AddWithValue("@CusIDDamangeBal", model.Lossdebtor);
                        command.Parameters.AddWithValue("@DmgAmt", model.Input9);
                        command.Parameters.AddWithValue("@PayDate", model.ContractorPayDate);
                        command.Parameters.AddWithValue("@APInvStatus", 0);
                        command.Parameters.AddWithValue("@Username", getId);
                        command.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                        command.Parameters.AddWithValue("@VendorCode", model.ContractorCreditor);

                        if (model.StartDateCarAll.HasValue)
                        {
                            DateTime startDateCarAll = model.StartDateCarAll.Value;
                            command.Parameters.AddWithValue("@FiscalYear", startDateCarAll.Year);
                            command.Parameters.AddWithValue("@FiscalPeriod", startDateCarAll.Month);
                            FiscalYear = startDateCarAll.Year;
                            FiscalPeriod = startDateCarAll.Month;
                        }

                        // ExecuteScalar() ใช้สำหรับดึงค่าจาก SCOPE_IDENTITY()
                        apinvId = Convert.ToInt32(command.ExecuteScalar());

                    }

                    foreach (var debtDetails in model.DebtDetails)
                    {
                        using (var command = new SqlCommand(insertApinvDetailsQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Company", company);
                            command.Parameters.AddWithValue("@Apinvid", apinvId); // ใช้ค่า APInvID ที่เพิ่งได้มา
                            command.Parameters.AddWithValue("@DetaiID", debtDetails.DetailID);
                            command.Parameters.AddWithValue("@NetWeight", debtDetails.NetWeight);
                            command.Parameters.AddWithValue("@ShipRate", debtDetails.TransportRate);
                            command.Parameters.AddWithValue("@Remark", debtDetails.Remark);
                            command.Parameters.AddWithValue("@RateType", debtDetails.RateType);
                            command.Parameters.AddWithValue("@ShipAmt", debtDetails.TotalAmount);
                            command.Parameters.AddWithValue("@Distance", debtDetails.Distance);
                            command.Parameters.AddWithValue("@Compensate", debtDetails.Compensation == "ชดเชย" ? 1 : 0);
                            command.Parameters.AddWithValue("@ShipViaCode", debtDetails.ShipViaCode);
                            command.Parameters.AddWithValue("@OilPrice", debtDetails.FuelPrice);
                            command.Parameters.AddWithValue("@DiffPrice", debtDetails.Difference);
                            command.Parameters.AddWithValue("@DetailStatus", 0);
                            command.Parameters.AddWithValue("@CreateDate", DateTime.Now);
                            command.Parameters.AddWithValue("@CreateBy", getId);

                            command.ExecuteNonQuery();
                        }

                        // อัปเดต DetailStatus เป็น 1 ใน BillingNoteD
                        using (var updateCommand = new SqlCommand(updateBillingNoteDQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@DetailID", debtDetails.DetailID);
                            updateCommand.ExecuteNonQuery();
                        }
                    }

                    // 🔵 ตรวจสอบว่า BillID ยังมีแถวที่ DetailStatus != 1 หรือไม่
                    int remainingDetails;
                    using (var checkCommand = new SqlCommand(checkRemainingDetailsQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@BillID", model.BillID);
                        remainingDetails = (int)checkCommand.ExecuteScalar();
                    }

                    //// 🔵 อัปเดต Status ใน BillingNoteH
                    int newStatus = remainingDetails == 0 ? 3 : 2;
                    using (var updateHCommand = new SqlCommand(updateBillingNoteHQuery, connection))
                    {
                        updateHCommand.Parameters.AddWithValue("@NewStatus", newStatus);
                        updateHCommand.Parameters.AddWithValue("@BillID", model.BillID);
                        updateHCommand.ExecuteNonQuery();
                    }


                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return Json(new { success = false, message = ex.Message });
                }
            }

            return Json(new
            {
                success = true,
                data = docId,
                    ApinvNo = docId,
                    VendorCode = model.ContractorCreditor,
                    Company = company,
                    ApinvDate = model.ContractorBillingDate,
                    TermsCode = "N07",
                    GroupID   = GroupID,
                    FiscalYear = FiscalYear,
                    FiscalPeriod = FiscalPeriod,
                    EntryPerson = "auto-dmt",
                    InvoiceAmt = "",
                    DocinvoiceAmt = model.Input6,
                    DocinvoiceVendorAmt = model.Input6,
                    Description = "ค่าขนส่งเสาเข็ม",
                    CurrencyCode = "THB",
                    RateGrpCode = "MAIN",
                    TaxRegionCode = "VT07",
                    ApinvDtlCompany = company,
                    APInvDtlInvoiceLine = "1",
                    APInvDtlLineType = "M",
                    ApinvDtlUnitCost = model.Input6,
                    APInvDtlPartNum = "6TR2001",
                    APInvDtlDescription = "ค่าจ้างขนส่ง-รถร่วม",
                    APInvDtlVendorQty = "1",
                    APInvDtlPUM = "JOB",
                    APInvDtlOurQty = "1",
                    APInvDtlIUM = "JOB",
                    ApinvDtlExtCost = model.Input6,
                    ApinvDtlDocExtCost = model.Input6,

            });
        }

    }

}
