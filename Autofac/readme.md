# General

> Dependency Injection (DI): A software design pattern that allows objects to receive dependencies from an external source rather than creating them internally.

> Inversion of Control (IoC): A software design principle in which the control of object creation and lifecycle management is inverted, such that the framework or container is responsible for creating and managing objects.

> Component: In Autofac, a component is a class that provides a service to other components. Components are registered with the container and can be resolved through dependency injection.

> Service: A service is an interface or abstract class that defines a contract for a component. Services are used to request dependencies from the container.

> Lifetime Scope: A lifetime scope defines the lifespan of a component and its dependencies within the container. Components can be registered with different lifetime scopes to control how they are created and managed.

> Registration: The process of adding a component or service to the container. Registrations can include additional configuration options such as lifetime scope, instance per dependency, or singleton.

> Resolution: The process of retrieving a component or service from the container. Resolution can be automatic (when a component requests a dependency through constructor or property injection) or manual (when the component directly requests a dependency from the container).

> Container: The main object in Autofac that manages the registration, resolution, and lifetime of components and their dependencies. The container is typically created at application startup and used throughout the application.