using Model;

namespace Source;

public interface IPriceParser
{
    Money Parse(string price);
}
