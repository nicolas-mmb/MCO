namespace MAID_COFFEE_OCIDENTAL.lib.Views.RELATORIOS
{
    partial class REL_PRODUTOS
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(REL_PRODUTOS));
            this.tb_PRODUTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet2 = new MAID_COFFEE_OCIDENTAL.DataSet2();
            this.tb_PRODUTOTableAdapter1 = new MAID_COFFEE_OCIDENTAL.MCODataSetTableAdapters.tb_PRODUTOTableAdapter();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tb_PRODUTOTableAdapter = new MAID_COFFEE_OCIDENTAL.DataSet2TableAdapters.tb_PRODUTOTableAdapter();
            this.tbPRODUTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tb_PRODUTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPRODUTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_PRODUTOBindingSource
            // 
            this.tb_PRODUTOBindingSource.DataMember = "tb_PRODUTO";
            this.tb_PRODUTOBindingSource.DataSource = this.dataSet2;
            // 
            // dataSet2
            // 
            this.dataSet2.DataSetName = "DataSet2";
            this.dataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tb_PRODUTOTableAdapter1
            // 
            this.tb_PRODUTOTableAdapter1.ClearBeforeFill = true;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet_2";
            reportDataSource1.Value = this.tb_PRODUTOBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "MAID_COFFEE_OCIDENTAL.Report2.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(652, 521);
            this.reportViewer2.TabIndex = 1;
            // 
            // tb_PRODUTOTableAdapter
            // 
            this.tb_PRODUTOTableAdapter.ClearBeforeFill = true;
            // 
            // REL_PRODUTOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 521);
            this.Controls.Add(this.reportViewer2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "REL_PRODUTOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RELATÓRIOS DE PRODUTOS";
            this.Load += new System.EventHandler(this.REL_PRODUTOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_PRODUTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPRODUTOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MCODataSetTableAdapters.tb_PRODUTOTableAdapter tb_PRODUTOTableAdapter1;
        private DataSet2 dataSet2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource tbPRODUTOBindingSource;
        private DataSet2TableAdapters.tb_PRODUTOTableAdapter tb_PRODUTOTableAdapter;
        private System.Windows.Forms.BindingSource tb_PRODUTOBindingSource;
    }
}