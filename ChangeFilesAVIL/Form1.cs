using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace ChangeFilesAVIL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (!Directory.Exists(txtCaminho.Text))
            {
                MessageBox.Show("O diretorio não existe, verifica ai!");
            }
            else
            {
                string[] files = System.IO.Directory.GetFiles(txtCaminho.Text, "*.*", SearchOption.TopDirectoryOnly);
                foreach (string s in files)
                {
                    System.IO.FileInfo fi = null;
                    try
                    {
                        fi = new System.IO.FileInfo(s);
                        string newName = fi.Name.Substring(0, fi.Name.IndexOf("_"));

                        if (!Directory.Exists(txtCaminho.Text +"\\novas imagens" ))
                        {
                            Directory.CreateDirectory(txtCaminho.Text + "\\novas imagens");
                        }

                        fi.CopyTo(txtCaminho.Text + "\\novas imagens\\" + newName +  fi.Extension);

                    }
                    catch
                    {
                    }
                }

                MessageBox.Show("Processado!");
            }
        }
    }
}
