using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
