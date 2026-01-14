using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    internal interface IArea
    {
        // Properties
        double Area { get; }
        double Perimeter { get; }

        // Methods

        // Is a coordinate within the area of this object?
        bool ContainsPosition(IPosition position);

        // Is this area larger than the area of another object?
        bool IsLargerThan(IArea areaToCheck);
    }
}
