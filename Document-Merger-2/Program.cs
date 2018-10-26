using System;
using System.IO;

namespace Document_Merger_2
{
    public class StreamWriter : System.IO.TextWriter
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("DocumentMerger2 <input_file_1> <input_file_2>...<input_file_n> <output_file>");
                Console.WriteLine("Supply a list of text files to merge followed by the name of the resulting merged text file as a command line arguments.");

            }

            else
            {

                for (int i = 0; i < args.Length - 1; i++)
                {
                    string fileName = args[i];
                    try
                    {
                        if (File.Exists(fileName + ".txt") == false)
                        {
                            Console.WriteLine("exiting");
                            Console.ReadLine();
                            break;
                        }

                        fileName += System.IO.File.ReadAllText(args[i]);
                    }

                    catch (Exception Ex)
                    {
                        Console.WriteLine("File error");
                        break;

                    }
                }

                try
                {
                    using (StreamWriter sw = new StreamWriter(args[args.Length - 1] + .txt))
                    {
                        sw.WriteLine(fileName);
                    }

                    Console.WriteLine($"{(args[args.Length - 1])} is saved");
                }

                catch (Exception Exc)
                {
                    using (StreamWriter sw = new StreamWriter())
                    {
                        sw.WriteLine(fileName);
                    }

                    Console.WriteLine("Your file will not open.");
                }
            }
            Console.ReadLine();
        }
    }
    
