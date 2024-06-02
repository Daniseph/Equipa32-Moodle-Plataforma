using System;
using System.Collections.Generic;

namespace PlatGestMoo
{
    public partial class BuscaAvancada
    {
        private Controller controller;

        public BuscaAvancada(Controller ctrl)
        {
            InitializeComponent();
            controller = ctrl;
            controller.ResultadosDaBusca += ExibirResultados;
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
