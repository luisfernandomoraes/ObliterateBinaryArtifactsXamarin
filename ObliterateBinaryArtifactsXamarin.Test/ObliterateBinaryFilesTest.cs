using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObliterateBinaryArtifactsXamarin.Domain;

namespace ObliterateBinaryArtifactsXamarin.Test
{
    [TestClass]
    public class ObliterateBinaryFilesTest
    {
        private string _path = "C:\\ProjectTarget";

        [TestInitialize]
        public void TestInit()
        {
            // Copiar binarios para a pasta de teste. 
            //var directory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString())
            //    .ToString()).ToString();

            // Caso o projeto de teste seja modificado, deve ser alterado manualmente o resultado esperado do teste
            // DEVE_RETORNAR_TODOS_OS_SUBDIR_QUE_CONTENHAM_BIN_E_OBJ.
            var directorySource = "C:\\ProjectTestBase";
            DirectoryHelper.DirectoryCopy(directorySource, _path, true);

        }

        [TestMethod]
        public void DEVE_DELETAR_PASTAS_OBJ_E_BIN()
        {
            // Arrange
            var obliterateBinaryFiles = new ObliterateBinaryFiles();

            // Act
            obliterateBinaryFiles.Delete(projectPath: _path);

            // Assert

            var binFolderExists = Directory.Exists($"{_path}/bin");
            var objFolderExists = Directory.Exists($"{_path}/obj");

            Assert.IsTrue(!binFolderExists);
            Assert.IsTrue(!objFolderExists);
        }

        [TestMethod]
        public void DEVE_RETORNAR_TODOS_OS_SUBDIR_QUE_CONTENHAM_BIN_E_OBJ()
        {
            // Arrange
            var obliterateBinaryFiles = new ObliterateBinaryFiles();

            //Act
            var directories = obliterateBinaryFiles.GetAllDirectoriesWithBinOrObjFolders(_path);

            //Assert
            Assert.AreEqual(8,directories.Count());
        }

        [TestMethod]
        public void DEVE_DELETAR_BIN_OBJ_EM_SUB_PASTAS()
        {
            // Arrange
            var obliterateBinaryFiles = new ObliterateBinaryFiles();

            //Act
            obliterateBinaryFiles.DeleteInSubFolders(_path);
            
            // Assert
            var dirs = obliterateBinaryFiles.GetAllDirectoriesWithBinOrObjFolders(_path);
            Assert.AreEqual(0,dirs.Count());
        }

        [TestMethod]
        public void DEVE_VALIDAR_SE_E_PASTA_RAIZ_DO_PROJETO()
        {
            // Arrange
            var obliterateBinaryFiles = new ObliterateBinaryFiles();

            // Act
            var isValidPath = obliterateBinaryFiles.IsValidPath(projectPath: _path);
            var isInvalidValidPath = obliterateBinaryFiles.IsValidPath(projectPath: _path+ "\\packages");
            // Assert

            var objFolderExists = Directory.Exists($"{_path}/obj");

            Assert.AreEqual(true,isValidPath);
            Assert.AreEqual(false, isInvalidValidPath);
        }
    }
}
