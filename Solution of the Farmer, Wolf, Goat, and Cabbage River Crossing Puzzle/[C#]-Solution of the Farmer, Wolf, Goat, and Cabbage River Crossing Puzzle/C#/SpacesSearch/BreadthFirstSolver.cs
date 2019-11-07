using System;
using System.Collections.Generic;

namespace SpacesSearch
{
    class BreadthFirstSolver : Solver
    {
        private Queue<State> queue = new Queue<State>();

        protected override void AddState(State state)
        {
            if (!queue.Contains(state))
                queue.Enqueue(state);
        }

        protected override bool HasElements()
        {
            return queue.Count != 0;
        }

        protected override State NextState()
        {
            return queue.Dequeue();
        }

        protected override void ClearOpen()
        {
            queue.Clear();
        }
    }
}
