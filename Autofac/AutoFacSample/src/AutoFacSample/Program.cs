// See https://aka.ms/new-console-template for more information
using AutoClassLib;
using Autofac;
using Autofac.Core;
using AutoFacSample;
using System.Reflection;

var builder = new ContainerBuilder();
builder.RegisterModule(new TransportModule { ObeySpeedLimit = true });
using (var c = builder.Build())
{
    c.Resolve<IVehicle>().Go();
}