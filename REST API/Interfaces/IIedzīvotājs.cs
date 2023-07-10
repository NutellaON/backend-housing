using REST_API.Models;

namespace REST_API.Interfaces
{
    public interface IIedzīvotājs
    {
        ICollection<Iedzīvotājs> GetIedzīvotāji();
        Iedzīvotājs GetIedzīvotājs(int id);
        ICollection<Iedzīvotājs> GetIedzīvotājusByDzivoklisId(int dzivoklis);

        bool IedzīovtājsExists(int id);
        bool CreateIedzīvotājs(int dzivoklis,Iedzīvotājs Iedzīvotājs);
        bool UpdateIedzīvotājs(Iedzīvotājs Iedzivotājs);
        bool DeleteIedzīvotājs(Iedzīvotājs Iedzivotājs);
        bool save();
    }
}
