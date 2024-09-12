using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreCRUD
{
    public partial class Sobre : Form
    {
        public Sobre()
        {
            InitializeComponent();
            CenterToScreen(); // Adicionado para centralizar a janela
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/willonoliver",
                UseShellExecute = true
            });
        }
    }
}
