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

namespace ferramentas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void informaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string info = $"Sistema Operacional:{ Environment.OSVersion}\n"+
                $"Arquitetura: {(Environment.Is64BitOperatingSystem ? "64Bits" : "32")}\n"+
                $"Processador: {System.Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER")}";

            MessageBox.Show(info);
        }

        private void limparOPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //EXIBE UMA MENSAGEM DE CONFIRMAÇÃO
            var result = MessageBox.Show("Certeza? Vai que da Ruim ", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //Captura o caminho da pasta temporaria
                string tempPatch = Path.GetTempPath();
                //Rodar metodo para apagar arquivos que vamos criar
                DeletarArquivosTemporarios(tempPatch);
            }
        }

        private void DeletarArquivosTemporarios(string tempPatch)
        {
            //Tente deletar
            try
            {
                //Se a pasta existir
                if (Directory.Exists(tempPatch))
                {
                    DirectoryInfo di = new DirectoryInfo(tempPatch);
                    //Deleta todos os arquivos
                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }
                    //Deletar todas as pastar
                    foreach(DirectoryInfo dir in di.GetDirectories())
                    {
                        dir.Delete();
                    }                     
                                                     
                                        
                }
                else
                {
                    MessageBox.Show("A Pasta nao existe !","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void desligarComputadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Criar uma instancia (Conexão) com o form 2
            desligaPC desliga = new desligaPC();
            desliga.ShowDialog();
        }
    }
}
