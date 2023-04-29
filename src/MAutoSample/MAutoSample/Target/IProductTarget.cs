using Model;

namespace Target;

public interface IProductTarget
{
    void Open();
    void AddProduct(Product product);
    void Close();
}
