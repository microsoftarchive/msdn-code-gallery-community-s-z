using System;
using System.Collections.Generic;

namespace SpacesSearch
{
    class FarmerWolfGoatCabbageState : State
    {
        private Side farmer = new Side(Side.EastWest.EAST);
        private Side wolf = new Side(Side.EastWest.EAST);
        private Side goat = new Side(Side.EastWest.EAST);
        private Side cabbage = new Side(Side.EastWest.EAST);
        public FarmerWolfGoatCabbageState() { }

        public FarmerWolfGoatCabbageState(
            FarmerWolfGoatCabbageState parent,
            Side farmer, Side wolf,
            Side goat, Side cabbage)
        {
            base.Parent = parent;
            this.cabbage = cabbage;
            this.farmer = farmer;
            this.goat = goat;
            this.wolf = wolf;
        }

        public override bool IsSolution()
        {
            return
                farmer.Bank == Side.EastWest.WEST &&
                wolf.Bank == Side.EastWest.WEST &&
                goat.Bank == Side.EastWest.WEST &&
                cabbage.Bank == Side.EastWest.WEST;
        }

        public override LinkedList<State> GetPossibleMoves()
        {
            LinkedList<State> moves = new LinkedList<State>();

            if (farmer.Bank == wolf.Bank)
            {
                (new FarmerWolfGoatCabbageState(
                    this,
                    new Side(farmer.GetOpposite()),
                    new Side(wolf.GetOpposite()),
                    goat,
                    cabbage)).AddIfSafe(moves);
            }
            if (farmer.Bank == goat.Bank)
            {
                (new FarmerWolfGoatCabbageState(
                    this,
                    new Side(farmer.GetOpposite()),
                    wolf,
                    new Side(goat.GetOpposite()),
                    cabbage)).AddIfSafe(moves);
            }
            if (farmer.Bank == cabbage.Bank)
            {
                (new FarmerWolfGoatCabbageState(
                    this,
                    new Side(farmer.GetOpposite()),
                    wolf, goat,
                    new Side(cabbage.GetOpposite()))).AddIfSafe(moves);
            }

            (new FarmerWolfGoatCabbageState(
                this, new Side(farmer.GetOpposite()),
                wolf, goat, cabbage)).AddIfSafe(moves);

            return moves;
        }

        public override double GetHeuristic()
        {
            return Distance + (farmer.Bank == wolf.Bank ? 1.0 : 0.0)
                + (farmer.Bank == goat.Bank ? 1.0 : 0.0);
        }

        private void AddIfSafe(LinkedList<State> moves)
        {
            bool nogood = (farmer.Bank != wolf.Bank &&
                farmer.Bank != goat.Bank) ||
                (farmer.Bank != goat.Bank && farmer.Bank != cabbage.Bank);

            if (!nogood)
                moves.AddLast(this);
        }

        private string FormatSide(Side s)
        {
            return s.Bank == Side.EastWest.EAST ? "East" : "West";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is FarmerWolfGoatCabbageState))
                return false;

            FarmerWolfGoatCabbageState fwgc = (FarmerWolfGoatCabbageState)obj;

            return
                farmer.Bank == fwgc.farmer.Bank &&
                wolf.Bank == fwgc.wolf.Bank &&
                goat.Bank == fwgc.goat.Bank &&
                cabbage.Bank == fwgc.cabbage.Bank;
        }

        public override int GetHashCode()
        {
            return
                (farmer.Bank == Side.EastWest.EAST ? 1 : 0) +
                (wolf.Bank == Side.EastWest.EAST ? 2 : 0) +
                (goat.Bank == Side.EastWest.EAST ? 4 : 0) +
                (cabbage.Bank == Side.EastWest.EAST ? 8 : 0);
        }

        public override string ToString()
        {
            string r = string.Empty;

            r += "F: " + FormatSide(farmer) + ", ";
            r += "W: " + FormatSide(wolf) + ", ";
            r += "G: " + FormatSide(goat) + ", ";
            r += "C: " + FormatSide(cabbage) + "\r\n";

            return r;
        }
    }
}
