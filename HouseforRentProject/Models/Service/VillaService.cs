using HouseforRentProject.Models.Concrete;
using HouseforRentProject.Models.Entity;
using HouseforRentProject.Models.MVVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseforRentProject.Models.Service
{
    public class VillaService
    {
        private readonly Context _context;
        public VillaService(Context context)
        {
            _context = context;
        }

        public Villa GetByID(int id)
        {
            var values = _context.Villas.Find(id);
            return values;
        }

        public List<Villa> GetAll()
        {
            var all = _context.Villas.ToList();
            return all;
        }

        public async Task<Villa> AddVillas(Villa model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public void VillaUpdate(VillaUpdateViewModel model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }
    }
}
