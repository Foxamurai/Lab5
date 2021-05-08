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

            Console.WriteLine(result);
        }

        public void Q5(string rieltorSurname)
        {
            var sales = context.Sales
                .Include(s => s.Realtor)
                .Where(s => s.Realtor.Surname == rieltorSurname);

            Console.WriteLine($"Минимум: {sales.Min(s => s.Price)} \n" +
                $"Максимум: {sales.Max(s => s.Price)}");
        }

        public void Q6(string districtName)
        {
            var result = context.Evaluations
                .Where(e => e.RealEstateObject.District.Name == districtName)
                .Average(x => x.EvaluationResult);

            Console.WriteLine(result);
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

            foreach (var item in result)
            {
                Console.WriteLine($"{item.district}: {item.count}");
            }
        }

        public void Q8(string reoType, string rieltorSurname, string evalCriteria)
        {
            var sales = context.Sales
                .Where(s => s.Realtor.Surname == rieltorSurname)
                .Where(s => s.RealEstateObject.RealEstateType.Name == reoType)
                .Include(x => x.RealEstateObject);
             //   .Select(s => s.RealEstateObject.Evaluations
             //       .Where(e => e.EvaluationCriteria.Name == evalCriteria));
               



            foreach (var item in sales)
            {
                Console.WriteLine(item);
            }
            
        }
    }
}