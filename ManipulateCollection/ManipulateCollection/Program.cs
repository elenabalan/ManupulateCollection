using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulateCollection
{
    public delegate void MyDelegate(string s);
    public delegate bool CompareDelegate(int i, string s);
    public delegate string ConcatDelegate(int i, string s);

    public static class ExtensionMethods
    {
        public static string UppercaseFirstLetter(this string ss)
        {
            // Uppercase the first letter in the string.

            if (ss.Length > 0)
            {
                char[] array = ss.ToCharArray();
                array[0] = char.ToUpper(array[0]);
                return new string(array);
            }
            return ss;
        }
    }

    class Program
    {

        public static void PrintConsoleUppercaseFirstLetter(string s)
        {
            if (s.Length > 0)
            {
                char[] array = s.ToCharArray();
                array[0] = char.ToUpper(array[0]);
                Console.Write(new string(array) + " ");
            }

        }
        public static void Print(string s, MyDelegate del)
        {
            del(s);
        }
        public bool CompareAsString(int i, string s)   //this method can be associated to CompareDelegate
        {
            return (i.ToString() == s);
        }


        static void Main(string[] args)
        {

            List<string> words = new List<string> { "some", "words", "in", "this", "list" };

            MyDelegate del1 = PrintConsoleUppercaseFirstLetter;
            Console.WriteLine("\nDelegate1    Uppercase First Letter");
            foreach (string s in words)
                del1(s);

            Console.WriteLine("\n****************");
            Console.WriteLine("\nDelegate2    Write as a sentences");
            MyDelegate del2 = s => Console.Write(s + "  ");
            // or using 
            //MyDelegate del2 = PrintWord;
            foreach (string s in words)
                del2(s);

            Console.WriteLine("\n****************");
            Console.WriteLine("\nDelegate1 + Delegate2");
            MyDelegate del = del1 + del2;
            foreach (string s in words)
                del(s);
            Console.WriteLine("\n****************");
            Console.WriteLine("\nDifferent delegates on even and non-even position");
            int poz = 0;
            foreach (string s in words)
            {
                if (poz % 2 == 0)
                    Print(s, del1);
                else
                    Print(s, del2);
                poz++;
            }

            Console.WriteLine("\n****************");
            Console.WriteLine("\nUsing of Anonimous function (in this exemple lambda expresion is Anonimous function)");
            int ii = 8;
            string ss = "2";
            ConcatDelegate myDel = ((i, s) => i.ToString() + s);   //i.ToString() + s    -  this is an anonimous function 
            Console.WriteLine($"Number {ii} + \"{ss}\" as string = \"{myDel(ii, ss)}\"");

            //
            // Use the string extension method on the first element of List WORDS
            //

            Console.WriteLine("\nUse the string extension method on the first element of List WORDS");
            Console.WriteLine($"The words[0] = {words.First()}. After appling UppercaseFirstLetter result is   {words.First().UppercaseFirstLetter()}");

            Console.ReadKey();
        }
    }
}
