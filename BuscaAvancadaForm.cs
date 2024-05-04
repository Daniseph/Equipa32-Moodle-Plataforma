// Base da implementação do formulário para a Busca Avançada
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SeuNamespace
{
    public partial class BuscaAvancadaForm : Form
    {
        private Controller controller;

        public BuscaAvancadaForm(Controller ctrl)
        {
            InitializeComponent();
            controller = ctrl;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string termoBusca = txtTermoBusca.Text;

            controller.Buscar(termoBusca);
        }
        public void ExibirResultados(List<ResultadoBusca> resultados)
        {
            lstResultados.Items.Clear();

            foreach (ResultadoBusca resultado in resultados)
            {
                lstResultados.Items.Add($"Título: {resultado.Titulo}, Descrição: {resultado.Descricao}");
            }
        }
    }
}
