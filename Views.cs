// Estrutura base dos métodos do Views
using System;
using System.Threading.Tasks;

namespace PlatGestMoo
{
    public class View
    {
        private Model model;

        public event EventHandler UtilizadorClicouEmLogin;
        public event EventHandler UtilizadorClicouEmSair;
        public event EventHandler UtilizadorSelecionouDisciplina;
        public event EventHandler PrecisoDeFormas;
        public event EventHandler PrecisoDeLog;
        public event EventHandler UtilizadorClicouEmBuscar;
        public event EventHandler UtilizadorClicouEmSalvarConfiguracoes;

        public View(Model model)
        {
            this.model = model;
        }
	//Base da logica para ativar a interface gráfica e interação com o usuário
        public async Task AtivarInterfaceAsync()
        {
            while (true)
            {
              
                await Task.Delay(1000); // Aguarda 1 segundo 
                UtilizadorClicouEmLogin?.Invoke(this, EventArgs.Empty);
            }
        }

        public string ObterNomeUsuario()
        {
           
            return "usuário"; // Retorna o nome de usuário inserido pelo usuário
        }

        public string ObterSenha()
        {
         
            return "senha"; // Retorna a senha inserida pelo usuário
        }

        public string ObterTermoBusca()
        {
           
            return "termo de busca"; // Retorna o termo de busca inserido pelo usuário
        }

        public ConfiguracoesPerfil ObterConfiguracoesPerfil()
        {
           
            return new ConfiguracoesPerfil(); // Retorna as configurações de perfil inseridas pelo usuário
        }

        public void AtivarViewDashboard()
        {
         
        }

        public void AtualizarListaDeDisciplinas()
        {
          
        }

        public void AtualizarProximasAvaliacoes()
        {
      
        }

        public void ExibirMensagem(string mensagem)
        {
            // Exibe uma mensagem na interface gráfica
            Console.WriteLine(mensagem);
        }

        public void ExibirMensagemErro(string mensagemErro)
        {
            // Exibe uma mensagem de erro na interface gráfica
            Console.WriteLine("Erro: " + mensagemErro);
        }

        public void Encerrar()
        {
     
        }

       
    }

	private async Task OnLoginButtonClick(object sender, EventArgs e)
{
    try
    {
        // Envia o pedido de login ao Controller
        await controller.Login(txtUsername.Text, txtPassword.Text);
    }
    catch (InvalidCredentialsException ex)
    {
        // Mostra uma mensagem de erro para o usuário
        ShowErrorMessage(ex.Message);
     }
  }

}
