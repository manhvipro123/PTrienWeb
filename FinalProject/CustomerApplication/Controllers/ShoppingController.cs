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
        /*[Route("api/cart/add")*/
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

            /*try
            {
                if (items != null)
                {
                    if (items.soluong > 0)
                    {
                        items.soluong = soluong.Value;
                    }
                }
            }*/
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
            var types = new List<SelectOption>();
            types.Add(new SelectOption() { Value = "COD", Text = "COD" });
            types.Add(new SelectOption() { Value = "Thẻ tín dụng", Text = "Thẻ tín dụng" });
            ViewBag.PartialTypes = types;
            
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
        public IActionResult ThanhToan(string s_name, string s_email, string s_phone, string s_pass, string s_dc, string s_dcg, string PhuongThucTt, string s_nh, string s_st)
        {
            var types = new List<SelectOption>();
            types.Add(new SelectOption() { Value = "COD", Text = "COD" });
            types.Add(new SelectOption() { Value = "Thẻ tín dụng", Text = "Thẻ tín dụng" });
            ViewBag.PartialTypes = types;
            
            DateTime now = DateTime.Now;
            
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

            //create user + khachhang + donhang + ctdh
            User u = new User()
            {
                Email = s_email,
                Password = s_pass,
                Name = s_name,
                Id = "U" + now.ToString("MMddyyyyHHmmsstt"),
            };
            KhachHang kh = new KhachHang()
            {
                TenKh = s_name,
                Sdt = s_phone,
                DiaChiKh = s_dc,
                UserId = "U" + now.ToString("MMddyyyyHHmmsstt"),
                Id = "KH" + now.ToString("MMddyyyyHHmmsstt"),
            };
            DonHang dh = new DonHang();
            dh.Id = "DH" + now.ToString("MMddyyyyHHmmsstt");
            dh.MaKh = "KH" + now.ToString("MMddyyyyHHmmsstt");
            if (PhuongThucTt == "Thẻ tín dụng")
            {
                
                dh.DiaChiGiao = s_dcg;
                dh.SoThe = s_st;
                dh.NganHangNhan = s_nh;
                dh.TongTien = tongTien;
                dh.PhuongThucTt = PhuongThucTt;
                dh.NgayLap = now;
               
                dh.TrangThaiDh = "Đang chuẩn bị hàng";            
            }
            else if(PhuongThucTt == "COD")
            {
                
                dh.DiaChiGiao = s_dcg;
                dh.SoThe = null;
                dh.NganHangNhan = null;
                dh.TongTien = tongTien;
                dh.PhuongThucTt = PhuongThucTt;
                dh.NgayLap = now;
           
                dh.TrangThaiDh = "Đang chuẩn bị hàng";
            }
           
            ChiTietDonHang ctdh = new ChiTietDonHang();
            foreach (ItemCart item in items)
            {
                ctdh.SoLuong = item.SoLuong;
                ctdh.MaSp = item.MaSp;
                ctdh.MaDh = "DH" + now.ToString("MMddyyyyHHmmsstt");
                ctx.ChiTietDonHangs.Add(ctdh);
            }
            ctx.Users.Add(u);
            ctx.KhachHangs.Add(kh);
            ctx.DonHangs.Add(dh);
            ctx.SaveChanges();

            return RedirectToAction("Index","Product");
        }
        
    }
}
