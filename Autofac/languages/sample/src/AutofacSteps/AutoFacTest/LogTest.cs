

using AutofacSamples;

namespace AutoFacTest
{
    public class LogTest
    {
        [Fact]
        public void Sample1Test()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleLog>().As<ILog>().AsSelf();
            builder.RegisterType<Engine>();
            builder.RegisterType<Car>();
            var container=builder.Build();
            //var log = new ConsoleLog();
            //var engine = new Engine(log);
            //var car = new Car(engine, log);

            //if want to resolve consolelog, will failed
            //the above  builder.RegisterType<ConsoleLog>().As<ILog>();
            //without AsSelf, cannot resolve directly
            var log =container.Resolve<ConsoleLog>();
            Assert.NotNull(log);


            var car = container.Resolve<Car>();
            Assert.NotNull(car);
            car.Go();

        }
    }

}
