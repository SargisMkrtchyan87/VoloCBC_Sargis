using EventsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var hp = new Printer();
            var ca = new Printer("Canon");

            hp.PrintStarted += Hp_PrintStarted;
            hp.PrintFinished += Hp_PrintFinished;
            hp.Printing += Hp_Printing;
            hp.PrintFailed += Hp_PrintFailed;
            ca.PrintStarted += Ca_PrintStarted;
            ca.PrintFinished += Ca_PrintFinished;
            ca.Printing += Ca_Printing;
            ca.PrintFailed += Ca_PrintFailed;


            try
            {
                hp.AddPapers(4);
                hp.Print(2);
                hp.Print(3);
                ca.AddPapers(10);
                ca.Print(6);
                ca.Print(2);
            }
            catch (ArgumentOutOfRangeException exception)
            {
                Console.WriteLine($"Opps! Wront argument {exception.ParamName}.{Environment.NewLine}Message: {exception.Message}");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.ReadKey();
            }

        }

        private static void Ca_PrintFailed(object sender, PrintFailedEventArgs e)
        {
            var printer = sender as Printer;
            Console.WriteLine($"{printer?.Name} Print failed. Remaining {e.RemainingPages} pages");
        }

        private static void Ca_Printing(object sender, PrintingEventArgs e)
        {
            var printer = sender as Printer;
            Console.WriteLine($"{printer?.Name} Printing page N{e.CurrentPage}");
        }

        private static void Ca_PrintFinished(object sender, EventArgs e)
        {
            var printer = sender as Printer;
            Console.WriteLine($"{printer?.Name} Print Finished");
        }

        private static void Ca_PrintStarted(object sender, EventArgs e)
        {
            var printer = sender as Printer;
            Console.WriteLine($"{printer?.Name} Print Started");
        }

        private static void Hp_PrintFailed(object sender, PrintFailedEventArgs e)
        {
            var printer = sender as Printer;
            Console.WriteLine($"{printer?.Name} Print failed. Remaining {e.RemainingPages} pages");
        }

        private static void Hp_Printing(object sender, PrintingEventArgs e)
        {
            var printer = sender as Printer;
            Console.WriteLine($"{printer?.Name} Printing page N{e.CurrentPage}");
        }

        private static void Hp_PrintFinished(object sender, EventArgs e)
        {
            var printer = sender as Printer;
            Console.WriteLine($"{printer?.Name} Print Finished");
        }

        private static void Hp_PrintStarted(object sender, EventArgs e)
        {
            var printer = sender as Printer;
            Console.WriteLine($"{printer?.Name} Print Started");
        }
    }
}
