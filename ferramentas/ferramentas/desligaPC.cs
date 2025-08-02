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

namespace ferramentas
{
    public partial class desligaPC : Form
    {
        public desligaPC()
        {
            InitializeComponent();
        }

    

        private void btnEscolhaH_Click(object sender, EventArgs e)
        {
            //Obtem o horario selecionado pelo usuario
            DateTime horarioDesligamento = dateTimePicker1.Value;
            //obtem a hora atual
            DateTime agora = DateTime.Now;

            //calcula o tempo restante até o horario especifico
            TimeSpan tempoRestante = horarioDesligamento - agora;

            //Converter o tempo para segundos
            int tempoRestanteSegundos = (int)tempoRestante.TotalSeconds;

            //Executa o comando para desligar
            Process.Start(new ProcessStartInfo("shutdown", $"/s /t {tempoRestanteSegundos}")
            {
                CreateNoWindow = true,
                UseShellExecute = false,
            });
            MessageBox.Show($"Seu pc vai de berço as {horarioDesligamento}");
        }

        private void btnCancelaDesl_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("shutdown", $"/a")
            {
                CreateNoWindow = true,
                UseShellExecute = false,
            });
            MessageBox.Show("Desligamento Cancelado");
        }
    }
}
