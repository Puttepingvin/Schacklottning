namespace Schacklottning
{
    partial class AddPlayerForm
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
            this.bntAddPlayerConfirm = new System.Windows.Forms.Button();
            this.txtAddPlayerName1 = new System.Windows.Forms.TextBox();
            this.txtAddPlayerName2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bntAddPlayerConfirm
            // 
            this.bntAddPlayerConfirm.Location = new System.Drawing.Point(144, 95);
            this.bntAddPlayerConfirm.Name = "bntAddPlayerConfirm";
            this.bntAddPlayerConfirm.Size = new System.Drawing.Size(75, 23);
            this.bntAddPlayerConfirm.TabIndex = 0;
            this.bntAddPlayerConfirm.Text = "Lägg till";
            this.bntAddPlayerConfirm.UseVisualStyleBackColor = true;
            this.bntAddPlayerConfirm.Click += new System.EventHandler(this.bntAddPlayerConfirm_Click);
            // 
            // txtAddPlayerName1
            // 
            this.txtAddPlayerName1.Location = new System.Drawing.Point(13, 13);
            this.txtAddPlayerName1.Name = "txtAddPlayerName1";
            this.txtAddPlayerName1.Size = new System.Drawing.Size(100, 20);
            this.txtAddPlayerName1.TabIndex = 1;
            this.txtAddPlayerName1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtAddPlayerName2
            // 
            this.txtAddPlayerName2.Location = new System.Drawing.Point(119, 12);
            this.txtAddPlayerName2.Name = "txtAddPlayerName2";
            this.txtAddPlayerName2.Size = new System.Drawing.Size(100, 20);
            this.txtAddPlayerName2.TabIndex = 2;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtAddPlayerName2);
            this.Controls.Add(this.txtAddPlayerName1);
            this.Controls.Add(this.bntAddPlayerConfirm);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntAddPlayerConfirm;
        private System.Windows.Forms.TextBox txtAddPlayerName1;
        private System.Windows.Forms.TextBox txtAddPlayerName2;
    }
}