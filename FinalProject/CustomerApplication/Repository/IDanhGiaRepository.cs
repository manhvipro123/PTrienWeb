using CustomerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApplication.Repository
{
    public interface IDanhGiaRepository
    {
        void createDanhGia(DanhGia danhgia);
        List<DanhGia> GetDanhGiaByMaSp(int MaSp);
        List<DanhGia> GetDanhGiaWithTenKh();
        List<DanhGia> getAllDanhGias();
    }
}
