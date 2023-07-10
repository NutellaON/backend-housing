using Microsoft.EntityFrameworkCore;
using REST_API.Data;
using REST_API.Interfaces;
using REST_API.Models;

namespace REST_API.Repository
{
    public class MājaRepository : IMāja
    {
        private readonly DataContext _context;

        public MājaRepository(DataContext context) 
        {
            _context = context;
        }

        public bool CreateMāja(Māja māja)
        {
            _context.Add(māja);
            return save();
        }

        public bool DeleteMāja(Māja maja)
        {
            _context.Remove(maja);
            return save();
        }

        public Māja GetMāja(int id)
        {
            return _context.Mājas.Where(p=>p.Id == id).FirstOrDefault();
        }

        public ICollection<Māja> GetMājas()
        {
            return _context.Mājas.OrderBy(m => m.Id).ToList();
        }

        public bool MājaExists(int majaId)
        {
            return _context.Mājas.Any(p=>p.Id == majaId);
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateMāja(Māja maja)
        {
            _context.Update(maja);
            return save();
        }
    }
}
