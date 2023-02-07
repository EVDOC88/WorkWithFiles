using System.Runtime.Serialization;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
#pragma warning disable SYSLIB0011

namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            BinaryFormatter formatter = new BinaryFormatter();
            DirectoryInfo newDirectory = new DirectoryInfo(@"C:\Users\VE\Desktop\Studets");
            if (!newDirectory.Exists)
            {
                newDirectory.Create();
            }
           
            using (FileStream fs = new FileStream("C:\\Users\\VE\\Desktop\\Students.dat", FileMode.OpenOrCreate))
            {
                Student[] newStudent = (Student[])formatter.Deserialize(fs);
                foreach ( Student student in newStudent) 
                {
                    Console.WriteLine($"Имя: {student.Name} --- Группа: {student.Group}--- Дата рождения: {student.DateOfBirth}");

                    string filePath = newDirectory.FullName + @"\" + student.Group + ".txt"; // Укажем путь 
                    
                        using (StreamWriter sw = File.AppendText(filePath))
                        { sw.WriteLine($"Имя: {student.Name} ---- Дата рождения: {student.DateOfBirth}"); }
                }
                 
               
                Console.WriteLine("Объект десериализован");
                
            }
        }
}

    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }



    }
}