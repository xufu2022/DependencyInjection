# Autofac Terminology

> Container: 

The container is a central part of any Autofac application. It's responsible for creating and managing objects and their dependencies. It is often initialized at the start of the application and used throughout the lifespan of the app.

> Module: 

In Autofac, a module is a small, independent piece of configuration. Modules are a great way to package up related registration code and share it between applications.

> Registration: 

This is the process of mapping a service to a component. The component is the implementation of a service.

> Lifetime Scope: 

This term refers to when Autofac creates and disposes instances of registered services. There are several lifetime scopes, such as Singleton (one instance shared among all requests), InstancePerDependency (a new instance for each request), InstancePerLifetimeScope (one instance per request in the same or nested lifetime scope), and InstancePerMatchingLifetimeScope (one instance per request in a lifetime scope that matches the provided tag).

> Resolve: 

This is the process of creating an instance of a registered service, taking into account the specified lifetime scope and any dependencies that the service might have.

> Component/Service: 

A component is a specific implementation of a service. A service is typically an interface that the component implements.

> Dependency Injection: 

This is a design pattern used to increase code modularity and enhance testability. In Autofac, dependency injection is done by 'injecting' dependencies (services) into a component via its constructor, property, or method.

> Decorator: 

This is a pattern where you wrap a component with additional behavior without modifying the underlying component. In Autofac, you can achieve this using the Decorate registration extension.

> Direct Registration: 

When you register a type directly with Autofac, i.e., it's not automatically registered by scanning assemblies.

> Assembly Scanning: 

A feature where Autofac will scan an assembly and register components based on conventions, attributes, or a specified predicate.

## Summary

> Two step constructor

-   used a container builder to actually register the components
-   using container to resolve each required component

> types are registered with

- builder.RegisterType<Foo>() : Registers a component of type Foo
- builder.RegisterType<Foo>().As<IFoo> : register component of type Foo to provide service IFoo, if register both, need AsSelf

> By default, last registration for the service is the one that's used

- builder.RegisterType<ConsoleLog>().As<ILog>()
- builder.RegisterType<EmailLog>().As<ILog>()
- container.Resolve<ILog>(); // yields an instance of EmailLog
- use PreserveExistingDefaults to prevent changing default

> Constructor with most arguments is chosen by default

- builder.RegisterType<Car>().UsingConstructor(typeof(Engine),typeof(Foo));
- can register instances instead of types (useful for testing)
- Lambda expression components can specify exactly which constructor to call
- builder.Register((c => new Engine(c.Resolve<ILog>(), 123)));
- The IcomponentContext lambda argument should be used to resolve any dependencies. Do not try to use the container itself.
- Open generic components let you serve IFoo<X> for every rquest of Foo<X>


