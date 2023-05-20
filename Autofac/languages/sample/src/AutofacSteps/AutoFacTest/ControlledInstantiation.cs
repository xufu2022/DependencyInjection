using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFacTest
{


    public class DelayInstantiation
    {
        private class Reporting
        {
            private Lazy<ConsoleLog> log;

            public Reporting(Lazy<ConsoleLog> log)
            {
                if (log == null)
                {
                    throw new ArgumentNullException(paramName: nameof(log));
                }
                this.log = log;
                Console.WriteLine("Reporting component created");
            }

            public void Report()
            {
                log.Value.Write("log started");
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
                report.Report();

            Assert.NotNull(report);

        }
    }
}
