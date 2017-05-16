using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObliterateBinaryArtifactsXamarin.Domain;

namespace ObliterateBinaryArtifactsXamarin.Test
{
    [TestClass]
    public class ConfigRepositoryTest
    {
        private ConfigRepository _configRepositoryInstance;
        private string _path = "C:\\Users\\Usuario\\Documents\\ProjectTest\\ProjectTarget";
        [TestInitialize]
        public void TestInit()
        {
            _configRepositoryInstance = new ConfigRepository();
        }

        [TestMethod]
        public void DEVE_CARREGAR_INFORMACOES_DO_ARQUIVO_DE_CONFIGURACAO()
        {
            // Arrange
            _configRepositoryInstance.ProjectPath = _path;

            // Action 
            _configRepositoryInstance.Save();
            _configRepositoryInstance = new ConfigRepository();
            _configRepositoryInstance.LoadConfigurations();


            // Assert
            var filePath = TestUtils.GetInstanceField(_configRepositoryInstance.GetType(), _configRepositoryInstance, "_filePath") as string;
            Assert.IsTrue(File.Exists(filePath));
            Assert.AreEqual(_configRepositoryInstance.ProjectPath,_path);
        }

        [TestMethod]
        public void DEVE_SALVAR_EM_ARQUIVO_AS_CONFIGURAÇÕES_SETADAS()
        {
            // Arrange
            var pathTest = _path + "\\packges";

            // Action
            _configRepositoryInstance.ProjectPath = pathTest;
            _configRepositoryInstance.Save();

            _configRepositoryInstance = new ConfigRepository();
            _configRepositoryInstance.LoadConfigurations();

            // Assert
            Assert.AreEqual(_configRepositoryInstance.ProjectPath, pathTest);
        }
    }
}