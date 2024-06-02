// Estrutura base dos métodos do Model 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlatGestMoo
{
    public class Model
    {
        private List<Disciplina> disciplinas;
        private List<Avaliacao> avaliacoes;
        private ModelLog modelLog;

        public event EventHandler DisciplinasAtualizadas;
        public event EventHandler AvaliacoesAtualizadas;

        public Model()
        {
            disciplinas = new List<Disciplina>();
            avaliacoes = new List<Avaliacao>();
            modelLog = new ModelLog();
        }

        public ModelLog ModelLog { get => modelLog; set => modelLog = value; }

        public void CarregarDisciplinas(IEnumerable<IDisciplina> disciplinas)
        {
            this.disciplinas.Clear();
            foreach (var disciplina in disciplinas)
            {
                this.disciplinas.Add(new Disciplina { Nome = disciplina.Nome, Codigo = disciplina.Codigo, Creditos = disciplina.Creditos });
            }

            // Notificar a View sobre a atualização das disciplinas
            DisciplinasAtualizadas?.Invoke(this, EventArgs.Empty);
        }

        public void CarregarAvaliacoes(IEnumerable<IAvaliacao> avaliacoes)
        {
            this.avaliacoes.Clear();
            foreach (var avaliacao in avaliacoes)
            {
                this.avaliacoes.Add(new Avaliacao { DisciplinaCodigo = avaliacao.DisciplinaCodigo, Tipo = avaliacao.Tipo, Data = avaliacao.Data, Nota = avaliacao.Nota });
            }

            // Notificar a View sobre a atualização das avaliações
            AvaliacoesAtualizadas?.Invoke(this, EventArgs.Empty);
        }
    }

    public class AuthService
    {
        public async Task VerifyCredentialsAsync(string username, string password)
        {
            // Verifica as credenciais 
            bool validCredentials = await SomeAuthenticationService.VerifyCredentialsAsync(username, password);

            if (!validCredentials)
            {
                // Se as credenciais forem inválidas
                throw new InvalidCredentialsException("Credenciais inválidas. Por favor, tente novamente.");
            }
        }
    }
}

