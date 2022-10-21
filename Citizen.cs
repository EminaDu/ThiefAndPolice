using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ThiefAndPoliceTest
{
    internal class Citizen : Person 
    {
      
         public List<Thing> Belongings { get; set; }


        public Citizen(int rowSize, int colSize):base(rowSize, colSize)
        {
            Name = "C";
            Belongings = new List<Thing> {
                new Thing (name: "Plånbok"),
                new Thing (name: "Keys"),
                new Thing (name: "Cell phone"),
                new Thing (name: "Money") 
            };
            
            
        }

        
        

        public override bool Colision(Person person)
        {
            bool successful = false;
            if (person is Thief)
            {
                Random rnd = new Random();

                int belongingIndex = rnd.Next(0,Belongings.Count);

                if (Belongings.Count > 0)
                {
                    successful = true;  
                    ((Thief)person).StolenGoods.Add(Belongings[belongingIndex]);
                    Belongings.RemoveAt(belongingIndex);
                    Robbed++;
                    Console.WriteLine("Tjuv rånar medborgare!");
                }

            }
            return successful;
        }
            
    }
}
