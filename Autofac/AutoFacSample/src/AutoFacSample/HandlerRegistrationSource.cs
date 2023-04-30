using System.Collections.Concurrent;
using AutoClassLib;
using Autofac;
using Autofac.Core;
using Autofac.Core.Activators.Delegate;
using Autofac.Core.Lifetime;
using Autofac.Core.Registration;

namespace AutoFacSample;

public class HandlerRegistrationSource : IRegistrationSource
{
    public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<ServiceRegistration>> registrationAccessor)
    {
        var swt = service as IServiceWithType;
        if (swt == null
            || swt.ServiceType == null
            || !swt.ServiceType.IsAssignableTo<BaseHandler>())
        {
            yield break;
        }

        yield return new ComponentRegistration(
            Guid.NewGuid(),
            new DelegateActivator(
                swt.ServiceType,
                (c, p) =>
                {
                    var provider = c.Resolve<IHandlerFactory>();
                    var method = provider.GetType().GetMethod("GetHandler").MakeGenericMethod(swt.ServiceType);
                    return method.Invoke(provider, null);
                }
            ),
            new CurrentScopeLifetime(),
            InstanceSharing.None,
            InstanceOwnership.OwnedByLifetimeScope,
            new[] { service },
            new ConcurrentDictionary<string, object>());
    }


    public bool IsAdapterForIndividualComponents => false;
}