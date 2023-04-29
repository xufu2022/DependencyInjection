using Shared;
using Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Target;
using Transformation;

namespace MAutoSample
{

    public class ProductImporter
    {
        private readonly IProductSource _productSource;
        private readonly IProductTransformer _productTransformer;
        private readonly IProductTarget _productTarget;
        private readonly IImportStatistics _importStatistics;

        public ProductImporter(
            IProductSource productSource,
            IProductTransformer productTransformer,
            IProductTarget productTarget,
            IImportStatistics importStatistics)
        {
            _productSource = productSource;
            _productTransformer = productTransformer;
            _productTarget = productTarget;
            _importStatistics = importStatistics;
        }

        public void Run()
        {
            _productSource.Open();
            _productTarget.Open();

            while (_productSource.hasMoreProducts())
            {
                var product = _productSource.GetNextProduct();

                var transformedProduct = _productTransformer.ApplyTransformations(product);

                _productTarget.AddProduct(transformedProduct);
            }

            _productSource.Close();
            _productTarget.Close();

            Console.WriteLine("Importing complete!");
            Console.WriteLine(_importStatistics.GetStatistics());
        }
    }
}
