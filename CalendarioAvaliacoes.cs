// Base da implementação do formulário para o Calendário de Avaliações 
using System;
using System.Collections.Generic;

namespace PlatGestMoo
{
    public partial class CalendarioAvaliacoes
    {
        private Controller controller;

        public CalendarioAvaliacoes(Controller ctrl)
        {
            InitializeComponent();
            controller = ctrl;
            controller.CalendarioAvaliacoesAtualizado += AtualizarCalendario;
        }

        public void AtualizarCalendario(List<Avaliacao> avaliacoes)
        {
            lstAvaliacoes.Items.Clear();

            foreach (Avaliacao avaliacao in avaliacoes)
            {
                lstAvaliacoes.Items.Add($"Data: {avaliacao.Data.ToShortDateString()} - Disciplina: {avaliacao.Disciplina}");
            }
        }
    }
}
