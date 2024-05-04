// Estrutura base dos métodos do controlador 
using System;
using System.Collections.Generic;

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
            model = new Model(view);
            view = new View(model);
            modelLog = new ModelLog();
            model.ModelLog = modelLog;

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

        private void Login(object sender, EventArgs e)
        {
            string nomeUsuario = view.ObterNomeUsuario();
            string senha = view.ObterSenha();
            bool autenticado = model.Login(nomeUsuario, senha);
            if (autenticado)
            {
            }
            else
            {
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

        private void RealizarBuscaAvancada(object sender, EventArgs e)
        {
            string termoBusca = view.ObterTermoBusca();
            model.BuscaAvancada(termoBusca);
        }

        private void SalvarConfiguracoesPerfil(object sender, EventArgs e)
        {
            ConfiguracoesPerfil configuracoes = view.ObterConfiguracoesPerfil();
            model.SalvarConfiguracoesPerfil(configuracoes);
        }

        public void IniciarPrograma()
        {
            do
            {
                try
                {
                    view.AtivarInterface();
                }
                catch (ExceptionFormaDesconhecida ex)
                {
                    view.ExibirMensagemErro(ex.Message);
                }
            } while (!sair);
        }
    }
}
