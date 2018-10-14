namespace ExcelGuiFun
{
    partial class ImportDialog
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.wizardControl1 = new AeroWizard.WizardControl();
            this.PathPage = new AeroWizard.WizardPage();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.PathButton = new System.Windows.Forms.Button();
            this.CoordinatePage = new AeroWizard.WizardPage();
            this.ZuordnungButton = new System.Windows.Forms.Button();
            this.CoordinateRadio = new System.Windows.Forms.RadioButton();
            this.ProjectionBox = new System.Windows.Forms.ComboBox();
            this.YBox = new System.Windows.Forms.ComboBox();
            this.XBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.PathPage.SuspendLayout();
            this.CoordinatePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.BackColor = System.Drawing.Color.White;
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.Add(this.PathPage);
            this.wizardControl1.Pages.Add(this.CoordinatePage);
            this.wizardControl1.Size = new System.Drawing.Size(376, 445);
            this.wizardControl1.TabIndex = 0;
            this.wizardControl1.Text = "Wizard Title";
            // 
            // PathPage
            // 
            this.PathPage.Controls.Add(this.PathBox);
            this.PathPage.Controls.Add(this.PathButton);
            this.PathPage.Name = "PathPage";
            this.PathPage.Size = new System.Drawing.Size(329, 291);
            this.PathPage.TabIndex = 0;
            this.PathPage.Text = "Pfad";
            // 
            // PathBox
            // 
            this.PathBox.Location = new System.Drawing.Point(29, 37);
            this.PathBox.Name = "PathBox";
            this.PathBox.Size = new System.Drawing.Size(163, 23);
            this.PathBox.TabIndex = 1;
            // 
            // PathButton
            // 
            this.PathButton.Location = new System.Drawing.Point(227, 37);
            this.PathButton.Name = "PathButton";
            this.PathButton.Size = new System.Drawing.Size(75, 23);
            this.PathButton.TabIndex = 0;
            this.PathButton.Text = "Pfad";
            this.PathButton.UseVisualStyleBackColor = true;
            this.PathButton.Click += new System.EventHandler(this.PathButton_Click);
            // 
            // CoordinatePage
            // 
            this.CoordinatePage.Controls.Add(this.ZuordnungButton);
            this.CoordinatePage.Controls.Add(this.CoordinateRadio);
            this.CoordinatePage.Controls.Add(this.ProjectionBox);
            this.CoordinatePage.Controls.Add(this.YBox);
            this.CoordinatePage.Controls.Add(this.XBox);
            this.CoordinatePage.Controls.Add(this.label3);
            this.CoordinatePage.Controls.Add(this.label2);
            this.CoordinatePage.Controls.Add(this.label1);
            this.CoordinatePage.Name = "CoordinatePage";
            this.CoordinatePage.Size = new System.Drawing.Size(329, 291);
            this.CoordinatePage.TabIndex = 1;
            this.CoordinatePage.Text = "Koordinaten";
            // 
            // ZuordnungButton
            // 
            this.ZuordnungButton.Location = new System.Drawing.Point(167, 237);
            this.ZuordnungButton.Name = "ZuordnungButton";
            this.ZuordnungButton.Size = new System.Drawing.Size(121, 23);
            this.ZuordnungButton.TabIndex = 7;
            this.ZuordnungButton.Text = "Zuordnung anpassen";
            this.ZuordnungButton.UseVisualStyleBackColor = true;
            // 
            // CoordinateRadio
            // 
            this.CoordinateRadio.AutoSize = true;
            this.CoordinateRadio.Location = new System.Drawing.Point(43, 162);
            this.CoordinateRadio.Name = "CoordinateRadio";
            this.CoordinateRadio.Size = new System.Drawing.Size(122, 19);
            this.CoordinateRadio.TabIndex = 6;
            this.CoordinateRadio.TabStop = true;
            this.CoordinateRadio.Text = "Keine Koordinaten";
            this.CoordinateRadio.UseVisualStyleBackColor = true;
            // 
            // ProjectionBox
            // 
            this.ProjectionBox.FormattingEnabled = true;
            this.ProjectionBox.Location = new System.Drawing.Point(167, 107);
            this.ProjectionBox.Name = "ProjectionBox";
            this.ProjectionBox.Size = new System.Drawing.Size(121, 23);
            this.ProjectionBox.TabIndex = 5;
            // 
            // YBox
            // 
            this.YBox.FormattingEnabled = true;
            this.YBox.Location = new System.Drawing.Point(167, 66);
            this.YBox.Name = "YBox";
            this.YBox.Size = new System.Drawing.Size(121, 23);
            this.YBox.TabIndex = 4;
            // 
            // XBox
            // 
            this.XBox.FormattingEnabled = true;
            this.XBox.Location = new System.Drawing.Point(167, 28);
            this.XBox.Name = "XBox";
            this.XBox.Size = new System.Drawing.Size(121, 23);
            this.XBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Projektion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "X:";
            // 
            // ImportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 445);
            this.Controls.Add(this.wizardControl1);
            this.Name = "ImportDialog";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.PathPage.ResumeLayout(false);
            this.PathPage.PerformLayout();
            this.CoordinatePage.ResumeLayout(false);
            this.CoordinatePage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AeroWizard.WizardControl wizardControl1;
        private AeroWizard.WizardPage PathPage;
        private AeroWizard.WizardPage CoordinatePage;
        private System.Windows.Forms.TextBox PathBox;
        private System.Windows.Forms.Button PathButton;
        private System.Windows.Forms.Button ZuordnungButton;
        private System.Windows.Forms.RadioButton CoordinateRadio;
        private System.Windows.Forms.ComboBox ProjectionBox;
        private System.Windows.Forms.ComboBox YBox;
        private System.Windows.Forms.ComboBox XBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

