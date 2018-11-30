namespace UPVApp
{
    partial class ChooseAddressForm
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
            this.components = new System.ComponentModel.Container();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.addListCbo = new System.Windows.Forms.ComboBox();
            this.editLbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(163, 50);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cancelBtn_MouseDown);
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(9, 50);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 14;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // addListCbo
            // 
            this.addListCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addListCbo.FormattingEnabled = true;
            this.addListCbo.Location = new System.Drawing.Point(62, 23);
            this.addListCbo.Name = "addListCbo";
            this.addListCbo.Size = new System.Drawing.Size(121, 21);
            this.addListCbo.TabIndex = 13;
            this.addListCbo.Validating += new System.ComponentModel.CancelEventHandler(this.addListCbo_Validating);
            this.addListCbo.Validated += new System.EventHandler(this.addListCbo_Validated);
            // 
            // editLbl
            // 
            this.editLbl.AutoSize = true;
            this.editLbl.Location = new System.Drawing.Point(62, 7);
            this.editLbl.Name = "editLbl";
            this.editLbl.Size = new System.Drawing.Size(120, 13);
            this.editLbl.TabIndex = 12;
            this.editLbl.Text = "Choose Address to Edit:";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ChooseAddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 86);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.addListCbo);
            this.Controls.Add(this.editLbl);
            this.Name = "ChooseAddressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose Address";
            this.Load += new System.EventHandler(this.ChooseAddressForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.ComboBox addListCbo;
        private System.Windows.Forms.Label editLbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}