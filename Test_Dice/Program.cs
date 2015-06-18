using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoC.ChainSystem;

namespace Test_Dice
{
    class Program
    {
        static void Main(string[] args)
        {
            for (Int64 count = -2000; count <= 4000; count++) {
                for (Byte range = Byte.MinValue; range <= Byte.MaxValue; range++) {
                    
                        var d = new CoC.Dice(count, range);
                        d.ToString();
                    
                }
                Console.WriteLine(count);
            }
        }
    }
}
