using System;
using System.Collections.Generic;

namespace SpacesSearch
{
    class PriorityQueue
    {
        List<State> stateList;

        public List<State> StateList
        {
            get
            {
                return stateList;
            }

            set
            {
                stateList = value;
            }
        }

        public PriorityQueue()
        {
            stateList = new List<State>();
        }

        public PriorityQueue(List<State> sl)
        {
            stateList = new List<State>();

            for (int i = 0; i < sl.Count; i++)
                stateList.Add(sl[i]);
        }

        int Comparison(State s1, State s2)
        {
            double f1 = s1.Distance + s1.GetHeuristic();
            double f2 = s1.Distance + s1.GetHeuristic();

            return (int)(f1 - f2);
        }

        public State ExtractMin()
        {
            stateList.Sort(Comparison);
            State result = stateList[0];
            stateList.RemoveAt(0);
            return result;
        }
    }
}
