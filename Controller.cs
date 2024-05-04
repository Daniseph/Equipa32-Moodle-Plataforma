using System;

namespace PlatGestMoo{
    class Controller {
        private Model model;
        private View view;
        private ModelLog modelLog;
        private bool sair;

        public Controller() {
            sair = false;
            model = new Model(view);
            view = new View(model);
            modelLog = new ModelLog();
            model.ModelLog = modelLog;

            view.UtilizadorClicouEmLogin += UtilizadorClicouEmNovaForma; 
            view.UtilizadorClicouEmSair += UtilizadorClicouEmSair;
            view.UtilizadorSelecionouDisciplina += model.CriarNovaForma;
            view.PrecisoDeFormas += model.SolicitarListaFormas;
            model.ListaDeFormasAlteradas += view.AtualizarListaDeFormas;
            view.PrecisoDeLog += modelLog.SolicitarLog;
            modelLog.NotificarLogAlterado += view.NotificacaoDeLogAlterado;
        }

        private void FormaDesconhecida(FormasPossiveis forma) {
            view.AtivarViewLog();
            model.RegistarLog(forma);
        }

        public void IniciarPrograma() {
            do {
                try {
                    view.AtivarInterface();
                } catch (ExceptionFormaDesconhecida ex) {
                    FormaDesconhecida(ex.tipoFormaDesconhecida);
                }
            } while (!sair);
        }

        public void UtilizadorClicouEmNovaForma(object fonte, System.EventArgs args) {
            model.CriarNovaForma();
        }

        private void UtilizadorClicouEmSair(object sender, EventArgs e) {
            sair = true;
            view.Encerrar();
        }
    }
}
