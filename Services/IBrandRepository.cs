using MAS_Final_Music_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAS_Final_Music_Store.Services
{
    public interface IBrandRepository
    {
        List<Brand> GetAllBrands();
        Brand GetBrandById(int id);
        Brand CreateBrand(Brand brand);
        Brand UpdateBrand(int id, Brand brand);
        bool RemoveBrand(int id);
    }
}
