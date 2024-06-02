// Base da implementação do formulário para as Configurações do Perfil
using System;
using System.Collections.Generic;

namespace PlatGestMoo
{
    public partial class ConfiguracoesPerfil
    {
        private Controller controller;

        public ConfiguracoesPerfil(Controller ctrl)
        {
            InitializeComponent();
            controller = ctrl;
            controller.ConfiguracoesPerfilAtualizadas += ConfirmacaoConfiguracoesPerfil;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string email = txtEmail.Text;
            string senha = txtSenha.Text;
            bool receberNotificacoes = chkReceberNotificacoes.Checked;
            
            controller.SalvarConfiguracoesPerfil(nome, email, senha, receberNotificacoes);
        }

        public void ConfirmacaoConfiguracoesPerfil(string mensagem)
        {
            MessageBox.Show(mensagem, "Configurações Salvas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
