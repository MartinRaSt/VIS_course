
namespace DesktopApp
{
    partial class KnihaForm
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
            this.paMain = new System.Windows.Forms.Panel();
            this.paBottom = new System.Windows.Forms.Panel();
            this.paTop = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.laNadpis = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.edNazevKnihy = new System.Windows.Forms.TextBox();
            this.edJmeno = new System.Windows.Forms.TextBox();
            this.edPrijmeni = new System.Windows.Forms.TextBox();
            this.edVydavatel = new System.Windows.Forms.TextBox();
            this.cmbJazyk = new System.Windows.Forms.ComboBox();
            this.edRok = new System.Windows.Forms.NumericUpDown();
            this.edVydani = new System.Windows.Forms.NumericUpDown();
            this.paMain.SuspendLayout();
            this.paBottom.SuspendLayout();
            this.paTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edRok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edVydani)).BeginInit();
            this.SuspendLayout();
            // 
            // paMain
            // 
            this.paMain.Controls.Add(this.edVydani);
            this.paMain.Controls.Add(this.edRok);
            this.paMain.Controls.Add(this.cmbJazyk);
            this.paMain.Controls.Add(this.edVydavatel);
            this.paMain.Controls.Add(this.edPrijmeni);
            this.paMain.Controls.Add(this.edJmeno);
            this.paMain.Controls.Add(this.edNazevKnihy);
            this.paMain.Controls.Add(this.label7);
            this.paMain.Controls.Add(this.label6);
            this.paMain.Controls.Add(this.label5);
            this.paMain.Controls.Add(this.label4);
            this.paMain.Controls.Add(this.label3);
            this.paMain.Controls.Add(this.label2);
            this.paMain.Controls.Add(this.label1);
            this.paMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paMain.Location = new System.Drawing.Point(0, 0);
            this.paMain.Name = "paMain";
            this.paMain.Size = new System.Drawing.Size(800, 450);
            this.paMain.TabIndex = 0;
            // 
            // paBottom
            // 
            this.paBottom.Controls.Add(this.btnOK);
            this.paBottom.Controls.Add(this.btnCancel);
            this.paBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paBottom.Location = new System.Drawing.Point(0, 396);
            this.paBottom.Name = "paBottom";
            this.paBottom.Size = new System.Drawing.Size(800, 54);
            this.paBottom.TabIndex = 1;
            // 
            // paTop
            // 
            this.paTop.Controls.Add(this.laNadpis);
            this.paTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.paTop.Location = new System.Drawing.Point(0, 0);
            this.paTop.Name = "paTop";
            this.paTop.Size = new System.Drawing.Size(800, 49);
            this.paTop.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(650, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(138, 42);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Zrušit";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(506, 9);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(138, 39);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // laNadpis
            // 
            this.laNadpis.AutoSize = true;
            this.laNadpis.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.laNadpis.Location = new System.Drawing.Point(7, 7);
            this.laNadpis.Name = "laNadpis";
            this.laNadpis.Size = new System.Drawing.Size(105, 39);
            this.laNadpis.TabIndex = 0;
            this.laNadpis.Text = "Kniha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Název knihy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(366, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Příjmení autora";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Jméno autora";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Jazyk";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Vydavatel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(434, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Vydání";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Rok vydání";
            // 
            // edNazevKnihy
            // 
            this.edNazevKnihy.Location = new System.Drawing.Point(165, 70);
            this.edNazevKnihy.Name = "edNazevKnihy";
            this.edNazevKnihy.Size = new System.Drawing.Size(604, 29);
            this.edNazevKnihy.TabIndex = 7;
            // 
            // edJmeno
            // 
            this.edJmeno.Location = new System.Drawing.Point(165, 119);
            this.edJmeno.Name = "edJmeno";
            this.edJmeno.Size = new System.Drawing.Size(178, 29);
            this.edJmeno.TabIndex = 8;
            // 
            // edPrijmeni
            // 
            this.edPrijmeni.Location = new System.Drawing.Point(513, 120);
            this.edPrijmeni.Name = "edPrijmeni";
            this.edPrijmeni.Size = new System.Drawing.Size(256, 29);
            this.edPrijmeni.TabIndex = 9;
            // 
            // edVydavatel
            // 
            this.edVydavatel.Location = new System.Drawing.Point(165, 171);
            this.edVydavatel.Name = "edVydavatel";
            this.edVydavatel.Size = new System.Drawing.Size(604, 29);
            this.edVydavatel.TabIndex = 10;
            // 
            // cmbJazyk
            // 
            this.cmbJazyk.FormattingEnabled = true;
            this.cmbJazyk.Location = new System.Drawing.Point(165, 269);
            this.cmbJazyk.Name = "cmbJazyk";
            this.cmbJazyk.Size = new System.Drawing.Size(287, 32);
            this.cmbJazyk.TabIndex = 11;
            // 
            // edRok
            // 
            this.edRok.Location = new System.Drawing.Point(165, 221);
            this.edRok.Maximum = new decimal(new int[] {
            2050,
            0,
            0,
            0});
            this.edRok.Minimum = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            this.edRok.Name = "edRok";
            this.edRok.Size = new System.Drawing.Size(103, 29);
            this.edRok.TabIndex = 12;
            this.edRok.Value = new decimal(new int[] {
            1800,
            0,
            0,
            0});
            // 
            // edVydani
            // 
            this.edVydani.Location = new System.Drawing.Point(513, 221);
            this.edVydani.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.edVydani.Name = "edVydani";
            this.edVydani.Size = new System.Drawing.Size(93, 29);
            this.edVydani.TabIndex = 13;
            this.edVydani.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // KnihaForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.paTop);
            this.Controls.Add(this.paBottom);
            this.Controls.Add(this.paMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KnihaForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.paMain.ResumeLayout(false);
            this.paMain.PerformLayout();
            this.paBottom.ResumeLayout(false);
            this.paTop.ResumeLayout(false);
            this.paTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edRok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edVydani)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel paMain;
        private System.Windows.Forms.Panel paBottom;
        private System.Windows.Forms.Panel paTop;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label laNadpis;
        private System.Windows.Forms.NumericUpDown edVydani;
        private System.Windows.Forms.NumericUpDown edRok;
        private System.Windows.Forms.ComboBox cmbJazyk;
        private System.Windows.Forms.TextBox edVydavatel;
        private System.Windows.Forms.TextBox edPrijmeni;
        private System.Windows.Forms.TextBox edJmeno;
        private System.Windows.Forms.TextBox edNazevKnihy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}