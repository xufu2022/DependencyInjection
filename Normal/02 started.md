## Registering types

When registering types you specify the lifetime, the requested service type, and the implementing type. If these types are the same, you provide it once.

- Resolves and creates types directly
- Provides dependencies of types you work with
- Provides dependencies to dependencies of the types you work with
- Manage the lifetimes of types

## Resolving types


When resolving a type, you request an instance of a service type. The container will find the implementing type, instantiate it if needed, and return it to you.

If the implementing type has dependencies, they are provided to the implementing type as well.

host.Services.GetRequiredService<ProductImporter>();