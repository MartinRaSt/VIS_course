#region FileDescription

// **************************************************************************************************
// Projekt: DesktopApp - KnihaForm.cs
// Created:  08.12.2020 18:58
// Modified: 08.12.2020 2020
// Description: Okno pro přidání/úpravu knihy
// ***************************************************************************************************

#endregion

using System.Deployment.Application;
using System.Windows.Forms;
using PresentationLayer;

namespace DesktopApp
{
    public partial class KnihaForm : Form
    {

        public static bool CreateKniha(
            IWin32Window owner,
            out string jmeno,
            out string prijmeni,
            out string nazev,
            out string vydavatel,
            out int rok,
            out int vydani,
            out string jazyk
        )
        {
            jmeno = string.Empty;
            prijmeni = string.Empty;
            nazev = string.Empty;
            vydavatel  = string.Empty;
            rok = 2020;
            vydani = 1;
            jazyk = string.Empty;

            KnihaForm frm = new KnihaForm();
            frm.laNadpis.Text = "Vytvoření nové knihy";
            frm.Text = "Nová kniha";
            frm.edRok.Value = rok;
            frm.edVydani.Value = vydani;
            frm.cmbJazyk.DataSource = JazykType.Instance.GetJazyky();
            frm.btnOK.Text = "Vytvořit";
            if (frm.ShowDialog(owner) == DialogResult.OK)
            {
                jmeno = frm.edJmeno.Text;
                prijmeni = frm.edPrijmeni.Text;
                nazev = frm.edNazevKnihy.Text;
                vydavatel = frm.edVydavatel.Text;
                rok = (int)frm.edRok.Value;
                vydani = (int)frm.edVydani.Value;
                int ix = frm.cmbJazyk.SelectedIndex;
                jazyk = JazykType.Instance.GetJazykFromIx(ix);
                return true;
            }
            return false;
        }


        public KnihaForm()
        {
            InitializeComponent();
        }
    } //class
} //namespace