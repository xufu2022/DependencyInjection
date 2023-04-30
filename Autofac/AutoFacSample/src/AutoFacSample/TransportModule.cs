using AutoClassLib;
using Autofac;
using System.Diagnostics;

namespace AutoFacSample;

public class TransportModule : Module
{
    public bool ObeySpeedLimit { get; set; }

    protected override void Load(ContainerBuilder builder)
    {
        if (ObeySpeedLimit)
            builder.RegisterType<SaneDriver>().As<IDriver>();
        else
            builder.RegisterType<CrazyDriver>().As<IDriver>();

        builder.RegisterType<Truck>().As<IVehicle>();
    }
}