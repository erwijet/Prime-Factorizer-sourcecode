using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prime_Factorizer
{
    class Program
    {
        /// <summary>
        /// Returns the users input as a lowercase text string
        /// </summary>
        public static string requestInput
        {
            get
            {
                Console.Write("=> ");
                string tmp = Console.ReadLine();
                return tmp.ToLower();
            }
        }
        /// <summary>
        /// Data for indenting
        /// </summary>
        public static int indentInt = 0;
        /// <summary>
        /// returns the real indents based on the indentInt variable
        /// </summary>
        public static string indent
        {
            get
            {
                string tmp = "";
                for (int i = 0; i < indentInt / 2; i++)
                {
                    tmp += " ";
                }
                return tmp;
            }
        }

        /// <summary>
        /// returns the last command the user entered
        /// </summary>
        public static string lastPrompt { get; set; } = "";

        static void Main(string[] args)
        {
            while (true)
            {
                //Get real user data
                lastPrompt = requestInput;

                //kill?
                if (lastPrompt == "quit")
                    break;
                //Clear?
                else if (lastPrompt == "clear")
                    Console.Clear();

                //Moving on...
                else
                {
                    //The try will indicate if the number is able to be parsed or not, in other words, did the user enter a number?
                    try
                    {
                        //Get the num equilivant of the input
                        var num = Convert.ToInt32(lastPrompt);
                        int length = 0;
                        //Declare Encoder { Code for encoder EncodeNumber.cs }
                        EncodeNumber en = new EncodeNumber();
                        //Draw results
                        #region draw
                        foreach (int i in en.encodeNumber(Convert.ToInt32(lastPrompt)))
                        {
                            for (int e = 0; e < Console.BufferWidth - indent.Length - 1; e++)
                            {
                                Console.Write("_");
                            }
                            if (num == Convert.ToInt32(lastPrompt))
                                Console.Write(" ");
                            Console.Write(indent);
                            Console.WriteLine("{0}|{1}", i.ToString(), num.ToString());
                            num = num / i;
                            indentInt += 4;
                            Console.Write(indent);
                            length++;
                        }

                        Console.WriteLine("\n");
                        for (int r = 0; r < en.encodeNumber(Convert.ToInt32(lastPrompt)).Length; r++)
                        {
                            Console.Write(en.encodeNumber(Convert.ToInt32(lastPrompt))[r].ToString());
                            if (r < length - 1)
                                Console.Write(", ");
                        }
                        indentInt = 0;
                        Console.WriteLine();
                        #endregion
                        //end draw results
                    }
                    catch
                    {
                        Console.WriteLine("Please provide a valid number to parse");
                    }
                }
            }
        }
    }
}
