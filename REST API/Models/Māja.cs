namespace REST_API.Models
{
    public class Māja 
    {
        public int Id { get; set; }
        public int Numurs { get; set; }
        public string Iela { get; set; }
        public string Pilseta { get; set; }
        public string Valsts { get; set; }
        public string Pasta_indekss { get; set; }
        public ICollection<Dzīvoklis> Dzīvokļi { get; set; }
    }
}
