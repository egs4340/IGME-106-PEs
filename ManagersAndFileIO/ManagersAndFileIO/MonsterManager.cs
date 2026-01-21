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
        
        //Global Random added to be able to give newly created instances of Dragons and Beholders a random number of health
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
            //Fields for the MonsterManager 
            monsterList = new List<Monster>();
            dragonFile = dragonData;
            beholderFile = beholderData;
            dragonCount = 0;
            beholderCount = 0;
            ReadDragonData();
            ReadBeholderData();
        
        }


        //Added ReadDragonData Stream reader to be able to read the Beholder Data text file
        public void ReadDragonData()
        {
            StreamReader readerDragon = null!;
            
            //Added Try catch for the Stream Reader of the Dragon Data
            try
            {
                //Creates the reader for the DragonData
                readerDragon = new StreamReader("dragonData.txt");
                string lineFromFile = "";


                //Added a While loop based on the Code Demo for File IOs
                while ((lineFromFile = readerDragon.ReadLine()!) != null)
                {
                    //Splits the File Reader at the '|' pipe symbol
                    string[] splitData = lineFromFile.Split('|');

                    //Added the try parse and it's requirements needed to turn the Enumerator from the Dragon Class
                    //Into a string that can be read when the program instantiates a new Dragon object
                    string dmgTemp = splitData[1];
                    Damage dmg = (Damage)Enum.Parse(typeof(Damage), dmgTemp);


                    //Gives all the attributes for the read dragon with the Parameters required to instantiate a new dragon
                    Dragon aDragon = new Dragon(

                        splitData[0],           //Dragon's Name
                        random.Next(50, 101),   //Random health from 50 to 100
                        dmg,                    //The Dragon's Damage after being parsed into a string from the enumerator
                        Damage.Lightning);      //Dragon's Resistance

                    //Adds the dragon to the list, then adds one to the dragon count
                    monsterList.Add(aDragon);
                    dragonCount++;

                }
            }


            //Catch for any errors in parsing a dragon from the file to the list
            catch
            {
                Console.WriteLine("Problem reading the file!");
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
                //Added a While loop based on the Code Demo for File IOs
                while ((lineFromFile = readerBeholder.ReadLine()!) != null)
                {
                    //Splits the File Reader at the '|' pipe symbol
                    string[] splitData = lineFromFile.Split('|');

                    //Added the try parse and it's requirements needed to turn the Enumerator from the Beholder Class
                    //Into a string that can be read when the program instantiates a new Beholder object
                    string dmgTemp = splitData[1];
                    Damage dmg = (Damage)Enum.Parse(typeof(Damage), dmgTemp);


                    //Gives all the attributes for the read dragon with the Parameters required to instantiate a new beholder
                    Beholder aBeholder = new Beholder(

                        splitData[0],           //Beholder's Name
                        random.Next(50, 101),   //Random health from 50 to 100
                        dmg,                    //The Beholder's Damage after being parsed into a string from the enumerator
                        Damage.Lightning);      //Beholder's Resistance

                    //Adds the dragon to the list, then adds one to the beholder count
                    monsterList.Add(aBeholder);
                    beholderCount++;

                }
            }
            //Catch method for any errors when loading the file
            catch
            {
                Console.WriteLine("Problem reading the file!");

            }
        }


        //Added GetDragon to be able to get a random dragon from the DragonData
        public Dragon GetDragon()
        {
            //Generates a Random number, sets an integer to a random number between 0 and ten, then returns the random number with
            //the assigned dragon attatched to that number on the monster list
            Random random = new Random();
            int i = random.Next(0, 10);
            return (Dragon)monsterList[i];

        }


        //Added GetDragonByType to be able to get a dragon with a specific damage type
        public Dragon GetDragonByType(Damage damageType)
        {
            //Generates a random number, and then it will run a while loop that runs forever, and sets an integer to a random number
            //between 0 and 10, that gets a dragon and compares if it's attack is the same as the damagetype going into the function,
            //then returns the dragon and exits the loop when it's a match
            Random random = new Random();
            while (true)
            {
                int i = random.Next(0, 10);
                Dragon draco = (Dragon)monsterList[i];
                
                if (draco.attackDamage == damageType)
                {
                    return draco;
                }

            }    

        }


        //Added GetBeholder to be able to get a random beholder from the BeholderData
        public Beholder GetBeholder()
        {
            //Generates a Random number, sets an integer to a random number between 10 and 18, then returns the random number with
            //the assigned beholder attatched to that number on the monster list
            Random random = new Random();
            int i = random.Next(10, 18);
            return (Beholder)monsterList[i];

        }


        //Added GetBeholderByType to be able to get a beholder with a specific damage type
        public Beholder GetBeholderByType(Damage damageType)
        {
            //Generates a random number, and then it will run a while loop that runs forever, and sets an integer to a random number
            //between 0 and 10, that gets a beholder and compares if it's attack is the same as the damagetype going into the
            //function, then returns the beholder and exits the loop when it's a match
            Random random = new Random();
            while (true)
            {
                int i = random.Next(10, 18);
                Beholder behold = (Beholder)monsterList[i];

                if (behold.attackDamage == damageType)
                {
                    return behold;
                }

            }

        }


    }
}
