
namespace DesktopApp
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbMain = new DesktopApp.TablessControl();
            this.tpKnihy = new System.Windows.Forms.TabPage();
            this.edKnihaRezervace = new System.Windows.Forms.Button();
            this.edKnihaID = new System.Windows.Forms.TextBox();
            this.btnKnihaFind = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.edKnihaDelete = new System.Windows.Forms.Button();
            this.edKnihaEdit = new System.Windows.Forms.Button();
            this.edKnihaAdd = new System.Windows.Forms.Button();
            this.grKnihy = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tpUzivatele = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tpZamest = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.přihlásitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.přihlášeníToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.konecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funkceISToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miKnihy = new System.Windows.Forms.ToolStripMenuItem();
            this.miUzivatele = new System.Windows.Forms.ToolStripMenuItem();
            this.miZamestnanci = new System.Windows.Forms.ToolStripMenuItem();
            this.nápovědaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oAplikaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsObsluha = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.tpKnihy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grKnihy)).BeginInit();
            this.tpUzivatele.SuspendLayout();
            this.tpZamest.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1319, 788);
            this.panel1.TabIndex = 0;
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tpKnihy);
            this.tbMain.Controls.Add(this.tpUzivatele);
            this.tbMain.Controls.Add(this.tpZamest);
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(1319, 788);
            this.tbMain.TabIndex = 0;
            // 
            // tpKnihy
            // 
            this.tpKnihy.Controls.Add(this.edKnihaRezervace);
            this.tpKnihy.Controls.Add(this.edKnihaID);
            this.tpKnihy.Controls.Add(this.btnKnihaFind);
            this.tpKnihy.Controls.Add(this.label4);
            this.tpKnihy.Controls.Add(this.edKnihaDelete);
            this.tpKnihy.Controls.Add(this.edKnihaEdit);
            this.tpKnihy.Controls.Add(this.edKnihaAdd);
            this.tpKnihy.Controls.Add(this.grKnihy);
            this.tpKnihy.Controls.Add(this.label1);
            this.tpKnihy.Location = new System.Drawing.Point(4, 33);
            this.tpKnihy.Name = "tpKnihy";
            this.tpKnihy.Padding = new System.Windows.Forms.Padding(3);
            this.tpKnihy.Size = new System.Drawing.Size(1311, 751);
            this.tpKnihy.TabIndex = 0;
            this.tpKnihy.Text = "Knihy";
            this.tpKnihy.UseVisualStyleBackColor = true;
            // 
            // edKnihaRezervace
            // 
            this.edKnihaRezervace.Location = new System.Drawing.Point(1138, 542);
            this.edKnihaRezervace.Name = "edKnihaRezervace";
            this.edKnihaRezervace.Size = new System.Drawing.Size(146, 57);
            this.edKnihaRezervace.TabIndex = 8;
            this.edKnihaRezervace.Text = "Rezervace";
            this.edKnihaRezervace.UseVisualStyleBackColor = true;
            this.edKnihaRezervace.Click += new System.EventHandler(this.edKnihaRezervace_Click);
            // 
            // edKnihaID
            // 
            this.edKnihaID.Location = new System.Drawing.Point(1138, 378);
            this.edKnihaID.Name = "edKnihaID";
            this.edKnihaID.Size = new System.Drawing.Size(146, 29);
            this.edKnihaID.TabIndex = 7;
            // 
            // btnKnihaFind
            // 
            this.btnKnihaFind.Location = new System.Drawing.Point(1138, 427);
            this.btnKnihaFind.Name = "btnKnihaFind";
            this.btnKnihaFind.Size = new System.Drawing.Size(146, 50);
            this.btnKnihaFind.TabIndex = 6;
            this.btnKnihaFind.Text = "Najdi";
            this.btnKnihaFind.UseVisualStyleBackColor = true;
            this.btnKnihaFind.Click += new System.EventHandler(this.btnKnihaFind_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1137, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "ID";
            // 
            // edKnihaDelete
            // 
            this.edKnihaDelete.Location = new System.Drawing.Point(1142, 209);
            this.edKnihaDelete.Name = "edKnihaDelete";
            this.edKnihaDelete.Size = new System.Drawing.Size(142, 55);
            this.edKnihaDelete.TabIndex = 4;
            this.edKnihaDelete.Text = "Smazat";
            this.edKnihaDelete.UseVisualStyleBackColor = true;
            this.edKnihaDelete.Click += new System.EventHandler(this.edKnihaDelete_Click);
            // 
            // edKnihaEdit
            // 
            this.edKnihaEdit.Location = new System.Drawing.Point(1138, 133);
            this.edKnihaEdit.Name = "edKnihaEdit";
            this.edKnihaEdit.Size = new System.Drawing.Size(146, 48);
            this.edKnihaEdit.TabIndex = 3;
            this.edKnihaEdit.Text = "Upravit";
            this.edKnihaEdit.UseVisualStyleBackColor = true;
            this.edKnihaEdit.Click += new System.EventHandler(this.edKnihaEdit_Click);
            // 
            // edKnihaAdd
            // 
            this.edKnihaAdd.Location = new System.Drawing.Point(1138, 68);
            this.edKnihaAdd.Name = "edKnihaAdd";
            this.edKnihaAdd.Size = new System.Drawing.Size(147, 45);
            this.edKnihaAdd.TabIndex = 2;
            this.edKnihaAdd.Text = "Přidat";
            this.edKnihaAdd.UseVisualStyleBackColor = true;
            this.edKnihaAdd.Click += new System.EventHandler(this.edKnihaAdd_Click);
            // 
            // grKnihy
            // 
            this.grKnihy.AllowUserToAddRows = false;
            this.grKnihy.AllowUserToDeleteRows = false;
            this.grKnihy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grKnihy.Location = new System.Drawing.Point(13, 69);
            this.grKnihy.MultiSelect = false;
            this.grKnihy.Name = "grKnihy";
            this.grKnihy.ReadOnly = true;
            this.grKnihy.RowHeadersWidth = 72;
            this.grKnihy.RowTemplate.Height = 31;
            this.grKnihy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grKnihy.Size = new System.Drawing.Size(1091, 627);
            this.grKnihy.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Knihy";
            // 
            // tpUzivatele
            // 
            this.tpUzivatele.Controls.Add(this.label2);
            this.tpUzivatele.Location = new System.Drawing.Point(4, 33);
            this.tpUzivatele.Name = "tpUzivatele";
            this.tpUzivatele.Padding = new System.Windows.Forms.Padding(3);
            this.tpUzivatele.Size = new System.Drawing.Size(1311, 751);
            this.tpUzivatele.TabIndex = 1;
            this.tpUzivatele.Text = "Uzivatele";
            this.tpUzivatele.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(18, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "Uživatelé";
            // 
            // tpZamest
            // 
            this.tpZamest.Controls.Add(this.label3);
            this.tpZamest.Location = new System.Drawing.Point(4, 33);
            this.tpZamest.Name = "tpZamest";
            this.tpZamest.Padding = new System.Windows.Forms.Padding(3);
            this.tpZamest.Size = new System.Drawing.Size(1311, 751);
            this.tpZamest.TabIndex = 2;
            this.tpZamest.Text = "Zamestnanci";
            this.tpZamest.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(20, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 42);
            this.label3.TabIndex = 0;
            this.label3.Text = "Zaměstnanci";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.přihlásitToolStripMenuItem,
            this.funkceISToolStripMenuItem,
            this.nápovědaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1319, 38);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // přihlásitToolStripMenuItem
            // 
            this.přihlásitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.přihlášeníToolStripMenuItem,
            this.konecToolStripMenuItem});
            this.přihlásitToolStripMenuItem.Name = "přihlásitToolStripMenuItem";
            this.přihlásitToolStripMenuItem.Size = new System.Drawing.Size(97, 34);
            this.přihlásitToolStripMenuItem.Text = "Soubor";
            // 
            // přihlášeníToolStripMenuItem
            // 
            this.přihlášeníToolStripMenuItem.Name = "přihlášeníToolStripMenuItem";
            this.přihlášeníToolStripMenuItem.Size = new System.Drawing.Size(220, 40);
            this.přihlášeníToolStripMenuItem.Text = "Přihlášení";
            this.přihlášeníToolStripMenuItem.Click += new System.EventHandler(this.přihlášeníToolStripMenuItem_Click);
            // 
            // konecToolStripMenuItem
            // 
            this.konecToolStripMenuItem.Name = "konecToolStripMenuItem";
            this.konecToolStripMenuItem.Size = new System.Drawing.Size(220, 40);
            this.konecToolStripMenuItem.Text = "Konec";
            this.konecToolStripMenuItem.Click += new System.EventHandler(this.konecToolStripMenuItem_Click);
            // 
            // funkceISToolStripMenuItem
            // 
            this.funkceISToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miKnihy,
            this.miUzivatele,
            this.miZamestnanci});
            this.funkceISToolStripMenuItem.Name = "funkceISToolStripMenuItem";
            this.funkceISToolStripMenuItem.Size = new System.Drawing.Size(119, 34);
            this.funkceISToolStripMenuItem.Text = "Funkce IS";
            // 
            // miKnihy
            // 
            this.miKnihy.Name = "miKnihy";
            this.miKnihy.Size = new System.Drawing.Size(249, 40);
            this.miKnihy.Text = "Knihy";
            this.miKnihy.Click += new System.EventHandler(this.miKnihy_Click);
            // 
            // miUzivatele
            // 
            this.miUzivatele.Name = "miUzivatele";
            this.miUzivatele.Size = new System.Drawing.Size(249, 40);
            this.miUzivatele.Text = "Uživatelé";
            this.miUzivatele.Click += new System.EventHandler(this.miUzivatele_Click);
            // 
            // miZamestnanci
            // 
            this.miZamestnanci.Name = "miZamestnanci";
            this.miZamestnanci.Size = new System.Drawing.Size(249, 40);
            this.miZamestnanci.Text = "Zaměstnanci";
            this.miZamestnanci.Click += new System.EventHandler(this.miZamestnanci_Click);
            // 
            // nápovědaToolStripMenuItem
            // 
            this.nápovědaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oAplikaciToolStripMenuItem});
            this.nápovědaToolStripMenuItem.Name = "nápovědaToolStripMenuItem";
            this.nápovědaToolStripMenuItem.Size = new System.Drawing.Size(126, 34);
            this.nápovědaToolStripMenuItem.Text = "Nápověda";
            // 
            // oAplikaciToolStripMenuItem
            // 
            this.oAplikaciToolStripMenuItem.Name = "oAplikaciToolStripMenuItem";
            this.oAplikaciToolStripMenuItem.Size = new System.Drawing.Size(225, 40);
            this.oAplikaciToolStripMenuItem.Text = "O Aplikaci";
            this.oAplikaciToolStripMenuItem.Click += new System.EventHandler(this.oAplikaciToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsObsluha,
            this.sbLabelUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 787);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1319, 39);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(108, 30);
            this.toolStripStatusLabel1.Text = "Přihlášen: ";
            // 
            // tsObsluha
            // 
            this.tsObsluha.Name = "tsObsluha";
            this.tsObsluha.Size = new System.Drawing.Size(0, 30);
            // 
            // sbLabelUser
            // 
            this.sbLabelUser.Name = "sbLabelUser";
            this.sbLabelUser.Size = new System.Drawing.Size(120, 30);
            this.sbLabelUser.Text = "nepřihlášen";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 826);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hlavní okno aplikace";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.tpKnihy.ResumeLayout(false);
            this.tpKnihy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grKnihy)).EndInit();
            this.tpUzivatele.ResumeLayout(false);
            this.tpUzivatele.PerformLayout();
            this.tpZamest.ResumeLayout(false);
            this.tpZamest.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem přihlásitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem přihlášeníToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem konecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funkceISToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nápovědaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oAplikaciToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private TablessControl tbMain;
        private System.Windows.Forms.TabPage tpKnihy;
        private System.Windows.Forms.TabPage tpUzivatele;
        private System.Windows.Forms.TabPage tpZamest;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsObsluha;
        private System.Windows.Forms.ToolStripStatusLabel sbLabelUser;
        private System.Windows.Forms.ToolStripMenuItem miKnihy;
        private System.Windows.Forms.ToolStripMenuItem miUzivatele;
        private System.Windows.Forms.ToolStripMenuItem miZamestnanci;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView grKnihy;
        private System.Windows.Forms.TextBox edKnihaID;
        private System.Windows.Forms.Button btnKnihaFind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button edKnihaDelete;
        private System.Windows.Forms.Button edKnihaEdit;
        private System.Windows.Forms.Button edKnihaAdd;
        private System.Windows.Forms.Button edKnihaRezervace;
    }
}

