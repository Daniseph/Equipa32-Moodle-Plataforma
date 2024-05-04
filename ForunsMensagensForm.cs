// Base da implementação do formulário para Fóruns e Mensagens
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PlatGestMoo
{
    public partial class ForunsMensagensForm : Form
    {
        private Controller controller;

        public ForunsMensagensForm(Controller ctrl)
        {
            InitializeComponent();
            controller = ctrl;
        }

        public void AtualizarForuns(List<Forum> foruns)
        {
            lstForuns.Items.Clear();

            foreach (Forum forum in foruns)
            {
                lstForuns.Items.Add(forum.Titulo);
            }
        }

        public void AtualizarMensagens(List<Mensagem> mensagens)
        {
            txtMensagens.Clear();

            foreach (Mensagem mensagem in mensagens)
            {
                txtMensagens.AppendText($"De: {mensagem.Remetente}\nAssunto: {mensagem.Assunto}\nMensagem: {mensagem.Conteudo}\n\n");
            }
        }

        private void lstForuns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstForuns.SelectedIndex >= 0)
            {
                int indice = lstForuns.SelectedIndex;
                controller.CarregarMensagensDoForum(indice);
            }
        }
    }
}
