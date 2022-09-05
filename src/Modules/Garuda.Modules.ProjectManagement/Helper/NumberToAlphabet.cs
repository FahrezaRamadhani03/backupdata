// <copyright file="NumberToAlphabet.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Text;

namespace Garuda.Modules.ProjectManagement.Helper
{
    public class NumberToAlphabet
    {
        public static string GetCode(int number)
        {
            int start = (int)'A' - 1;
            if (number <= 26)
            {
                return ((char)(number + start)).ToString();
            }

            StringBuilder str = new StringBuilder();
            int nxt = number;

            List<char> chars = new List<char>();

            while (nxt != 0)
            {
                int rem = nxt % 26;
                if (rem == 0)
                {
                    rem = 26;
                }

                chars.Add((char)(rem + start));
                nxt = nxt / 26;

                if (rem == 26)
                {
                    nxt = nxt - 1;
                }
            }

            for (int i = chars.Count - 1; i >= 0; i--)
            {
                str.Append((char)chars[i]);
            }

            return str.ToString();
        }
    }
}
