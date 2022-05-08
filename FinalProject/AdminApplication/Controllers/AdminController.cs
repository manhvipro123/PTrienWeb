using Microsoft.AspNetCore.Mvc;
using AdminApplication.Models;

namespace AdminApplication.Controllers
{
    
    public class AdminController : Controller
    {
        StoreContext ctx = new StoreContext();
        public IActionResult Index()
        {
            return View();
        }

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

        //Product
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
    }

   
}
