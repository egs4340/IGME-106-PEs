using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

            set { abilityName = ""; }
        }

        public bool talentLearned
        {
            get { return talentLearned; }
            set { talentLearned = true; }
        }

        //TalentTree Constructor

        public TalentTreeNode()
        {
            this.AbName = "Fireball";
            this.talentLearned = true;
        }

        TalentTreeNode leftNode = new TalentTreeNode();

        TalentTreeNode rightNode = new TalentTreeNode();

        //method for List all talents
        internal void ListAllTalents()
        {
            AbName = "Fireball, Big Fireball, Small Fireball";
        }

        //method for List known talents
        internal void ListKnownTalents()
        {
            if (talentLearned = true)
            {
                this.ListAllTalents();
            }

        }

        //method for List possible talents
        internal void ListPossibleTalents()
        {

        }

    }
}
