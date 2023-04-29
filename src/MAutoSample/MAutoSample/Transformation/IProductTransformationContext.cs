using Model;

namespace Transformation;

public interface IProductTransformationContext
{
    void SetProduct(Product product);
    public Product GetProduct();
    bool IsProductChanged();
}
