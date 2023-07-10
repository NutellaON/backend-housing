using REST_API.Models;

namespace REST_API.Interfaces
{
    public interface IDzīvoklis
    {
        ICollection<Dzīvoklis> GetDzīvokļus();
        ICollection<Dzīvoklis> GetDzīvokļusByMajaId(int majaid);
        Dzīvoklis GetDzīvoklis(int id);
        Dzīvoklis GetDzīvoklisAndMaja(int majaid);

        bool DzīvoklisExists(int dzivoklisid);
        bool CreateDzīvoklis(int iedzivotajs, Dzīvoklis dzivoklis);
        bool UpdateDzīvoklis(Dzīvoklis dzivoklis);

        bool DeleteDzīvoklis(Dzīvoklis dzīvoklis);
        bool save();
    }
}
