namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           


        }

        public static void DeleteFunc()
        {
            var time = DateTime.Now - TimeSpan.FromMinutes(30);
            Console.WriteLine("Напишите адрес папки для удаления!");
            string path = Console.ReadLine();

            if (Directory.Exists(path)) // Проверим, что директория существует
            {
                Console.WriteLine(" По данному адресу будут удалены :");
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(path);  // Получим все директории из адреса

                foreach (string d in dirs) // Выведем их все
                    Console.WriteLine(d);

                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(path);// Получим все файлы  из адреса

                foreach (string s in files)   // Выведем их все
                    Console.WriteLine(s);
                Console.WriteLine("Подвердите удаление? Да или Нет");
                string approve = Console.ReadLine();
                if (approve == "Да")
                {

                    var di = new DirectoryInfo(path);
                    foreach (FileInfo file in di.GetFiles())
                    {
                        if (di.LastAccessTime < time)
                        {
                            file.Delete();
                        }
                        else { Console.WriteLine("Ничего из файлов не удалено"); }
                    }

                    foreach (DirectoryInfo dir in di.GetDirectories())
                    {
                        if (di.LastAccessTime < time)
                        {
                            dir.Delete(true);
                        }
                        else { Console.WriteLine("Ничего из папок не удалено"); }
                    }
                }
                else { Console.WriteLine("Отмена удаления"); }

            }
            else
            {
                Console.WriteLine($"Такого адреса {path} не существует");
            }

        }


    }
}
