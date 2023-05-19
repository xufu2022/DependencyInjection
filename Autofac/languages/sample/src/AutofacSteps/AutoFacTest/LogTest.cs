

using AutofacSamples;

namespace AutoFacTest
{
    public class LogTest
    {
        [Fact]
        public void Sample1Test()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleLog>().As<ILog>();

            //var engine = new Engine(new ConsoleLog(), 123);
            //builder.RegisterInstance(engine);
            //builder.RegisterType<Engine>();

            //specify a lambda which take exponent context and it creates a new engine where the log is still created by that component by calling resolve, busing using component context
            builder.Register((c => new Engine(c.Resolve<ILog>(), 123)));
            builder.RegisterType<Car>();
            var container=builder.Build();

            var car = container.Resolve<Car>();
            Assert.NotNull(car);
            car.Go();

        }
    }

}
