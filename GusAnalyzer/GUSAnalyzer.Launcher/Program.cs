using System;
using System.Dynamic;
using System.Linq;
using System.Threading;
using ClassLibrary.Implementations;

namespace GUSAnalyzer.Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var tercanalyzer = new TERCAnalyzer();
            var data1 = tercanalyzer.GetVoivodeships(@"D:\test\TERC_Urzedowy_2017-11-03.xml").ToList();
            var data2 = tercanalyzer.GetTownships(@"D:\test\TERC_Urzedowy_2017-11-03.xml").ToList();
            var data3 = tercanalyzer.GetBoroughs(@"D:\test\TERC_Urzedowy_2017-11-03.xml").ToList();
            var data4 = tercanalyzer.GetData(@"D:\test\TERC_Urzedowy_2017-11-03.xml");
            Console.WriteLine();
            
            
        }
    }
}