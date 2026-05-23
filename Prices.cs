using System;
using System.Collections.Generic;
using System.Text;
    public sealed record class Prices
    {

    public decimal Value { get; }
            private Prices(decimal value) => Value = value;
    
            public static Result<Prices> Create(decimal value)
            {
                if (value <= 0)
                    return Result<Prices>.Fail("El precio debe ser mayor a 0.");
    
                if (value > 1_000_000)
                    return Result<Prices>.Fail("El precio excede el máximo permitido.");
    
                return Result<Prices>.OK(new Prices(value));
            }
    
            public override string ToString() => $"${Value:N2}";

}
