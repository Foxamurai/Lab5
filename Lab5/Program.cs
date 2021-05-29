using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Queries queries = new Queries();

            queries.Q1(1000000, 5000000, "Советский");
            queries.Q2(4);
            queries.Q3(4);
            queries.Q4(2,"Советский");
            queries.Q5("Иванов");
            queries.Q6("Кировский");
            queries.Q7(2);
            queries.Q8("Первичное", "Иванов", "Безопасность");
            queries.Q9("Первичное", "20.04.2021", "30.04.2021");
            queries.Q10();
            queries.Q11("Первичное");
            queries.Q12(2);
            queries.Q13();
            queries.Q14("Кировский");
            queries.Q15("Кировский");
            queries.Q16("Иванов");
            queries.Q17("Иванов",2021);
            queries.Q18();
            queries.Q19(2021);
            queries.Q20();
        }
    }
}
