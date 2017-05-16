using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ObliterateBinaryArtifactsXamarin.Domain
{
    public class ConfigRepository
    {
        [JsonIgnore]
        private readonly string _filePath;

        #region Fields&Properties
        /// <summary>
        /// Propriedade que contém o diretorio raiz do projeto selecionado.
        /// </summary>
        private string _projectPath = string.Empty;
        public string ProjectPath
        {
            get { return _projectPath; }
            set { _projectPath = value; }
        }

        #endregion

        /// <summary>
        /// Ctor da classe, que cria o arquivo para persistir informações caso elas não existam.
        /// </summary>
        public ConfigRepository()
        {
            string currentDir = Directory.GetCurrentDirectory();
            _filePath = $"{currentDir}\\obliterate_configs.json";

            if (!File.Exists(_filePath))
                File.Create(_filePath).Close();
        }

        /// <summary>
        /// Carrega as informações do arquivo json, previamente persistidas.
        /// </summary>
        public void LoadConfigurations()
        {
            using (StreamReader r = new StreamReader(_filePath))
            {
                string json = r.ReadToEnd();
                var deserializeObject = JsonConvert.DeserializeObject<ConfigRepository>(json);
                if(deserializeObject == null) return;
                this.ProjectPath = deserializeObject.ProjectPath;
            }
        }

        /// <summary>
        /// Persiste as informações no arquivo de configuração json.
        /// </summary>
        /// <returns>true caso tenha sido executado com exito ou uma exception caso tenha ocorrido algum erro.</returns>
        public bool Save()
        {
            string json = JsonConvert.SerializeObject(this,Formatting.None);
            File.WriteAllText(_filePath, json);
            return true;
        }
    }
}