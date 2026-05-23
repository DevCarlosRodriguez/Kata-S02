# S02-Kata-Problem — DRY · KISS · YAGNI

Proyecto de inicio para el hands-on del Sábado 2.  
**Solo edita los archivos indicados.** `Program.cs` ya está completo — no lo modifiques.

---

## Requisitos

- .NET 10 SDK → [dot.net/download](https://dot.net/download)
- Cualquier editor: VS Code, Rider, Visual Studio

---

## Cómo empezar

```bash
git clone <URL-del-repo>
cd S02-Kata-Problem
dotnet run
```

Al clonar, el proyecto **no compila** — eso es intencional.  
Tu trabajo es implementar los TODOs hasta que la salida coincida exactamente con la esperada.

---

## Kata 1 — DRY: Value Object `Price` (45 min)

**Archivo a editar:** `Price.cs`

Implementa los dos `TODO` dentro de `Price.Create()`:

1. Si `value <= 0` → retornar `Result<Price>.Fail("El precio debe ser mayor a 0.")`
2. Si `value > 1_000_000` → retornar `Result<Price>.Fail("El precio excede el máximo permitido.")`
3. Si válido → retornar `Result<Price>.OK(new Price(value))`

Quita el `throw new NotImplementedException()` cuando termines.

**Salida esperada (Kata 1):**
```
=== Kata 1: DRY — Value Object Price ===
✅ Laptop creado — $1,299.99
❌ Precio inválido: El precio debe ser mayor a 0.
❌ Precio inválido: El precio excede el máximo permitido.
✅ Mouse creado — $29.99
--- Cambiando límite máximo a $500 ---
```

> Verificación DRY: cambia `1_000_000` por `500m` en `Price.Create()` y vuelve a correr.
> Debes ver una línea extra `❌` sin modificar `Program.cs`. Luego devuélvelo a `1_000_000m`.

---

## Kata 2 — KISS: Descuento simple (25 min)

**Archivo a editar:** `Program.cs` → método `CalculateDiscount`

Regla: **10% de descuento si `subtotal >= 100`; 0% si `subtotal < 100`**.  
Impleméntalo en 5 líneas o menos. Sin interfaces, factories ni clases adicionales.  
Quita el `throw new NotImplementedException()`.

**Salida esperada (Kata 2):**
```
=== Kata 2: KISS — Descuento simple ===
Subtotal $50.00 → Descuento: $0.00
Subtotal $100.00 → Descuento: $10.00
Subtotal $200.00 → Descuento: $20.00
```

---

## Kata 3 — YAGNI: Auditar `ProductService` (15 min)

**Archivo a editar:** `Program.cs` → clase `ProductService`

Los 4 métodos al final de `ProductService` no tienen requisito real.  
Para cada uno:
1. Coméntalo o elimínalo
2. Agrega `// YAGNI: [tu razón]` explicando por qué lo eliminas

`CreateProduct()` y `ListProducts()` deben seguir compilando y funcionando.

**Salida esperada (Kata 3):**
```
=== Kata 3: YAGNI — ProductService ===
  · Laptop — $1,299.99
  · Mouse — $29.99
Solo CreateProduct y ListProducts están disponibles.
```

---

## Kata 4 — ADRs: Documentar las 3 decisiones (20 min)

**Archivos a editar:** `docs/adr/ADR-001-*.md`, `ADR-002-*.md`, `ADR-003-*.md`

Cada archivo tiene el formato MADR con secciones vacías y pistas en comentarios.  
Rellena **Contexto**, **Decisión** (incluye la alternativa descartada) y **Consecuencias**.

| ADR | Decisión a documentar |
|-----|-----------------------|
| ADR-001 | Por qué `sealed record` y no `class` para `Price` |
| ADR-002 | Por qué `Result<T>` y no `throw` / `null` en `Create()` |
| ADR-003 | Por qué eliminar los 4 métodos especulativos de `ProductService` |

---

## Criterios de aceptación

| Kata | Criterio |
|------|---------|
| 1 | `Price.cs` compila; `Create()` retorna `Result<Price>` sin `throw` |
| 1 | `new Price(999)` **no compila** desde `Program.cs` (constructor `private`) |
| 1 | Cambiar el límite en `Create()` afecta la salida sin tocar `Program.cs` |
| 2 | `CalculateDiscount` en 5 líneas o menos; sin clases adicionales |
| 3 | Los 4 métodos tienen `// YAGNI: [razón]` y están comentados/eliminados |
| 4 | Cada ADR tiene Contexto, Decisión (con alternativa descartada) y Consecuencias |

---

## Salida completa esperada

```
=== Kata 1: DRY — Value Object Price ===
✅ Laptop creado — $1,299.99
❌ Precio inválido: El precio debe ser mayor a 0.
❌ Precio inválido: El precio excede el máximo permitido.
✅ Mouse creado — $29.99
--- Cambiando límite máximo a $500 ---

=== Kata 2: KISS — Descuento simple ===
Subtotal $50.00 → Descuento: $0.00
Subtotal $100.00 → Descuento: $10.00
Subtotal $200.00 → Descuento: $20.00

=== Kata 3: YAGNI — ProductService ===
  · Laptop — $1,299.99
  · Mouse — $29.99
Solo CreateProduct y ListProducts están disponibles.
```
