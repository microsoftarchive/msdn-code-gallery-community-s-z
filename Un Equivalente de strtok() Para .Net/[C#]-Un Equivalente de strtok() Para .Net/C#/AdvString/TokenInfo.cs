using System;

namespace AdvString
{
    public class TokenInfo
    {
        #region Properties
        public int StartPosition { get; private set; }
        public int Length { get; private set; }
        #endregion

        #region Constructors

        public TokenInfo(int startPosition, int length)
        {
            StartPosition = startPosition;
            Length = length;
        }
        #endregion

        #region Methods

        public override string ToString()
        {
            return String.Format("Start: {0}, Length: {1}", StartPosition, Length);
        }

        #endregion
    }
}
