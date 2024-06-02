// Estrutura base dos métodos do controlador 
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlatGestMoo
{
    class Controller
    {
        private Model model;
        private View view;
        private ModelLog modelLog;
        private bool sair;

        public Controller()
        {
            sair = false;
            model = new Model(); // Primeiro cria o Model
            view = new View(model); // Depois cria a View
            modelLog = new ModelLog();
            model.ModelLog = modelLog;

            // Registra os eventos da View
            view.UtilizadorClicouEmLogin += Login;
            view.UtilizadorClicouEmSair += UtilizadorClicouEmSair;
            view.UtilizadorSelecionouDisciplina += AtualizarDetalhesDisciplina;
            view.PrecisoDeFormas += PrecisoDeFormas;
            view.PrecisoDeLog += PrecisoDeLog;
            view.UtilizadorClicouEmBuscar += RealizarBuscaAvancada;
            view.UtilizadorClicouEmSalvarConfiguracoes += SalvarConfiguracoesPerfil;
            model.ListaDeFormasAlteradas += view.AtualizarListaDeFormas;
            modelLog.NotificarLogAlterado += view.NotificacaoDeLogAlterado;
            model.ResultadosDaBusca += view.ExibirResultadosBusca;
            model.ConfiguracoesPerfilAtualizadas += view.ConfirmacaoConfiguracoesPerfil;
            model.ForunsAtualizados += view.AtualizarForuns;
            model.MensagensAtualizadas += view.AtualizarMensagens;
            model.CalendarioAvaliacoesAtualizado += view.AtualizarCalendarioAvaliacoes;
            model.DashboardPersonalizadoAtualizado += view.AtualizarDashboard;
        }

        private async Task Login(object sender, EventArgs e)
        {
            try
            {
                string nomeUsuario = view.ObterNomeUsuario();
                string senha = view.ObterSenha();
                bool autenticado = await model.LoginAsync(nomeUsuario, senha);
                if (autenticado)
                {
                    // login bem sucedido
                    view.AtivarViewDashboard(); 
                    view.AtualizarListaDeDisciplinas();
                    view.AtualizarProximasAvaliacoes(); 
                }
                else
                {
                    // login mal sucedido
                    view.ExibirMensagem("Credenciais inválidas. Por favor, tente novamente.");
                }
            }
            catch (ExceptionFormaDesconhecida ex)
            {
                // Mensagem de erro na interface gráfica
                view.ExibirMensagemErro("Erro ao efetuar login: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Erro genérica na interface gráfica
                view.ExibirMensagemErro("Erro ao efetuar login: " + ex.Message);
            }
        }

        private void UtilizadorClicouEmSair(object sender, EventArgs e)
        {
            sair = true;
            view.Encerrar();
        }

        private void AtualizarDetalhesDisciplina(object sender, EventArgs e)
        {
            
        }

        private void PrecisoDeFormas(object sender, EventArgs e)
        {
            
        }

        private void PrecisoDeLog(object sender, EventArgs e)
        {
            
        }

        private async Task RealizarBuscaAvancada(object sender, EventArgs e)
        {
            try
            {
                string termoBusca = view.ObterTermoBusca();
                await model.BuscaAvancadaAsync(termoBusca);
            }
            catch (Exception ex)
            {
                view.ExibirMensagemErro("Erro ao realizar busca avançada: " + ex.Message);
            }
        }

        private async Task SalvarConfiguracoesPerfil(object sender, EventArgs e)
        {
            try
            {
                ConfiguracoesPerfil configuracoes = view.ObterConfiguracoesPerfil();
                await model.SalvarConfiguracoesPerfilAsync(configuracoes);
            }
            catch (Exception ex)
            {
                view.ExibirMensagemErro("Erro ao salvar configurações do perfil: " + ex.Message);
            }
        }

        public async Task IniciarPrograma()
        {
            do
            {
                try
                {
                    await view.AtivarInterfaceAsync();
                }
                catch (Exception ex)
                {
                    view.ExibirMensagemErro("Erro ao iniciar o programa: " + ex.Message);
                }
            } while (!sair);
        }

        public async Task FetchDisciplinasAsync()
        {
            // Método para buscar disciplinas da fonte de dados e carregar no Model
            string jsonDisciplinas = await GetJsonDisciplinasAsync();
            var disciplinas = JsonConvert.DeserializeObject<List<IDisciplina>>(jsonDisciplinas);
            model.CarregaDisciplinas(disciplinas);
        }

        public async Task FetchAvaliacoesAsync()
        {
            // Método para buscar avaliações da fonte de dados e carregar no Model
            string jsonAvaliacoes = await GetJsonAvaliacoesAsync();
            var avaliacoes = JsonConvert.DeserializeObject<List<IAvaliacao>>(jsonAvaliacoes);
            model.CarregaAvaliacoes(avaliacoes);
        }

        private async Task<string> GetJsonDisciplinasAsync()
        {
            // Simula a obtenção de dados de disciplinas de uma fonte externa
            await Task.Delay(1000); // Simula atraso de rede
            return "[{\"Nome\": \"Disciplina 1\", \"Codigo\": \"D001\", \"Creditos\": 4}, {\"Nome\": \"Disciplina 2\", \"Codigo\": \"D002\", \"Creditos\": 3}]";
        }

        private async Task<string> GetJsonAvaliacoesAsync()
        {
            // Simula a obtenção de dados de avaliações de uma fonte externa
            await Task.Delay(1000); // Simula atraso de rede
            return "[{\"DisciplinaCodigo\": \"D001\", \"Tipo\": \"Prova\", \"Data\": \"2024-06-10\", \"Nota\": 8.5}, {\"DisciplinaCodigo\": \"D002\", \"Tipo\": \"Trabalho\", \"Data\": \"2024-06-15\", \"Nota\": 9.0}]";
        }
    }
}

