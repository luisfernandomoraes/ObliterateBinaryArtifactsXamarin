using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ObliterateBinaryArtifactsXamarin.Domain
{
    public class ObliterateBinaryFiles
    {
        /// <summary>
        /// Valida se o diretorio informado é o root, contendo o arquivo de .sln do projeto.
        /// </summary>
        /// <param name="projectPath"></param>
        /// <returns></returns>
        public bool IsValidPath(string projectPath)
        {
            if (!Directory.GetFiles(projectPath, "*.sln").Any()
                && !Directory.GetFiles(projectPath, "*.csproj").Any())
                return false;
            return true;

        }
        public void Delete(string projectPath)
        {

            if (!IsValidPath(projectPath))
                throw new Exception("Este não é um diretorio valido.");

            var binFolder = $"{projectPath}/bin";
            if (Directory.Exists(binFolder))
                Directory.Delete(binFolder, true);
            
            var objFolder = $"{projectPath}/obj";
            if (Directory.Exists(objFolder))
                Directory.Delete(binFolder, true);
        }

        public IEnumerable<string> GetAllDirectoriesWithBinOrObjFolders(string projectPath)
        {
            var directories = Directory.EnumerateDirectories(projectPath, "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith("bin") || s.EndsWith("obj")).ToList(); 

            return directories;
        }

        public void DeleteInSubFolders(string projectPath)
        {
            if (!IsValidPath(projectPath))
                throw new Exception("Este não é um diretorio valido.");

            var directories = GetAllDirectoriesWithBinOrObjFolders(projectPath);

            foreach (var directory in directories)
            {
                Directory.Delete(directory,true);
            }
        }
    }
}