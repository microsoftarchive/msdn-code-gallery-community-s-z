using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tokenize
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
    }
}
