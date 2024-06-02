// Base da implementação do formulário de Dashboard, será necessário alterar o design e a lógica
using System;
using System.Collections.Generic;

namespace PlatGestMoo
{
    public partial class Dashboard
    {
        private Controller controller;

        public Dashboard(Controller ctrl)
        {
            InitializeComponent();
            controller = ctrl;
        }

        public void AtualizarDashboard(DashboardData dados)
        {
            lblDisciplinas.Text = $"Disciplinas: {dados.NumeroDisciplinas}";
            lblEventosCalendario.Text = $"Eventos do Calendário: {dados.NumeroEventos}";
        }
    }
}
