using Microsoft.EntityFrameworkCore;
using REST_API.Data;
using REST_API.Interfaces;
using REST_API.Models;

namespace REST_API.Repository
{
    public class DzīvoklisRepository : IDzīvoklis
    {
        private readonly DataContext _context;
        public DzīvoklisRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateDzīvoklis(int iedzivotajs, Dzīvoklis dzivoklis)
        {
            var iedzīvotājSDzīvoklisEntity = _context.Iedzīvotāji.Where(i => i.Id == iedzivotajs).FirstOrDefault();

            var iedzīvotājsDzīvoklis = new IedzīvotājiDzīvokļi()
            {
                Dzīvoklis = dzivoklis,
                Iedzīvotājs = iedzīvotājSDzīvoklisEntity,
            };
            _context.Add(iedzīvotājsDzīvoklis);

            _context.Add(dzivoklis);

            return save();
        }

        public bool DeleteDzīvoklis(Dzīvoklis dzīvoklis)
        {
            _context.Remove(dzīvoklis);
            return save();
        }

        public bool DzīvoklisExists(int id)
        {
            return _context.Dzīvokļi.Any(d=>d.Id == id);
        }

        public Dzīvoklis GetDzīvoklis(int id)
        {
            return _context.Dzīvokļi.Where(d => d.Id == id).FirstOrDefault();
        }

        public Dzīvoklis GetDzīvoklisAndMaja(int majaid)
        {
            return _context.Dzīvokļi.Include(d => d.Māja).FirstOrDefault(d => d.MājaId == majaid);
        }

        public ICollection<Dzīvoklis> GetDzīvokļus()
        {
            return _context.Dzīvokļi.OrderBy(m => m.Id).ToList();
        }

        public ICollection<Dzīvoklis> GetDzīvokļusByMajaId(int majaid)
        {
            return _context.Dzīvokļi.Where(d => d.MājaId == majaid).ToList();
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateDzīvoklis(Dzīvoklis dzivoklis)
        {
            _context.Update(dzivoklis);
            return save();
        }
    }
}
