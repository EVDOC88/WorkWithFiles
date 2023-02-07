using System.Drawing;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Напишите адрес папки для подсчета!");
            string path = Console.ReadLine();
            Console.WriteLine($" Дирректория по указанному пути имеет размер : {ByteCount(path)} байт");
            
        }

        public static long ByteCount(string path)
        {
            long size = 0;
            try
            {

                if (Directory.Exists(path))
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(path);
                    // Размер файлов
                    FileInfo[] file = dirInfo.GetFiles();
                    foreach (FileInfo fi in file)
                    {
                        size += fi.Length;

                    }
                    // Размер поддирректорий
                    DirectoryInfo[] ddir = dirInfo.GetDirectories();
                    foreach (DirectoryInfo di in ddir)
                    {
                        // Рекурсия 
                        size += ByteCount(Convert.ToString(di));

                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return size;

        }
      
    }
}