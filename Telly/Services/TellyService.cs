using Microsoft.EntityFrameworkCore;
using Telly.Data;
using Telly.Models;

namespace Telly.Services
{
    public class TellyService : ITellyService
    {
        private readonly TellyDbContext _context; // Assuming your DbContext is named this or similar

        public TellyService(TellyDbContext context)
        {
            _context = context;
        }

        public List<Brand> GetAllBrands() => _context.Brands.ToList();

        public List<Dimension> GetAllDimensions() => _context.Dimensions.ToList();

        public List<Tv> GetAllTvs(string? searchString)
        {
            var query = _context.Tvs.Include(t => t.Brand).Include(t => t.Dimension).AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(t => t.Tvname.Contains(searchString));
            }
            return query.ToList();
        }

        public List<Tv> GetFilteredTvs(string? searchString, List<int>? selectedBrands, List<int>? selectedSizes, decimal? minPrice, decimal? maxPrice)
        {
            var query = _context.Tvs.Include(t => t.Brand).Include(t => t.Dimension).AsQueryable();

            // 1. Filter by search keyword if provided
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(t => t.Tvname.Contains(searchString));
            }

            // 2. Filter by selected brands checkboxes
            if (selectedBrands != null && selectedBrands.Any())
            {
                query = query.Where(t => t.BrandId.HasValue && selectedBrands.Contains(t.BrandId.Value));
            }

            // 3. Filter by selected sizes checkboxes
            if (selectedSizes != null && selectedSizes.Any())
            {
                query = query.Where(t => t.DimensionId.HasValue && selectedSizes.Contains(t.DimensionId.Value));
            }

            // 4. Filter by max price range slider
            if (maxPrice.HasValue)
            {
                query = query.Where(t => t.Price <= (double)maxPrice.Value);
            }

            return query.ToList();
        }

        public List<Tvaccessory> GetAllAccessories() => _context.Tvaccessories.ToList();
    }
}