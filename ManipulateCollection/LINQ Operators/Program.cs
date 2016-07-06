using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Operators
{
    class Products
    {
        public string name;
        public string category;
        public double price;
        public int storeNumber;
        int count;

        public Products(string s, string c, double p, int nr, int i)
        {
            name = s;
            category = c;
            price = p;
            storeNumber = i;
            count = nr;
        }

        public override string ToString()
        {
            return $"{name,10}  {category,10}  price= {price,7}  nrStory= {storeNumber,2}  count= {count,5}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var criterii = new { category = "FURNITURE",
                                 price = 500
                                };

            var prod = new List<Products> {
                new Products ("table","FURNITURE",1547,12,1),
                new Products("chair", "FURNITURE", 567, 52, 1),
                new Products("TV","ELECTRIC",35000,5,1),
                new Products("blender","ELECTRIC",980.50,15,2),
                new Products("sofa","FURNITURE",14750,2,2),
                new Products("Chips","FOOD",20.7,100,1) };

            prod.Add(new Products("nuts", "FOOD", 5.67, 200, 2));  
            prod.Add(new Products("bookcase", "FURNITURE", 276.5, 17, 1));

            Console.WriteLine("Lista de produse initiala");
            foreach (var p in prod)            
                Console.WriteLine(p.ToString());

            // QUERY
            Console.WriteLine("\nUsing QUERY     Selectam toate produsele de tip FURNITURE\n");

            var furniture = (from pr in prod
                            where pr.category == criterii.category          //aici folosim un anonimous type CRITERII
                             select pr.name +"  " + pr.price ).ToList();            //ToList() implica executarea imediata;

            foreach (var p in furniture)            //fara ToList() executarea ar fi aminata pina a incepe iteratia data
                Console.WriteLine(p);

            ////FLUENT (LambdaSyntax)
            Console.WriteLine($"\nUsing FLUENT (LAMBDASYNTAX)    \nSelectam produsele cu cost mai mare decit {criterii.price} si le afisam in ordinea de la mai mare la mai mic\n");

            var hightPrice = prod.
                            Where(p => p.price > criterii.price).      //aici folosim un anonimous type CRITERII
                            OrderByDescending(p => p.price).       
                            Select(p => p.name + " " + p.category + " " + p.price);
             
            foreach (var p in hightPrice)
                Console.WriteLine(p);

            Console.ReadKey();
        }
    }
}
