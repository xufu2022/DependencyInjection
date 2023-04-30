using AutoClassLib;
using Autofac;

public class ParentChildModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Parent>();
        builder.Register(c => new Child() { Parent = c.Resolve<Parent>() });
    }
}