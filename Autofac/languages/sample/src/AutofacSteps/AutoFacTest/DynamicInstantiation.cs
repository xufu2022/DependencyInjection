using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFacTest
{


    public class DynamicInstantiation
    {
        private class Reporting
        {
            private Func<ConsoleLog> _consoleLog;

            public Reporting(Func<ConsoleLog> consoleLog)
            {
                if (_consoleLog == null)
                {
                    throw new ArgumentNullException(paramName: nameof(_consoleLog));
                }
                this._consoleLog = consoleLog;

            }

            public void Report()
            {
                _consoleLog().Write("Reporting to console");
                _consoleLog().Write(" And again");
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
