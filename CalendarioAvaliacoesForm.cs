// Base da implementação do formulário para o Calendário de Avaliações 
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PlatGestMoo
{
    public partial class CalendarioAvaliacoesForm : Form
    {
        private Controller controller;

        public CalendarioAvaliacoesForm(Controller ctrl)
        {
            InitializeComponent();
            controller = ctrl;
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
