using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFacTest
{
    public class Service
    {
        public string DoSomthing(int value)
        {
            return $"I have {value}";
        }
    }

    public class DomainObject
    {
        private Service service;
        private int value;

        // parameter int value need to be the same as constructor
        public delegate DomainObject Factory(int value);
        public DomainObject(Service service, int value)
        {
            this.service = service;
            this.value = value;
        }

        public override string ToString()
        {
            return service.DoSomthing(value);
        }
    }
    public class DelegateFactoryTest
    {
        [Fact]
        public void Test()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<Service>(); 
            cb.RegisterType<DomainObject>();

            var container=cb.Build();
            var dor=container.Resolve<DomainObject>(new PositionalParameter(1,42)); //int value is position 1
            Assert.NotNull(dor);

            var factory = container.Resolve<DomainObject.Factory>();
            var dor2 = factory(42);

            Assert.NotNull(dor2);



        }
    }
}
