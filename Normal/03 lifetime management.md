## About the Different Lifetimes

The lifetime determines weather the DI container will create a new instance

> Transient : A new instance is created every time a type is requested

> Scoped : A new instance is created once per scope, and then reused in the scope

> Singleton : A new instance is created once and reused from then onwards


```csharp
services.AddTransient<IProductImporter, ProductImporter>();
...
var resolvedOnce = host.Services.GetService<IProductImporter>();
var resolvedTwice = host.Services.GetService<IProductImporter>();
var areSameInstance = Object.ReferenceEquals(resolvedOnce, resolvedTwice); // f
```

```csharp
services.AddScoped<IProductImporter, ProductImporter>();
...
using var firstScope = host.Services.CreateScope()
var resolvedOnce = firstScope.ServiceProvider.GetRequiredService<IProductImporter>();
var resolvedTwice = firstScope.ServiceProvider.GetRequiredService<IProductImporter>();
var isSameInFirstScope = Object.ReferenceEquals(resolvedOnce, resolvedTwice); // true
using var secondScope = host.Services.CreateScope()
var resolvedThrice = secondScope.ServiceProvider.GetRequiredService<IProductImporter>();
var resolvedFourth = secondScope.ServiceProvider.GetRequiredService<IProductImporter>();
var isSameCrossScope = Object.ReferenceEquals(resolvedOnce, resolvedFourth); // false
var isSameInSecondScope = Object.ReferenceEquals(resolvedThrice, resolvedFourthTime); //t

```

## Avoiding dependency captivity

## Some Pointers

- If there is no state at all, choose transient
- If the state is derived or can be calculated on the fly, choose transient
- If the state relates to a single item, request or context, and needs to be shared between depending classes, choose scoped
- If the state relates to everything in the application, choose singleton
- Shy away from (too many) custom scopes; leave that to your framework
