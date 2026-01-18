using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagersAndFileIO
{
    //Added Class for the Monster Manager
    internal class MonsterManager
    {

        //Added the Stream Readers of the Dragon and Beholder data
        StreamReader ReadDragonData = null!;
        StreamReader ReadBeholderData = null!;
        public MonsterManager()
        {
            //Added the Dragon and Beholder to be used by the Monster Manager
            Dragon guy1;                // Fighter #1
            Beholder guy2;              // Fighter #2

            //Declares the variables of the 'new' guys.
            guy1 = new Dragon("Dude 1", 100, Damage.Ice, Damage.Lightning);
            guy2 = new Beholder("Dude 2", 115, Damage.Psychic, Damage.Ice);


            //Creation of the monster list for the Monster Manager
            List<Monster> monsterList = new List<Monster>();
            
            monsterList.Add(guy1);
            monsterList.Add(guy2);


            //Added Try catch for the Stream Readers of the Dragon and Beholder Data
            try
            {
                ReadDragonData = new StreamReader("dragonData.txt");

                ReadBeholderData = new StreamReader("beholderData.txt");

            }

            catch (Exception ex)
            {


            }

        }

    }
}
