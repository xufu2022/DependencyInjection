using Autofac.Core;
using AutofacSamples;
using System;

namespace AutoFacTest
{
    public class LogTest
    {
        [Fact]
        public void Sample1Test()
        {
            var builder = new ContainerBuilder();
            // named parameter
            //builder.RegisterType<SMSLog>()
            //  .As<ILog>()
            //  .WithParameter("phoneNumber", "+12345678");

            // typed parameter
            //builder.RegisterType<SMSLog>()
            //  .As<ILog>()
            //  .WithParameter(new TypedParameter(typeof(string), "+12345678"));

            // resolved parameter
            //builder.RegisterType<SMSLog>()
            //  .As<ILog>()
            //  .WithParameter(
            //    new ResolvedParameter(
            //      // predicate
            //      (pi, ctx) => pi.ParameterType == typeof(string) && pi.Name == "phoneNumber",
            //      // value accessor
            //      (pi, ctx) => "+12345678"
            //    )
            //  );
            Random random = new Random();

            //var log = container.Resolve<ILog>();

            //register the smslog but phone number need to resolve at runtime
            builder.Register((c, p) => new SMSLog(p.Named<string>("phoneNumber")))
                .As<ILog>();
            //          
            var container = builder.Build();

            //resolve at runtime
            var log = container.Resolve<ILog>(new NamedParameter("phoneNumber", random.Next().ToString()));

            Assert.NotNull(log);
            log.Write("hi");
        }
    }
}