
using AdminApplication.Models;

using Microsoft.EntityFrameworkCore;
namespace AdminApplication.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private StoreContext ctx = new StoreContext();
        public ReviewRepository(StoreContext contx)
        {
            ctx = contx;
        }

        List<DanhGia> IReviewRepository.getAllReViews()
        {
            return ctx.DanhGias.Include(x => x.MaKhNavigation).ToList();
        }

        List<DanhGia> IReviewRepository.getAllReViewsByProdID(int id)
        {
            throw new NotImplementedException();
        }

        DanhGia IReviewRepository.getDetails(int id)
        {
            throw new NotImplementedException();
        }
    }
}
