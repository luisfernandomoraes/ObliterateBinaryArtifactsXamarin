using MetroFramework.Controls;

namespace ObliterateBinaryArtifactsXamarin
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txbProjetcPath = new MetroFramework.Controls.MetroTextBox();
            this.btnOpenProjectRootPage = new MetroFramework.Controls.MetroButton();
            this.btnObliterateFiles = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // txbProjetcPath
            // 
            // 
            // 
            // 
            this.txbProjetcPath.CustomButton.Image = null;
            this.txbProjetcPath.CustomButton.Location = new System.Drawing.Point(339, 2);
            this.txbProjetcPath.CustomButton.Name = "";
            this.txbProjetcPath.CustomButton.Size = new System.Drawing.Size(15, 15);
            this.txbProjetcPath.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txbProjetcPath.CustomButton.TabIndex = 1;
            this.txbProjetcPath.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txbProjetcPath.CustomButton.UseSelectable = true;
            this.txbProjetcPath.CustomButton.Visible = false;
            this.txbProjetcPath.Lines = new string[0];
            this.txbProjetcPath.Location = new System.Drawing.Point(8, 167);
            this.txbProjetcPath.MaxLength = 32767;
            this.txbProjetcPath.Name = "txbProjetcPath";
            this.txbProjetcPath.PasswordChar = '\0';
            this.txbProjetcPath.ReadOnly = true;
            this.txbProjetcPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txbProjetcPath.SelectedText = "";
            this.txbProjetcPath.SelectionLength = 0;
            this.txbProjetcPath.SelectionStart = 0;
            this.txbProjetcPath.ShortcutsEnabled = true;
            this.txbProjetcPath.Size = new System.Drawing.Size(409, 20);
            this.txbProjetcPath.TabIndex = 0;
            this.txbProjetcPath.UseSelectable = true;
            this.txbProjetcPath.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txbProjetcPath.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnOpenProjectRootPage
            // 
            this.btnOpenProjectRootPage.Location = new System.Drawing.Point(8, 138);
            this.btnOpenProjectRootPage.Name = "btnOpenProjectRootPage";
            this.btnOpenProjectRootPage.Size = new System.Drawing.Size(409, 23);
            this.btnOpenProjectRootPage.TabIndex = 1;
            this.btnOpenProjectRootPage.Text = "Selecionar pasta raiz do projeto";
            this.btnOpenProjectRootPage.UseSelectable = true;
            this.btnOpenProjectRootPage.Click += new System.EventHandler(this.btnOpenProjectRootPage_Click);
            // 
            // btnObliterateFiles
            // 
            this.btnObliterateFiles.BackColor = System.Drawing.Color.Red;
            this.btnObliterateFiles.ForeColor = System.Drawing.Color.White;
            this.btnObliterateFiles.Location = new System.Drawing.Point(8, 86);
            this.btnObliterateFiles.Name = "btnObliterateFiles";
            this.btnObliterateFiles.Size = new System.Drawing.Size(409, 29);
            this.btnObliterateFiles.TabIndex = 2;
            this.btnObliterateFiles.Text = "Obliterar Artefatos Binários";
            this.btnObliterateFiles.UseSelectable = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 346);
            this.Controls.Add(this.btnObliterateFiles);
            this.Controls.Add(this.btnOpenProjectRootPage);
            this.Controls.Add(this.txbProjetcPath);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Xamarin Clear Binary Artefacts";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroTextBox txbProjetcPath;
        private MetroButton btnOpenProjectRootPage;
        private MetroButton btnObliterateFiles;
    }
}

