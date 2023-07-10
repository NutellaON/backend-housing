using REST_API.Data;
using REST_API.Models;

namespace REST_API
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            // Houses
            var houses = new[]
            {
                new Māja { Id = 1, Iela = "Ganibu", Numurs = 21, Pasta_indekss = "LV3007", Pilseta = "Riga", Valsts = "Latvija" },
                new Māja { Id = 2, Iela = "Zvejnieku", Numurs = 30, Pasta_indekss = "LV3011", Pilseta = "Jelgava", Valsts = "Latvija" }
            };
            dataContext.Mājas.AddRange(houses);

            // Apartments
            var apartments = new[]
            {
                new Dzīvoklis { Id = 1, Numurs = 21, Stavs = 6, Istabu_skaits = 4, Iedzivotaju_skaits = 4, Pilna_platiba = 65.21, Dzivojama_platiba = 60.51, MājaId = 1 },
                new Dzīvoklis { Id = 2, Numurs = 4, Stavs = 1, Istabu_skaits = 4, Iedzivotaju_skaits = 4, Pilna_platiba = 52.11, Dzivojama_platiba = 50.541, MājaId = 1 },
                new Dzīvoklis { Id = 3, Numurs = 32, Stavs = 2, Istabu_skaits = 3, Iedzivotaju_skaits = 4, Pilna_platiba = 47.44, Dzivojama_platiba = 44.43, MājaId = 1 },
                new Dzīvoklis { Id = 4, Numurs = 8, Stavs = 4, Istabu_skaits = 2, Iedzivotaju_skaits = 2, Pilna_platiba = 31.2, Dzivojama_platiba = 29.1, MājaId = 2 },
                new Dzīvoklis { Id = 5, Numurs = 16, Stavs = 9, Istabu_skaits = 1, Iedzivotaju_skaits = 1, Pilna_platiba = 25.21, Dzivojama_platiba = 24.4, MājaId = 2 }
            };
            dataContext.Dzīvokļi.AddRange(apartments);

            // Inhabitants
            var inhabitants = new[]
            {
                new Iedzīvotājs { Id = 1, Vards = "Jānis", Uzvards = "Bērzins", Personas_kods = "12412-220191", Dzimsanas_datums = new DateTime(1991, 01, 22), Telefons = 22132451, Epasts = "bob@inbox.lv" },
                new Iedzīvotājs { Id = 2, Vards = "Andris", Uzvards = "Zveja", Personas_kods = "12345-230292", Dzimsanas_datums = new DateTime(1992, 02, 23), Telefons = 24371234, Epasts = "testers@gmail.com" },
                new Iedzīvotājs { Id = 3, Vards = "Anna", Uzvards = "Liepa", Personas_kods = "58214-020599", Dzimsanas_datums = new DateTime(1999, 05, 02), Telefons = 24352357, Epasts = "programmetajs@inbox.lv" },
                new Iedzīvotājs { Id = 4, Vards = "Marija", Uzvards = "Modre", Personas_kods = "14561-111181", Dzimsanas_datums = new DateTime(1981, 11, 11), Telefons = 27545345, Epasts = "epastsepasts@inbox.lv" }
            };
            dataContext.Iedzīvotāji.AddRange(inhabitants);

            // Inhabitants-Apartments relationship
            var inhabitantsApartments = new[]
            {
                new IedzīvotājiDzīvokļi { DzivoklaID = 1, IedzivotajaID = 1 },
                new IedzīvotājiDzīvokļi { DzivoklaID = 1, IedzivotajaID = 3 },
                new IedzīvotājiDzīvokļi { DzivoklaID = 2, IedzivotajaID = 3 },
                new IedzīvotājiDzīvokļi { DzivoklaID = 3, IedzivotajaID = 4 },
                new IedzīvotājiDzīvokļi { DzivoklaID = 3, IedzivotajaID = 3 },
                new IedzīvotājiDzīvokļi { DzivoklaID = 4, IedzivotajaID = 1 },
                new IedzīvotājiDzīvokļi { DzivoklaID = 4, IedzivotajaID = 2 },
                new IedzīvotājiDzīvokļi { DzivoklaID = 5, IedzivotajaID = 4 }
            };
            dataContext.IedzīvotājiDzīvokļi.AddRange(inhabitantsApartments);

            dataContext.SaveChanges();
        }
    }
}
