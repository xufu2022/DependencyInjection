using System.Collections.Concurrent;

namespace AutoClassLib;

public abstract class BaseHandler
{
    public virtual string Handle(string message)
    {
        return "Handled: " + message;
    }
}

public class HandlerA : BaseHandler
{
    public override string Handle(string message)
    {
        return "Handled by A: " + message;
    }
}

public class HandlerB : BaseHandler
{
    public override string Handle(string message)
    {
        return "Handled by B: " + message;
    }
}

public interface IHandlerFactory
{
    T GetHandler<T>() where T : BaseHandler;
}

public class HandlerFactory : IHandlerFactory
{
    public T GetHandler<T>() where T : BaseHandler
    {
        return Activator.CreateInstance<T>();
    }
}

public class ConsumerA
{
    private HandlerA handlerA;

    public ConsumerA(HandlerA handlerA)
    {
        if (handlerA == null)
        {
            throw new ArgumentNullException(paramName: nameof(handlerA));
        }
        this.handlerA = handlerA;
    }

    public void DoWork()
    {
        Console.WriteLine(handlerA.Handle("ConsumerA"));
    }
}

public class ConsumerB
{
    private HandlerB handlerB;


    public ConsumerB(HandlerB handlerB)
    {
        if (handlerB == null)
        {
            throw new ArgumentNullException(paramName: nameof(handlerB));
        }
        this.handlerB = handlerB;
    }

    public void DoWork()
    {
        Console.WriteLine(handlerB.Handle("ConsumerB"));
    }
}

