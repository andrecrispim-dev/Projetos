namespace Trial_Seguros.Front
{
    partial class frm_Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.dgPrincipal = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPF_CNPJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATA_NASCIMENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LOGRADOURO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAIRRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIDADE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESTADO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EMAIL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEGURADORA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NUMERO_APOLICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VEICULO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANO_VEICULO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLACA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHASSI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RENAVAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VIGENCIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DATA_VENCIMENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINC_CONDUTOR_NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINC_CONDUTOR_CPF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINC_CONDUTOR_NASCIMENTO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxFilter = new System.Windows.Forms.ComboBox();
            this.txbSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgPrincipal
            // 
            this.dgPrincipal.AllowUserToAddRows = false;
            this.dgPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPrincipal.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            this.dgPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPrincipal.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPrincipal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPrincipal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NOME,
            this.CPF_CNPJ,
            this.DATA_NASCIMENTO,
            this.LOGRADOURO,
            this.BAIRRO,
            this.CIDADE,
            this.ESTADO,
            this.Column1,
            this.EMAIL,
            this.SEGURADORA,
            this.NUMERO_APOLICE,
            this.VEICULO,
            this.ANO_VEICULO,
            this.PLACA,
            this.CHASSI,
            this.RENAVAM,
            this.VIGENCIA,
            this.DATA_VENCIMENTO,
            this.PRINC_CONDUTOR_NOME,
            this.PRINC_CONDUTOR_CPF,
            this.PRINC_CONDUTOR_NASCIMENTO,
            this.OBS});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(78)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPrincipal.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgPrincipal.EnableHeadersVisualStyles = false;
            this.dgPrincipal.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(183)))), ((int)(((byte)(189)))));
            this.dgPrincipal.Location = new System.Drawing.Point(11, 211);
            this.dgPrincipal.Margin = new System.Windows.Forms.Padding(2);
            this.dgPrincipal.Name = "dgPrincipal";
            this.dgPrincipal.ReadOnly = true;
            this.dgPrincipal.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(195)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(78)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPrincipal.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgPrincipal.RowHeadersVisible = false;
            this.dgPrincipal.RowHeadersWidth = 62;
            this.dgPrincipal.RowTemplate.Height = 28;
            this.dgPrincipal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPrincipal.Size = new System.Drawing.Size(1344, 498);
            this.dgPrincipal.TabIndex = 4;
            this.dgPrincipal.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPrincipal_CellContentDoubleClick);
            this.dgPrincipal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgPrincipal_KeyDown);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // NOME
            // 
            this.NOME.DataPropertyName = "NOME";
            this.NOME.HeaderText = "Nome";
            this.NOME.MinimumWidth = 8;
            this.NOME.Name = "NOME";
            this.NOME.ReadOnly = true;
            this.NOME.Width = 200;
            // 
            // CPF_CNPJ
            // 
            this.CPF_CNPJ.DataPropertyName = "CPF_CNPJ";
            this.CPF_CNPJ.HeaderText = "CPF/CNPJ";
            this.CPF_CNPJ.MinimumWidth = 8;
            this.CPF_CNPJ.Name = "CPF_CNPJ";
            this.CPF_CNPJ.ReadOnly = true;
            this.CPF_CNPJ.Width = 150;
            // 
            // DATA_NASCIMENTO
            // 
            this.DATA_NASCIMENTO.DataPropertyName = "DATA_NASCIMENTO";
            this.DATA_NASCIMENTO.HeaderText = "Data de Nascimento";
            this.DATA_NASCIMENTO.MinimumWidth = 8;
            this.DATA_NASCIMENTO.Name = "DATA_NASCIMENTO";
            this.DATA_NASCIMENTO.ReadOnly = true;
            // 
            // LOGRADOURO
            // 
            this.LOGRADOURO.DataPropertyName = "LOGRADOURO";
            this.LOGRADOURO.HeaderText = "Logradouro";
            this.LOGRADOURO.MinimumWidth = 8;
            this.LOGRADOURO.Name = "LOGRADOURO";
            this.LOGRADOURO.ReadOnly = true;
            this.LOGRADOURO.Width = 150;
            // 
            // BAIRRO
            // 
            this.BAIRRO.DataPropertyName = "BAIRRO";
            this.BAIRRO.HeaderText = "Bairro";
            this.BAIRRO.MinimumWidth = 8;
            this.BAIRRO.Name = "BAIRRO";
            this.BAIRRO.ReadOnly = true;
            this.BAIRRO.Width = 150;
            // 
            // CIDADE
            // 
            this.CIDADE.DataPropertyName = "CIDADE";
            this.CIDADE.HeaderText = "Cidade";
            this.CIDADE.MinimumWidth = 8;
            this.CIDADE.Name = "CIDADE";
            this.CIDADE.ReadOnly = true;
            this.CIDADE.Width = 150;
            // 
            // ESTADO
            // 
            this.ESTADO.DataPropertyName = "ESTADO";
            this.ESTADO.HeaderText = "Estado";
            this.ESTADO.MinimumWidth = 8;
            this.ESTADO.Name = "ESTADO";
            this.ESTADO.ReadOnly = true;
            this.ESTADO.Width = 50;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CEP";
            this.Column1.HeaderText = "CEP";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // EMAIL
            // 
            this.EMAIL.DataPropertyName = "EMAIL";
            this.EMAIL.HeaderText = "E-Mail";
            this.EMAIL.MinimumWidth = 8;
            this.EMAIL.Name = "EMAIL";
            this.EMAIL.ReadOnly = true;
            this.EMAIL.Width = 150;
            // 
            // SEGURADORA
            // 
            this.SEGURADORA.DataPropertyName = "SEGURADORA";
            this.SEGURADORA.HeaderText = "Seguradora";
            this.SEGURADORA.MinimumWidth = 8;
            this.SEGURADORA.Name = "SEGURADORA";
            this.SEGURADORA.ReadOnly = true;
            // 
            // NUMERO_APOLICE
            // 
            this.NUMERO_APOLICE.DataPropertyName = "NUMERO_APOLICE";
            this.NUMERO_APOLICE.HeaderText = "Numero da Apólice";
            this.NUMERO_APOLICE.Name = "NUMERO_APOLICE";
            this.NUMERO_APOLICE.ReadOnly = true;
            // 
            // VEICULO
            // 
            this.VEICULO.DataPropertyName = "VEICULO";
            this.VEICULO.HeaderText = "Veículo";
            this.VEICULO.MinimumWidth = 8;
            this.VEICULO.Name = "VEICULO";
            this.VEICULO.ReadOnly = true;
            // 
            // ANO_VEICULO
            // 
            this.ANO_VEICULO.DataPropertyName = "ANO_VEICULO";
            this.ANO_VEICULO.HeaderText = "Ano";
            this.ANO_VEICULO.Name = "ANO_VEICULO";
            this.ANO_VEICULO.ReadOnly = true;
            // 
            // PLACA
            // 
            this.PLACA.DataPropertyName = "PLACA";
            this.PLACA.HeaderText = "Placa";
            this.PLACA.Name = "PLACA";
            this.PLACA.ReadOnly = true;
            // 
            // CHASSI
            // 
            this.CHASSI.DataPropertyName = "CHASSI";
            this.CHASSI.HeaderText = "Chassi";
            this.CHASSI.Name = "CHASSI";
            this.CHASSI.ReadOnly = true;
            // 
            // RENAVAM
            // 
            this.RENAVAM.DataPropertyName = "RENAVAM";
            this.RENAVAM.HeaderText = "Renavam";
            this.RENAVAM.Name = "RENAVAM";
            this.RENAVAM.ReadOnly = true;
            // 
            // VIGENCIA
            // 
            this.VIGENCIA.DataPropertyName = "VIGENCIA";
            this.VIGENCIA.HeaderText = "Vigência";
            this.VIGENCIA.MinimumWidth = 8;
            this.VIGENCIA.Name = "VIGENCIA";
            this.VIGENCIA.ReadOnly = true;
            this.VIGENCIA.Width = 50;
            // 
            // DATA_VENCIMENTO
            // 
            this.DATA_VENCIMENTO.DataPropertyName = "DATA_VENCIMENTO";
            this.DATA_VENCIMENTO.HeaderText = "Data Vencimento";
            this.DATA_VENCIMENTO.MinimumWidth = 8;
            this.DATA_VENCIMENTO.Name = "DATA_VENCIMENTO";
            this.DATA_VENCIMENTO.ReadOnly = true;
            // 
            // PRINC_CONDUTOR_NOME
            // 
            this.PRINC_CONDUTOR_NOME.DataPropertyName = "PRINC_CONDUTOR_NOME";
            this.PRINC_CONDUTOR_NOME.HeaderText = "Nome do Condutor";
            this.PRINC_CONDUTOR_NOME.MinimumWidth = 8;
            this.PRINC_CONDUTOR_NOME.Name = "PRINC_CONDUTOR_NOME";
            this.PRINC_CONDUTOR_NOME.ReadOnly = true;
            this.PRINC_CONDUTOR_NOME.Width = 200;
            // 
            // PRINC_CONDUTOR_CPF
            // 
            this.PRINC_CONDUTOR_CPF.DataPropertyName = "PRINC_CONDUTOR_CPF";
            this.PRINC_CONDUTOR_CPF.HeaderText = "CPF do Condutor";
            this.PRINC_CONDUTOR_CPF.Name = "PRINC_CONDUTOR_CPF";
            this.PRINC_CONDUTOR_CPF.ReadOnly = true;
            // 
            // PRINC_CONDUTOR_NASCIMENTO
            // 
            this.PRINC_CONDUTOR_NASCIMENTO.DataPropertyName = "PRINC_CONDUTOR_NASCIMENTO";
            this.PRINC_CONDUTOR_NASCIMENTO.HeaderText = "Nascimento do Condutor";
            this.PRINC_CONDUTOR_NASCIMENTO.MinimumWidth = 8;
            this.PRINC_CONDUTOR_NASCIMENTO.Name = "PRINC_CONDUTOR_NASCIMENTO";
            this.PRINC_CONDUTOR_NASCIMENTO.ReadOnly = true;
            // 
            // OBS
            // 
            this.OBS.DataPropertyName = "OBS";
            this.OBS.HeaderText = "Obs";
            this.OBS.MinimumWidth = 8;
            this.OBS.Name = "OBS";
            this.OBS.ReadOnly = true;
            this.OBS.Width = 150;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1932, 31);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 66);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(45, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Filtrar por:";
            // 
            // cbxFilter
            // 
            this.cbxFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(195)))));
            this.cbxFilter.DisplayMember = "1";
            this.cbxFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxFilter.FormattingEnabled = true;
            this.cbxFilter.Items.AddRange(new object[] {
            "Nome do Cliente",
            "CPF / CNPJ",
            "Seguradora"});
            this.cbxFilter.Location = new System.Drawing.Point(48, 121);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(176, 21);
            this.cbxFilter.TabIndex = 0;
            // 
            // txbSearch
            // 
            this.txbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(195)))));
            this.txbSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSearch.Location = new System.Drawing.Point(48, 165);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Size = new System.Drawing.Size(381, 16);
            this.txbSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(435, 163);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Pesquisar";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1366, 720);
            this.shapeContainer1.TabIndex = 14;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 48;
            this.lineShape1.X2 = 413;
            this.lineShape1.Y1 = 185;
            this.lineShape1.Y2 = 185;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(78)))), ((int)(((byte)(81)))));
            this.label2.Location = new System.Drawing.Point(42, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 31);
            this.label2.TabIndex = 15;
            this.label2.Text = "Clientes";
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 720);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txbSearch);
            this.Controls.Add(this.cbxFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgPrincipal);
            this.Controls.Add(this.shapeContainer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trial Seguros";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Main_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_Main_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgPrincipal;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxFilter;
        private System.Windows.Forms.TextBox txbSearch;
        private System.Windows.Forms.Button btnSearch;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPF_CNPJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATA_NASCIMENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn LOGRADOURO;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAIRRO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIDADE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTADO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EMAIL;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEGURADORA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NUMERO_APOLICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn VEICULO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANO_VEICULO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PLACA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHASSI;
        private System.Windows.Forms.DataGridViewTextBoxColumn RENAVAM;
        private System.Windows.Forms.DataGridViewTextBoxColumn VIGENCIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn DATA_VENCIMENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINC_CONDUTOR_NOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINC_CONDUTOR_CPF;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINC_CONDUTOR_NASCIMENTO;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBS;
    }
}