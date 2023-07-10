using Microsoft.EntityFrameworkCore;

namespace REST_API.Models
{
    public class Dzīvoklis
    {
        public int Id { get; set; }
        public int Numurs { get; set; }
        public int Stavs { get; set; }
        public int Istabu_skaits { get; set; }
        public int Iedzivotaju_skaits { get; set; }
        public double Pilna_platiba { get; set; }
        public double Dzivojama_platiba { get; set; }
        public int MājaId { get; set; }

        public Māja Māja { get; set; }
        public ICollection<IedzīvotājiDzīvokļi> IedzīvotājiDzīvokļi { get; set; }

    }
}
