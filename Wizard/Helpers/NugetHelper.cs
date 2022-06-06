using NuGet.Common;
using NuGet.Configuration;
using NuGet.Frameworks;
using NuGet.Packaging;
using NuGet.Packaging.Core;
using NuGet.Packaging.Signing;
using NuGet.Protocol.Core.Types;
using NuGet.Resolver;
using NuGet.Versioning;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wizard.Helpers
{
    public class NugetHelper
    {
        [DllImport("shell32.dll")]
        static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, [Out] StringBuilder lpszPath, int nFolder, bool fCreate);
        const int CSIDL_LOCAL_APPDATA = 0x1c;

        //framework - "net6.0"
        public async void AddNuget(string packageId, string version, string framework, string solutionPath)
        {
            //var packageId = "newtonsoft.json";
            var settings = Settings.LoadDefaultSettings(root: null);
            
            var sourceRepositoryProvider = new SourceRepositoryProvider(settings, Repository.Provider.GetCoreV3());

            string source = "https://pkgs.dev.azure.com/theworksdev/_packaging/theworksdev/nuget/v3/index.json";
            sourceRepositoryProvider.CreateRepository(new PackageSource(source));

            using (var cacheContext = new SourceCacheContext())
            {
                var repositories = sourceRepositoryProvider.GetRepositories();
                var availablePackages = new HashSet<SourcePackageDependencyInfo>(PackageIdentityComparer.Default);
                //await GetPackageDependencies(
                //    new PackageIdentity("newtonsoft.json", NuGetVersion.Parse("12.0.1")),
                //    NuGetFramework.ParseFolder("net6.0"), cacheContext, NullLogger.Instance, repositories, availablePackages);

                await GetPackageDependencies(
                    new PackageIdentity(packageId, NuGetVersion.Parse(version)),
                    NuGetFramework.ParseFolder(framework), cacheContext, NullLogger.Instance, repositories, availablePackages);

                var resolverContext = new PackageResolverContext(
                    DependencyBehavior.Lowest,
                    new[] { packageId },
                    Enumerable.Empty<string>(),
                    Enumerable.Empty<PackageReference>(),
                    Enumerable.Empty<PackageIdentity>(),
                    availablePackages,
                    sourceRepositoryProvider.GetRepositories().Select(s => s.PackageSource),
                    NullLogger.Instance);

                var resolver = new PackageResolver();
                var packagesToInstall = resolver.Resolve(resolverContext, CancellationToken.None)
                    .Select(p => availablePackages.Single(x => PackageIdentityComparer.Default.Equals(x, p)));

                foreach (var packageToInstall in packagesToInstall)
                {
                    Console.WriteLine(packageToInstall);
                }

                foreach (var packageToInstall in packagesToInstall)
                {
                    var downloadResource = await packageToInstall.Source.GetResourceAsync<DownloadResource>(CancellationToken.None);
                    var downloadResult = await downloadResource.GetDownloadResourceResultAsync(
                        packageToInstall,
                        new PackageDownloadContext(cacheContext),
                        SettingsUtility.GetGlobalPackagesFolder(settings),
                        NullLogger.Instance, CancellationToken.None);

                    //string path = @"D:\Projects\Templates\NuGetTesting\packages";
                    StringBuilder allUserProfile = new StringBuilder(260);
                    SHGetSpecialFolderPath(IntPtr.Zero, allUserProfile, CSIDL_LOCAL_APPDATA, false);
                    string commonDesktopPath = allUserProfile.ToString();

                    string thePath = commonDesktopPath.Substring(0, commonDesktopPath.LastIndexOf("AppData"));

                    //MessageBox.Show("Path: " + thePath);

                    string nugetPath =  thePath + ".nuget";
                    string path = nugetPath + "\\packages";

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    //var packagePathResolver = new PackagePathResolver(Path.GetFullPath("packages"));
                    var packagePathResolver = new PackagePathResolver(path);
                    ClientPolicyContext ctx = ClientPolicyContext.GetClientPolicy(settings, NullLogger.Instance);
                    var packageExtractionContext = new PackageExtractionContext(
                        PackageSaveMode.Defaultv3,
                        XmlDocFileSaveMode.None,
                        ctx,
                        NullLogger.Instance);

                    await PackageExtractor.ExtractPackageAsync(
                                downloadResult.PackageSource,
                                downloadResult.PackageStream,
                                packagePathResolver,
                                packageExtractionContext,
                                CancellationToken.None);
                }
            }
        }

        private async Task GetPackageDependencies(PackageIdentity package,
            NuGetFramework framework,
            SourceCacheContext cacheContext,
            ILogger logger,
            IEnumerable<SourceRepository> repositories,
            ISet<SourcePackageDependencyInfo> availablePackages)
        {
            if (availablePackages.Contains(package)) return;

            foreach (var sourceRepository in repositories)
            {
                var dependencyInfoResource = await sourceRepository.GetResourceAsync<DependencyInfoResource>();
                var dependencyInfo = await dependencyInfoResource.ResolvePackage(
                    package, framework, cacheContext, logger, CancellationToken.None);

                if (dependencyInfo == null) continue;

                availablePackages.Add(dependencyInfo);
                foreach (var dependency in dependencyInfo.Dependencies)
                {
                    await GetPackageDependencies(
                        new PackageIdentity(dependency.Id, dependency.VersionRange.MinVersion),
                        framework, cacheContext, logger, repositories, availablePackages);
                }
            }
        }
    }
}
