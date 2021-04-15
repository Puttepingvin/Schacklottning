namespace Schacklottning
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnShowRound = new System.Windows.Forms.Button();
            this.lstbPlayers = new System.Windows.Forms.ListBox();
            this.lstbResToday = new System.Windows.Forms.ListBox();
            this.lstbResTot = new System.Windows.Forms.ListBox();
            this.btnNewRound = new System.Windows.Forms.Button();
            this.lstbInactive = new System.Windows.Forms.ListBox();
            this.btnMakeInactive = new System.Windows.Forms.Button();
            this.btnMakeActive = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Lägg till spelare";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnShowRound
            // 
            this.btnShowRound.Location = new System.Drawing.Point(12, 36);
            this.btnShowRound.Name = "btnShowRound";
            this.btnShowRound.Size = new System.Drawing.Size(136, 28);
            this.btnShowRound.TabIndex = 1;
            this.btnShowRound.Text = "Rapportera resultat";
            this.btnShowRound.UseVisualStyleBackColor = true;
            this.btnShowRound.Click += new System.EventHandler(this.btnShowRound_Click);
            // 
            // lstbPlayers
            // 
            this.lstbPlayers.FormattingEnabled = true;
            this.lstbPlayers.Location = new System.Drawing.Point(323, 36);
            this.lstbPlayers.Name = "lstbPlayers";
            this.lstbPlayers.Size = new System.Drawing.Size(207, 121);
            this.lstbPlayers.TabIndex = 2;
            this.lstbPlayers.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lstbResToday
            // 
            this.lstbResToday.FormattingEnabled = true;
            this.lstbResToday.Location = new System.Drawing.Point(28, 277);
            this.lstbResToday.Name = "lstbResToday";
            this.lstbResToday.Size = new System.Drawing.Size(120, 95);
            this.lstbResToday.TabIndex = 3;
            // 
            // lstbResTot
            // 
            this.lstbResTot.FormattingEnabled = true;
            this.lstbResTot.Location = new System.Drawing.Point(257, 277);
            this.lstbResTot.Name = "lstbResTot";
            this.lstbResTot.Size = new System.Drawing.Size(120, 95);
            this.lstbResTot.TabIndex = 4;
            // 
            // btnNewRound
            // 
            this.btnNewRound.Location = new System.Drawing.Point(12, 70);
            this.btnNewRound.Name = "btnNewRound";
            this.btnNewRound.Size = new System.Drawing.Size(136, 28);
            this.btnNewRound.TabIndex = 5;
            this.btnNewRound.Text = "Lotta ny Rond";
            this.btnNewRound.UseVisualStyleBackColor = true;
            this.btnNewRound.Click += new System.EventHandler(this.btnNewRound_Click);
            // 
            // lstbInactive
            // 
            this.lstbInactive.FormattingEnabled = true;
            this.lstbInactive.Location = new System.Drawing.Point(581, 36);
            this.lstbInactive.Name = "lstbInactive";
            this.lstbInactive.Size = new System.Drawing.Size(207, 121);
            this.lstbInactive.TabIndex = 6;
            // 
            // btnMakeInactive
            // 
            this.btnMakeInactive.Location = new System.Drawing.Point(536, 39);
            this.btnMakeInactive.Name = "btnMakeInactive";
            this.btnMakeInactive.Size = new System.Drawing.Size(39, 25);
            this.btnMakeInactive.TabIndex = 7;
            this.btnMakeInactive.Text = "-->";
            this.btnMakeInactive.UseVisualStyleBackColor = true;
            this.btnMakeInactive.Click += new System.EventHandler(this.btnMakeInactive_Click);
            // 
            // btnMakeActive
            // 
            this.btnMakeActive.Location = new System.Drawing.Point(536, 132);
            this.btnMakeActive.Name = "btnMakeActive";
            this.btnMakeActive.Size = new System.Drawing.Size(39, 25);
            this.btnMakeActive.TabIndex = 8;
            this.btnMakeActive.Text = "<--";
            this.btnMakeActive.UseVisualStyleBackColor = true;
            this.btnMakeActive.Click += new System.EventHandler(this.btnMakeActive_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(323, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Närvarande spelare";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(578, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Frånvarande Spelare";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Poängställning totalt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Poängställning idag";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMakeActive);
            this.Controls.Add(this.btnMakeInactive);
            this.Controls.Add(this.lstbInactive);
            this.Controls.Add(this.btnNewRound);
            this.Controls.Add(this.lstbResTot);
            this.Controls.Add(this.lstbResToday);
            this.Controls.Add(this.lstbPlayers);
            this.Controls.Add(this.btnShowRound);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnShowRound;
        private System.Windows.Forms.ListBox lstbPlayers;
        private System.Windows.Forms.ListBox lstbResToday;
        private System.Windows.Forms.ListBox lstbResTot;
        private System.Windows.Forms.Button btnNewRound;
        private System.Windows.Forms.ListBox lstbInactive;
        private System.Windows.Forms.Button btnMakeInactive;
        private System.Windows.Forms.Button btnMakeActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

