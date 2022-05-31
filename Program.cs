using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace laba3
{
  
    internal class Program
    {
        static void Main(string[] args)
        {
            string Apath = @"C:\Users\WelcOM\OneDrive\Рабочий стол\Lessons\С# LABS\laba3\laba3\bin\Debug\A.txt";
            string Bpath = @"C:\Users\WelcOM\OneDrive\Рабочий стол\Lessons\С# LABS\laba3\laba3\bin\Debug\B.txt";

            string[] AstringsStart = { };
            string[] BstringsStart = { };

            string[] Astrings = { };
            string[] Bstrings = { };

            try
            {
                using (StreamReader readerA = new StreamReader(Apath))
                {
                    AstringsStart = File.ReadAllLines(Apath);
                    Astrings = File.ReadAllLines(Apath);
                }

                using (StreamReader readerB = new StreamReader(Bpath))
                {
                    BstringsStart = File.ReadAllLines(Bpath);
                    Bstrings = File.ReadAllLines(Bpath);
                }
                if (AstringsStart.Length == 0 || BstringsStart.Length == 0)
                    throw new EmptyFileException("Ой... Какой-то из файлов оказался пустым.");
                Array.Sort(Astrings);
                Array.Sort(Bstrings);

                for (int i = 0; i < Astrings.Length; i++)
                {
                    if (Astrings[i] != AstringsStart[i])
                        throw new NotSortedFileA("Изначально слова в файле А не были расположены в лексикографическом порядке. Мы их перезапишем.");
                }
                for (int i = 0; i < Bstrings.Length; i++)
                {
                    if (Bstrings[i] != BstringsStart[i])
                        throw new NotSortedFileB("Изначально слова в файле B не были расположены в лексикографическом порядке. Мы их перезапишем.");
                }

                using (StreamWriter writerA = new StreamWriter(Apath, true))
                {
                    
                    writerA.WriteLine();
                    writerA.WriteLine("Повторяющиеся слова : ");
                    for (int i = 0; i < Astrings.Length; i++)
                    {
                        for (int j = 0; j < Bstrings.Length; j++)
                        {
                            if (Astrings[i] == Bstrings[j])
                                writerA.WriteLine(Astrings[i]);
                        }

                    }
                    Console.WriteLine("Программа выполнила работу успешно!");
                }


            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл A не был найден. Будет создан новый.");
                StreamWriter writer = new StreamWriter(Apath);
            }
            catch (EmptyFileException)
            {

            }
            catch (NotSortedFileA)
            {
                
                using (StreamWriter writerA = new StreamWriter(Apath, false))
                {
                    Console.WriteLine("Для файла А слова должны быть записаны как :");
                    for (int i = 0; i < Astrings.Length; i++)
                    {
                        Console.WriteLine(Astrings[i]);
                        writerA.WriteLine(Astrings[i]);
                    }
                }
            }
            catch (NotSortedFileB)
            {
                using (StreamWriter writerB = new StreamWriter(Bpath, false))
                {
                    Console.WriteLine("Для файла B слова должны быть записаны как :");
                    for (int i = 0; i < Bstrings.Length; i++)
                    {
                        Console.WriteLine(Bstrings[i]);
                        writerB.WriteLine(Bstrings[i]);
                    }
                }
            }
            finally
            {
                Console.WriteLine("Файлы закрыты");
            }


            Console.ReadKey();

        }
    }

    [Serializable]
    internal class EmptyFileException : Exception
    {
        public EmptyFileException()
        {
        }

        public EmptyFileException(string message) : base(message)
        {
            Console.WriteLine(message);
        }

        public EmptyFileException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyFileException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class NotSortedFileB : Exception
    {
        public NotSortedFileB()
        {
        }

        public NotSortedFileB(string message) : base(message)
        {
            Console.WriteLine(message);
        }

        public NotSortedFileB(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotSortedFileB(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class NotSortedFileA : Exception
    {
        public NotSortedFileA()
        {
        }

        public NotSortedFileA(string message) : base(message)
        {
            Console.WriteLine(message);
        }

        public NotSortedFileA(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotSortedFileA(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
