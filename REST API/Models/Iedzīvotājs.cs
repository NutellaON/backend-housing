using Microsoft.EntityFrameworkCore;

namespace REST_API.Models
{
    public class Iedzīvotājs 
    {
        public int Id { get; set; }
        public string Vards { get; set; }
        public string Uzvards { get; set; }
        public string Personas_kods { get; set; }
        public DateTime Dzimsanas_datums { get; set; }
        public int Telefons { get; set; }
        public string Epasts { get; set; }
        public bool IsOwner { get; set; }
        public ICollection<IedzīvotājiDzīvokļi> IedzīvotājiDzīvokļi { get; set; }
    }
}
