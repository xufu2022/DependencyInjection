using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFacTest
{

    public class ParentChildModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Parent>();
            builder.Register(c => new Child() { Parent = c.Resolve<Parent>() });
        }
    }
    public class ModuleParentChildTest
    {
        [Fact]
        public void Test()
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(typeof(ParentChildModule).Assembly);
            var container = builder.Build();
            var parent = container.Resolve<Child>().Parent;
            Assert.NotNull(parent);
        }
    }
}
