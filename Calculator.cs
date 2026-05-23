using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_Kata
{
    public class Calculator
    {
        public static decimal CalculateDiscount(decimal subtotal)
        {
            if (subtotal >= 100m)
                return subtotal * 0.10m; 
            return 0m; 
        }

    }
}
