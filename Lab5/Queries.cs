using Lab5.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Queries
    {
        AppDbContext context;
        public Queries()
        {
            context = new AppDbContext();
        }

        public void Q1(double startPrice, double endPrice, string districtName)
        {
            var result = context.RealEstateObjects.Include(reo => reo.District)
                .Where(reo => reo.District.Name == districtName & reo.Price >= startPrice & reo.Price <= endPrice);

            Console.WriteLine("Q1");
            foreach (var item in result)
            {
                Console.WriteLine($"Адрес: {item.Address} \n" +
                    $"Площадь: {item.Area} м^2 \n" +
                    $"Этаж: {item.Floor} \n\n");
            }
        }

        public void Q2(int roomsNumber)
        {
            var result = context.Sales
                .Include(s => s.RealEstateObject)
                .Where(x => x.RealEstateObject.RoomsNumber == roomsNumber)
                .Select(x => x.Realtor.Surname + " " + x.Realtor.Name + " " + x.Realtor.Patronymic);

            Console.WriteLine("Q2");
            foreach (var item in result)
            {
                Console.WriteLine(item + "\n");
                Console.WriteLine("\n\n");
            }
        }

        public void Q3(int floor)
        {
            var result = context.Sales
                .Include(s => s.RealEstateObject)
                .Where(x => x.RealEstateObject.Floor == floor)
                .Select(x => new
                {
                    Address = x.RealEstateObject.Address,
                    Difference = x.RealEstateObject.Price - x.Price,
                    Rieltor = x.Realtor.getFullName()
                });

            Console.WriteLine("Q3");
            foreach (var item in result)
            {
                Console.WriteLine($"Адрес: {item.Address} \n" +
                    $"Разница: {item.Difference} \n" +
                    $"Риелтор: {item.Rieltor} \n\n");
            }
        }

        public void Q4(int roomsNumber, string districtName)
        {
            var result = context.RealEstateObjects
                .Include(reo => reo.District)
                .Where(reo => reo.District.Name == districtName & reo.RoomsNumber == roomsNumber)
                .Sum(x => x.Price);

            Console.WriteLine("Q4");
            Console.WriteLine(result + "\n\n");
        }

        public void Q5(string rieltorSurname)
        {
            var sales = context.Sales
                .Include(s => s.Realtor)
                .Where(s => s.Realtor.Surname == rieltorSurname);

            Console.WriteLine("Q5");
            Console.WriteLine($"Минимум: {sales.Min(s => s.Price)} \n" +
                $"Максимум: {sales.Max(s => s.Price)} \n\n");
        }

        public void Q6(string districtName)
        {
            var result = context.Evaluations
                .Where(e => e.RealEstateObject.District.Name == districtName)
                .Average(x => x.EvaluationResult);

            Console.WriteLine("Q6");
            Console.WriteLine(result + "\n\n");
        }

        public void Q7(int floor)
        {
            var result = context.RealEstateObjects
                .Where(reo => reo.Floor == floor)
                .GroupBy(reo => reo.District.Name)
                .Select(x => new
                {
                    district = x.Key,
                    count = x.Count()
                });

            Console.WriteLine("Q7");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.district}: {item.count}");
            }
            Console.WriteLine("\n\n");
        }

        //TO-DO
        public void Q8(string reoType, string rieltorSurname, string evalCriteria)
        {
            var sales = context.Sales
                .Where(s => s.Realtor.Surname == rieltorSurname)
                .Where(s => s.RealEstateObject.RealEstateType.Name == reoType);

            Console.WriteLine("Q8");
            foreach (var item in sales)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n\n");
        }

        public void Q9(string reoType, String starDate, String endDate)
        {
            DateTime sd = DateTime.Parse(starDate);
            DateTime ed = DateTime.Parse(endDate);
            var result = context.Sales
                .Where(x => x.RealEstateObject.RealEstateType.Name == reoType)
                .Where(x => x.SaleDate >= sd & x.SaleDate <= ed)
                .Select(x => new
                {
                    priceForSqrMeter = x.Price/x.RealEstateObject.Area
                }).Average(x => x.priceForSqrMeter);

            Console.WriteLine("Q9");
            Console.WriteLine(Math.Round(result,2) + "\n\n");

        }

        public void Q10()
        {
            var result = context.Realtors
                .Select(x => new
                {
                    realtor = x.getFullName(),
                    salesCounter = x.Sales.Count(),
                    salesSum = x.Sales.Sum(x => x. Price)
                });


            Console.WriteLine("Q10");
            foreach (var item in result)
            {
                string line = item.realtor + " - ";
                if (item.salesCounter > 0)
                {
                    line += (item.salesCounter * item.salesSum * 0.05) / 100 * 87;
                }
                else
                {
                    line += "остался без премии";
                }
                line += "\n";
                Console.WriteLine(line);                
            }

            Console.WriteLine("\n\n");

        }

        public void Q11(string reoType)
        {
            var result = context.Realtors
                .Select(x => new 
                {
                    realtor = x.getFullName(),
                    salesCounter = x.Sales.Count(x => x.RealEstateObject.RealEstateType.Name == reoType)
                });

            Console.WriteLine("Q11");
            foreach (var item in result)
            {
                Console.WriteLine(item.realtor + " - " + item.salesCounter + "\n");
            }
            Console.WriteLine("\n\n");
        }

        public void Q12(int floor)
        {
            var result = context.RealEstateObjects
                .Where(x => x.Floor == floor)
                .GroupBy(x => x.BuildingMaterial.Name)
                .Select(x => new
                {
                    material = x.Key,
                    avg = x.Select(x => x).Average(x => x.Price)
                });

            Console.WriteLine("Q12");
            
            foreach (var item in result)
            {
                Console.WriteLine(item.material + " - " + item.avg + "\n");
            }
            Console.WriteLine("\n\n");
        }

        public void Q13()
        {
            var result = context.RealEstateObjects
                .Select(x => x)
                .AsEnumerable()
                .GroupBy(x => x.DistrictId)
                .Select(x => new 
                { 
                    district = context.Districts.First(y => y.Id == x.Key).Name,
                    reos = x.Select(x => x).OrderByDescending(x => x.Price).ThenBy(x => x.Floor).Take(3)
                });

            Console.WriteLine("Q13");
            foreach (var item in result)
            {
                Console.WriteLine(item.district);
                foreach (var reo in item.reos)
                {
                    Console.WriteLine($"\t{reo.Address}, {reo.Price}, {reo.Floor}\n");
                }
                
            }
            Console.WriteLine("\n");
        }

        public void Q14(string districtName) 
        {
            var result = context.RealEstateObjects
                .Where(x => x.Status == true & x.District.Name == districtName)
                .Select(x => x.Address);

            Console.WriteLine("Q14");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");
        }

        public void Q15(string districtName) 
        {
            var result = context.Sales
                .Where(x => x.RealEstateObject.District.Name == districtName)
                .Where(x => Math.Abs(x.Price - x.RealEstateObject.Price) <= x.RealEstateObject.Price / 100 * 80)
                .Select(x => new 
                {
                    address = x.RealEstateObject.Address,
                    district = x.RealEstateObject.District.Name
                });

            Console.WriteLine("Q15");
            foreach (var item in result)
            {
                Console.WriteLine(item.address + " - " + item.district);
            }
            Console.WriteLine("\n");
        }

        public void Q16(string rielstorSurname)
        {
            var result = context.Sales
                .Where(x => x.Realtor.Surname == rielstorSurname)
                .Where(x => (x.RealEstateObject.Price - x.Price) > 100000)
                .Select(x => new
                {
                    address = x.RealEstateObject.Address,
                    district = x.RealEstateObject.District.Name
                });

            Console.WriteLine("Q16");
            foreach (var item in result)
            {
                Console.WriteLine(item.address + " - " + item.district);
            }
            Console.WriteLine("\n");

        }

        public void Q17(string rielstorSurname, int year)
        {
            var result = context.Sales
                .Where(x => x.Realtor.Surname == rielstorSurname)
                .Where(x => x.SaleDate.Year == year)
                .Select(x => new 
                {
                    address = x.RealEstateObject.Address,
                    diff = (x.Price / x.RealEstateObject.Price - 1) * 100
                });
            Console.WriteLine("Q17");
            foreach (var item in result)
            {
                Console.WriteLine(item.address + " : " + Math.Round(item.diff,2) + "%\n");
            }
            Console.WriteLine("\n");
        }

        public void Q18()
        {
            var distrGrouping = context.RealEstateObjects
                .AsEnumerable()
                .GroupBy(x => x.District.Name);


            Console.WriteLine("Q18");
            foreach (var item in distrGrouping)
            {
                Console.WriteLine(item.Key);

                var avgPrice = item.Select(x => x.Price / x.Area).Average();

                var result = item.Where(x => (x.Price / x.Area) < avgPrice);

                foreach (var reo in result)
                {
                    Console.WriteLine("\t" + reo.Address);
                }
            }
            Console.WriteLine("\n");
        }

        public void Q19(int year)
        {
            var result = context.Realtors
                .Where(x => x.Sales.Where(y => y.SaleDate.Year == year).Count() == 0);

            Console.WriteLine("Q19");
            foreach (var item in result)
            {
                Console.WriteLine(item.getFullName());
            }
            Console.WriteLine();
        }

        public void Q20() 
        {
            var distrGrouping = context.RealEstateObjects
                .Where(x => (x.AdDate.Month - DateTime.Today.Month) <= 4)
                .AsEnumerable()
                .GroupBy(x => x.District.Name);


            Console.WriteLine("Q20");
            foreach (var item in distrGrouping)
            {
                Console.WriteLine(item.Key);

                var avgPrice = item.Select(x => x.Price / x.Area).Average();

                var result = item.Where(x => (x.Price / x.Area) < avgPrice);

                foreach (var reo in result)
                {
                    Console.WriteLine("\t" + reo.Address + " : " + reo.Status);
                }
            }
            Console.WriteLine("\n");
        }
    }
}