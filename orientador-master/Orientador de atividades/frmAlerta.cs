using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orientador_de_atividades
{
    public partial class frmAlerta : Form
    {
        private string Descricao;
        public frmAlerta()
        {
            InitializeComponent();
        }
        public frmAlerta(string descricao)
        {
            InitializeComponent();
            Descricao = descricao; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmAlerta_Load(object sender, EventArgs e)
        {
            labelDesc.Text = Descricao;
        }
    }
}
