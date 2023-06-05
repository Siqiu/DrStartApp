namespace WindowsFormsApp1
{
    partial class FactoryApp
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
            this.btn_new_one = new System.Windows.Forms.Button();
            this.btn_close_all = new System.Windows.Forms.Button();
            this.labelTotalBackEnd = new System.Windows.Forms.Label();
            this.tbBackendNum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_new_one
            // 
            this.btn_new_one.Location = new System.Drawing.Point(27, 54);
            this.btn_new_one.Name = "btn_new_one";
            this.btn_new_one.Size = new System.Drawing.Size(199, 79);
            this.btn_new_one.TabIndex = 0;
            this.btn_new_one.Text = "btn_new_one";
            this.btn_new_one.UseVisualStyleBackColor = true;
            this.btn_new_one.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_close_all
            // 
            this.btn_close_all.Location = new System.Drawing.Point(252, 54);
            this.btn_close_all.Name = "btn_close_all";
            this.btn_close_all.Size = new System.Drawing.Size(199, 79);
            this.btn_close_all.TabIndex = 1;
            this.btn_close_all.Text = "btn_close_all";
            this.btn_close_all.UseVisualStyleBackColor = true;
            this.btn_close_all.Click += new System.EventHandler(this.btn_close_all_Click);
            // 
            // labelTotalBackEnd
            // 
            this.labelTotalBackEnd.Location = new System.Drawing.Point(27, 9);
            this.labelTotalBackEnd.Name = "labelTotalBackEnd";
            this.labelTotalBackEnd.Size = new System.Drawing.Size(179, 31);
            this.labelTotalBackEnd.TabIndex = 2;
            this.labelTotalBackEnd.Text = "TotalBackEnd: ";
            // 
            // tbBackendNum
            // 
            this.tbBackendNum.Location = new System.Drawing.Point(212, 8);
            this.tbBackendNum.Name = "tbBackendNum";
            this.tbBackendNum.Size = new System.Drawing.Size(238, 35);
            this.tbBackendNum.TabIndex = 3;
            // 
            // FactoryApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 155);
            this.Controls.Add(this.tbBackendNum);
            this.Controls.Add(this.labelTotalBackEnd);
            this.Controls.Add(this.btn_close_all);
            this.Controls.Add(this.btn_new_one);
            this.Name = "FactoryApp";
            this.Text = "FactoryApp";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox tbBackendNum;

        private System.Windows.Forms.Label labelTotalBackEnd;

        private System.Windows.Forms.Button btn_new_one;

        private System.Windows.Forms.Button btn_close_all;

        #endregion
    }
}