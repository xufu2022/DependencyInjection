using Model;

namespace Transformation;

public interface IProductTransformer
{
    Product ApplyTransformations(Product product);
}
