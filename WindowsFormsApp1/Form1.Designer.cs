
namespace WindowsFormsApp1
{
    partial class Form1
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
            this.listBoxNonPair = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxPaired = new System.Windows.Forms.ListBox();
            this.notPairedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pairedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.buttonPairing = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.notPairedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pairedBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxNonPair
            // 
            this.listBoxNonPair.DataSource = this.listBoxNonPair.CustomTabOffsets;
            this.listBoxNonPair.FormattingEnabled = true;
            this.listBoxNonPair.ItemHeight = 16;
            this.listBoxNonPair.Location = new System.Drawing.Point(23, 46);
            this.listBoxNonPair.Name = "listBoxNonPair";
            this.listBoxNonPair.Size = new System.Drawing.Size(230, 292);
            this.listBoxNonPair.TabIndex = 0;
            this.listBoxNonPair.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Not Paired";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBoxPaired
            // 
            this.listBoxPaired.DataSource = this.pairedBindingSource;
            this.listBoxPaired.FormattingEnabled = true;
            this.listBoxPaired.ItemHeight = 16;
            this.listBoxPaired.Location = new System.Drawing.Point(259, 46);
            this.listBoxPaired.Name = "listBoxPaired";
            this.listBoxPaired.Size = new System.Drawing.Size(230, 292);
            this.listBoxPaired.TabIndex = 2;
            // 
            // notPairedBindingSource
            // 
            this.notPairedBindingSource.DataSource = typeof(WindowsFormsApp1.Form1);
            // 
            // pairedBindingSource
            // 
            this.pairedBindingSource.DataSource = typeof(WindowsFormsApp1.Form1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(254, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Paired";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // buttonPairing
            // 
            this.buttonPairing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPairing.Location = new System.Drawing.Point(23, 404);
            this.buttonPairing.Name = "buttonPairing";
            this.buttonPairing.Size = new System.Drawing.Size(165, 34);
            this.buttonPairing.TabIndex = 4;
            this.buttonPairing.Text = "Pairing";
            this.buttonPairing.UseVisualStyleBackColor = true;
            this.buttonPairing.Click += new System.EventHandler(this.buttonPairing_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonRefresh.Location = new System.Drawing.Point(194, 404);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(165, 34);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonPairing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxPaired);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxNonPair);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.notPairedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pairedBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxNonPair;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxPaired;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonPairing;
        private System.Windows.Forms.BindingSource notPairedBindingSource;
        private System.Windows.Forms.BindingSource pairedBindingSource;
        private System.Windows.Forms.Button buttonRefresh;
    }
}

