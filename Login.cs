//Base da implementação do formulário de login
using System;
using System.Threading.Tasks;

namespace PlatGestMoo
{
    public class Login
    {
        private Model model;
        private View view;

        public Login(Model model, View view)
        {
            this.model = model;
            this.view = view;
            
            view.UtilizadorClicouEmLogin += LoginAsync;
        }

        public async Task LoginAsync(object sender, EventArgs e)
        {
            try
            {
                string nomeUsuario = view.ObterNomeUsuario();
                string senha = view.ObterSenha();
                bool autenticado = await model.LoginAsync(nomeUsuario, senha);
                if (autenticado)
                {
                    // Login bem-sucedido
                    view.AtivarViewDashboard();
                    view.AtualizarListaDeDisciplinas();
                    view.AtualizarProximasAvaliacoes();
                }
                else
                {
                    // Login mal-sucedido
                    view.ExibirMensagem("Credenciais inválidas. Por favor, tente novamente.");
                }
            }
            catch (ExceptionFormaDesconhecida ex)
            {
                view.ExibirMensagemErro("Erro ao efetuar login: " + ex.Message);
            }
            catch (Exception ex)
            {
                view.ExibirMensagemErro("Erro ao efetuar login: " + ex.Message);
            }
        }
    }
}

}
