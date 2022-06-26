using Microsoft.AspNetCore.Mvc;
using CustomerApplication.Repository;
using CustomerApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApplication.Controllers
{
    public class ProductController : Controller
    {
        ICategoryRepository categoryRepository = new CategoryRepository();
        StoreContext ctx = new StoreContext();
       
        public IActionResult Index()
        {
            List<SanPham> lst = categoryRepository.getAllSanPhams();
            return View(lst);
        }
        public IActionResult Filter(int id)
        {
            List<SanPham> sp = ctx.SanPhams.Where(x => x.Goi == id).ToList();
            return View(sp);
        }

        public IActionResult Details (int masp)
        {
            SanPham sp = ctx.SanPhams.Where(x => x.MaSp == masp).FirstOrDefault();
            List<DanhGia> lst = new List<DanhGia>();
           /* DanhGiaRepository danhGiaRepository = new DanhGiaRepository(ctx);
            List<DanhGia> temp = danhGiaRepository.GetDanhGiaByMaSp(masp);
            ViewBag.khachhangs = danhGiaRepository.GetDanhGiaWithTenKh();
            foreach(DanhGia danhgia in ViewBag.khachhangs)
            {
                foreach(DanhGia dg in temp)
                {
                    if(dg.MaKh == danhgia.MaKhNavigation.MaKh)
                    {
                        lst.Add(danhgia); 
                    }
                }
            }
            ViewBag.danhgias = lst; */
            List<DanhGia> danhGiaList = ctx.DanhGias.Include(x => x.MaKhNavigation).Include(y => y.MaSpNavigation).ToList();
            foreach(DanhGia danhGia in danhGiaList)
            {
                if (danhGia.MaSp == sp.MaSp) { 
                    lst.Add(danhGia);
                }
            }
            ViewBag.danhgias = lst;
            return View(sp);
        }

    }
}
