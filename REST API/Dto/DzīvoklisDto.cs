namespace REST_API.Dto
{
    public class DzīvoklisDto
    {
        public int Id { get; set; }
        public int Numurs { get; set; }
        public int Stavs { get; set; }
        public int Istabu_skaits { get; set; }
        public int Iedzivotaju_skaits { get; set; }
        public double Pilna_platiba { get; set; }
        public double Dzivojama_platiba { get; set; }
        public int MājaId { get; set; }
    }
}
