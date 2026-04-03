using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Tree
{
    internal class TalentTreeNode
    {
        private string abilityName;

        private bool hasLearnedTalent;


        public string AbName
        { 
            get { return abilityName; } 

            set { abilityName = value; }
        }

        //TalentTree Constructor
        public TalentTreeNode()
        {
            this.AbName = "";


        }



        //method for List all talents
        internal void ListAllTalents()
        {
            
        }

        //method for List known talents
        internal void ListKnownTalents()
        {

        }

        //method for List possible talents
        internal void ListPossibleTalents()
        {

        }




    }
}
