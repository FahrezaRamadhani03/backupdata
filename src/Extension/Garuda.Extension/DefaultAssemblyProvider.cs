// <copyright file="DefaultAssemblyProvider.cs" company="CV Garuda Infinity Kreasindo">
// Copyright (c) CV Garuda Infinity Kreasindo. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Garuda.Extension.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.Extensions.Logging;

namespace Garuda.Extension
{
    public class DefaultAssemblyProvider : IAssemblyProvider
    {
        protected ILogger _logger;

        public Func<Assembly, bool> IsCandidateAssembly { get; set; }

        public Func<Library, bool> IsCandidateCompilationLibrary { get; set; }

        public DefaultAssemblyProvider(IServiceProvider serviceProvider)
        {
            _logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger("Garuda.Extension");
            IsCandidateAssembly = assembly =>
              !assembly.FullName.StartsWith("System", StringComparison.OrdinalIgnoreCase) &&
              !assembly.FullName.StartsWith("Microsoft", StringComparison.OrdinalIgnoreCase);

            IsCandidateCompilationLibrary = library =>
              !library.Name.StartsWith("mscorlib", StringComparison.OrdinalIgnoreCase) &&
              !library.Name.StartsWith("netstandard", StringComparison.OrdinalIgnoreCase) &&
              !library.Name.StartsWith("System", StringComparison.OrdinalIgnoreCase) &&
              !library.Name.StartsWith("Microsoft", StringComparison.OrdinalIgnoreCase) &&
              !library.Name.StartsWith("WindowsBase", StringComparison.OrdinalIgnoreCase);
        }

        public IEnumerable<Assembly> GetAssemblies(string path, bool includingSubpaths)
        {
            List<Assembly> assemblies = new List<Assembly>();

            GetAssembliesFromDependencyContext(assemblies);
            GetAssembliesFromPath(assemblies, path, includingSubpaths);
            return assemblies;
        }

        private void GetAssembliesFromDependencyContext(List<Assembly> assemblies)
        {
            _logger.LogInformation("Discovering and loading assemblies from DependencyContext");

            foreach (CompilationLibrary compilationLibrary in DependencyContext.Default.CompileLibraries)
            {
                if (IsCandidateCompilationLibrary(compilationLibrary))
                {
                    Assembly assembly = null;

                    try
                    {
                        assembly = AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(compilationLibrary.Name));

                        if (!assemblies.Any(a => string.Equals(a.FullName, assembly.FullName, StringComparison.OrdinalIgnoreCase)))
                        {
                            assemblies.Add(assembly);
                            _logger.LogInformation("Assembly '{0}' is discovered and loaded", assembly.FullName);
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.LogWarning("Error loading assembly '{0}'", compilationLibrary.Name);
                        _logger.LogWarning(e.ToString());
                    }
                }
            }
        }

        private void GetAssembliesFromPath(List<Assembly> assemblies, string path, bool includingSubpaths)
        {
            if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
            {
                _logger.LogInformation("Discovering and loading assemblies from path '{0}'", path);

                foreach (string extensionPath in Directory.EnumerateFiles(path, "*.dll"))
                {
                    Assembly assembly = null;

                    try
                    {
                        assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(extensionPath);

                        if (IsCandidateAssembly(assembly) && !assemblies.Any(a => string.Equals(a.FullName, assembly.FullName, StringComparison.OrdinalIgnoreCase)))
                        {
                            assemblies.Add(assembly);
                            _logger.LogInformation("Assembly '{0}' is discovered and loaded", assembly.FullName);
                        }
                    }
                    catch (Exception e)
                    {
                        _logger.LogWarning("Error loading assembly '{0}'", extensionPath);
                        _logger.LogWarning(e.ToString());
                    }
                }

                if (includingSubpaths)
                {
                    foreach (string subpath in Directory.GetDirectories(path))
                    {
                        GetAssembliesFromPath(assemblies, subpath, includingSubpaths);
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(path))
                {
                    _logger.LogWarning("Discovering and loading assemblies from path skipped: path not provided", path);
                }
                else
                {
                    _logger.LogWarning("Discovering and loading assemblies from path '{0}' skipped: path not found", path);
                }
            }
        }
    }
}