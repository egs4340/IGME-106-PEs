using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ManagersAndFileIO
{
    //Added Class for the Monster Manager
    internal class MonsterManager
    {
        //Creation of a global monster list and dragon + beholder files for whole Monster Manager
        //Also added a count for the number of dragons and beholders in the count
        public List<Monster> monsterList;
        public string dragonFile, beholderFile;
        public int dragonCount, beholderCount;
        public Random random = new Random();

        //Constructor for the MonsterManager
        public MonsterManager()
        {
            //Creation of the monster list for the Monster Manager
            monsterList = new List<Monster>();
            dragonCount = 0;
            beholderCount = 0;
            
        }

        //Parameterized constructor for the MonsterManager
        public MonsterManager(string dragonData, string beholderData)
        {
            monsterList = new List<Monster>();
            dragonFile = dragonData;
            beholderFile = beholderData;
            dragonCount = 0;
            beholderCount = 0;
            //ReadDragonData();
            //ReadBeholderData();
        
        }


        //Added ReadDragonData Stream reader to be able to read the Beholder Data text file
        public void ReadDragonData()
        {
            StreamReader readerDragon = null!;
            
            //Added Try catch for the Stream Reader of the Dragon Data
            try
            {
                readerDragon = new StreamReader("dragonData.txt");

                string lineFromFile = "";

                while ((lineFromFile = readerDragon.ReadLine()!) != null)
                {
                    string[] splitData = lineFromFile.Split('|');

                    string temp = splitData[1];
                    Damage dmg;
                    Enum.TryParse<Damage>(temp, out dmg);


                    //Gives all the attributes for the read dragon
                    Dragon aDragon = new Dragon(
                        splitData[0],           //Dragon's Name
                        random.Next(50, 101),   //Random health from 50 to 100
                        dmg,                    //The Dragon's Damage
                        Damage.Lightning);      //Dragon's Resistance

                    //Adds the dragon to the list, then adds one to the dragon count
                    monsterList.Add(aDragon);
                    dragonCount++;
                }
            }


            //Catch for any errors in parsing a dragon from the file to the list
            catch (Exception error)
            {
                Console.WriteLine("Error: " + error.Message);
            }


            //end of the try catch to close the reader
            finally
            {
                if (readerDragon != null)
                {
                    readerDragon.Close();
                }
            }
        }

        //added ReadBeholderData Stream reader to be able to read the Beholder Data text file
        public void ReadBeholderData()
        {
            StreamReader readerBeholder = null!;

            //Added try catch for the stream reader of the Beholder Data
            try
            {
                readerBeholder = new StreamReader("beholderData.txt");

                string lineFromFile = "";
            }

            catch
            {
                Console.WriteLine("Problem reading the file!");

            }
        }


        //Added GetDragon to be able to get a random dragon from the DragonData
        public Dragon GetDragon()
        {


        }


        //Added GetDragonByType to be able to get a dragon with a specific damage type
        public Dragon GetDragonByType(Damage damageType)
        {


        }


        //Added GetBeholder to be able to get a random beholder from the BeholderData
        public Beholder GetBeholder()
        {


        }


        //Added GetBeholderByType to be able to get a beholder with a specific damage type
        public Beholder GetBeholderByType(Damage damageType)
        {


        }


    }
}
