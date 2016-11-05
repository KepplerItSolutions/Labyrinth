using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B_ESA_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> bracketsOpen = new Stack<string>();
            bool errorFlag = false;
            if (args != null && args[0] != string.Empty)
            {
                for (int i = 0; i < args[0].Length; i++)
                {
                    string temp = args[0].Substring(i, 1);
                    if (temp == "(")
                    {
                        bracketsOpen.Push(temp);
                    }
                    else if (temp == ")")
                    {
                        if (bracketsOpen.Count > 0)
                        {
                            string bracketFromStack = bracketsOpen.Pop();
                        }
                        else
                        {
                            errorFlag = true;
                        }
                    }
                }
                if (bracketsOpen.Count > 0)
                {
                    errorFlag = true;
                }

                if (errorFlag)
                {
                    PrintError(args[0]);
                }
                else
                {
                    PrintNoError(args[0]);
                }
                DisplayHelp();
                Console.ReadLine();
            }
        }

        static void PrintNoError(string expression)
        {
            Console.WriteLine("Der eingegebene Ausdruck ist korrekt geklammert.\nEingegebener Ausdruck: {0}", expression);            
        }

        static void PrintError(string expression)
        {
            Console.WriteLine("Der eingegebene Ausdruck hat mindestens einen Fehler bei der Klammerung.\nEingegebener Ausdruck: {0}", expression);            
        }

        public static void DisplayHelp()
        {
            Console.WriteLine("\n- korrekte Ausdrücke schließen alle geöffneten Klammern, z.B. (() () ())\n"
                + "- werden nicht alle geöffneten Klammern auch wieder geschlossen, ist ein Ausdruck inkorrekt, z.B. (()\n"
                + "- die Anwedung ignoriert alle Zeichen außer Klammern.");

        }

        public static void DisplayShortDescription()
        {
            Console.WriteLine("Geben Sie einen geklammerten Ausdruck ein, den Sie auf Korrektheit prüfen wollen (-h für Hilfe / -e für Ende):");
        }
    }
}
