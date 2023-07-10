using AutoMapper;
using Microsoft.EntityFrameworkCore;
using REST_API.Data;
using REST_API.Interfaces;
using REST_API.Models;

namespace REST_API.Repository
{
    public class IedzīvotājsRepository : IIedzīvotājs
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public IedzīvotājsRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool CreateIedzīvotājs(int dzīvoklisId,Iedzīvotājs Iedzīvotājs)
        {
            var iedzīvotājSDzīvoklisEntity = _context.Dzīvokļi.Where(i => i.Id == dzīvoklisId).FirstOrDefault();

            var iedzīvotājsDzīvoklis = new IedzīvotājiDzīvokļi()
            {
                Iedzīvotājs = Iedzīvotājs,
                Dzīvoklis = iedzīvotājSDzīvoklisEntity,
            };
            _context.Add(iedzīvotājsDzīvoklis);

            _context.Add(Iedzīvotājs);

            return save();
        }

        public bool DeleteIedzīvotājs(Iedzīvotājs Iedzivotājs)
        {
            _context.Remove(Iedzivotājs);
            return save();
        }

        public ICollection<Iedzīvotājs> GetIedzīvotāji()
        {
            return _context.Iedzīvotāji.ToList();
        }

        public Iedzīvotājs GetIedzīvotājs(int id)
        {
            return _context.Iedzīvotāji.Where(i => i.Id == id).FirstOrDefault();
        }
        public ICollection<Iedzīvotājs> GetIedzīvotājusByDzivoklisId(int dzivoklisId)
        {
            return _context.Iedzīvotāji.Where(i => i.IedzīvotājiDzīvokļi.Any(d => d.DzivoklaID == dzivoklisId)).ToList();
        }
        public bool IedzīovtājsExists(int id)
        {
            return _context.Iedzīvotāji.Any(i => i.Id == id);
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateIedzīvotājs(Iedzīvotājs Iedzivotājs)
        {
            _context.Update(Iedzivotājs);
            return save();
        }
    }
}
