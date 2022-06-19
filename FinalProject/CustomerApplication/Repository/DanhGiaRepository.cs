using CustomerApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace CustomerApplication.Repository
{
    public class DanhGiaRepository : IDanhGiaRepository
    {
        private StoreContext _ctx;
        public DanhGiaRepository()
        {

        }
        public DanhGiaRepository(StoreContext ctx)
        {
            _ctx = ctx; 
        }

        public void createDanhGia(DanhGia danhgia)
        {
            _ctx.DanhGias.Add(danhgia);
            _ctx.SaveChanges();
        }

        public List<DanhGia> getAllDanhGias()
        {
            return _ctx.DanhGias.Include(x => x.MaSpNavigation).ToList();
        }

        public List<DanhGia> GetDanhGiaByMaSp(int MaSp)
        {
           List<DanhGia> temp = new List<DanhGia>();
           foreach(DanhGia dg in _ctx.DanhGias)
            {
                if(dg.MaSp == MaSp)
                {
                    temp.Add(dg);
                }
            }
            return temp;
        }

        public List<DanhGia> GetDanhGiaWithTenKh()
        {   
           return  _ctx.DanhGias.Include(x => x.MaKhNavigation).ToList();
        }

    }
}
