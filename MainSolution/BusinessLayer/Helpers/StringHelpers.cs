using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITGateWorkDesk.Business.Helpers
{
    public static class StringHelpers
    {
        public static bool EqualsIgnoreCase(this string source, string compareTo)
        {
            return System.String.Compare(source, compareTo, System.StringComparison.OrdinalIgnoreCase) > 0;
        }
    }
}
