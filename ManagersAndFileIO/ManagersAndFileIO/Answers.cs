using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagersAndFileIO
{
    internal class Answers
    {
        // This class will not contain any code.
        // It's entire purpose if a place for students to answer questions posed in the PE description.

        // Answer any questions that are listed in the PE with a question mark:


        // Why is Monster abstract?
        // Monster is Abstract so that the Beholder and Dragon classes can take things, as Monster is their parent class,
        // and should not be created directly, and without the need to actually code those individual aspects of the separate
        // classes


        // Briefly summarize:  What code does the Monster class have/is handling?  
        // the code in the monster class contains a constructor that the child classes can use, an abstract Attack method,
        // an abstract TakeDamage method, both of which can be used by the dragon and beholder classes. it also has a ToString
        // method that reports information on the object


        // Briefly summarize:  What code do the two child classes have/are handling?  
        // The two child classes, Dragon and Beholder, contain code for Attack and TakeDamage (from the parent class),
        // that calculates and reports the damage points they inflict or recieve. They also contain unique parameters for
        // damage Vulnerability and damage Resistence
        

        // Why are those classes handling the code that they contain?  (In other words, why was the project architecture designed this way?)
        // Each Dragon object and Beholder object have different numbers of parameters that need to be handled differently.
        

        // Why is the Random object a field of the Monster class and not a field of the child classes?
        // The Monster class has the Random object for convenience: both child classes are able to access and use it,
        // without the added necessity of needing to add it to both classes.


    }
}
