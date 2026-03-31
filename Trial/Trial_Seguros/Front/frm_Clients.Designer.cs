namespace Trial_Seguros.Front
{
    partial class frm_Clients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Clients));
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxSeguradora = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxUF = new System.Windows.Forms.ComboBox();
            this.txbCidade = new System.Windows.Forms.TextBox();
            this.txbEmail = new System.Windows.Forms.TextBox();
            this.txbCEP = new System.Windows.Forms.TextBox();
            this.txbBairro = new System.Windows.Forms.TextBox();
            this.txbLogradouro = new System.Windows.Forms.TextBox();
            this.txbCPFCNPJ = new System.Windows.Forms.TextBox();
            this.txbNome = new System.Windows.Forms.TextBox();
            this.labelSucess = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.tbxObs = new System.Windows.Forms.TextBox();
            this.tbxCondutorCPF = new System.Windows.Forms.TextBox();
            this.txbCondutorNome = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxVigencia = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxAnoVeiculo = new System.Windows.Forms.ComboBox();
            this.tbxRenavam = new System.Windows.Forms.TextBox();
            this.tbxChassi = new System.Windows.Forms.TextBox();
            this.txbPlaca = new System.Windows.Forms.TextBox();
            this.txbVeiculo = new System.Windows.Forms.TextBox();
            this.chkPrincipalCondutor = new System.Windows.Forms.CheckBox();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.lineShape13 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape12 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape11 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape10 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.lineShape9 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape8 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape7 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape6 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape5 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape15 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape14 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txbDataNasc = new System.Windows.Forms.TextBox();
            this.txbDataNascCond = new System.Windows.Forms.TextBox();
            this.rbJuridica = new System.Windows.Forms.RadioButton();
            this.rbFisica = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(78)))), ((int)(((byte)(81)))));
            this.label2.Location = new System.Drawing.Point(42, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cliente";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(45, 516);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 43;
            this.label4.Text = "Seguradora:";
            // 
            // cbxSeguradora
            // 
            this.cbxSeguradora.Enabled = false;
            this.cbxSeguradora.FormattingEnabled = true;
            this.cbxSeguradora.Location = new System.Drawing.Point(47, 536);
            this.cbxSeguradora.Name = "cbxSeguradora";
            this.cbxSeguradora.Size = new System.Drawing.Size(121, 21);
            this.cbxSeguradora.TabIndex = 10;
            this.cbxSeguradora.SelectedIndexChanged += new System.EventHandler(this.cbxSeguradora_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(405, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 17);
            this.label3.TabIndex = 42;
            this.label3.Text = "UF:";
            // 
            // cbxUF
            // 
            this.cbxUF.Enabled = false;
            this.cbxUF.FormattingEnabled = true;
            this.cbxUF.Items.AddRange(new object[] {
            "AC",
            "AL",
            "AM",
            "AP",
            "BA",
            "CE",
            "DF",
            "ES",
            "EXT",
            "GO",
            "MA",
            "MG",
            "MS",
            "MT",
            "PA",
            "PB",
            "PE",
            "PI",
            "PR",
            "RJ",
            "RN",
            "RO",
            "RR",
            "RS",
            "SC",
            "SE",
            "SP",
            "TO"});
            this.cbxUF.Location = new System.Drawing.Point(408, 347);
            this.cbxUF.Name = "cbxUF";
            this.cbxUF.Size = new System.Drawing.Size(82, 21);
            this.cbxUF.TabIndex = 7;
            // 
            // txbCidade
            // 
            this.txbCidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(195)))));
            this.txbCidade.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbCidade.Enabled = false;
            this.txbCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCidade.Location = new System.Drawing.Point(227, 346);
            this.txbCidade.Name = "txbCidade";
            this.txbCidade.Size = new System.Drawing.Size(175, 16);
            this.txbCidade.TabIndex = 6;
            this.txbCidade.Text = "Cidade";
            // 
            // txbEmail
            // 
            this.txbEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(170)))), ((int)(((byte)(172)))));
            this.txbEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbEmail.Enabled = false;
            this.txbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbEmail.Location = new System.Drawing.Point(47, 467);
            this.txbEmail.Name = "txbEmail";
            this.txbEmail.Size = new System.Drawing.Size(443, 16);
            this.txbEmail.TabIndex = 9;
            this.txbEmail.Text = "Email";
            // 
            // txbCEP
            // 
            this.txbCEP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(182)))), ((int)(((byte)(185)))));
            this.txbCEP.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbCEP.Enabled = false;
            this.txbCEP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCEP.Location = new System.Drawing.Point(47, 406);
            this.txbCEP.Name = "txbCEP";
            this.txbCEP.Size = new System.Drawing.Size(168, 16);
            this.txbCEP.TabIndex = 8;
            this.txbCEP.Text = "CEP";
            // 
            // txbBairro
            // 
            this.txbBairro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(195)))));
            this.txbBairro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbBairro.Enabled = false;
            this.txbBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbBairro.Location = new System.Drawing.Point(47, 346);
            this.txbBairro.Name = "txbBairro";
            this.txbBairro.Size = new System.Drawing.Size(168, 16);
            this.txbBairro.TabIndex = 5;
            this.txbBairro.Text = "Bairro";
            // 
            // txbLogradouro
            // 
            this.txbLogradouro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(195)))));
            this.txbLogradouro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbLogradouro.Enabled = false;
            this.txbLogradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLogradouro.Location = new System.Drawing.Point(47, 286);
            this.txbLogradouro.Name = "txbLogradouro";
            this.txbLogradouro.Size = new System.Drawing.Size(443, 16);
            this.txbLogradouro.TabIndex = 4;
            this.txbLogradouro.Text = "Logradouro";
            // 
            // txbCPFCNPJ
            // 
            this.txbCPFCNPJ.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(195)))));
            this.txbCPFCNPJ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbCPFCNPJ.Enabled = false;
            this.txbCPFCNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCPFCNPJ.Location = new System.Drawing.Point(47, 226);
            this.txbCPFCNPJ.Name = "txbCPFCNPJ";
            this.txbCPFCNPJ.Size = new System.Drawing.Size(219, 16);
            this.txbCPFCNPJ.TabIndex = 2;
            this.txbCPFCNPJ.Text = "CPF / CNPJ";
            this.txbCPFCNPJ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCPFCNPJ_KeyPress);
            // 
            // txbNome
            // 
            this.txbNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(195)))));
            this.txbNome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbNome.Enabled = false;
            this.txbNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNome.Location = new System.Drawing.Point(47, 164);
            this.txbNome.Name = "txbNome";
            this.txbNome.Size = new System.Drawing.Size(443, 16);
            this.txbNome.TabIndex = 1;
            this.txbNome.Text = "Nome";
            this.txbNome.Enter += new System.EventHandler(this.txbNome_Enter);
            // 
            // labelSucess
            // 
            this.labelSucess.AutoSize = true;
            this.labelSucess.BackColor = System.Drawing.Color.Transparent;
            this.labelSucess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSucess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.labelSucess.Location = new System.Drawing.Point(1119, 245);
            this.labelSucess.Name = "labelSucess";
            this.labelSucess.Size = new System.Drawing.Size(181, 17);
            this.labelSucess.TabIndex = 59;
            this.labelSucess.Text = "Cliente Salvo com Sucesso!";
            this.labelSucess.Visible = false;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(195)))));
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnSalvar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.Location = new System.Drawing.Point(1068, 123);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(264, 119);
            this.btnSalvar.TabIndex = 58;
            this.btnSalvar.Text = "          Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Visible = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // tbxObs
            // 
            this.tbxObs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(195)))));
            this.tbxObs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxObs.Enabled = false;
            this.tbxObs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxObs.Location = new System.Drawing.Point(1068, 285);
            this.tbxObs.Multiline = true;
            this.tbxObs.Name = "tbxObs";
            this.tbxObs.Size = new System.Drawing.Size(264, 83);
            this.tbxObs.TabIndex = 21;
            this.tbxObs.Text = "Obs";
            // 
            // tbxCondutorCPF
            // 
            this.tbxCondutorCPF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.tbxCondutorCPF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxCondutorCPF.Enabled = false;
            this.tbxCondutorCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCondutorCPF.Location = new System.Drawing.Point(564, 527);
            this.tbxCondutorCPF.Name = "tbxCondutorCPF";
            this.tbxCondutorCPF.Size = new System.Drawing.Size(218, 16);
            this.tbxCondutorCPF.TabIndex = 19;
            this.tbxCondutorCPF.Text = "CPF do Condutor";
            // 
            // txbCondutorNome
            // 
            this.txbCondutorNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(170)))), ((int)(((byte)(172)))));
            this.txbCondutorNome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbCondutorNome.Enabled = false;
            this.txbCondutorNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCondutorNome.Location = new System.Drawing.Point(564, 467);
            this.txbCondutorNome.Name = "txbCondutorNome";
            this.txbCondutorNome.Size = new System.Drawing.Size(443, 16);
            this.txbCondutorNome.TabIndex = 18;
            this.txbCondutorNome.Text = "Nome do Condutor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(805, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 54;
            this.label6.Text = "Vigência:";
            // 
            // cbxVigencia
            // 
            this.cbxVigencia.Enabled = false;
            this.cbxVigencia.FormattingEnabled = true;
            this.cbxVigencia.Items.AddRange(new object[] {
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024"});
            this.cbxVigencia.Location = new System.Drawing.Point(808, 341);
            this.cbxVigencia.Name = "cbxVigencia";
            this.cbxVigencia.Size = new System.Drawing.Size(121, 21);
            this.cbxVigencia.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(805, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 17);
            this.label5.TabIndex = 52;
            this.label5.Text = "Ano:";
            // 
            // cbxAnoVeiculo
            // 
            this.cbxAnoVeiculo.Enabled = false;
            this.cbxAnoVeiculo.FormattingEnabled = true;
            this.cbxAnoVeiculo.Items.AddRange(new object[] {
            "2000",
            "2000/2001",
            "2001",
            "2001/2002",
            "2002",
            "2002/2003",
            "2003",
            "2003/2004",
            "2004",
            "2004/2005",
            "2005",
            "2005/2006",
            "2006",
            "2006/2007",
            "2007",
            "2007/2008",
            "2008",
            "2008/2009",
            "2009",
            "2009/2010",
            "2010",
            "2010/2011",
            "2011",
            "2011/2012",
            "2012",
            "2012/2013",
            "2013",
            "2013/2014",
            "2014",
            "2014/2015",
            "2015",
            "2015/2016",
            "2016",
            "2016/2017",
            "2017",
            "2017/2018",
            "2018",
            "2018/2019",
            "2019",
            "2019/2020",
            "2020",
            "2020/2021",
            "2021",
            "2021/2022",
            "2022",
            "2022/2023",
            "2023",
            "2023/2024",
            "2024",
            "2024/2025",
            ""});
            this.cbxAnoVeiculo.Location = new System.Drawing.Point(808, 226);
            this.cbxAnoVeiculo.Name = "cbxAnoVeiculo";
            this.cbxAnoVeiculo.Size = new System.Drawing.Size(121, 21);
            this.cbxAnoVeiculo.TabIndex = 13;
            // 
            // tbxRenavam
            // 
            this.tbxRenavam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(195)))));
            this.tbxRenavam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxRenavam.Enabled = false;
            this.tbxRenavam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRenavam.Location = new System.Drawing.Point(566, 347);
            this.tbxRenavam.Name = "tbxRenavam";
            this.tbxRenavam.Size = new System.Drawing.Size(219, 16);
            this.tbxRenavam.TabIndex = 15;
            this.tbxRenavam.Text = "Renavam";
            // 
            // tbxChassi
            // 
            this.tbxChassi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(195)))));
            this.tbxChassi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxChassi.Enabled = false;
            this.tbxChassi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxChassi.Location = new System.Drawing.Point(566, 286);
            this.tbxChassi.Name = "tbxChassi";
            this.tbxChassi.Size = new System.Drawing.Size(219, 16);
            this.tbxChassi.TabIndex = 14;
            this.tbxChassi.Text = "Chassi";
            // 
            // txbPlaca
            // 
            this.txbPlaca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(195)))));
            this.txbPlaca.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbPlaca.Enabled = false;
            this.txbPlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPlaca.Location = new System.Drawing.Point(566, 226);
            this.txbPlaca.Name = "txbPlaca";
            this.txbPlaca.Size = new System.Drawing.Size(219, 16);
            this.txbPlaca.TabIndex = 12;
            this.txbPlaca.Text = "Placa";
            // 
            // txbVeiculo
            // 
            this.txbVeiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(195)))));
            this.txbVeiculo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbVeiculo.Enabled = false;
            this.txbVeiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbVeiculo.Location = new System.Drawing.Point(566, 164);
            this.txbVeiculo.Name = "txbVeiculo";
            this.txbVeiculo.Size = new System.Drawing.Size(428, 16);
            this.txbVeiculo.TabIndex = 11;
            this.txbVeiculo.Text = "Veículo";
            // 
            // chkPrincipalCondutor
            // 
            this.chkPrincipalCondutor.AutoSize = true;
            this.chkPrincipalCondutor.BackColor = System.Drawing.Color.Transparent;
            this.chkPrincipalCondutor.Checked = true;
            this.chkPrincipalCondutor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrincipalCondutor.Enabled = false;
            this.chkPrincipalCondutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrincipalCondutor.Location = new System.Drawing.Point(566, 405);
            this.chkPrincipalCondutor.Name = "chkPrincipalCondutor";
            this.chkPrincipalCondutor.Size = new System.Drawing.Size(168, 21);
            this.chkPrincipalCondutor.TabIndex = 17;
            this.chkPrincipalCondutor.Text = "É o Principal Condutor";
            this.chkPrincipalCondutor.UseVisualStyleBackColor = false;
            this.chkPrincipalCondutor.CheckedChanged += new System.EventHandler(this.chkPrincipalCondutor_CheckedChanged);
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.Location = new System.Drawing.Point(1036, 118);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(2, 528);
            // 
            // lineShape13
            // 
            this.lineShape13.Name = "lineShape13";
            this.lineShape13.X1 = 564;
            this.lineShape13.X2 = 780;
            this.lineShape13.Y1 = 548;
            this.lineShape13.Y2 = 548;
            // 
            // lineShape12
            // 
            this.lineShape12.Name = "lineShape12";
            this.lineShape12.X1 = 563;
            this.lineShape12.X2 = 1000;
            this.lineShape12.Y1 = 486;
            this.lineShape12.Y2 = 486;
            // 
            // lineShape11
            // 
            this.lineShape11.Name = "lineShape11";
            this.lineShape11.X1 = 565;
            this.lineShape11.X2 = 781;
            this.lineShape11.Y1 = 365;
            this.lineShape11.Y2 = 365;
            // 
            // lineShape10
            // 
            this.lineShape10.Name = "lineShape10";
            this.lineShape10.X1 = 565;
            this.lineShape10.X2 = 781;
            this.lineShape10.Y1 = 307;
            this.lineShape10.Y2 = 307;
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Location = new System.Drawing.Point(519, 116);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(2, 528);
            // 
            // lineShape9
            // 
            this.lineShape9.Name = "lineShape9";
            this.lineShape9.X1 = 226;
            this.lineShape9.X2 = 400;
            this.lineShape9.Y1 = 367;
            this.lineShape9.Y2 = 367;
            // 
            // lineShape8
            // 
            this.lineShape8.Name = "lineShape8";
            this.lineShape8.X1 = 566;
            this.lineShape8.X2 = 782;
            this.lineShape8.Y1 = 246;
            this.lineShape8.Y2 = 246;
            // 
            // lineShape7
            // 
            this.lineShape7.Name = "lineShape7";
            this.lineShape7.X1 = 564;
            this.lineShape7.X2 = 991;
            this.lineShape7.Y1 = 184;
            this.lineShape7.Y2 = 184;
            // 
            // lineShape6
            // 
            this.lineShape6.Name = "lineShape6";
            this.lineShape6.X1 = 48;
            this.lineShape6.X2 = 487;
            this.lineShape6.Y1 = 488;
            this.lineShape6.Y2 = 488;
            // 
            // lineShape5
            // 
            this.lineShape5.Name = "lineShape5";
            this.lineShape5.X1 = 48;
            this.lineShape5.X2 = 212;
            this.lineShape5.Y1 = 427;
            this.lineShape5.Y2 = 426;
            // 
            // lineShape4
            // 
            this.lineShape4.Name = "lineShape4";
            this.lineShape4.X1 = 48;
            this.lineShape4.X2 = 215;
            this.lineShape4.Y1 = 367;
            this.lineShape4.Y2 = 367;
            // 
            // lineShape3
            // 
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 48;
            this.lineShape3.X2 = 491;
            this.lineShape3.Y1 = 308;
            this.lineShape3.Y2 = 308;
            // 
            // lineShape2
            // 
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 48;
            this.lineShape2.X2 = 264;
            this.lineShape2.Y1 = 248;
            this.lineShape2.Y2 = 248;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 49;
            this.lineShape1.X2 = 490;
            this.lineShape1.Y1 = 186;
            this.lineShape1.Y2 = 186;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape15,
            this.lineShape14,
            this.lineShape1,
            this.lineShape2,
            this.lineShape3,
            this.lineShape4,
            this.lineShape5,
            this.lineShape6,
            this.lineShape7,
            this.lineShape8,
            this.lineShape9,
            this.rectangleShape1,
            this.lineShape10,
            this.lineShape11,
            this.lineShape12,
            this.lineShape13,
            this.rectangleShape2});
            this.shapeContainer1.Size = new System.Drawing.Size(1366, 720);
            this.shapeContainer1.TabIndex = 60;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape15
            // 
            this.lineShape15.Name = "lineShape15";
            this.lineShape15.X1 = 798;
            this.lineShape15.X2 = 925;
            this.lineShape15.Y1 = 548;
            this.lineShape15.Y2 = 548;
            // 
            // lineShape14
            // 
            this.lineShape14.Name = "lineShape14";
            this.lineShape14.X1 = 290;
            this.lineShape14.X2 = 415;
            this.lineShape14.Y1 = 248;
            this.lineShape14.Y2 = 248;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(195)))));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(1068, 123);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(264, 119);
            this.btnEdit.TabIndex = 61;
            this.btnEdit.Text = "          Editar";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txbDataNasc
            // 
            this.txbDataNasc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(193)))), ((int)(((byte)(195)))));
            this.txbDataNasc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbDataNasc.Enabled = false;
            this.txbDataNasc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDataNasc.Location = new System.Drawing.Point(290, 227);
            this.txbDataNasc.MaxLength = 10;
            this.txbDataNasc.Name = "txbDataNasc";
            this.txbDataNasc.Size = new System.Drawing.Size(126, 16);
            this.txbDataNasc.TabIndex = 3;
            this.txbDataNasc.Text = "Data de Nascimento";
            this.txbDataNasc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbDataNasc.Enter += new System.EventHandler(this.txbDataNasc_Enter);
            this.txbDataNasc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbDataNasc_KeyPress);
            // 
            // txbDataNascCond
            // 
            this.txbDataNascCond.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(155)))), ((int)(((byte)(156)))));
            this.txbDataNascCond.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbDataNascCond.Enabled = false;
            this.txbDataNascCond.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDataNascCond.Location = new System.Drawing.Point(798, 527);
            this.txbDataNascCond.MaxLength = 10;
            this.txbDataNascCond.Name = "txbDataNascCond";
            this.txbDataNascCond.Size = new System.Drawing.Size(126, 16);
            this.txbDataNascCond.TabIndex = 20;
            this.txbDataNascCond.Text = "Data de Nascimento";
            this.txbDataNascCond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbDataNascCond.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbDataNascCond_KeyPress);
            // 
            // rbJuridica
            // 
            this.rbJuridica.AutoSize = true;
            this.rbJuridica.BackColor = System.Drawing.Color.Transparent;
            this.rbJuridica.Enabled = false;
            this.rbJuridica.Location = new System.Drawing.Point(145, 116);
            this.rbJuridica.Name = "rbJuridica";
            this.rbJuridica.Size = new System.Drawing.Size(101, 17);
            this.rbJuridica.TabIndex = 65;
            this.rbJuridica.Text = "Pessoa Jurídica";
            this.rbJuridica.UseVisualStyleBackColor = false;
            // 
            // rbFisica
            // 
            this.rbFisica.AutoSize = true;
            this.rbFisica.BackColor = System.Drawing.Color.Transparent;
            this.rbFisica.Checked = true;
            this.rbFisica.Enabled = false;
            this.rbFisica.Location = new System.Drawing.Point(47, 116);
            this.rbFisica.Name = "rbFisica";
            this.rbFisica.Size = new System.Drawing.Size(92, 17);
            this.rbFisica.TabIndex = 64;
            this.rbFisica.TabStop = true;
            this.rbFisica.Text = "Pessoa Física";
            this.rbFisica.UseVisualStyleBackColor = false;
            // 
            // frm_Clients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 720);
            this.Controls.Add(this.rbJuridica);
            this.Controls.Add(this.rbFisica);
            this.Controls.Add(this.txbDataNascCond);
            this.Controls.Add(this.txbDataNasc);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.labelSucess);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.tbxObs);
            this.Controls.Add(this.tbxCondutorCPF);
            this.Controls.Add(this.txbCondutorNome);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxVigencia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxAnoVeiculo);
            this.Controls.Add(this.tbxRenavam);
            this.Controls.Add(this.tbxChassi);
            this.Controls.Add(this.txbPlaca);
            this.Controls.Add(this.txbVeiculo);
            this.Controls.Add(this.chkPrincipalCondutor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxSeguradora);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxUF);
            this.Controls.Add(this.txbCidade);
            this.Controls.Add(this.txbEmail);
            this.Controls.Add(this.txbCEP);
            this.Controls.Add(this.txbBairro);
            this.Controls.Add(this.txbLogradouro);
            this.Controls.Add(this.txbCPFCNPJ);
            this.Controls.Add(this.txbNome);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shapeContainer1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_Clients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Clients";
            this.Load += new System.EventHandler(this.frm_Clients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxSeguradora;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxUF;
        private System.Windows.Forms.TextBox txbCidade;
        private System.Windows.Forms.TextBox txbEmail;
        private System.Windows.Forms.TextBox txbCEP;
        private System.Windows.Forms.TextBox txbBairro;
        private System.Windows.Forms.TextBox txbLogradouro;
        private System.Windows.Forms.TextBox txbCPFCNPJ;
        private System.Windows.Forms.TextBox txbNome;
        private System.Windows.Forms.Label labelSucess;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox tbxObs;
        private System.Windows.Forms.TextBox tbxCondutorCPF;
        private System.Windows.Forms.TextBox txbCondutorNome;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxVigencia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxAnoVeiculo;
        private System.Windows.Forms.TextBox tbxRenavam;
        private System.Windows.Forms.TextBox tbxChassi;
        private System.Windows.Forms.TextBox txbPlaca;
        private System.Windows.Forms.TextBox txbVeiculo;
        private System.Windows.Forms.CheckBox chkPrincipalCondutor;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape13;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape12;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape11;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape10;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape9;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape8;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape7;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape6;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape5;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Button btnEdit;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape15;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape14;
        private System.Windows.Forms.TextBox txbDataNasc;
        private System.Windows.Forms.TextBox txbDataNascCond;
        private System.Windows.Forms.RadioButton rbJuridica;
        private System.Windows.Forms.RadioButton rbFisica;
    }
}