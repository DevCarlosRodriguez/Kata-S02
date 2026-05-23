using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_Kata.Domain.ValueObjects
{
    public class Product
    {

        public static Result<Price> Create(decimal price)
        {

            var result = Price.Create(price);

            if (!result.IsSuccess)
            {
                return Result<Price>.Fail(result.Error);
            }

            return Result<Price>.OK(result.Value);

            throw new NotImplementedException();
        }
    }
    }
