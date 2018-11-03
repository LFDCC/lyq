using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lyq.Console1
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                int result = 0;
                for (int i = 1; i <= 100; i++)
                {
                    if (i % 3 == 0 || i % 4 == 0)
                    {
                        result += i;
                    }
                }
                Console.WriteLine("for："+result);
            }
            {
                int result = 0;
                int i = 0;
                while (true)
                {
                    i++;
                    if (i % 3 == 0 || i % 4 == 0)
                    {
                        result += i;
                    }
                    if (i == 100) { break; }
                }
                Console.WriteLine("while：" + result);
            }

            {
                int starNo = 7;
                for (int i = starNo; i > 0; i--)
                {
                    if (i % 2 > 0)
                    {
                        var f = (starNo - i) / 2;
                        for (int s = 0; s < f; s++)
                        {
                            Console.Write(" ");
                        }
                        for (int j = 0; j < i; j++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine();
                    }
                }
                for (int i = 1; i <= starNo; i++)
                {
                    if (i % 2 > 0 && i != 1)
                    {
                        var f = (starNo - i) / 2;
                        for (int s = 0; s < f; s++)
                        {
                            Console.Write(" ");
                        }
                        for (int j = 0; j < i; j++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine();
                    }
                }
                Console.ReadKey();
            }

        }
    }
}
