using Microsoft.Extensions.DependencyInjection;
using Model;
using Shared;
using Transformation.Transformations;

namespace Transformation;

public class ProductTransformer : IProductTransformer
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IImportStatistics _importStatistics;

    public ProductTransformer(IServiceScopeFactory serviceScopeFactory, IImportStatistics importStatistics)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _importStatistics = importStatistics;
    }

    public Product ApplyTransformations(Product product)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var transformationContext = scope.ServiceProvider.GetRequiredService<IProductTransformationContext>();
        transformationContext.SetProduct(product);

        var nameCapitalizer = scope.ServiceProvider.GetRequiredService<INameDecapitaliser>();
        var currencyNormalizer = scope.ServiceProvider.GetRequiredService<ICurrencyNormalizer>();

        nameCapitalizer.Execute();
        currencyNormalizer.Execute();

        if (transformationContext.IsProductChanged())
        {
            _importStatistics.IncrementTransformationCount();
        }

        return transformationContext.GetProduct();
    }
}
