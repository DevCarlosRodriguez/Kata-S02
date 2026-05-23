// ── Tipo auxiliar — NO modificar ─────────────────────────────────────────────
using S2_Kata;

// ── Programa principal — NO modificar ────────────────────────────────────────
Console.WriteLine("=== Kata 1: DRY — Value Object Price ===");

var casos = new[] { 1299.99m, -10m, 1_500_000m, 29.99m };
var nombres = new[] { "Laptop", "", "", "Mouse" };

for (int i = 0; i < casos.Length; i++)
{
    var r = Price.Create(casos[i]);
    if (r.IsSuccess)
        Console.WriteLine($"✅ {nombres[i]} creado — {r.Value}");
    else
        Console.WriteLine($"❌ Precio inválido: {r.Error}");
}

Console.WriteLine("--- Cambiando límite máximo a $500 ---");
var prueba = Price.Create(1299.99m);
if (!prueba.IsSuccess)
    Console.WriteLine($"❌ Precio inválido: {prueba.Error}");

Console.WriteLine("\n=== Kata 2: KISS — Descuento simple ===");
decimal[] subtotales = [50m, 100m, 200m];
foreach (var s in subtotales)
{
    var d = Calculator.CalculateDiscount(s);
    Console.WriteLine($"Subtotal ${s:N2} → Descuento: ${d:N2}");
}

Console.WriteLine("\n=== Kata 3: YAGNI — ProductService ===");
var svc = new ProductService();
svc.CreateProduct("Laptop", 1_299.99m);
svc.CreateProduct("Mouse", 29.99m);
foreach (var p in svc.ListProducts())
    Console.WriteLine($"  · {p}");
Console.WriteLine("Solo CreateProduct y ListProducts están disponibles.");

public sealed class Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public string Error { get; }

    private Result(bool ok, T? value, string error)
        => (IsSuccess, Value, Error) = (ok, value, error);

    public static Result<T> OK(T value) => new(true, value, string.Empty);
    public static Result<T> Fail(string msg) => new(false, default, msg);
}

// ── Kata 2 — KISS: completa este método (máx 5 líneas) ───────────────────────
// Regla: 10% de descuento si subtotal >= 100; 0% si subtotal < 100

// ── Kata 3 — YAGNI: audita ProductService ────────────────────────────────────
// Comenta o elimina los métodos que violen YAGNI.
// Agrega // YAGNI: [tu razón] junto a cada uno.
public sealed class ProductService
{
    private readonly List<string> _productos = [];

    // Funcionalidad requerida hoy
    public Result<Guid> CreateProduct(string name, decimal price)
    {
        _productos.Add($"{name} — ${price:N2}");
        return Result<Guid>.OK(Guid.NewGuid());
    }

    public IReadOnlyList<string> ListProducts() => _productos.AsReadOnly();

    // "por si acaso lo necesitamos después"
    //public Task ExportToExcelAsync() => Task.CompletedTask;
    //public Task ImportFromSapAsync(string ep) => Task.CompletedTask;
    //public void SendToAnalyticsPlatform() { }
    //public string GenerateReportPdf() => string.Empty;
}
