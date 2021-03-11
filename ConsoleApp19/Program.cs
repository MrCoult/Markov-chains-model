using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectModelareEconomica
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti numarul de produse care urmeaza a fii studiate ");
            int n = int.Parse(Console.ReadLine());
            int i, a, j, f, m, k;
            var rand = new Random();
            int[,] x = new int[n, n];
            int[,] p = new int[n, n];
            int[] r = new int[n];
            a = 0;
            k = 0;

            for (i = 0; i < n; i++)
            {

                for (j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        Console.WriteLine("Introduceti procentul de fidelitate pentur produsul " + (i + 1));
                        x[i, j] = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        Console.WriteLine("Introduceti procentul in care cumparatori produsuli " + (i + 1) + " se orienteaza catre produsul " + (j + 1));
                        x[i, j] = int.Parse(Console.ReadLine());
                    }
                    a = a + x[i, j];
                }
                if (a != 100)
                {
                    i = i-1;
                    Console.WriteLine("Suma de pe linile matricei probabilitatilor trebuie sa fie egala 100% din cauza ca este diferita de 100% trebuie sa o rescrieti !!!");
                    a = 0;
                }
                else a = 0;
            }

            Console.Write("Matricea probabilitatilor este : ");
            for (i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (j = 0; j < n; j++)
                {
                    Console.Write(x[i, j] + "% ");
                }
            }

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (j == 0)
                    { p[i, j] = x[i, j]; }
                    else
                    {
                        p[i, j] = p[i, j - 1] + x[i, j];
                    }
                }
            }

            Console.WriteLine();
            Console.Write("Matricea probabilitatilor cumulate este : ");
            for (i = 0; i < n; i++)
            {
                Console.WriteLine();
                for (j = 0; j < n; j++)
                {
                    Console.Write(p[i, j] + "% ");
                }
            }

            Console.WriteLine();
            for (i = 0; i < n; i++)
            {
                Console.WriteLine("Intervalul de numere aleatorae pentru produsul " + (i + 1) + " este : ");
                for (j = 0; j < n; j++)
                {
                    if (j == 0)
                    {
                        Console.Write("[" + 0 + "; 0," + p[i, j] + ") ");
                    }
                    else if (j == n - 1)
                    {
                        Console.Write("[0," + p[i, j - 1] + "; 1) ");
                    }
                    else
                    {
                        Console.Write("[0," + p[i, j - 1] + "; 0," + p[i, j] + ") ");
                    }

                }
                Console.WriteLine();
            }

            Console.WriteLine("Introduceti numarul de teste pe care doriti sa le efectuati ");
            int t = int.Parse(Console.ReadLine());

            for (i = 0; i < n; i++)
            {
                for (f = 0; f < t; f++)
                {
                    m = rand.Next(1, 100);
                    Console.WriteLine((f + 1) + " numar generat este : 0," + m);
                    for (j = 0; j < n; j++)
                    {
                        if (m < p[i, j])
                        {
                            Console.WriteLine("Dupa realizarea testului cu numarul " + (f + 1) + " se obserava ca se cumpara produsul " + (j + 1));
                            r[j] = r[j] + 1;
                            i = j;
                            k = k + 1;
                            break;
                        }
                        else
                        {
                            j++;
                            if ((m > p[i, j - 1] && m < p[i, j]))
                            {
                                Console.WriteLine("Dupa realizarea testului cu numarul " + (f + 1) + " se obserava ca se cumpara produsul " + (j + 1));
                                r[j] = r[j] + 1;
                                i = j;
                                k = k + 1;
                                break;
                            }
                        }
                    }
                    if (k == t) break;
                }
                k = 0;
                a = 0;
                for (i = 0; i < n; i++)
                {
                    
                    Console.WriteLine("Dupa finalizare testelor se observa ca produsul " + (i + 1) + " are gradul de fidelitate " + r[i]);
                    if (k < r[i])
                    {
                        k = r[i];
                        a = i;
                    }
                }
                Console.WriteLine("Produsul cu cel mai mare grad de fidelitate este :" + (a+1));
                Console.ReadKey();
            }


        }
    }
}
