using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Features.OwnedInstances;

namespace AutoFacTest
{


    public class ControlledInstantiation
    {
        private class Reporting
        {
            private Owned<ConsoleLog> log;

            public Reporting(Owned<ConsoleLog> log)
            {
                if (log == null)
                {
                    throw new ArgumentNullException(paramName: nameof(log));
                }
                this.log = log;
                Console.WriteLine("Reporting component created");
            }

            public void ReportOnce()
            {
                log.Value.Write("log started");
                log.Dispose();
            }
        }
        [Fact]
        public void Test()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleLog>();
            builder.RegisterType<Reporting>();
            var c=builder.Build();
            
            var report = c.Resolve<Reporting>();
                report.ReportOnce();
               // report.ReportOnce(); this will fail

            Assert.NotNull(report);

        }
    }
}
