using System;
using System.Collections.Generic;

namespace SpacesSearch
{
    public interface ISolver
    {
        LinkedList<State> Solve(State initial);
    }
}
