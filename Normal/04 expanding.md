## Expanding Importer

-   Organizing DI registrations
-   Specific situations
    - Application configuration
    - HttpClient
-   Service Locator pattern
-   DI and testability

## Introducing a composition root

```csharp
        services.AddSingleton<ImportStatistics>();
        
        services.AddSingleton<IGetImportStatistics>((serviceProvider) =>
        {
            return serviceProvider.GetRequiredService<ImportStatistics>();
        });

        services.AddSingleton<IWriteImportStatistics>((serviceProvider) =>
        {
            return serviceProvider.GetRequiredService<ImportStatistics>();
        });
```

```csharp
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        public async Task WhenItReadsNProductsFromSource_ThenItWritesNProductsToTarget(int numberOfProducts)
        {
            var productCounter = 0;

            _productSource
                .Setup(x => x.hasMoreProducts())
                .Callback(() => productCounter++)
                .Returns(() => productCounter <= numberOfProducts);

            await _subjectUnderTest.RunAsync();

            _productTarget
                .Verify(x => x.AddProduct(It.IsAny<Product>()), Times.Exactly(numberOfProducts));
        }
```