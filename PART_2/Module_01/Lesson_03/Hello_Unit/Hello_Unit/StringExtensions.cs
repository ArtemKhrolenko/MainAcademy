using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Unit
{
        public static class StringExtensions
        {
            public static bool IsBaseColor(this string ClrStr)
            {
                string[] baseColor = { "black", "white"};
                foreach (var item in baseColor)
                {
                    if (ClrStr.Equals(item, StringComparison.CurrentCultureIgnoreCase))
                        return true;
                }
                return false;
            }        
        }
}
