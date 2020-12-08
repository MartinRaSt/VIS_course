#region FileDescription

// **************************************************************************************************
// Projekt: DesktopApp - LoginForm.cs
// Created:  07.12.2020 22:35
// Modified: 07.12.2020 2020
// Description: Dialog zadání jména a hesla
// ***************************************************************************************************

#endregion

using System;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Zobrazení dialogového okna pro zadání přihlašovacích údajů
        /// </summary>
        /// <param name="owner"> Vlastník okna</param>
        /// <param name="jmeno">Zadané jméno</param>
        /// <param name="heslo">Zadané heslo</param>
        /// <returns>Podle toho jak se ukončil dialog tak máme výsledný DialogResult</returns>
        public static DialogResult AskForLogin(IWin32Window owner , out string jmeno, out string heslo)
        {
            var frm = new LoginForm();
            DialogResult dlr = frm.ShowDialog(owner);
            jmeno = frm.edJmeno.Text;
            heslo = frm.edHeslo.Text;
            return dlr;
        }
    } //class
} //namespace