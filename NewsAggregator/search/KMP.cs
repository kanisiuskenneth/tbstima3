
using System;
using System.Collections.Generic;
namespace search
{
    public class KMP : SearcherAlgorithm
    {
        public KMP(string text, string pattern) : base(text, pattern)
        {

        }
       
        
        public override int SearchPattern()
        {
            /* Compute Border */
            int patternlength = this.pattern.Length;
            int textlength = this.text.Length;

            int[] border = new int[this.pattern.Length];
            int i, j;

            border[0] = 0;
            i = 1;
            j = 0;
            while (i < patternlength)
            {
                if (pattern[i] == pattern[j])
                {
                    border[i] = j + 1;
                    i++;
                    j++;
                } else if (j > 0)
                {
                    j = border[j - 1];
                } else
                {
                    border[i] = 0;
                    i++;
                }
                
            }

            i = 0;
            j = 0;
            while (i < textlength)
            {
                if (text[i] == pattern[j])
                {
                    if (j == patternlength - 1)
                    {
                        return i - patternlength + 1;
                    }
                    i++;
                    j++;
                } else if (j > 0)
                {
                    j = border[j - 1];
                } else
                {
                    i++;
                }
            }
            return -1;
        }
    }
}
