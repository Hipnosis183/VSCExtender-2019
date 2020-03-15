namespace VSCELicenseExtender
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.Button_Extend = new System.Windows.Forms.Button();
            this.Label_Date = new System.Windows.Forms.Label();
            this.TextBox_Expiration = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Button_Extend
            // 
            this.Button_Extend.Location = new System.Drawing.Point(186, 12);
            this.Button_Extend.Name = "Button_Extend";
            this.Button_Extend.Size = new System.Drawing.Size(86, 23);
            this.Button_Extend.TabIndex = 0;
            this.Button_Extend.Text = "Extend";
            this.Button_Extend.UseVisualStyleBackColor = true;
            this.Button_Extend.Click += new System.EventHandler(this.Button_Extend_Click);
            // 
            // Label_Date
            // 
            this.Label_Date.AutoSize = true;
            this.Label_Date.Location = new System.Drawing.Point(12, 17);
            this.Label_Date.Name = "Label_Date";
            this.Label_Date.Size = new System.Drawing.Size(79, 13);
            this.Label_Date.TabIndex = 2;
            this.Label_Date.Text = "Expiration Date";
            // 
            // TextBox_Expiration
            // 
            this.TextBox_Expiration.Location = new System.Drawing.Point(97, 14);
            this.TextBox_Expiration.Name = "TextBox_Expiration";
            this.TextBox_Expiration.Size = new System.Drawing.Size(83, 20);
            this.TextBox_Expiration.TabIndex = 6;
            this.TextBox_Expiration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 47);
            this.Controls.Add(this.TextBox_Expiration);
            this.Controls.Add(this.Label_Date);
            this.Controls.Add(this.Button_Extend);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VSCELicenseExtender";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Extend;
        private System.Windows.Forms.Label Label_Date;
        private System.Windows.Forms.TextBox TextBox_Expiration;
    }
}
