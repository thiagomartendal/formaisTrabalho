using System;
using Gtk;
using System.Collections.Generic;

namespace Trabalho1 {
	public partial class NovoAutomato : Gtk.Dialog {
		private List<string[]> automato;
		MainWindow janela;

		public NovoAutomato (MainWindow main) {
			automato = new List<string[]> ();
			janela = main;
			this.Build ();
		}

		protected void OnButtonOkClicked (object sender, EventArgs e) {
			string texto = textview1.Buffer.Text;
			string[] particao = texto.Split('\n');
			for (int i = 0; i < particao.Length; i++) {
				string[] divisao = particao[i].Split(' ');
				automato.Add (divisao);
			}
			janela.atualizarAutomato ();
			this.Hide ();
		}

		public Automato getAutomato() {
			Automato novo = new Automato (automato);
			return novo;
		}
	}
}
