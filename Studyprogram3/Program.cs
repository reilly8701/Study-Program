using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Studyprogram3
{
    //code by Maura Reilly
    //made with assistance from Brendan in the IAM tutoring lounge
    //additional assistance from Programming is Fun "Reading and Writing External Data (C# Console Application)"
    //terms and definitions found in the reference section of the Programming is Fun website
    class Program
    {
        static void Main(string[] args)
        {

          
            bool isgamerunning = true;
            player player = new player();
            Random rnd = new Random();
            string DataFile = "TextFile1.txt";
            string content = "(empty file)";
                Console.Title = "Study  by Maura Reilly";


            Console.WriteLine("Please enter your name.");
            player.name = Console.ReadLine();
            Console.WriteLine("Ok " + player.name + ", press Enter to continue");
            Console.ReadLine();
       


            term[] termarray = new term[15];
            string[] definitiondisplay = File.ReadAllLines("definitions.txt");
            string[] termdisplay = File.ReadAllLines("terms.txt");

            for (int i = 0; i < 15; i++)
            {
                termarray[i] = new term();
                termarray[i].vocab = termdisplay[i];
                termarray[i].definition = definitiondisplay[i];

            }

            while (isgamerunning)
            {
                int randomvocab = rnd.Next(0, 15);

                Console.WriteLine(termarray[randomvocab].definition);

                Console.WriteLine("Write your term that matches the definition");
                string playeranswer = Console.ReadLine();

                playeranswer.ToLower();

                if (playeranswer == termarray[randomvocab].vocab)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congrats, you earned +1");
                    Console.ResetColor();
                    player.progress++;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, your answer is incorrect");
                    Console.ResetColor();

                    player.progress--;
                }

                Console.WriteLine("Your score is " + player.progress);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Continue? press y for yes, any other key for no");
                Console.ResetColor();
                playeranswer = Console.ReadLine();
                playeranswer.ToLower();
                if (playeranswer != "y")
                {
                    isgamerunning = false;
                }
               
            }


        }
    }
}
