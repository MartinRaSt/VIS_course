#region FileDescription

// **************************************************************************************************
// Projekt: DesktopApp - Class1.cs
// Created:  07.12.2020 22:29
// Modified: 07.12.2020 2020
// Description: User control TabControl který ma v Runtime skryté záložky
// ***************************************************************************************************

#endregion

using System;
using System.Windows.Forms;

namespace DesktopApp
{
    public class TablessControl : TabControl
    {
        protected override void WndProc(ref Message m)
        {
            // Hide tabs by trapping the TCM_ADJUSTRECT message
            if (m.Msg == 0x1328 && !DesignMode) m.Result = (IntPtr) 1;
            else base.WndProc(ref m);
        }
    } //class
} //namespace