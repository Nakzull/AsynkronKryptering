using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsynkronKryptering
{
    public partial class Form1 : Form
    {
        Encryption encryption = new Encryption();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            var encrypted = encryption.Encrypt(Encoding.Default.GetBytes(textBoxPlainText.Text), textBoxExponent.Text, textBoxModulus.Text);
            textBoxEncrypted.Text = encryption.HexPrint(Encoding.Default.GetString(encrypted));
        }
    }
}
