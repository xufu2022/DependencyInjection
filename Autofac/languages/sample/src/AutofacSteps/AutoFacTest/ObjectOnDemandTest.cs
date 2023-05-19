using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFacTest
{
    public class Entity
    {
        public delegate Entity Factory();
        public static Random random = new Random();
        private int number;

        public Entity()
        {
            number = random.Next();
        }

        public override string ToString()
        {
            return "test" + number;
        }
    }

    public class ViewModel
    {
        private readonly Entity.Factory _entFactory;
        //private readonly IContainer _container;
        //public ViewModel(IContainer container)
        //{
        //    _container = container;
        //}
        //public void Method()
        //{
        //    var entity = _container.Resolve<Entity>();
        //}

        //rather using the method above, we can use delegateFactory
        //just inject Entity.Factory into constructor
        public ViewModel(Entity.Factory entFactory)
        {
            _entFactory = entFactory;
        }

        public void Method()
        {
            var entity = _entFactory();
            Console.WriteLine(entity);
        }
    }
    public class ObjectOnDemandTest
    {
        [Fact]
        public void Method()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<Entity>().InstancePerDependency();
            cb.RegisterType<ViewModel>();

            var container = cb.Build();
            var vm = container.Resolve<ViewModel>();
            var entity = container.Resolve<Entity.Factory>();
            vm.Method();
            vm.Method();
        }
    }
}