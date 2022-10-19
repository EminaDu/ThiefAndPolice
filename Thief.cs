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

        public Thief()
        {
            Name = "T";
            StolenGoods = new List<Thing>();
        }
        public override void Colision(Person person)
        {
            if (person is Citizen)
            {
                Random rnd = new Random();

                int belongingIndex = rnd.Next(0, ((Citizen)person).Belongings.Count);
               
                if(((Citizen)person).Belongings.Count > 0)
                {
                    return;
                }
                StolenGoods.Add(((Citizen)person).Belongings[belongingIndex]);
                ((Citizen)person).Belongings.RemoveAt(belongingIndex);
                Console.WriteLine("Tjuv rånar medborgare!");


            }
            else if (person is Police)
            {
                foreach (Thing Good in StolenGoods)
                {
                    ((Police)person).Seized.Add(Good);

                }
                StolenGoods = new List<Thing>();
                Console.WriteLine("Polis tar tjuv!");
            }

        }
    }
}
