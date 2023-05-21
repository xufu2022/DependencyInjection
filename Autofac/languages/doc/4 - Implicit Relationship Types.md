# Implicit Dependency

## Delayed Instantiation

-   Delayed instantiation implies a lazy dependency
-   used for an infrequently used or expensive-to-construct object
-   inject and store a Lazy<T>
-   Container will auto-initialize it with code that resolves a T
-   Getting myField.Value constructs and returns a fully-initialized T

## Controlled Instantiation

-   An Owned dependency
-   can be released by owner when no longer required
-   particularly useful for IDisposable
    -   Typically, Autofac handles disposal
-   Inject and stored Owned<T>
    -   an autofac type!
-   Use myField.Value to access the owned object
-   Use myField.Dispose() any time you want

## Dynamic Instantiation

-   Injects an auto-generated factory for your component
-   Allows you to Resolve<T>() without typing yourself to Autofac
-   Inject and Store a component as Func<T>
-   Call myField() to construct the dependency via the container
-   The aboce will repect lifetime
