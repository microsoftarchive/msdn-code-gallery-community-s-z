using System;

namespace SpacesSearch
{
    class Side
    {
        public enum EastWest {EAST, WEST};
        private EastWest side;

        public EastWest Bank
        {
            get
            {
                return side;
            }

            set
            {
                side = value;
            }
        }

        public Side(EastWest side)
        {
            this.side = side;
        }

        public EastWest GetOpposite()
        {
            if (side == EastWest.EAST)
                return EastWest.WEST;
            else
                return EastWest.EAST;
        }
    }
}
