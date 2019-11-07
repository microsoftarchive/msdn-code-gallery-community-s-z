using System;
using System.Collections.Generic;

namespace SpacesSearch
{
    public interface IState
    {
        LinkedList<State> GetPossibleMoves();
        bool IsSolution();
        double GetHeuristic();
    }
}