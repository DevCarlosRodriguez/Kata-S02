using S2_Kata.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_Kata
{
    public sealed record Price
    {
        public decimal Value { get; }
        private Price(decimal value) => Value = value;

        public static Result<Price> Create(decimal value)
        {
            if (value < 0)
            {
                return Result<Price>.Fail("El precio debe ser mayor a 0");
            }
            if (value <= 0 || value > 1_000_00)
            {
                return Result<Price>.Fail("Precio invalido");
            }
            return Result<Price>.OK(new Price(value));
        }
       public override string ToString() => $"${Value:N2}";
    }
}

