namespace StokTakipSistemi
{
    partial class ReportForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCriticalStock = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAllStock = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriticalStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllStock)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "KRİTİK STOK SEVİYESİ";
            // 
            // dgvCriticalStock
            // 
            this.dgvCriticalStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCriticalStock.Location = new System.Drawing.Point(224, 59);
            this.dgvCriticalStock.Name = "dgvCriticalStock";
            this.dgvCriticalStock.RowHeadersWidth = 51;
            this.dgvCriticalStock.RowTemplate.Height = 24;
            this.dgvCriticalStock.Size = new System.Drawing.Size(299, 150);
            this.dgvCriticalStock.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "GENEL STOK ÖZETİ";
            // 
            // dgvAllStock
            // 
            this.dgvAllStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllStock.Location = new System.Drawing.Point(224, 273);
            this.dgvAllStock.Name = "dgvAllStock";
            this.dgvAllStock.RowHeadersWidth = 51;
            this.dgvAllStock.RowTemplate.Height = 24;
            this.dgvAllStock.Size = new System.Drawing.Size(299, 150);
            this.dgvAllStock.TabIndex = 3;
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvAllStock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvCriticalStock);
            this.Controls.Add(this.label1);
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriticalStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCriticalStock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAllStock;
    }
}