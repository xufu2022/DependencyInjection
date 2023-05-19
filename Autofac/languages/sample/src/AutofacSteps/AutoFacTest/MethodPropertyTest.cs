using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac.Core;

namespace AutoFacTest
{
    public class MethodPropertyTest
    {
        [Fact]
        public void TestParentChildFailed()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Parent>();
            builder.RegisterType<Child>();
            var container = builder.Build();
            var parent = container.Resolve<Child>().Parent;
            Console.WriteLine(parent);
            Assert.Null(parent);
        }        
        
        [Fact]
        public void TestParentChild()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Parent>();

            //builder.RegisterType<Child>().PropertiesAutowired();

            //builder.RegisterType<Child>()
            //  .WithProperty("Parent", new Parent());

            //builder.Register(c =>
            //{
            //    var child = new Child();
            //    child.SetParent(c.Resolve<Parent>());
            //    return child;
            //});

            builder.RegisterType<Child>()
                .OnActivated((IActivatedEventArgs<Child> e) =>
                {
                    var p = e.Context.Resolve<Parent>();
                    e.Instance.SetParent(p);
                });
            var container = builder.Build();
            var parent = container.Resolve<Child>().Parent;
            Console.WriteLine(parent);
            Assert.NotNull(parent);
        }

        [Fact]
        public void ScanForType()
        {
            var assembly = typeof(Parent).Assembly;
            var builder= new ContainerBuilder();

            //Instead of simply ignoring ConsoleLog, this code is registering ConsoleLog as a single instance (SingleInstance()) of the ILog interface (As<ILog>()).
            //This means whenever ILog is requested, the same ConsoleLog instance will be returned every time.
            //builder.RegisterAssemblyTypes(assembly)
            //    .Where(t => t.Name.EndsWith("Log"))
            //    .Except<SMSLog>()
            //    .Except<ConsoleLog>(c => c.As<ILog>().SingleInstance())
            //    .AsSelf();


            //excluding the SMSLog type from the registration process
            //As(t => t.GetInterfaces()[0]); This method is configuring the services to be resolved as their first interface
            // For example, if you have a class ErrorLog implementing interfaces ILog and IError, the ErrorLog class will be resolved as ILog when you inject ILog.This assumes that the types have at least one interface. If a type doesn't implement any interfaces or the order of interfaces is not consistent, this could lead to unexpected results or runtime errors.
            builder.RegisterAssemblyTypes(assembly)
                .Except<SMSLog>()
                .Where(t => t.Name.EndsWith("Log"))
                .As(t => t.GetInterfaces()[0]);

            var container = builder.Build();
            var log = container.Resolve<ILog>();
            Assert.NotNull(log);
        }
    }
}
