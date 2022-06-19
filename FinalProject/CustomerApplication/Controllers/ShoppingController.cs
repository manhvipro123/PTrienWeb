using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using CustomerApplication.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
namespace CustomerApplication.Controllers
{
    public class ShoppingController : Controller
    {
        StoreContext ctx = new StoreContext();


        public IActionResult Index()
        {

            ViewBag.Title = "Shopping Cart";

            var id = HttpContext.Session.Id;

            // ViewBag.sessionMaSp = sessionMaSp;

            List<ItemCart> items = null;
            //doc sesion
            var giohang = HttpContext.Session.GetString("giohang");
            //chuyen tu chuoi json thanh object
            if (giohang != null)
            {
                items = (List<ItemCart>)JsonSerializer.Deserialize(giohang, typeof(List<ItemCart>));

            }
            else
            {
                items = new List<ItemCart>();
            }
            ViewBag.Cart = items;

            //tongtien
            decimal tongTien = 0;
            foreach (ItemCart item in items)
            {
                tongTien += item.Gia * item.SoLuong;
            }
            ViewBag.TongTien = tongTien;
            return View();

        }


        [HttpPost]
        public IActionResult AddToCart()
        {
            int masp = int.Parse(Request.Form["MaSp"].ToString());
            int soluong = int.Parse(Request.Form["Sl"].ToString());

            List<ItemCart> items = null;
            //doc sesion
            var giohang = HttpContext.Session.GetString("giohang");
            //chuyen tu chuoi json thanh object
            if (giohang != null)
            {
                items = (List<ItemCart>)JsonSerializer.Deserialize(giohang, typeof(List<ItemCart>));

            }
            else
            {
                items = new List<ItemCart>();
            }
            //tim san pham co trong db
            SanPham sanpham = ctx.SanPhams.Where(x => x.MaSp == masp).SingleOrDefault();
            //teo item trong gio hang
            ItemCart item = new ItemCart()
            {
                MaSp = masp,
                SoLuong = soluong,
                Image = sanpham.HinhAnh,
                Gia = (decimal)sanpham.Gia,
                TenSp = sanpham.TenSp,
            };
            //luu session
            items.Add(item);
            HttpContext.Session.SetString("giohang", JsonSerializer.Serialize(items, typeof(List<ItemCart>)));

            //if(HttpContext.Session.SetString("Giỏ hàng", ))
            //1. Doc thong tin gio hang trong session

            //1.1 gio hang chua co --> tao session --> bo hang vao gio

            //1.2 gio hang da ton tai
            //add item to cart*//**/
            return RedirectToAction("Index");
        }

    
        public IActionResult ThanhToan()
        {               
            List<ItemCart> items = null;
            var giohang = HttpContext.Session.GetString("giohang");
            //chuyen tu chuoi json thanh object
            if (giohang != null)
            {
                items = (List<ItemCart>)JsonSerializer.Deserialize(giohang, typeof(List<ItemCart>));

            }         
            ViewBag.Cart = items;

            //tongtien
            decimal tongTien = 0;
            foreach (ItemCart item in items)
            {
                tongTien += item.Gia * item.SoLuong;
            }
            ViewBag.TongTien = tongTien;
            return View();
        }

        [HttpPost]
        public IActionResult ThanhToan(string s_name, string s_email, string s_phone, string s_pass, string s_dc, string s_dcg, string s_ttd, string s_cod, string s_nh, string s_st)
        {
            List<ItemCart> items = null;
            var giohang = HttpContext.Session.GetString("giohang");
            //chuyen tu chuoi json thanh object
            if (giohang != null)
            {
                items = (List<ItemCart>)JsonSerializer.Deserialize(giohang, typeof(List<ItemCart>));

            }
            //tongtien
            decimal tongTien = 0;
            foreach (ItemCart item in items)
            {
                tongTien += item.Gia * item.SoLuong;
            }
            

            KhachHang kh = new KhachHang() 
            {
                TenKh = s_name,
                Sdt = s_phone,
                DiaChiKh = s_dc,
               
                
            };
            DonHang dh = new DonHang()
            {
                MaKh = 
            };
            ChiTietDonHang ctdh = new ChiTietDonHang();
            User u = new User() 
            {
                Email = s_email,
                Password = s_pass,
                Name = s_name,
            };

           
            

            return ViewBag(s_name,s_email,s_phone,s_pass,s_dc,s_dcg,s_ttd,s_cod,s_nh,s_st);
        }
        
    }
}
