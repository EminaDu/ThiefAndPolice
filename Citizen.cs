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


        public Citizen() 
        {
            Name = "C";
            Belongings = new List<Thing> { 
            new Thing (name: "Wallet"),
            new Thing (name: "Keys"),
            new Thing (name: "Cell phone"),
            new Thing (name: "Money") };
            
            
        }
        

        public override void Colision(Person person)
        {
            if (person is Thief)
            {
                Random rnd = new Random();

                int belongingIndex = rnd.Next(0,Belongings.Count);
               
                if(Belongings.Count>0) 
                {
                    return;
                }
                
                ((Thief)person).StolenGoods.Add(Belongings[belongingIndex]);
                Belongings.RemoveAt(belongingIndex);
                Console.WriteLine("Tjuv rånar medborgare!");


            }
        }
            
    }
}
