using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiefAndPoliceTest
{
    internal class Police : Person
    {
        
         public List<Thing> Seized { get; set; }


        public Police() 
        {
            Name = "P";
            Seized = new List<Thing>();
        }
        public override void Colision(Person person)
        {
            if (person is Thief)
            {
                foreach (Thing Good in ((Thief)person).StolenGoods)
                {
                    Seized.Add(Good);

                }
               ((Thief)person).StolenGoods = new List<Thing>();
                Console.WriteLine("Polis tar tjuv!");
            
            }
        }

    }
}
