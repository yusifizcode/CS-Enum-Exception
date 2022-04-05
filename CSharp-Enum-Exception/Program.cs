using System;
using ClassLibrary;
namespace CSharp_Enum_Exception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Product product = new Product();
            //product.Name = "Pepsi";
            //product.Price = 1.1;
            //product.Type = ProductType.Icki;
            //Product product1 = new Product();
            //product1.Name = "Corek";
            //product1.Price = 0.6;
            //product1.Type = ProductType.Qida;
            //Store oba = new Store();
            //oba.AddProduct(product);
            //oba.AddProduct(product1);
            //foreach (var item in oba.Products)
            //{
            //    Console.WriteLine(item.Name);
            //}
            //Console.WriteLine("=========After remove product=========");
            //foreach (var item in oba.RemoveProductByNo(1))
            //{
            //    Console.WriteLine(item.Name);
            //}
            //Console.WriteLine("========Filter Products by Type========");

            //foreach(var item in oba.FilterProductsByType(ProductType.Icki))
            //{
            //    Console.WriteLine(item.Name);
            //}
            //Console.WriteLine("========Filter Products by Name========");
            //foreach (var item in oba.FilterProductByName("e"))
            //{
            //    Console.WriteLine(item.Name);
            //}
            char answer = ' ';
            Store bravo = new Store();

            do
            {

                Console.WriteLine("1. Mehsul elave et\n2. Mehsulun type-na gore filterle\n3.Butun mehsullari goster\n4.Mehsul sil\n0. Proqrami dayandir");
                string strAnswer = Console.ReadLine();
                answer = char.Parse(strAnswer);
                switch (answer)
                {
                    case '1':
                        string name = "";
                        do
                        {
                            Console.WriteLine("Mehsulun adini yazin: ");
                            name = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(name));

                        string strPrice = "";
                        double price;
                        do
                        {
                            Console.WriteLine("Mehsulun qiymetini daxil edin: ");
                            strPrice = Console.ReadLine();
                            
                        } while (!double.TryParse(strPrice,out price));

                        Console.WriteLine("Mehsul novleri:");
                        foreach (var item in Enum.GetValues(typeof(ProductType)))
                        {
                            Console.WriteLine((int)item + " - " + item);
                        }

                        string strVal = "";
                        int val;
                        do
                        {
                            Console.WriteLine("Mehsulun novunu sec:");
                            strVal = Console.ReadLine();
                        } while (!int.TryParse(strVal,out val));

                        while (!Enum.IsDefined(typeof(ProductType),val))
                        {
                            Console.WriteLine("Dogru secim edin!");
                            strVal = Console.ReadLine();
                            while (!int.TryParse(strVal,out val))
                            {
                                Console.WriteLine("Reqem daxil edin!");
                                strVal = Console.ReadLine();
                            }
                        }
                        
                        Product product = new Product();
                        product.Name = name;
                        product.Price = price;
                        product.Type = (ProductType)val;
                        bravo.AddProduct(product);
                        
                        break;
                    case '2':

                        Console.WriteLine("Mehsul novleri:");
                        foreach (var item in Enum.GetValues(typeof(ProductType)))
                        {
                            Console.WriteLine((int)item + " - " + item);
                        }

                        string strType = "";
                        int intType;
                        do
                        {
                            Console.WriteLine("Mehsulun novunu sec:");
                            strType = Console.ReadLine();
                        } while (!int.TryParse(strType, out intType));

                        while (!Enum.IsDefined(typeof(ProductType), intType))
                        {
                            Console.WriteLine("Dogru secim edin!");
                            strType = Console.ReadLine();
                            while (!int.TryParse(strType, out intType))
                            {
                                Console.WriteLine("Reqem daxil edin!");
                                strType = Console.ReadLine();
                            }
                        }
                        foreach (var item in bravo.FilterProductsByType((ProductType)intType))
                        {
                            Console.WriteLine(item.Name);
                        }
                        break;
                    case '3':
                        bravo.Show();
                        break;
                    case '4':
                        int intAns = 0;
                        string strAns = "";
                        do
                        {
                            Console.WriteLine("Silmek istediyiniz mehsulun nomresini daxil edin: ");
                            strAns = Console.ReadLine();
                        } while (!int.TryParse(strAns, out intAns));

                        bravo.RemoveProductByNo(intAns);
                        break;
                    default:
                        break;
                }
            } while (answer!='0');
        }
    }
}
