using Analyzer.Core.Domain.Models;
using Microsoft.CodeAnalysis;
using Solution = Analyzer.Core.Domain.Models.Solution;

namespace Analyzer.Core.Application.Interfaces
{
    /// <summary>
    /// Service used to turn Solution into solution of project Compilations to prepare it for further analysis
    /// </summary>
    public interface ISolutionBuilderService
    {
        /// <summary>
        /// Accepts <see cref="SolutionReference"/> and converts it to <see cref="Solution"/>
        /// </summary>
        /// <param name="solutionReference">Solution to be analyzed</param>
        public Task<Solution> CompileAsync(SolutionReference solutionReference);
    }
}
