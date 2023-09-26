namespace Practica_Parcial.Diseño
{
    partial class FrmReporteStock
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetStock = new Practica_Parcial.Diseño.Reportes.DataSetStock();
            this.sPREPORTESTOCKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sP_REPORTE_STOCKTableAdapter = new Practica_Parcial.Diseño.Reportes.DataSetStockTableAdapters.SP_REPORTE_STOCKTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPREPORTESTOCKBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sPREPORTESTOCKBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Practica_Parcial.Diseño.Reportes.rpStock.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(625, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetStock
            // 
            this.dataSetStock.DataSetName = "DataSetStock";
            this.dataSetStock.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sPREPORTESTOCKBindingSource
            // 
            this.sPREPORTESTOCKBindingSource.DataMember = "SP_REPORTE_STOCK";
            this.sPREPORTESTOCKBindingSource.DataSource = this.dataSetStock;
            // 
            // sP_REPORTE_STOCKTableAdapter
            // 
            this.sP_REPORTE_STOCKTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteStock";
            this.Text = "FrmReporteStock";
            this.Load += new System.EventHandler(this.FrmReporteStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPREPORTESTOCKBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Reportes.DataSetStock dataSetStock;
        private System.Windows.Forms.BindingSource sPREPORTESTOCKBindingSource;
        private Reportes.DataSetStockTableAdapters.SP_REPORTE_STOCKTableAdapter sP_REPORTE_STOCKTableAdapter;
    }
}