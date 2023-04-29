using Model;

namespace Target;

public interface IProductFormatter
{
    string Format(Product product);
    string GetHeaderLine();
}
