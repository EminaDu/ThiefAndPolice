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


        public Police(int rowSize, int colSize) : base(rowSize, colSize)
        {
            Name = "P";
            Seized = new List<Thing>();
        }
        public override bool Colision(Person person)
        {
            bool successful = false;
            if (person is Thief)
            {
                if (((Thief)person).StolenGoods.Count() > 0)
                {
                    successful = true;
                }
                foreach (Thing Good in ((Thief)person).StolenGoods)
                {
                    Seized.Add(Good);

                }
               ((Thief)person).StolenGoods = new List<Thing>();
                Arrested++;
                Console.WriteLine("Polis tar tjuv!");
            
            }
            return successful;
        }

    }
}
