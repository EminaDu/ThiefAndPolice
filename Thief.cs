using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiefAndPoliceTest
{
    internal class Thief : Person
    {
        public List<Thing> StolenGoods { get; set; }

        public Thief(int rowSize, int colSize) : base(rowSize, colSize)
        {
            Name = "T";
            StolenGoods = new List<Thing>();
        }
        public override bool Colision(Person person)
        {
            bool successful = false;
            if (person is Citizen)
            {
                Random rnd = new Random();

                int belongingIndex = rnd.Next(0, ((Citizen)person).Belongings.Count);
               
                if(((Citizen)person).Belongings.Count > 0)
                {
                    successful = true;
                    StolenGoods.Add(((Citizen)person).Belongings[belongingIndex]);
                    ((Citizen)person).Belongings.RemoveAt(belongingIndex);
                    Robbed++;
                    Console.WriteLine("Tjuv rånar medborgare!");
                }

            }
            else if (person is Police)
            {
                if (StolenGoods.Count() > 0)
                {
                    successful = true;
                }

                foreach (Thing Good in StolenGoods)
                {
                    ((Police)person).Seized.Add(Good);

                }
                StolenGoods = new List<Thing>();
                Arrested++;
                Console.WriteLine("Polis tar tjuv!");
            }
            return successful;
        }
        public void MoveToPrison(int rowSize, int colSize)
        {
            Random rnd = new Random();
            LocationRow = rnd.Next(0, rowSize);
            LocationCol = rnd.Next(0, colSize);
        }
    }
}
