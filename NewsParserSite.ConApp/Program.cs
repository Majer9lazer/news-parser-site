using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using NewsParserSite.Core.Implementation;
using NewsParserSite.Core.Interfaces;

namespace NewsParserSite.ConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IParser parser = new Parser();

            Green();
            Console.WriteLine("You are parsing : " + Parser.SiteUrl);
            White();

            Console.WriteLine("[1] - Parse first page");
            Console.WriteLine("[2] - Parse pages to ... ");
            Console.WriteLine("[3] - Parse pages from 2 to ...");
            Console.WriteLine("[4] - Exit");
            bool parseResult = int.TryParse(Console.ReadLine(), out int choice);

            if (parseResult)
            {
                try
                {
                    switch (choice)
                    {

                        case 1:
                            {
                                Console.WriteLine("Started...\n Wait fo ending process");
                                parser.Run();
                                break;
                            }
                        case 2:
                            {
                                Console.Write("To : ");
                                int to = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                                Console.WriteLine("Started...\n Wait fo ending process");
                                parser.BulkInsertRange(to);
                                break;
                            }
                        case 3:
                            {
                                Console.Write("From : ");
                                int from = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                                Console.Write("To : ");
                                int to = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
                                Console.WriteLine("Started...\n Wait fo ending process");
                                parser.BulkInsertRange(from, to);
                                break;
                            }
                        case 4:
                            {
                                Green();
                                Console.WriteLine("Ok. Bye");
                                White();
                                break;
                            }
                    }
                    Green();
                    Console.WriteLine("Finished successfully");
                    White();
                }
                catch (Exception e)
                {
                    Red();
                    Console.WriteLine(e);
                    White();
                }

            }
            else
            {
                Red();
                Console.WriteLine("You entered something wrong. Try again.");
                White();
            }

            Console.WriteLine("Process finished");

            Console.Read();
        }

        private static void Red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        private static void Green()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        private static void White()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
