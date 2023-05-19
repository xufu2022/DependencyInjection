

using AutofacSamples;

namespace AutoFacTest
{
    public class LogTest
    {
        [Fact]
        public void Sample1Test()
        {
            var builder = new ContainerBuilder();

            //the last one win, so emaillog win
            //builder.RegisterType<ConsoleLog>().As<ILog>().AsSelf();
            //builder.RegisterType<EmailLog>().As<ILog>().AsSelf();

            //the  so EmailLog win even through it is second because of PreserveExistingDefaults
            builder.RegisterType<EmailLog>().As<ILog>()
                .AsSelf(); ;
            builder.RegisterType<ConsoleLog>().As<ILog>()
                .As<IConsole>()
                .AsSelf().PreserveExistingDefaults();

            builder.RegisterType<Engine>();
            //default using most populated constructive one
            builder.RegisterType<Car>().UsingConstructor(typeof(Engine));
            var container=builder.Build();
            //var log = new ConsoleLog();
            //var engine = new Engine(log);
            //var car = new Car(engine, log);

            //if want to resolve consolelog, will failed
            //the above  builder.RegisterType<ConsoleLog>().As<ILog>();
            //without AsSelf, cannot resolve directly
            var log = container.Resolve<ConsoleLog>();
            Assert.NotNull(log);


            var car = container.Resolve<Car>();
            Assert.NotNull(car);
            car.Go();

        }
    }

}
