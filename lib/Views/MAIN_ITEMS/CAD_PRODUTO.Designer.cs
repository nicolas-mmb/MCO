namespace MAID_COFFEE_OCIDENTAL.lib.Views.MAIN_ITEMS
{
    partial class CAD_PRODUTO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAD_PRODUTO));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.TSL_MD_USER = new System.Windows.Forms.ToolStripLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.PBX_ITEM = new System.Windows.Forms.PictureBox();
            this.TXB_QTD = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TXB_DV = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TXB_VALOR = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TXB_PD = new System.Windows.Forms.TextBox();
            this.OFD_imagem = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_ITEM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXB_QTD)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Pink;
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(461, 40);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripLabel2,
            this.TSL_MD_USER});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(461, 40);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.BackgroundImage = global::MAID_COFFEE_OCIDENTAL.Properties.Resources.btn_error;
            this.toolStripButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(38, 37);
            this.toolStripButton2.Text = "         ";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(260, 37);
            this.toolStripLabel2.Text = " MODIFICACOES FEITAS POR:";
            // 
            // TSL_MD_USER
            // 
            this.TSL_MD_USER.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSL_MD_USER.Name = "TSL_MD_USER";
            this.TSL_MD_USER.Size = new System.Drawing.Size(40, 37);
            this.TSL_MD_USER.Text = "...";
            this.TSL_MD_USER.Click += new System.EventHandler(this.TSL_MD_USER_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Pink;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.PBX_ITEM);
            this.panel2.Controls.Add(this.TXB_QTD);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.TXB_DV);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.TXB_VALOR);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.TXB_PD);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(461, 324);
            this.panel2.TabIndex = 1;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(277, 263);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 38);
            this.button2.TabIndex = 5;
            this.button2.Text = "IMAGEM";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PBX_ITEM
            // 
            this.PBX_ITEM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PBX_ITEM.ErrorImage = null;
            this.PBX_ITEM.Location = new System.Drawing.Point(277, 94);
            this.PBX_ITEM.Name = "PBX_ITEM";
            this.PBX_ITEM.Size = new System.Drawing.Size(156, 156);
            this.PBX_ITEM.TabIndex = 14;
            this.PBX_ITEM.TabStop = false;
            // 
            // TXB_QTD
            // 
            this.TXB_QTD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TXB_QTD.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXB_QTD.Location = new System.Drawing.Point(26, 179);
            this.TXB_QTD.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.TXB_QTD.Name = "TXB_QTD";
            this.TXB_QTD.Size = new System.Drawing.Size(138, 26);
            this.TXB_QTD.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 22);
            this.label4.TabIndex = 11;
            this.label4.Text = "QUANTIDADE DO PRODUTO: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 22);
            this.label3.TabIndex = 9;
            this.label3.Text = "VALIDADE DO PRODUTO: ";
            // 
            // TXB_DV
            // 
            this.TXB_DV.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXB_DV.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.TXB_DV.Location = new System.Drawing.Point(26, 239);
            this.TXB_DV.MinDate = new System.DateTime(1999, 12, 31, 0, 0, 0, 0);
            this.TXB_DV.Name = "TXB_DV";
            this.TXB_DV.Size = new System.Drawing.Size(138, 26);
            this.TXB_DV.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "VALOR DO PRODUTO: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "NOME DO PRODUTO: ";
            // 
            // TXB_VALOR
            // 
            this.TXB_VALOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TXB_VALOR.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXB_VALOR.Location = new System.Drawing.Point(26, 115);
            this.TXB_VALOR.Name = "TXB_VALOR";
            this.TXB_VALOR.Size = new System.Drawing.Size(138, 26);
            this.TXB_VALOR.TabIndex = 1;
            this.TXB_VALOR.TextChanged += new System.EventHandler(this.TXB_VALOR_TextChanged);
            this.TXB_VALOR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXB_VALOR_KeyPress);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(358, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "SALVAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TXB_PD
            // 
            this.TXB_PD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TXB_PD.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXB_PD.Location = new System.Drawing.Point(16, 44);
            this.TXB_PD.Name = "TXB_PD";
            this.TXB_PD.Size = new System.Drawing.Size(417, 26);
            this.TXB_PD.TabIndex = 0;
            // 
            // OFD_imagem
            // 
            this.OFD_imagem.FileName = "openFileDialog1";
            // 
            // CAD_PRODUTO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 364);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CAD_PRODUTO";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CADASTRAR PRODUTO";
            this.Load += new System.EventHandler(this.CAD_PRODUTO_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBX_ITEM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXB_QTD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.TextBox TXB_PD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TXB_VALOR;
        private System.Windows.Forms.NumericUpDown TXB_QTD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker TXB_DV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripLabel TSL_MD_USER;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox PBX_ITEM;
        private System.Windows.Forms.OpenFileDialog OFD_imagem;
    }
}