using Microsoft.EntityFrameworkCore;
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
    public partial class frmVisualizar : Form
    {
        private List<Tarefa> tarefas;
        public frmVisualizar()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var frmTask = new frmNovaTarefa(tarefas[list.SelectedIndex], this);
            frmTask.ShowDialog();
            frmTask.Dispose();
        }

        private void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            using (var ctx = new OrientadorContext())
            {
                ctx.Tarefa.Remove(tarefas[list.SelectedIndex]);
                await ctx.SaveChangesAsync();
                await Atualizar();
            }
        }

        public async Task Atualizar() 
        {
            list.Items.Clear();
            using (var ctx = new OrientadorContext())
            {
                tarefas = await ctx.Tarefa.ToListAsync();
                tarefas.ForEach(ta => {
                    var t = new List<string>();
                    list.Items.Add("Dia: " + ta.Data.ToString() + " | Descrição: " + ta.Descricao);
                });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private async void frmVisualizar_Load(object sender, EventArgs e)
        {
            await Atualizar();
        }
    }
}
