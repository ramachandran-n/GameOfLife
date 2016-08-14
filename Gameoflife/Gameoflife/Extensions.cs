using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gameoflife
{
    public static class Extensions
    {        
            public static void Fill<T>(this T[,] originalArray, T with)
            {
                for (int i = 0; i < originalArray.GetLength(0); i++)
                {
                    for (int j = 0; j < originalArray.GetLength(1); j++)
                    {
                        originalArray[i, j] = with;
                    }
                }
            }   
    }
}
