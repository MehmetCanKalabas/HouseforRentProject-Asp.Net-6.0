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

        public async Task<Villa> GetByID(int id)
        {
            Villa? villa = await _context.Villas.FindAsync(id);
            return villa;
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

        public async Task<Villa> UpdateVilla(Villa model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public bool DeleteVilla(int id)
        {
            try
            {
                using (Context context = new Context())
                {
                    Villa villa = context.Villas.FirstOrDefault(x => x.VillaID == id);
                    context.Remove(villa);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
