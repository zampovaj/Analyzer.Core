using Analyzer.Core.Application.Interfaces;
using Analyzer.Core.Domain.Interfaces;
using Analyzer.Core.Infrastructure.ApplicationServices;
using Analyzer.Core.Infrastructure.Helpers;
using Analyzer.Core.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Analyzer.Core.Infrastructure
{
    /// <summary>
    /// Provides extension method to register infrastructure-level dependencies.
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Adds services from the Infrastructure layer to the dependency injection container.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The updated service collection.</returns>
        public static IServiceCollection AddAnalyzerCore(this IServiceCollection services)
        {
            services.AddScoped<ISyntaxParser, SyntaxParser>();
            services.AddScoped<ICompilationBuilder, CompilationBuilder>();
            services.AddScoped<IDiagnosticsMapper, DiagnosticsMapper>();
            services.AddScoped<ICodeAnalyzer, RoslynCodeAnalyzer>();
            services.AddScoped<ISolutionAnalyzer, RoslynSolutionAnalyzer>();
            services.AddScoped<IZipHandler, ZipHandler>();
            services.AddScoped<IZipExtractor, ZipExtractor>();
            services.AddScoped<ISolutionFinder, SolutionFinder>();
            services.AddScoped<ISolutionBuilderService, SolutionMSBuilderService>();
            services.AddScoped<IPathTrimmer, PathTrimmer>();
            return services;
        }
    }

}
