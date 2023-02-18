using System;
using System.IO;

namespace TextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu(){
            Console.Clear();
            Console.WriteLine("What do you want do to?");
            Console.WriteLine("1 - Open file\n2 - Creat new file\n0 - Sair;");
            short option = short.Parse(Console.ReadLine());

            switch(option){
                case 0: System.Environment.Exit(0); break;
                case 1: Open();break;
                case 2: Edit();break;
            }

            static void Open(){
                Console.Clear();
                Console.WriteLine("Wich file do you want to open?");                
                string path = Console.ReadLine();

                using(var file = new StreamReader(path)){
                    string text = file.ReadToEnd();
                    Console.WriteLine(text);
                }
                Menu();
            }

            static void Edit(){
                Console.Clear();
                Console.WriteLine("Write your text (ESC to exit)");                
                Console.WriteLine("-----------------");                
                string text = "";
                
                do{
                    text += Console.ReadLine();
                    text += Environment.NewLine;
                }
                while(Console.ReadKey().Key != ConsoleKey.Escape);

                Console.Write(text);
                Save(text);
            }

            static void Save(string text){
                
                Console.Clear();
                Console.WriteLine("Wich path do you want to save?");
                var path = Console.ReadLine();

                using(var file = new StreamWriter(path)){
                    file.Write(text);
                }

                Console.WriteLine($"File saved on {path}");
                Console.ReadLine();
                Menu();
            }

        }
    }
}