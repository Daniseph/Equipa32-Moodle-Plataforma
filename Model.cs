// Estrutura base dos métodos do Model 
using System;
using System.Collections.Generic;
using System.Numerics;

namespace PlatGestMoo{

    class Model {
        private View view;
        private List<Forma> formas;
        private Random aoCalha;
       
        public const int EscalaDoMundo = 1000;

        public delegate void NotificarListaDeFormasAlteradas();
        public event NotificarListaDeFormasAlteradas ListaDeFormasAlteradas;

        private ModelLog modelLog;

        public Model(View v) {
            view = v;
            formas = new List<Forma>();
            aoCalha = new Random();
            modelLog = new ModelLog();
        }

        public ModelLog ModelLog { get => modelLog; set => modelLog = value; }

        public void CriarNovaForma() {
            Forma f = new Forma();

            int sorteada = aoCalha.Next(Enum.GetNames(typeof(FormasPossiveis)).Length);
            switch (sorteada) {
                case 0:
                    f.TipoForma = FormasPossiveis.Retangulo;
                    break;
                case 1:
                    f.TipoForma = FormasPossiveis.Elipse;
                    break;
                case 2:
                    f.TipoForma = FormasPossiveis.Estrela;
                    break;
                case 3:
                    f.TipoForma = FormasPossiveis.Pentagono;
                    break;
            }
            f.Altura = aoCalha.Next(EscalaDoMundo);
            f.Largura = aoCalha.Next(EscalaDoMundo);
            f.PontoBasilar = new Vector2(aoCalha.Next(EscalaDoMundo), aoCalha.Next(EscalaDoMundo));

            formas.Add(f);

            ListaDeFormasAlteradas?.Invoke();
        }

        public void RegistarLog(FormasPossiveis tipoFormaDesconhecida) {
            ModelLog.LogErro(tipoFormaDesconhecida);
        }

        public void SolicitarListaFormas(ref List<Forma> listaDeFormas) {
            listaDeFormas = new List<Forma>();
            foreach (Forma f in formas) {
                listaDeFormas.Add(f.Clone());
            }
         }
    }
}
