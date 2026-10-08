using Telly.Models;

namespace Telly.Services
{
    public interface ITellyService
    {
        List<Brand> GetAllBrands();
        List<Dimension> GetAllDimensions();
        List<Tv> GetAllTvs(string? searchString);
        List<Tv> GetFilteredTvs(string? searchString, List<int>? selectedBrands, List<int>? selectedSizes, decimal? minPrice, decimal? maxPrice);
        List<Tvaccessory> GetAllAccessories();
    }
}