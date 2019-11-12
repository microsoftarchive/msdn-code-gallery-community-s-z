using System;
using System.Collections.Generic;

namespace SpacesSearch
{
    class BestFirstSolver : Solver
    {
        private PriorityQueue queue = new PriorityQueue();

        protected override void AddState(State state)
        {
            queue.StateList.Add(state);
        }

        protected override bool HasElements()
        {
            return queue.StateList.Count != 0;
        }

        protected override State NextState()
        {
            return queue.ExtractMin();
        }

        protected override void ClearOpen()
        {
            queue.StateList = new List<State>();
        }
    }
}
