namespace REST_API.Models
{
    public class IedzīvotājiDzīvokļi
    {
        public int IedzivotajaID { get; set; }
        public int DzivoklaID { get; set; }
        public Iedzīvotājs Iedzīvotājs { get; set; }
        public Dzīvoklis Dzīvoklis { get; set; }

        
    }
}
