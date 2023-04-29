﻿using Microsoft.Extensions.DependencyInjection;

namespace CompositionRoot
{
    public static class DIRegistrations
    {
        public static IServiceCollection RegisterProductTransformations(this IServiceCollection services, Action<ProductTransformationOptions> optionsProvider)
        {
            var options = new ProductTransformationOptions();
            optionsProvider(options);

            services.AddScoped<IProductTransformationContext, ProductTransformationContext>();
            services.AddScoped<IProductTransformation, NameDecapitaliser>();

            if (options.EnableCurrencyNormalizer)
            {
                services.AddScoped<IProductTransformation, CurrencyNormalizer>();
            }
            else
            {
                services.AddScoped<IProductTransformation, NullCurrencyNormalizer>();
            }

            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IProductTransformation, ReferenceAdder>();
            services.AddScoped<IReferenceGenerator, ReferenceGenerator>();
            services.AddSingleton<IIncrementingCounter, IncrementingCounter>();

            return services;
        }
    }
}