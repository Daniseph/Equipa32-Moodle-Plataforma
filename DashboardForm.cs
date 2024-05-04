// Base da implementação do formulário de Dashboard, será necessário alterar o design e a lógica
using System;
using System.Windows.Forms;

namespace PlatGestMoo
{
    public partial class DashboardForm : Form
    {
        private Controller controller;

        public DashboardForm(Controller ctrl)
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
