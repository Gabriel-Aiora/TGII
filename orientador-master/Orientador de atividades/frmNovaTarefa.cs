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
    public partial class frmNovaTarefa : Form
    {
        private Tarefa Tarefa;
        private frmVisualizar FrmVisualizar;
        public frmNovaTarefa()
        {
            InitializeComponent();
        }
        
        public frmNovaTarefa(Tarefa tarefa, frmVisualizar frmVisualizar)
        {
            Tarefa = tarefa;
            FrmVisualizar = frmVisualizar;
            InitializeComponent();
            date.Value = tarefa.Data;
            time.Value = tarefa.Data;
            textDesc.Text = tarefa.Descricao;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (Tarefa == null)
            {
                var data = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, time.Value.Hour, time.Value.Minute, time.Value.Second);
                var tarefa = new Tarefa(textDesc.Text, data);

                using (var ctx = new OrientadorContext())
                {
                    ctx.Tarefa.Add(tarefa);
                    await ctx.SaveChangesAsync();
                }
            }
            else 
            {
                Tarefa.Data = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, time.Value.Hour, time.Value.Minute, time.Value.Second);
                Tarefa.Descricao = textDesc.Text;

                using (var ctx = new OrientadorContext())
                {
                    ctx.Tarefa.Update(Tarefa);
                    await ctx.SaveChangesAsync();
                }

                FrmVisualizar.Atualizar();
            }
            Close();
            Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
