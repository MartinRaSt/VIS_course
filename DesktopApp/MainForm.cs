#region FileDescription

// **************************************************************************************************
// Projekt: DesktopApp - Form1.cs
// Created:  17.11.2020 23:22
// Modified: 07.12.2020 2020
// Description: Hlavní okno aplikace

// ***************************************************************************************************

#endregion

using System.Collections.Generic;
using System.Windows.Forms;
using BusinessLayer.BO;
using BusinessLayer.Controllers;

namespace DesktopApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetMenuState();
        }

        //Nastavení menu po spuštění
        private void SetMenuState()
        {
            sbLabelUser.Text = "Nepřihlášen";
            miKnihy.Enabled = false;
            miUzivatele.Enabled = false;
            miZamestnanci.Enabled = false;
            tbMain.Visible = false;
        }

        private void oAplikaciToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            ShowDialogAbout();
        }

        //Zobrazení dialogu About
        private void ShowDialogAbout()
        {
            var frm = new AboutForm();
            frm.ShowDialog(this);
        }

        private void konecToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            AppClose();
        }

        //Ukonceni aplikace
        private void AppClose()
        {
            this.Close();
        }

        private void přihlášeníToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            LoginToIS();
        }

        /// <summary>
        /// Metoda pro pihlášení do systému
        /// </summary>
        private void LoginToIS()
        {
            string jmeno = string.Empty;
            string heslo = string.Empty;

            DialogResult dlr = LoginForm.AskForLogin(this, out jmeno, out heslo);
            if (dlr == DialogResult.OK)
            {
                if (!UIHelper.Instance.ValidateLogin(jmeno,heslo))
                    MessageBox.Show(null, "Chybně zadané jméno nebo heslo", "Přihlášení do IS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(null, "Přihlášení zrušeno uživatelem","Přihlášení do IS",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            UpdateMenuAndStatusBar();
        }

        /// <summary>
        /// Aktualizace menu a stavového řádku
        /// </summary>
        private void UpdateMenuAndStatusBar()
        {
            if (!UIHelper.Instance.Prihlasen)
            {
                sbLabelUser.Text = "Nepřihlášen";
                miKnihy.Enabled = false;
                miUzivatele.Enabled = false;
                miZamestnanci.Enabled = false;
                tbMain.Visible = false;
            }
            else
            {
                string typ = UIHelper.Instance.Uzivatel ? "uživatel" : "správce";
                sbLabelUser.Text = $@"{UIHelper.Instance.Jmeno} ({typ})";
                if (UIHelper.Instance.Uzivatel)
                {
                    miKnihy.Enabled = true;
                    miUzivatele.Enabled = false;
                    miZamestnanci.Enabled = false;
                    tbMain.Visible = true;
                    tbMain.SelectedIndex = 0; //tab knihy
                }
                else
                {
                    //Správce
                    miKnihy.Enabled = true;
                    miUzivatele.Enabled = true;
                    miZamestnanci.Enabled = true;
                    tbMain.Visible = true;
                    tbMain.SelectedIndex = 0; //tab knihy
                }
                ShowKnihy();
            }

        }

        private void miKnihy_Click(object sender, System.EventArgs e)
        {
            ShowKnihy();
        }

        /// <summary>
        /// Zobrazení záložky knihy, zobrazí všechny knihy
        /// </summary>
        private void ShowKnihy()
        {
            tbMain.SelectedIndex = 0;
            grKnihy.DataSource = typeof(List<>);
            grKnihy.DataSource = UIHelper.Instance.SpravceKnihBL.SeznamKnih;
            grKnihy.ResetBindings();
            grKnihy.AutoResizeColumns();
            grKnihy.Refresh();
        }

        private void miUzivatele_Click(object sender, System.EventArgs e)
        {
            ShowUzivatele();
        }

        /// <summary>
        /// Zobrazí záložku uživatelé
        /// </summary>
        private void ShowUzivatele()
        {
            tbMain.SelectedIndex = 1;
        }

        private void miZamestnanci_Click(object sender, System.EventArgs e)
        {
            ShowZamestnanci();
        }

        /// <summary>
        /// Zobrazí záložku zaměstnanci
        /// </summary>
        private void ShowZamestnanci()
        {
            tbMain.SelectedIndex = 2;
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            UpdateMenuAndStatusBar();
        }

        private void edKnihaAdd_Click(object sender, System.EventArgs e)
        {
            AddNewKniha();
        }

        /// <summary>
        /// Přidání nové knihy
        /// </summary>
        private void AddNewKniha()
        {
            string jmeno = string.Empty;
            string prijmeni = string.Empty;
            string nazev = string.Empty;
            string vydavatel = string.Empty;
            int rok = 2020;
            int vydani = 1;
            string jazyk = string.Empty;
            if (KnihaForm.CreateKniha(this, out jmeno, out prijmeni, out nazev, out vydavatel, out rok, out vydani, out jazyk))
            {
                //Vytvorime novy BO kniha
                SpravaKnih.Instance.AddKniha(new Kniha()
                {
                    AutorJmeno = jmeno,
                    AutorPrijmeni = prijmeni,
                    NazevKnihy = nazev,
                    Vydavatel = vydavatel,
                    RokVydani = rok,
                    Vydani = vydani,
                    Jazyk = jazyk
                });
                //musime obnovit seznam knih v UI
                ShowKnihy();
                MessageBox.Show(this, "Nová kniha byla přidána do IS", "Knihy", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show(this,"Přidání knihy bylo zrušeno uživatelem","Knihy",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void edKnihaDelete_Click(object sender, System.EventArgs e)
        {
            DeleteKniha();
        }

        /// <summary>
        /// Smažeme knihu z IS, ta na které aktuálně stojíme
        /// </summary>
        private void DeleteKniha()
        {
            if (grKnihy.CurrentRow != null)
            {
                var kniha = (Kniha)grKnihy.CurrentRow.DataBoundItem;
                var odp = MessageBox.Show(this, $"Chcete opravdu odstranit knihu {kniha.NazevKnihy}", "Knihy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (odp == DialogResult.Yes)
                {
                    SpravaKnih.Instance.DeleteKniha(kniha);
                    //musime obnovit seznam knih v UI
                    ShowKnihy();
                    MessageBox.Show(this, "Kniha byla odstraněna z IS", "Knihy", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show(this, "Mazání knihy bylo zrušeno", "Knihy", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
            }
            else
            {
                MessageBox.Show(this, "Není vybrána kniha ke smazání", "Knihy", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void edKnihaEdit_Click(object sender, System.EventArgs e)
        {
            AddKnihaDoIS();
        }

        ///Přidání nové knihy
        private void AddKnihaDoIS()
        {
            MessageBox.Show(this, "Funkce není implementována", "Knihy", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKnihaFind_Click(object sender, System.EventArgs e)
        {
            NajdiKnihuPodleID();
        }

        /// <summary>
        /// Nalezení knihy podle jejího ID  (nedává moc smysl)
        /// </summary>
        private void NajdiKnihuPodleID()
        {
            MessageBox.Show(this, "Funkce není implementována", "Knihy", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void edKnihaRezervace_Click(object sender, System.EventArgs e)
        {
            VytvorRezervaci();
        }

        /// <summary>
        /// Vytvoření nové rezervace
        /// </summary>
        private void VytvorRezervaci()
        {
            MessageBox.Show(this, "Funkce není implementována", "Knihy", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    } //class
} //namespace