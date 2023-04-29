using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IImportStatistics
    {
        void IncrementImportCount();
        void IncrementOutputCount();

        string GetStatistics();
        void IncrementTransformationCount();
    }

}
