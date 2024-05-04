// Estrutura base dos métodos do Views
using System;
using System.Collections.Generic;

namespace PlatGestMoo
{
    public class View
    {
        private Model model;
        private FormMain janela;
        private ViewLog viewlog;

        private List<Disciplina> listaDisciplinas;
        private List<Avaliacao> listaProximasAvaliacoes;

        public event EventHandler UtilizadorClicouEmLogin;
        public event EventHandler UtilizadorSelecionouDisciplina;
        public event EventHandler UtilizadorClicouEmSair;

        internal View(Model m)
        {
            model = m;
            viewlog = new ViewLog(janela);
        }

        public void Encerrar()
        {
            janela.Encerrar();
        }

        public void AtivarInterface()
        {
            janela = new FormMain();
            janela.View = this;
            janela.ShowDialog();
        }

        public void AtivarViewLog()
        {
            viewlog.AtivarViewLog();
        }

        public void AtualizarListaDeDisciplinas()
        {
            listaDisciplinas = model.ObterListaDisciplinas();
            janela.RenderizarListaDisciplinas(listaDisciplinas);
        }

        public void AtualizarProximasAvaliacoes()
        {
            listaProximasAvaliacoes = model.ObterProximasAvaliacoes();
            janela.RenderizarProximasAvaliacoes(listaProximasAvaliacoes);
        }

        public void CliqueEmLogin(object sender, EventArgs e)
        {
            UtilizadorClicouEmLogin?.Invoke(sender, e);
        }

        public void SelecionarDisciplina(object sender, EventArgs e)
        {
            UtilizadorSelecionouDisciplina?.Invoke(sender, e);
        }

        public void CliqueEmSair(object sender, EventArgs e)
        {
            UtilizadorClicouEmSair?.Invoke(sender, e);
        }
    }
}
