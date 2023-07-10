using REST_API.Models;

namespace REST_API.Interfaces
{
    public interface IMāja
    {
        ICollection<Māja> GetMājas();
        Māja GetMāja(int id);
        bool MājaExists(int majaId);
        bool CreateMāja(Māja maja);
        bool UpdateMāja(Māja maja);
        bool DeleteMāja(Māja maja);
        bool save();

    }
}
