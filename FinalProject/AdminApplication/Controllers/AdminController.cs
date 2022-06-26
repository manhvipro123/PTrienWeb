using Microsoft.AspNetCore.Mvc;
using AdminApplication.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections;

namespace AdminApplication.Controllers
{
    public class AdminController : Controller
    {

        public Admin MainLayoutViewModel { get; set; }
        StoreContext ctx = new StoreContext();


        public IActionResult Index(int id)
        {
            this.MainLayoutViewModel = new Admin();
            foreach (Admin ad in ctx.Admins)
            {
                if (ad.UserAd == id)
                {
                    this.MainLayoutViewModel = ad;
                }
            }
            this.ViewData["MainLayoutViewModel"] = this.MainLayoutViewModel;
            return View(this.MainLayoutViewModel);
        }

        //==========================Product================================================
        public IActionResult GetAllProducts()
        {

            //select * from SanPham
            List<SanPham> sp = ctx.SanPhams.Include(x => x.MaDmNavigation).ToList();
            return View(sp);
        }
        public IActionResult AddProduct()
        {
            var sTypes = new List<SelectOption>();
            sTypes.Add(new SelectOption() { Value = "Tồn tại", Text = "Tồn tại" });
            sTypes.Add(new SelectOption() { Value = "Hết hàng", Text = "Hết hàng" });
            sTypes.Add(new SelectOption() { Value = "Ngưng bán", Text = "Ngưng bán" });
            ViewBag.PartialTypes_1 = sTypes;
            var pTypes = new List<SelectOption>();
            pTypes.Add(new SelectOption() { Value = "0", Text = "0" });
            pTypes.Add(new SelectOption() { Value = "3", Text = "3" });
            pTypes.Add(new SelectOption() { Value = "10", Text = "10" });
            pTypes.Add(new SelectOption() { Value = "12", Text = "12" });
            pTypes.Add(new SelectOption() { Value = "30", Text = "30" });
            ViewBag.PartialTypes_2 = pTypes;
            var dTypes = new List<SelectOption>();
            dTypes.Add(new SelectOption() { Value = "Bổ sung gel", Text = "Bổ sung gel" });
            dTypes.Add(new SelectOption() { Value = "Có gân và gai", Text = "Có gân và gai" });
            dTypes.Add(new SelectOption() { Value = "Có mùi vị", Text = "Có mùi vị" });
            dTypes.Add(new SelectOption() { Value = "Cơ bản", Text = "Cơ bản" });
            dTypes.Add(new SelectOption() { Value = "Gel có mùi", Text = "Gel có mùi" });
            dTypes.Add(new SelectOption() { Value = "Gel gốc nước", Text = "Gel gốc nước" });
            dTypes.Add(new SelectOption() { Value = "Kéo dài thời gian", Text = "Kéo dài thời gian" });
            dTypes.Add(new SelectOption() { Value = "Mỏng", Text = "Mỏng" });
            ViewBag.PartialTypes_3 = dTypes;

            List<DanhMuc> DanhMucs = ctx.DanhMucs.ToList();
            ViewBag.DanhMucs = DanhMucs;
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(SanPham sp)
        {
            //option forms
            var sTypes = new List<SelectOption>();
            sTypes.Add(new SelectOption() { Value = "Tồn tại", Text = "Tồn tại" });
            sTypes.Add(new SelectOption() { Value = "Hết hàng", Text = "Hết hàng" });
            sTypes.Add(new SelectOption() { Value = "Ngưng bán", Text = "Ngưng bán" });
            ViewBag.PartialTypes_1 = sTypes;
            var pTypes = new List<SelectOption>();
            pTypes.Add(new SelectOption() { Value = "0", Text = "0" });
            pTypes.Add(new SelectOption() { Value = "3", Text = "3" });
            pTypes.Add(new SelectOption() { Value = "10", Text = "10" });
            pTypes.Add(new SelectOption() { Value = "12", Text = "12" });
            pTypes.Add(new SelectOption() { Value = "30", Text = "30" });
            ViewBag.PartialTypes_2 = pTypes;
            var dTypes = new List<SelectOption>();
            dTypes.Add(new SelectOption() { Value = "Bổ sung gel", Text = "Bổ sung gel" });
            dTypes.Add(new SelectOption() { Value = "Có gân và gai", Text = "Có gân và gai" });
            dTypes.Add(new SelectOption() { Value = "Có mùi vị", Text = "Có mùi vị" });
            dTypes.Add(new SelectOption() { Value = "Cơ bản", Text = "Cơ bản" });
            dTypes.Add(new SelectOption() { Value = "Gel có mùi", Text = "Gel có mùi" });
            dTypes.Add(new SelectOption() { Value = "Gel gốc nước", Text = "Gel gốc nước" });
            dTypes.Add(new SelectOption() { Value = "Kéo dài thời gian", Text = "Kéo dài thời gian" });
            dTypes.Add(new SelectOption() { Value = "Mỏng", Text = "Mỏng" });
            ViewBag.PartialTypes_3 = dTypes;
            List<DanhMuc> DanhMucs = ctx.DanhMucs.ToList();
            ViewBag.DanhMucs = DanhMucs;

            try
            {
                /*Boolean check = false;*/
                //images url
                var formFile = Request.Form.Files[0];

                string rootPath = @"C:\Users\Admin\source\repos\manhvipro123\PTrienWeb\FinalProject\CustomerApplication\wwwroot\assets\images\";
                var fileName = formFile.FileName;
                string path = rootPath + fileName;
                string[] fileEntries = Directory.GetFiles(@"C:\Users\Admin\source\repos\manhvipro123\PTrienWeb\FinalProject\CustomerApplication\wwwroot\assets\images\");
              /*  if (System.IO.File.Exists(path))
                {
                    ModelState.AddModelError(string.Empty, "File name hình ảnh đã tồn tại");
                    return View(sp);
                }*/
              /*  foreach (string fName in fileEntries)
                {
                    if (fName == path)
                    {
                        check = true;
                        System.IO.File.Replace(fName, path, null);
                    }
                }*/

                var stream = System.IO.File.Create(path);
                formFile.CopyTo(stream);


                if (ModelState.IsValid)
                {

                    //check TenSp
                    SanPham spm = new SanPham()
                    {
                        MaDm = sp.MaDm,
                        TenSp = sp.TenSp,
                        Gia = sp.Gia,
                        SoLuong = sp.SoLuong,
                        MoTa = sp.MoTa,
                        NgayNhap = sp.NgayNhap,
                        TrangThai = sp.TrangThai,
                        HinhAnh = fileName,
                        Goi = sp.Goi,
                        DacDiem = sp.DacDiem,

                    };

                    SanPham sp_indb = ctx.SanPhams.Where(x => x.TenSp == sp.TenSp).SingleOrDefault();
                    if (sp_indb != null)
                    {
                        ModelState.AddModelError(string.Empty, "Tên sản phẩm đã tồn tại");
                        return View(sp);
                    }
                    else
                    {
                        //insert db
                        stream.Close();
                        ctx.SanPhams.Add(spm);
                        ctx.SaveChanges();
                        return RedirectToAction("GetAllProducts");
                    }
                }
                else
                {
                    return View(sp);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.ToString());
            }
            return View(sp);
        }

        public IActionResult DeleteProduct(int id)
        {
            //tim doi tuong co id
            //select * from sanpham where maSP = id 
            SanPham sp = ctx.SanPhams.Where(x => x.MaSp == id).SingleOrDefault();

            //xoa du lieu

            foreach (DanhGia d in ctx.DanhGias)
            {
                if (d.MaSp == id)
                {
                    ctx.DanhGias.Remove(d);
                }
            }
            ctx.SanPhams.Remove(sp);
            ctx.SaveChanges();
            return RedirectToAction("GetAllProducts");
        }

        public IActionResult EditProduct(int id)
        {
            var sTypes = new List<SelectOption>();
            sTypes.Add(new SelectOption() { Value = "Tồn tại", Text = "Tồn tại" });
            sTypes.Add(new SelectOption() { Value = "Hết hàng", Text = "Hết hàng" });
            sTypes.Add(new SelectOption() { Value = "Ngưng bán", Text = "Ngưng bán" });
            ViewBag.PartialTypes_1 = sTypes;
            var pTypes = new List<SelectOption>();
            pTypes.Add(new SelectOption() { Value = "0", Text = "0" });
            pTypes.Add(new SelectOption() { Value = "3", Text = "3" });
            pTypes.Add(new SelectOption() { Value = "10", Text = "10" });
            pTypes.Add(new SelectOption() { Value = "12", Text = "12" });
            pTypes.Add(new SelectOption() { Value = "30", Text = "30" });
            ViewBag.PartialTypes_2 = pTypes;
            var dTypes = new List<SelectOption>();
            dTypes.Add(new SelectOption() { Value = "Bổ sung gel", Text = "Bổ sung gel" });
            dTypes.Add(new SelectOption() { Value = "Có gân và gai", Text = "Có gân và gai" });
            dTypes.Add(new SelectOption() { Value = "Có mùi vị", Text = "Có mùi vị" });
            dTypes.Add(new SelectOption() { Value = "Cơ bản", Text = "Cơ bản" });
            dTypes.Add(new SelectOption() { Value = "Gel có mùi", Text = "Gel có mùi" });
            dTypes.Add(new SelectOption() { Value = "Gel gốc nước", Text = "Gel gốc nước" });
            dTypes.Add(new SelectOption() { Value = "Kéo dài thời gian", Text = "Kéo dài thời gian" });
            dTypes.Add(new SelectOption() { Value = "Mỏng", Text = "Mỏng" });
            ViewBag.PartialTypes_3 = dTypes;
            //tim doi tuong co id
            List<DanhMuc> DanhMucs = ctx.DanhMucs.ToList();
            ViewBag.DanhMucs = DanhMucs;
            SanPham sp = ctx.SanPhams.Where(x => x.MaSp == id).SingleOrDefault();
            return View(sp);
        }

        [HttpPost]
        public IActionResult EditProduct(SanPham sp)
        {
            var sTypes = new List<SelectOption>();
            sTypes.Add(new SelectOption() { Value = "Tồn tại", Text = "Tồn tại" });
            sTypes.Add(new SelectOption() { Value = "Hết hàng", Text = "Hết hàng" });
            sTypes.Add(new SelectOption() { Value = "Ngưng bán", Text = "Ngưng bán" });
            ViewBag.PartialTypes_1 = sTypes;
            var pTypes = new List<SelectOption>();
            pTypes.Add(new SelectOption() { Value = "0", Text = "0" });
            pTypes.Add(new SelectOption() { Value = "3", Text = "3" });
            pTypes.Add(new SelectOption() { Value = "10", Text = "10" });
            pTypes.Add(new SelectOption() { Value = "12", Text = "12" });
            pTypes.Add(new SelectOption() { Value = "30", Text = "30" });
            ViewBag.PartialTypes_2 = pTypes;
            var dTypes = new List<SelectOption>();
            dTypes.Add(new SelectOption() { Value = "Bổ sung gel", Text = "Bổ sung gel" });
            dTypes.Add(new SelectOption() { Value = "Có gân và gai", Text = "Có gân và gai" });
            dTypes.Add(new SelectOption() { Value = "Có mùi vị", Text = "Có mùi vị" });
            dTypes.Add(new SelectOption() { Value = "Cơ bản", Text = "Cơ bản" });
            dTypes.Add(new SelectOption() { Value = "Gel có mùi", Text = "Gel có mùi" });
            dTypes.Add(new SelectOption() { Value = "Gel gốc nước", Text = "Gel gốc nước" });
            dTypes.Add(new SelectOption() { Value = "Kéo dài thời gian", Text = "Kéo dài thời gian" });
            dTypes.Add(new SelectOption() { Value = "Mỏng", Text = "Mỏng" });
            ViewBag.PartialTypes_3 = dTypes;
            //tim doi tuong co id
            List<DanhMuc> DanhMucs = ctx.DanhMucs.ToList();
            ViewBag.DanhMucs = DanhMucs;
            try
            {      
                if(Request.Form.Files[0] != null)
                {
                    //images url
                    var formFile = Request.Form.Files[0];
                    string rootPath = @"C:\Users\Admin\source\repos\manhvipro123\PTrienWeb\FinalProject\CustomerApplication\wwwroot\assets\images\";
                    var fileName = formFile.FileName;
                    var path = rootPath + fileName;
                    /*  string[] fileEntries = Directory.GetFiles(@"C:\Users\Admin\source\repos\manhvipro123\PTrienWeb\FinalProject\CustomerApplication\wwwroot\assets\images\");*/
                    var stream = System.IO.File.Create(path);
                    formFile.CopyTo(stream);
                    if (ModelState.IsValid)
                    {

                        //tim doi tuong co trong db tuong ung ma cateid
                        SanPham sp_indb = ctx.SanPhams.Where(x => x.MaSp == sp.MaSp).SingleOrDefault();
                        if (sp_indb != null)
                        {
                            sp_indb.MaDm = sp.MaDm;
                            sp_indb.TenSp = sp.TenSp;
                            sp_indb.Gia = sp.Gia;
                            sp_indb.SoLuong = sp.SoLuong;
                            sp_indb.MoTa = sp.MoTa;
                            sp_indb.NgayNhap = sp.NgayNhap;
                            sp_indb.TrangThai = sp.TrangThai;
                            sp_indb.HinhAnh = fileName;
                            sp_indb.Goi = sp.Goi;
                            sp_indb.DacDiem = sp.DacDiem;
                        }
                        //cap nhat thong tin
                        stream.Close();
                        ctx.SaveChanges();
                        return RedirectToAction("GetAllProducts");
                    }else
                    {
                        return View();
                    }
                }
                else
                {
                    if (ModelState.IsValid)
                    {

                        //tim doi tuong co trong db tuong ung ma cateid
                        SanPham sp_indb = ctx.SanPhams.Where(x => x.MaSp == sp.MaSp).SingleOrDefault();
                        if (sp_indb != null)
                        {
                            sp_indb.MaDm = sp.MaDm;
                            sp_indb.TenSp = sp.TenSp;
                            sp_indb.Gia = sp.Gia;
                            sp_indb.SoLuong = sp.SoLuong;
                            sp_indb.MoTa = sp.MoTa;
                            sp_indb.NgayNhap = sp.NgayNhap;
                            sp_indb.TrangThai = sp.TrangThai;
                            sp_indb.HinhAnh = sp.HinhAnh;
                            sp_indb.Goi = sp.Goi;
                            sp_indb.DacDiem = sp.DacDiem;
                        }
                        //cap nhat thong tin
                        ctx.SaveChanges();
                        return RedirectToAction("GetAllProducts");
                    }
                    else
                    {
                        return View(sp);
                    }
                }
             
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.ToString());
            }
            return View(sp);


        }


        //========================================Category=====================================
        public IActionResult GetAllCategories()
        {
            //select * from DanhMuc
            List<DanhMuc> dm = ctx.DanhMucs.ToList();
            return View(dm);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(DanhMuc dm)
        {
            if (ModelState.IsValid)
            {
                //check tenDM
                DanhMuc d = ctx.DanhMucs.Where(x => x.TenDm == dm.TenDm).FirstOrDefault();
                if (d != null)
                {
                    ModelState.AddModelError(string.Empty, "Tên danh mục đã tồn tại");
                    return View(dm);
                }
                else
                {
                    //insert db
                    ctx.DanhMucs.Add(dm);
                    ctx.SaveChanges();
                    return RedirectToAction("GetAllCategories");
                }

            }
            else
            {
                return View(dm);
            }
        }

        public IActionResult DeleteCategory(int id)
        {
            //tim doi tuong co id
            //select * from DanhMuc where MaDm = id 
            DanhMuc dm = ctx.DanhMucs.Where(x => x.MaDm == id).SingleOrDefault();
            List<SanPham> prodLST = ctx.SanPhams.Where(x => x.MaDm == id).ToList();
            //xoa du lieu
            List<DanhGia> temp = new List<DanhGia>();
            foreach (SanPham pham in prodLST)
            {
                temp = ctx.DanhGias.Where(x => x.MaSp == pham.MaSp).ToList();
            }
            foreach (DanhGia gia in temp)
            {
                ctx.DanhGias.Remove(gia);
            }

            foreach (SanPham sp in prodLST)
            {
                ctx.SanPhams.Remove(sp);
            }
            //xoa du lieu
            if (dm != null)
            {
                ctx.DanhMucs.Remove(dm);
                ctx.SaveChanges();
            }
            return RedirectToAction("GetAllCategories");
        }

        public IActionResult EditCategory(int id)
        {

            //tim doi tuong co id
            //select * from DanhMuc where MaDm = id 
            DanhMuc dm = ctx.DanhMucs.Where(x => x.MaDm == id).SingleOrDefault();
            return View(dm);
        }

        [HttpPost]
        public IActionResult EditCategory(DanhMuc dm)
        {

            if (ModelState.IsValid)
            {
                //check tenDM
                DanhMuc d = ctx.DanhMucs.Where(x => x.TenDm == dm.TenDm).FirstOrDefault();
                if (d != null)
                {
                    ModelState.AddModelError(string.Empty, "Tên danh mục đã tồn tại hoặc trùng với tên danh mục ban đầu!");
                    return View(dm);
                }
                else
                {
                    //tim doi tuong co trong db tuong ung ma id
                    DanhMuc dm_indb = ctx.DanhMucs.Where(x => x.MaDm == dm.MaDm).SingleOrDefault();
                    if (dm_indb != null)
                    {
                        dm_indb.TenDm = dm.TenDm;
                    }
                    //cap nhat thong tin
                    ctx.SaveChanges();
                    return RedirectToAction("GetAllCategories");
                }

            }
            else
            {
                return View(dm);
            }
        }

        //========================================Customer 000 User 00 Rating =====================================

        //----------------------------------------------------GET---------------------------------------------------
        public IActionResult GetAllCustomers()
        {
            //select * from khachhang
            List<KhachHang> kh = ctx.KhachHangs.ToList();

            return View(kh);
        }
        public IActionResult GetAllCustomerRates(string id)
        {
            KhachHang kh = ctx.KhachHangs.Where(x => x.Id == id).SingleOrDefault();
            ViewBag.custName = kh.TenKh;
            List<DanhGia> lst = new List<DanhGia>();
            List<DanhGia> lst_tmp = ctx.DanhGias.Include(x => x.MaKhNavigation)
                .Include(y => y.MaSpNavigation).ToList();
            foreach (DanhGia d in lst_tmp)
            {
                if (d.MaKh == id)
                {
                    lst.Add(d);
                }
            }

            return View(lst);
        }
        public IActionResult GetAllProductRates(int id)
        {
            SanPham sp = ctx.SanPhams.Where(x => x.MaSp == id).SingleOrDefault();
            ViewBag.prodName = sp.TenSp;
            List<DanhGia> lst = new List<DanhGia>();
            List<DanhGia> lst_tmp = ctx.DanhGias.Include(x => x.MaKhNavigation)
             .Include(y => y.MaSpNavigation).ToList();
            foreach (DanhGia d in lst_tmp)
            {
                if (d.MaSp == id)
                {
                    lst.Add(d);
                }
            }

            return View(lst);


        }
        public IActionResult GetUserAccount(string id)
        {
            KhachHang kh_temp = new KhachHang();
            //select * from khachhang
            List<KhachHang> khs = ctx.KhachHangs.Include(x => x.User).ToList();
            foreach (KhachHang kh in khs)
            {
                if (kh.UserId == id)
                {
                    kh_temp = kh;
                }
            }
            return View(kh_temp);
        }

        //--------------------------DELETE---------------------------------------------------------------------------//
        public IActionResult DeleteCustomer(string cId, string uId)
        {
            //tim doi tuong co id
            //select * from KhachHang where MaKh = id 
            KhachHang kh = ctx.KhachHangs.Where(x => x.Id == cId).SingleOrDefault();
            User u = ctx.Users.Where(x => x.Id == uId).SingleOrDefault();

            //xoa du lieu
            foreach (DanhGia d in ctx.DanhGias)
            {
                if (d.MaKh == cId)
                {
                    ctx.DanhGias.Remove(d);
                }
            }
            ctx.KhachHangs.Remove(kh);
            ctx.Users.Remove(u);

            ctx.SaveChanges();
            return RedirectToAction("GetAllCustomers");
        }

        public IActionResult DeleteRatingByC(int id1, string id2)
        {
            //tim doi tuong co id
            //select * from DanhGia where MaDg = id1 
            DanhGia dg = ctx.DanhGias.Where(x => x.MaDg == id1).SingleOrDefault();

            //xoa du lieu
            ctx.DanhGias.Remove(dg);
            ctx.SaveChanges();
            return RedirectToAction("GetAllCustomerRates", new { id = id2 });
        }

        public IActionResult DeleteRatingByP(int id1, int id2)
        {
            //tim doi tuong co id
            //select * from KhachHang where MaDg = id 
            DanhGia dg = ctx.DanhGias.Where(x => x.MaDg == id1).SingleOrDefault();

            //xoa du lieu
            ctx.DanhGias.Remove(dg);
            ctx.SaveChanges();
            return RedirectToAction("GetAllProductRates", new { id = id2 });
        }

        //--------------------------EDIT----------------------------------------------------------------------//
        public IActionResult EditCustomer(string id)
        {
            //tim doi tuong co id
            //select * from KhachHnag where MaDm = id 
            KhachHang dm = ctx.KhachHangs.Where(x => x.Id == id).SingleOrDefault();
            return View(dm);
        }

        public IActionResult EditUser(int id)
        {
            //tim doi tuong co id
            //select * from User where MaDm = id 
            User u = ctx.Users.Where(x => x.UserId == id).SingleOrDefault();
            return View(u);
        }

        //-----------------------------------------------UPDATE-----------------------------------------------//
        [HttpPost]
        public IActionResult EditCustomer(KhachHang kh)
        {

            //tim doi tuong co trong db tuong ung ma id
            KhachHang kh_indb = ctx.KhachHangs.Where(x => x.MaKh == kh.MaKh).SingleOrDefault();
            if (kh_indb != null)
            {
                kh_indb.Id = kh.Id;
                kh_indb.TenKh = kh.TenKh;
                kh_indb.Sdt = kh.Sdt;
                kh_indb.DiaChiKh = kh.DiaChiKh;
                kh_indb.UserId = kh.UserId;
            }
            //cap nhat thong tin
            ctx.SaveChanges();
            return RedirectToAction("GetAllCustomers");


        }



        [HttpPost]
        public IActionResult EditUser(User u)
        {
            if (ModelState.IsValid)
            {
                //tim doi tuong co trong db tuong ung ma cateid
                User u_indb = ctx.Users.Where(x => x.UserId == u.UserId).SingleOrDefault();
                if (u_indb != null)
                {
                    u_indb.Password = u.Password;
                    u_indb.Email = u.Email;
                }
                //cap nhat thong tin
                ctx.SaveChanges();
                return RedirectToAction("GetUserAccount", new { id = u_indb.UserId });
            }
            else
            {
                return View(u);
            }

        }


        //-------------------------------------------------------BILL-----------------------------------------------------//

        //GET ALL BILLS
        public IActionResult GetAllBills()
        {
            //select * from DanhMuc
            List<DonHang> dh = ctx.DonHangs.Include(x => x.MaKhNavigation).ToList();
            return View(dh);
        }

        //EDIT AND UPDATE BILL
        [HttpGet]
        public IActionResult EditBill(int id)
        {
            var types = new List<SelectOption>();
            types.Add(new SelectOption() { Value = "Đang giao", Text = "Đang giao" });
            types.Add(new SelectOption() { Value = "Đã giao", Text = "Đã giao" });
            ViewBag.PartialTypes = types;
            //tim doi tuong co id
            DonHang dh = ctx.DonHangs.Where(x => x.MaDh == id).SingleOrDefault();
            return View(dh);
        }

        [HttpPost]
        public IActionResult SaveBill(DonHang dh)
        {
            //tim doi tuong co trong db tuong ung ma id
            DonHang dh_indb = ctx.DonHangs.Where(x => x.MaDh == dh.MaDh).SingleOrDefault();
            if (dh_indb != null)
            {
                dh_indb.TrangThaiDh = dh.TrangThaiDh;
                dh_indb.NgayGiao = dh.NgayGiao;
                dh_indb.NgayNhan = dh.NgayNhan;
            }
            //cap nhat thong tin
            ctx.SaveChanges();
            return RedirectToAction("GetAllBills");
        }

        //---------------------------------------------- BILL's DETAIL----------------------------------------------------------//

        public IActionResult GetBillDetail(string id)
        {
            List<ChiTietDonHang> lst_temp = ctx.ChiTietDonHangs.Include(x => x.MaDhNavigation).Include(y => y.MaSpNavigation).ToList();
            List<ChiTietDonHang> lst = new List<ChiTietDonHang> { };
            foreach (ChiTietDonHang ctdh in lst_temp)
            {
                if (ctdh.MaDh == id)
                {
                    lst.Add(ctdh);
                }
            }
            return View(lst);
        }

    }
}
