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

    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnNovaTarefa_Click(object sender, EventArgs e)
        {
            frmNovaTarefa f = new frmNovaTarefa();
            f.ShowDialog();
            f.Dispose();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            frmVisualizar f = new frmVisualizar();
            f.ShowDialog();
            f.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmConfig f = new frmConfig();
            f.ShowDialog();
            f.Dispose();
        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Timer tick");
            var tarefas = await getTarefas();
            var agora = DateTime.Now;
            tarefas.ForEach(ta => 
            {
                if (ta.Data.TrimTime() == agora.TrimTime()) 
                { 
                    var frmAlerta = new frmAlerta(ta.Descricao);
                    frmAlerta.ShowDialog();
                }
            });
        }

        private async Task<List<Tarefa>> getTarefas() 
        {
            List<Tarefa> tarefas;

            using (var ctx = new OrientadorContext())
            {
                tarefas = await ctx.Tarefa.ToListAsync();
                await ctx.SaveChangesAsync();
            }

            return tarefas;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
