using AdminApplication.Models;
namespace AdminApplication.Repository
{
    public interface IReviewRepository
    {
        List<DanhGia> getAllReViews();

        List<DanhGia> getAllReViewsByProdID(int id);

        DanhGia getDetails(int id);
    }
}
