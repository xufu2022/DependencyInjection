// See https://aka.ms/new-console-template for more information
using AutoClassLib;
using Autofac;

var builder = new ContainerBuilder();
//builder.RegisterType<EmailLog>()
//    .As<ILog>();
//builder.RegisterType<ConsoleLog>()
//    .As<ILog>()
//    .As<IConsole>()
//    .PreserveExistingDefaults();
//builder.RegisterType<Engine>();
//builder.RegisterType<Car>();


builder.RegisterType<ConsoleLog>().As<ILog>();
//var log = new ConsoleLog();
//builder.RegisterInstance(log).As<ILog>();

//builder.RegisterType<Engine>();
//builder.RegisterType<Car>()
//    .UsingConstructor(typeof(Engine));
//.UsingConstructor(typeof(Engine), typeof(ILog));


builder.Register((IComponentContext c) =>
    new Engine(c.Resolve<ILog>(), 123));
builder.RegisterType<Car>();

builder.RegisterGeneric(typeof(List<>)).As(typeof(IList<>));

IContainer container = builder.Build();

//var log = container.Resolve<ILog>();

var myList = container.Resolve<IList<int>>();
Console.WriteLine(myList.GetType());

var car = container.Resolve<Car>();
car.Go();
