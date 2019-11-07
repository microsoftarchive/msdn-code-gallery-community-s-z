using System;
using System.Collections.Generic;

namespace SpacesSearch
{
    class DepthFirstSolver : Solver
    {
        private Stack<State> stack = new Stack<State>();

        protected override void AddState(State s)
        {
            if (!stack.Contains(s))
                stack.Push(s);
        }

        protected override bool HasElements()
        {
            return stack.Count != 0;
        }

        protected override State NextState()
        {
            return stack.Pop();
        }

        protected override void ClearOpen()
        {
            stack.Clear();
        }
    }
}
