using System.Collections;

namespace PortfolioMergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random zufallszahl = new Random();
            int anzahlZahlen = 100;
            int[] zahlen = new int[anzahlZahlen];

            for(int i = 0; i < anzahlZahlen; i++)
            {
                zahlen[i] = zufallszahl.Next(100);
            }

            Console.WriteLine("Nicht sortiert: ");
            PrintValues(zahlen);

            var start = DateTime.Now.TimeOfDay;
            zahlen = MergeSortAlgorithmus(zahlen);
            var ende = DateTime.Now.TimeOfDay;
            Console.WriteLine("Sortiert: ");
            PrintValues(zahlen);

            Console.WriteLine("Dauer = " + (ende - start).TotalMilliseconds);
        }

        static int[] MergeSortAlgorithmus(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int mitte = array.Length / 2;
            int[] linkeSeite = new int[mitte];
            int[] rechteSeite = new int[array.Length - mitte];

            for (int i = 0; i < linkeSeite.Length; i++)
            {
                linkeSeite[i] = array[i];
            }
            for (int i = 0; i < rechteSeite.Length; i++)
            {
                rechteSeite[i] = array[i + mitte];
            }

            linkeSeite = MergeSortAlgorithmus(linkeSeite);
            rechteSeite = MergeSortAlgorithmus(rechteSeite);
            array = ArraysVerbinden(linkeSeite, rechteSeite);

            return array;
        }

        static int[] ArraysVerbinden(int[] links, int[] rechts)
        {
            ArrayList array = new ArrayList();
            int linkerIndex = 0;
            int rechterIndex = 0;

            for (int i = 0; i < links.Length + rechts.Length; i++)
            {
                if (linkerIndex < links.Length)
                {
                    if (rechterIndex < rechts.Length)
                    {
                        if (links[linkerIndex] < rechts[rechterIndex])
                        {
                            array.Add(links[linkerIndex]);
                            linkerIndex++;
                            continue;
                        }
                    }

                }
                else
                {
                    array.Add(rechts[rechterIndex]);
                    rechterIndex++;
                    continue;
                }

                if (rechterIndex < rechts.Length)
                {
                    if (rechts[rechterIndex] < links[linkerIndex])
                    {
                        array.Add(rechts[rechterIndex]);
                        rechterIndex++;
                        continue;
                    }
                }
                else
                {
                    array.Add(links[linkerIndex]);
                    linkerIndex++;
                    continue;
                }

                if (links[linkerIndex] == rechts[rechterIndex])
                {
                    array.Add(links[linkerIndex]);
                    linkerIndex++;
                }

            }
            return (int[])array.ToArray(typeof(int));
        }
        static void PrintValues(int[] array)
        {
                foreach (int i in array)
                {
                    Console.Write(i + " ");
                }

                Console.Write("\n\n");
        }
    }
}




