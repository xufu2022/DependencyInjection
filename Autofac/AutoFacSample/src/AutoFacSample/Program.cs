// See https://aka.ms/new-console-template for more information
using AutoClassLib;
using Autofac;
using Autofac.Core;
using AutoFacSample;
using System.Reflection;

var b = new ContainerBuilder();
b.RegisterType<HandlerFactory>().As<IHandlerFactory>();
b.RegisterSource(new HandlerRegistrationSource());
b.RegisterType<ConsumerA>();
b.RegisterType<ConsumerB>();

using (var c = b.Build())
{
    c.Resolve<ConsumerA>().DoWork();
    c.Resolve<ConsumerB>().DoWork();
}