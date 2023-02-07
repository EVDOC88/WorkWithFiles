using System.Runtime;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Напишите адрес папки для удаления!");
            string path = Console.ReadLine();
            
            Console.WriteLine($" Дирректория по указанному пути имеет размер : {ByteCount(path)} байт");
            Console.WriteLine($" Освобождено : {DeleteFunc(path)} байт");
            Console.WriteLine($" После очистки Дирректория по указанному пути имеет размер : {ByteCount(path)} байт");


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

        public static long DeleteFunc(string path)
        {
            var time = DateTime.Now - TimeSpan.FromMinutes(10);
            long size = 0;

            if (Directory.Exists(path)) // Проверим, что директория существует
            {
                    var di = new DirectoryInfo(path);        
            
                    foreach (FileInfo file in di.GetFiles())
                    {
                        if (di.LastAccessTime < time)
                        
                    {
                        size += file.Length;
                            file.Delete();
                        }
                       
                    }

                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        if (di.LastAccessTime < time)
                        {
                     
                        size += DeleteFunc(Convert.ToString(dir));
                        dir.Delete(true);
                        }
                        
                    }
                }

            return size;
        }

        }


    }

