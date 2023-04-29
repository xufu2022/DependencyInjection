# Common Pitfalls and Challenges

Reusing the same implementing type for multiple service types

Lifetimes are coupled to the service type, the implementing type

## Hanging State Due to Lifetime Issues

Hanging state is often caused by dependency captivity

Dependency constructor parameters that are known only after constructing the depending class

All created types are disposed when the container or scope is disposed

Scoped lifetimes resolved on a scope are disposed when the scope is disposed

The instance associated with the root container is never disposed


## Dos and Don’ts

- Do implement IDisposable in your classes as needed
- Don’t register IDisposable types as transient, instead instantiate them using a factory
- Don’t resolve IDisposable types in the root container
- Avoid (custom) scopes and scoped IDisposables when you can

