// Price.cs — Kata 1: DRY — Value Object


public class Product
    {
        public static Result<Prices> Create(decimal price)
        {

            var result = Prices.Create(price);

            if (!result.IsSuccess)
            {
                return Result<Prices>.Fail(result.Error);
            }

            return Result<Prices>.OK(result.Value);

            throw new NotImplementedException();
        }
    }