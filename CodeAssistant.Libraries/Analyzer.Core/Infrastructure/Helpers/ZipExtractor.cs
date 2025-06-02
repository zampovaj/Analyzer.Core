using System.IO.Compression;

namespace Analyzer.Core.Infrastructure.Helpers
{
    /// <summary>
    /// Extracts and saves .zip file to local directory.
    /// </summary>
    public class ZipExtractor : IZipExtractor
    {
        /// <summary>
        /// Represents the path in which we save the extrcated file.
        /// </summary>
        private readonly string _basePath;
        /// <summary>
        /// Initializes new <see cref="ZipExtractor"/> instance.
        /// Assigns value to <see cref="_basePath"/>.
        /// </summary>
        public ZipExtractor() 
        {
            _basePath = Path.Combine(Path.GetTempPath(), "SolutionUploads");
        }

        /// <summary>
        /// Takes a .zip file, extracts it, and saves it to local directory.
        /// Runs asynchronously.
        /// </summary>
        /// <param name="zipFile">The .zip file to be saved. Comes from API request.</param>
        /// <returns><see cref="Task"/> containing string with path to the extracted file.</returns>
        public async Task<string> SaveAndExtractAsync(byte[] zipBytes)
        {
            // Create unique folder
            var id = Guid.NewGuid().ToString();
            var uploadPath = Path.Combine(_basePath, id);
            Directory.CreateDirectory(uploadPath);

            // Save ZIP file
            var zipPath = Path.Combine(uploadPath, "solution.zip");
            await File.WriteAllBytesAsync(zipPath, zipBytes);

            // Extract and clean up
            ZipFile.ExtractToDirectory(zipPath, uploadPath);
            File.Delete(zipPath);

            return uploadPath;
        }
    }
}
