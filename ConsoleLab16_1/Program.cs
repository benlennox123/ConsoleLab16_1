using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace ConsoleLab16_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = 1;
            Product[] newProduct = new Product[5];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Ввод данных продукта {0}", t++);
                newProduct[i] = new Product();
                Console.Write("Введите код продукта - ");
                newProduct[i].ProductCode = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите наименование продукта - ");
                newProduct[i].ProductName = Convert.ToString(Console.ReadLine());
                Console.Write("Введите стоимость продукта - ");
                newProduct[i].ProductPrice = Convert.ToDouble(Console.ReadLine());
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                //WriteIndented = true
            };
            string path = @"Test\Test.txt";
            using (File.Create(path))
            {

            }
            int p = 0;
            foreach (Product s in newProduct)
            {
                string JSONstring = JsonSerializer.Serialize(newProduct[p], options);
                Console.WriteLine(JSONstring);
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(JSONstring);
                }
                p++;
            }
            Console.WriteLine();
            Console.WriteLine("Для завершения нажмите любую клавишу");
            Console.ReadKey();
        }
    }

    class Product
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }
}
