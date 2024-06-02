// Base da implementação do formulário para visualizar as disciplinas disponíveis
using System;
using System.Collections.Generic;

namespace PlatGestMoo
{
    public partial class Disciplinas 
    {
        private Controller controller;

        public DisciplinasForm(Controller ctrl)
        {
            InitializeComponent();
            controller = ctrl;
        }

        public void AtualizarListaDisciplinas(List<Disciplina> disciplinas)
        {
            dgvDisciplinas.Rows.Clear();

            foreach (Disciplina disciplina in disciplinas)
            {
                dgvDisciplinas.Rows.Add(disciplina.Nome, disciplina.Descricao, disciplina.Professor);
            }
        }

        private void dgvDisciplinas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDisciplinas.SelectedRows.Count > 0)
            {
                string nome = dgvDisciplinas.SelectedRows[0].Cells[0].Value.ToString();
                string descricao = dgvDisciplinas.SelectedRows[0].Cells[1].Value.ToString();
                string professor = dgvDisciplinas.SelectedRows[0].Cells[2].Value.ToString();

                txtNome.Text = nome;
                txtDescricao.Text = descricao;
                txtProfessor.Text = professor;
            }
        }
    }
}

