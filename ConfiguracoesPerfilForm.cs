// Base da implementação do formulário para as Configurações do Perfil
using System;
using System.Windows.Forms;

namespace PlatGestMoo
{
    public partial class ConfiguracoesPerfilForm : Form
    {
        private Controller controller;

        public ConfiguracoesPerfilForm(Controller ctrl)
        {
            InitializeComponent();
            controller = ctrl;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;
            bool receberNotificacoes = chkReceberNotificacoes.Checked;
            
            controller.SalvarConfiguracoesPerfil(nome, email, senha, receberNotificacoes);
        }
    }
}
