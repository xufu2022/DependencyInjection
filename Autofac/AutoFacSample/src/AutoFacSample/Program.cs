// See https://aka.ms/new-console-template for more information
using AutoClassLib;
using Autofac;
using Autofac.Core;
using System.Reflection;

var builder = new ContainerBuilder();
builder.RegisterType<ConsoleLog>()
    .InstancePerMatchingLifetimeScope("foo")
    ;
//  This means that the container will create one instance of ConsoleLog per lifetime scope that has a tag of "foo".
var container = builder.Build();

using (var scope1 = container.BeginLifetimeScope("foo"))
{
    for (int i = 0; i < 3; i++)
    {
        scope1.Resolve<ConsoleLog>();
    }

    using (var scope2 = scope1.BeginLifetimeScope())
    {
        for (int i = 0; i < 3; i++)
        {
            scope2.Resolve<ConsoleLog>();
        }
    }
}

builder.RegisterType<Parent>();
builder.RegisterType<Child>()
    .OnActivating(a =>
    {
        Console.WriteLine("Child activating");
        //a.Instance.Parent = a.Context.Resolve<Parent>();

        a.ReplaceInstance(new BadChild());
    })
    .OnActivated(a =>
    {
        Console.WriteLine("Child activated");
    })
    .OnRelease(a =>
    {
        Console.WriteLine("Child about to be removed");
    });

builder.RegisterType<ConsoleLog>().AsSelf();
builder.Register<ILog>(c => c.Resolve<ConsoleLog>())
    .OnActivating(a => a.ReplaceInstance(new SMSLog("+123456")));

using (var scope = builder.Build().BeginLifetimeScope())
{
    var child = scope.Resolve<Child>();
    var parent = child.Parent;
    Console.WriteLine(child);
    Console.WriteLine(parent);

    var log = scope.Resolve<ILog>();
    log.Write("Testing");
}



using (var scope3 = container.BeginLifetimeScope())
{
    scope3.Resolve<ConsoleLog>();
}