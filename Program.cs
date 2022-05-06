using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using Open_f;

namespace OOP3
{
    class Program
    {
        static void Main(string[] args)
        {
            Open f = new Open(); //Creates an object
            string[] First_file; //An array for each line of the first file
            string[] Second_file;
            String Line2;
            String Line;
            int Line_num;
            int x;
            Line_num = 0;
            x = 0;
            string txt;
            StreamReader sr = new StreamReader(@"GitRepositories_1a.txt");
            StreamReader sr2 = new StreamReader(@"GitRepositories_1b.txt");
            Line = sr.ReadLine(); //Stores a string of each line of the file
            Line2 = sr2.ReadLine();
            while (Line != null && Line2 != null) //Loops the program until there's no content left in the files
            {
                Line_num += 1; //With each iteration the program updates the file number for outputs
                First_file = Line.Split(" "); //Splits the file by spaces into an array
                Second_file = Line2.Split(" ");
                if (Line == Line2) //if the lines are exactly the same
                {
                    txt = "There are no differences on line " + Line_num;
                    Console.WriteLine("There are no differences on line " + Line_num);
                    File.AppendAllText(@"log.txt", txt + Environment.NewLine);
                }
                else if (First_file.Length == Second_file.Length)
                {
                    Console.Write("Line " + Line_num);
                    for (int i = 0; i < First_file.Length - 1; i++) //for loop to iterate through the array
                    {
                        if (First_file[x] != Second_file[x]) //If the program finds a change
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(First_file[x]);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(Second_file[x]);
                            Console.ForegroundColor = ConsoleColor.White;
                            txt = "Differences on Line " + Line_num + First_file[x] + " " + Second_file[x]; //Summarises the differences
                            File.AppendAllText(@"log.txt", txt + Environment.NewLine); //Appends the differences to the log file
                        }
                        else
                        {
                            Console.Write(" " + First_file[x] + " ");
                        }

                        if (x == First_file.Length - 1)
                        {
                           break;
                        }
                        else
                        {
                            x += 1;
                        }
                    }
                }
                else if (First_file.Length > Second_file.Length)
                {
                    Console.ForegroundColor = ConsoleColor.Red; //Line number is highlighted if there is a difference
                    Console.Write("Line " + Line_num);
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int n = 0; n <= First_file.Length - 1; n++)
                    {
                        if (n == Second_file.Length)
                        { 
                            Console.Write(" " + First_file[n] + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (First_file[n] == Second_file[n])
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" " + First_file[n] + " ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red; //Highlights the line that has the removed word starting with the added word
                            Console.Write(First_file[n]);
                            n += 1;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
                else if (First_file.Length < Second_file.Length)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Line " + Line_num);
                    Console.ForegroundColor = ConsoleColor.White;
                    for (int n = 0; n <= Second_file.Length - 1; n++)
                    {
                        if (n == First_file.Length)
                        {
                            Console.Write(" " + Second_file[n] + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else if (First_file[n] == Second_file[n])
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" " + First_file[n] + " ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(" " + Second_file[n] + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
                Line = sr.ReadLine(); //reads the next line
                Line2 = sr2.ReadLine();
            }
            sr.Close(); //closes the file
            sr2.Close();
            f.Open_file("log.txt"); 
        }
    }
}