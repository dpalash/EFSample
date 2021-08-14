using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkTestDBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDBFirst context = new TestDBFirst();
            var encCells= context.EncCells.ToList();

            Console.ReadLine();
        }
    }
}
