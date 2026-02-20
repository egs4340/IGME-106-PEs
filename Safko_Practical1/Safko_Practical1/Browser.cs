using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safko_Practical1
{
    internal class Browser
    {
        //data structure for the forwards activity. I made this a list that will eventually get the current webpage and the new webpage, the one we want to proceed towards, and move to it.
        List<string> dataForwards = new List<string>();
        
        //data structure for the backwards activity. I made these lists that will eventually get the current webpage and add the next webpage (previous webpage) and move to it.
        List<string> dataBackwards = new List<string>();


        public Browser() 
        {
            


        }

        //added the method for visiting a new page
        public void VisitNewPage(string browser)
        {

            dataForwards.Add(browser);


            dataBackwards.Add(browser);
        }


        //method for moving forwards
        public void MoveForward()
        {

        }

        //method for moving backwards
        public void MoveBackward()
        {

        }



    }
}
