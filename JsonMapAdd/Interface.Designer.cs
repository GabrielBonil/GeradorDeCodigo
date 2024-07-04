
namespace JsonMapAdd
{
    partial class Interface
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChangeLabel = new System.Windows.Forms.Label();
            this.KeyLabel = new System.Windows.Forms.Label();
            this.filtroLabel = new System.Windows.Forms.Label();
            this.tipoLabel = new System.Windows.Forms.Label();
            this.changeText = new System.Windows.Forms.TextBox();
            this.keyText = new System.Windows.Forms.TextBox();
            this.filterOneTxt = new System.Windows.Forms.TextBox();
            this.tipoBuscaTxt = new System.Windows.Forms.ComboBox();
            this.AddBtn = new System.Windows.Forms.Button();
            this.filterTwoTxt = new System.Windows.Forms.TextBox();
            this.JsonList = new System.Windows.Forms.CheckedListBox();
            this.slctRmvBtn = new System.Windows.Forms.Button();
            this.attBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ChangeLabel
            // 
            this.ChangeLabel.AutoSize = true;
            this.ChangeLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChangeLabel.Location = new System.Drawing.Point(423, 66);
            this.ChangeLabel.Name = "ChangeLabel";
            this.ChangeLabel.Size = new System.Drawing.Size(101, 21);
            this.ChangeLabel.TabIndex = 1;
            this.ChangeLabel.Text = "Onde mudar:";
            // 
            // KeyLabel
            // 
            this.KeyLabel.AutoSize = true;
            this.KeyLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.KeyLabel.Location = new System.Drawing.Point(439, 108);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(85, 21);
            this.KeyLabel.TabIndex = 2;
            this.KeyLabel.Text = "Key da tag:";
            // 
            // filtroLabel
            // 
            this.filtroLabel.AutoSize = true;
            this.filtroLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filtroLabel.Location = new System.Drawing.Point(468, 149);
            this.filtroLabel.Name = "filtroLabel";
            this.filtroLabel.Size = new System.Drawing.Size(56, 21);
            this.filtroLabel.TabIndex = 3;
            this.filtroLabel.Text = "Filtros:";
            this.filtroLabel.Click += new System.EventHandler(this.filtroLabel_Click);
            // 
            // tipoLabel
            // 
            this.tipoLabel.AutoSize = true;
            this.tipoLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tipoLabel.Location = new System.Drawing.Point(416, 192);
            this.tipoLabel.Name = "tipoLabel";
            this.tipoLabel.Size = new System.Drawing.Size(108, 21);
            this.tipoLabel.TabIndex = 4;
            this.tipoLabel.Text = "Tipo de busca:";
            // 
            // changeText
            // 
            this.changeText.Location = new System.Drawing.Point(530, 65);
            this.changeText.Name = "changeText";
            this.changeText.Size = new System.Drawing.Size(203, 23);
            this.changeText.TabIndex = 5;
            this.changeText.TextChanged += new System.EventHandler(this.changeText_TextChanged);
            // 
            // keyText
            // 
            this.keyText.Location = new System.Drawing.Point(530, 107);
            this.keyText.Name = "keyText";
            this.keyText.Size = new System.Drawing.Size(203, 23);
            this.keyText.TabIndex = 6;
            this.keyText.TextChanged += new System.EventHandler(this.keyText_TextChanged);
            // 
            // filterOneTxt
            // 
            this.filterOneTxt.Location = new System.Drawing.Point(530, 148);
            this.filterOneTxt.Name = "filterOneTxt";
            this.filterOneTxt.Size = new System.Drawing.Size(98, 23);
            this.filterOneTxt.TabIndex = 7;
            this.filterOneTxt.TextChanged += new System.EventHandler(this.filterOneTxt_TextChanged);
            // 
            // tipoBuscaTxt
            // 
            this.tipoBuscaTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoBuscaTxt.FormattingEnabled = true;
            this.tipoBuscaTxt.Location = new System.Drawing.Point(530, 191);
            this.tipoBuscaTxt.Name = "tipoBuscaTxt";
            this.tipoBuscaTxt.Size = new System.Drawing.Size(203, 23);
            this.tipoBuscaTxt.TabIndex = 8;
            this.tipoBuscaTxt.SelectedIndexChanged += new System.EventHandler(this.tipoBuscaTxt_SelectedIndexChanged);
            // 
            // AddBtn
            // 
            this.AddBtn.Enabled = false;
            this.AddBtn.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.AddBtn.Location = new System.Drawing.Point(530, 245);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(203, 47);
            this.AddBtn.TabIndex = 9;
            this.AddBtn.Text = "Adicionar";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // filterTwoTxt
            // 
            this.filterTwoTxt.Enabled = false;
            this.filterTwoTxt.Location = new System.Drawing.Point(634, 148);
            this.filterTwoTxt.Name = "filterTwoTxt";
            this.filterTwoTxt.Size = new System.Drawing.Size(99, 23);
            this.filterTwoTxt.TabIndex = 10;
            // 
            // JsonList
            // 
            this.JsonList.FormattingEnabled = true;
            this.JsonList.Location = new System.Drawing.Point(30, 37);
            this.JsonList.Name = "JsonList";
            this.JsonList.Size = new System.Drawing.Size(361, 454);
            this.JsonList.TabIndex = 11;
            // 
            // slctRmvBtn
            // 
            this.slctRmvBtn.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.slctRmvBtn.Location = new System.Drawing.Point(397, 428);
            this.slctRmvBtn.Name = "slctRmvBtn";
            this.slctRmvBtn.Size = new System.Drawing.Size(127, 63);
            this.slctRmvBtn.TabIndex = 12;
            this.slctRmvBtn.Text = "Remover Selecionados";
            this.slctRmvBtn.UseVisualStyleBackColor = true;
            this.slctRmvBtn.Click += new System.EventHandler(this.slctRmvBtn_Click);
            // 
            // attBtn
            // 
            this.attBtn.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.attBtn.Location = new System.Drawing.Point(360, 4);
            this.attBtn.Name = "attBtn";
            this.attBtn.Size = new System.Drawing.Size(31, 27);
            this.attBtn.TabIndex = 13;
            this.attBtn.Text = "🔁";
            this.attBtn.UseVisualStyleBackColor = true;
            this.attBtn.Click += new System.EventHandler(this.attBtn_Click);
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 535);
            this.Controls.Add(this.attBtn);
            this.Controls.Add(this.slctRmvBtn);
            this.Controls.Add(this.JsonList);
            this.Controls.Add(this.filterTwoTxt);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.tipoBuscaTxt);
            this.Controls.Add(this.filterOneTxt);
            this.Controls.Add(this.keyText);
            this.Controls.Add(this.changeText);
            this.Controls.Add(this.tipoLabel);
            this.Controls.Add(this.filtroLabel);
            this.Controls.Add(this.KeyLabel);
            this.Controls.Add(this.ChangeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Interface";
            this.Text = "JsonController";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ChangeLabel;
        private System.Windows.Forms.Label KeyLabel;
        private System.Windows.Forms.Label filtroLabel;
        private System.Windows.Forms.Label tipoLabel;
        private System.Windows.Forms.TextBox changeText;
        private System.Windows.Forms.TextBox keyText;
        private System.Windows.Forms.TextBox filterOneTxt;
        private System.Windows.Forms.ComboBox tipoBuscaTxt;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.TextBox filterTwoTxt;
        private System.Windows.Forms.CheckedListBox JsonList;
        private System.Windows.Forms.Button slctRmvBtn;
        private System.Windows.Forms.Button attBtn;
    }
}

