using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using ObliterateBinaryArtifactsXamarin.Domain;

namespace ObliterateBinaryArtifactsXamarin
{
    public partial class MainForm : MetroForm
    {
        private Domain.ConfigRepository _configRepository;
        private Domain.ObliterateBinaryFiles _obliterateBinaryFiles;
        public MainForm()
        {
            InitializeComponent();
            btnObliterateFiles.UseCustomForeColor = true;
            btnObliterateFiles.UseCustomBackColor = true;
            _configRepository = new ConfigRepository();
            RefreshForm();
            _obliterateBinaryFiles = new ObliterateBinaryFiles();
        }

        private void RefreshForm()
        {
            _configRepository.LoadConfigurations();
            if (!string.IsNullOrEmpty(_configRepository.ProjectPath))
            {
                txbProjetcPath.Text = _configRepository.ProjectPath;
                btnObliterateFiles.Enabled = true;
            }
            else
                btnObliterateFiles.Enabled = false;
        }

        private void btnOpenProjectRootPage_Click(object sender, EventArgs e)
        {


            using (var fbd = new FolderBrowserDialog())
            {
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    if (_obliterateBinaryFiles.IsValidPath(fbd.SelectedPath))
                    {
                        _configRepository.ProjectPath = fbd.SelectedPath;
                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            bool isSaved = _configRepository.Save();
                            if (isSaved)
                            {
                                MetroMessageBox.Show(this, "Informações salvas com sucesso.", this.Text,
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                RefreshForm();
                            }
                        }
                        catch (Exception exception)
                        {
                            MetroMessageBox.Show(this,
                                $"Ocorreu um erro ao salvar as informações. Descrição: {exception}", this.Text,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            Cursor.Current = Cursors.Default;
                        }
                    }
                    else

                        MetroMessageBox.Show(this, $"O diretorio selecionado \"{fbd.SelectedPath}\" é inválido. Por favor, selecione o diretorio raiz do projeto.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnObliterateFiles_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_configRepository.ProjectPath))
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _obliterateBinaryFiles.DeleteInSubFolders(_configRepository.ProjectPath);
                    MetroMessageBox.Show(this, "Arquivos deletados com sucesso!", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MetroMessageBox.Show(this,
                        $"Ocorreu um erro ao salvar as informações. Descrição: {exception}", this.Text,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
        }
    }
}
