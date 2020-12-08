using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /* char[] charsToTrim = { '*', ' ', '\'' };
             string banner = "*** Much Ado About Nothing ***";
             string result = banner.Trim(charsToTrim);
             Console.WriteLine("Trimmmed\n   {0}\nto\n   '{1}'", banner, result);
            */

            char[] smb = {'h', 'w', '*' };
            string text = " hwhwh ************Hello*** World!";
            string text1 = text.Trim(smb);
            Console.WriteLine(text1) ;
            Console.ReadKey();
        }
    }
}
