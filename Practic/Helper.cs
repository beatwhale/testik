using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic
{
    public class Helper
    {
        public static bool CheckField(string field)
        {
            return field.Trim().Length >= 1;
        }
    }
}
