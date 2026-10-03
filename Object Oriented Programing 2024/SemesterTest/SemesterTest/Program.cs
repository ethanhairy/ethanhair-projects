using System;
namespace SemesterTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Sales sales;

            Batch batch1;
            Batch batch2;
            Batch batch3;

            Transaction trans1;
            Transaction trans2;
            Transaction trans3;
            Transaction trans4;
            Transaction trans5;

            sales = new Sales();

            batch1 = new Batch("#0001", "Books of Science");
            batch2 = new Batch("#04000", "Books of Electronics");
            batch3 = new Batch("#3202", "More Books");

            trans1 = new Transaction("#123", "Physics", 15.70m);
            trans2 = new Transaction("#167", "Biology", 23.40m);
            trans3 = new Transaction("#014", "Glass Making", 143.25m);
            trans4 = new Transaction("#198", "Woodworking", 184.00m);
            trans5 = new Transaction("#018", "Mathematics", 19.00m);

            sales.Add(batch1);
            sales.Add(batch2);
            sales.Add(trans3);
            sales.Add(trans4);

            batch1.Add(trans1);
            batch1.Add(trans2);
            batch1.Add(batch3);
            batch3.Add(trans5);

            Console.WriteLine("Press key to Print Order");
            Console.ReadLine();
            sales.PrintOrders();
            Console.ReadLine();
        }
    }
}