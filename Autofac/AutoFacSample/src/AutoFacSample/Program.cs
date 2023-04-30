// See https://aka.ms/new-console-template for more information
using AutoClassLib;
using Autofac;
using Autofac.Core;
using System.Reflection;

var builder = new ContainerBuilder();
//builder.RegisterType<Parent>();

//builder.RegisterType<Child>()
//    .OnActivated((IActivatedEventArgs<Child> e) =>
//    {
//        var p = e.Context.Resolve<Parent>();
//        e.Instance.SetParent(p);
//    })
//    ;

//var container = builder.Build();
////var parent = container.Resolve<Parent>();
//var parent = container.Resolve<Child>().Parent;
//Console.WriteLine(parent);

var assembly = Assembly.GetExecutingAssembly();
builder.RegisterAssemblyTypes(assembly)
    .Where(t => t.Name.EndsWith("Log"))
    .Except<SMSLog>()
    .Except<ConsoleLog>(c => c.As<ILog>().SingleInstance())
    .AsSelf();
//log apart from smslog and consolelog


builder.RegisterAssemblyTypes(assembly)
    .Except<SMSLog>()
    .Where(t => t.Name.EndsWith("Log"))
    .As(t => t.GetInterfaces()[0]);

builder.RegisterAssemblyModules(typeof(Program).Assembly);

var container = builder.Build();
Console.WriteLine(container.Resolve<Child>().Parent);
//specifies that each type should be registered with the container using its first implemented interface as the service type.
//This means that when a component requests an instance of an interface that is implemented by one of the registered types, the container will resolve and return an instance of that type.


public class ParentChildModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<Parent>();
        builder.Register(c => new Child() { Parent = c.Resolve<Parent>() });
    }
}
