using Microsoft.AspNetCore.Mvc;
using AdminApplication.Models;
using System.Linq;

namespace AdminApplication.Controllers
{

    public class AdminController : Controller
    {
        StoreContext ctx = new StoreContext();
        public IActionResult Index()
        {
            return View();
        }

        //==========================Product================================================
        public IActionResult GetAllProducts()
        {
            //select * from SanPham
            List<SanPham> sp = ctx.SanPhams.ToList();
            return View(sp);
        }
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveProduct(SanPham sp)
        {
            //insert db
            ctx.SanPhams.Add(sp);
            ctx.SaveChanges();
            return RedirectToAction("GetAllProducts");
        }

        public IActionResult DeleteProduct(int id)
        {
            //tim doi tuong co id
            //select * from sanpham where maSP = id 
            SanPham sp = ctx.SanPhams.Where(x => x.MaSp == id).SingleOrDefault();
            //xoa du lieu
            ctx.SanPhams.Remove(sp);
            ctx.SaveChanges();
            return RedirectToAction("GetAllProducts");
        }

        public IActionResult EditProduct(int id)
        {
            //tim doi tuong co id
            //select * from countries where CCategoryId = id 
            SanPham sp = ctx.SanPhams.Where(x => x.MaSp == id).SingleOrDefault();
            return View(sp);
        }

        [HttpPost]
        public IActionResult UpdateProduct(SanPham sp)
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
            }
            //cap nhat thong tin
            ctx.SaveChanges();
            return RedirectToAction("GetAllProducts");
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
        public IActionResult SaveCategory(DanhMuc dm)
        {
            //insert db
            ctx.DanhMucs.Add(dm);
            ctx.SaveChanges();
            return RedirectToAction("GetAllCategories");
        }

        public IActionResult DeleteCategory(int id)
        {
            //tim doi tuong co id
            //select * from DanhMuc where MaDm = id 
            DanhMuc dm = ctx.DanhMucs.Where(x => x.MaDm == id).SingleOrDefault();
            //xoa du lieu
            if(dm != null)
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
        public IActionResult UpdateCategory(DanhMuc dm)
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

        //========================================Customer 000 User 00 Rating =====================================

        //----------------------------------------------------GET---------------------------------------------------
        public IActionResult GetAllCustomers()
        {
            //select * from khachhang
            List<KhachHang> kh = ctx.KhachHangs.ToList();
            
            return View(kh);
        }
        public IActionResult GetAllCustomerRates(int id)
        {
            List<DanhGia> lst = new List<DanhGia> { };
            foreach(DanhGia d in ctx.DanhGias)
            {
                if(d.MaKh == id)
                {
                    lst.Add(d);
                }
            }
            return View(lst);
        }
        public IActionResult GetUserAccount(int id)
        {
            //select * from khachhang
            User u = ctx.Users.Where(x => x.UserId == id).SingleOrDefault();
            return View(u);
        }

        //--------------------------DELETE---------------------------------------------------------------------------//
        public IActionResult DeleteCustomer(int cId, int uId)
        {
            Console.Write(" " + cId + " " + uId);
            
            //tim doi tuong co id
            //select * from KhachHang where MaKh = id 
            KhachHang kh = ctx.KhachHangs.Where(x => x.MaKh == cId).SingleOrDefault();
            User u = ctx.Users.Where(x => x.UserId == uId).SingleOrDefault();
            DanhGia dg = ctx.DanhGias.Where(x => x.MaKh == cId).SingleOrDefault();
            //xoa du lieu

            ctx.DanhGias.Remove(dg);
            ctx.KhachHangs.Remove(kh);
            ctx.Users.Remove(u);
          
            ctx.SaveChanges();
            return RedirectToAction("GetAllCustomers");
        }

        public IActionResult DeleteRating(int id)
        {
            //tim doi tuong co id
            //select * from KhachHang where MaDg = id 
            DanhGia dg = ctx.DanhGias.Where(x => x.MaDg == id).SingleOrDefault();
            
            //xoa du lieu
            ctx.DanhGias.Remove(dg);
            ctx.SaveChanges();
            return View("GetAllCustomerRates", new { id = id});
        }

        //--------------------------EDIT----------------------------------------------------------------------//
        public IActionResult EditCustomer(int id)
        {
            //tim doi tuong co id
            //select * from KhachHnag where MaDm = id 
            KhachHang dm = ctx.KhachHangs.Where(x => x.MaKh == id).SingleOrDefault();
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
        public IActionResult UpdateCustomer(KhachHang kh) 
        { 
            //tim doi tuong co trong db tuong ung ma id
            KhachHang kh_indb = ctx.KhachHangs.Where(x => x.MaKh == kh.MaKh).SingleOrDefault();
            if (kh_indb != null)
            {
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
        public IActionResult UpdateUser(User u)
        {
            //tim doi tuong co trong db tuong ung ma cateid
            User u_indb = ctx.Users.Where(x => x.UserId == u.UserId).SingleOrDefault();
            if (u_indb != null)
            {
                u_indb.Name = u.Name;
                u_indb.Password = u.Password;
                u_indb.Email = u.Email;
            }
            //cap nhat thong tin
            ctx.SaveChanges();
            return RedirectToAction("GetUserAccount", new { id = u_indb.UserId });
        }
    }
}
