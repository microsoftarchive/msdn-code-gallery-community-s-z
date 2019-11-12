using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvString
{
    public static class Tokenize
    {
        public static IEnumerable<TokenInfo> GetTokens(string text, params char[] separators)
        {
            List<TokenInfo> tokens = new List<TokenInfo>();
            if (String.IsNullOrWhiteSpace(text)) throw new ArgumentNullException("text");
            unsafe
            {
                fixed (char* startChar = text)
                {
                    char* curChar = startChar;
                    int start = 0;
                    int textLength = text.Length;
                    bool insideToken = false;
                    while (curChar - startChar < textLength - 1)
                    {
                        if (separators.Contains(*curChar))
                        {
                            if (insideToken)
                            {
                                //End of token.
                                insideToken = false;
                                //Yield a new TokenInfo object to the caller.
                                tokens.Add(new TokenInfo(start, (int)(curChar - startChar) - start));
                            }
                        }
                        else if (!insideToken)
                        {
                            insideToken = true;
                            start = (int)(curChar - startChar);
                        }
                        ++curChar;
                    }
                    if (insideToken)
                    {
                        //Yield the last token.
                        tokens.Add(new TokenInfo(start, (int)(curChar - startChar) - start + 1));
                    }
                }
            }
            return tokens;
        }
    }
}
