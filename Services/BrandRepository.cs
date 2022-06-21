using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public class BrandRepository : IBrandRepository
    {
        private readonly Context _context;

        public BrandRepository(Context context)
        {
            _context = context;
        }

        public Brand CreateBrand(Brand brand)
        {
            var newBrand = new Brand
            {
                Name = brand.Name,
                YearEstablished = brand.YearEstablished,
                Logo = brand.Logo
            };

            _context.Brands.Add(newBrand);
            return newBrand;
        }

        public List<Brand> GetAllBrands()
        {
            return _context.Brands.ToList();
        }

        public Brand GetBrandById(int id)
        {
            return _context.Brands.Where(b => b.BrandId == id).FirstOrDefault();
        }

        public bool RemoveBrand(int id)
        {
            var brand = GetBrandById(id);
            if (brand is null)
            {
                return false;
            }

            _context.Brands.Remove(brand);
            _context.SaveChanges();
            return true;
        }

        public Brand UpdateBrand(int id, Brand brand)
        {
            var editedBrand = GetBrandById(id);
            if (editedBrand is null)
            {
                return null;
            }

            editedBrand.Name = brand.Name;
            editedBrand.YearEstablished = brand.YearEstablished;
            editedBrand.Logo = brand.Logo;

            _context.SaveChanges();

            return editedBrand;

        }
    }
}
