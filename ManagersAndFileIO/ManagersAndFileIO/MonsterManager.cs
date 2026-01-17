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
            List<Monster> monsterList = new List<Monster>();
            monsterList.Add(Dragon);
            monsterList.Add(Beholder);

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
