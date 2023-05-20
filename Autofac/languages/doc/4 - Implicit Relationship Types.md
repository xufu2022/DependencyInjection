# Implicit Dependency

## Delayed Instantiation

-   Delayed instantiation implies a lazy dependency
-   used for an infrequently used or expensive-to-construct object
-   inject and store a Lazy<T>
-   Container will auto-initialize it with code that resolves a T
-   Getting myField.Value constructs and returns a fully-initialized T

