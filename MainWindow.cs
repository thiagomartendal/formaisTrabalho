using System;
using Gtk;
using Trabalho1;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window {
	private List<string[]> automato;
	private NovoAutomato novo;

	public MainWindow () : base (Gtk.WindowType.Toplevel) {
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a) {
		Application.Quit ();
		a.RetVal = true;
	}

	protected void inserirAutomato (object sender, EventArgs e) {
		novo = new NovoAutomato (this);
		Automato novoAutomato = novo.getAutomato ();
		automato = novoAutomato.getAutomato ();
	}

	public void atualizarAutomato() {
		Table tabela = new Table((uint)automato.Count, 3, false);
		tabela.BorderWidth = 0;
		scrolledwindow1.Add (tabela);
		Label lbl = new Label ("Estado 1");
		Label lbl2 = new Label ("Transição");
		Label lbl3 = new Label ("Estado 2");
		tabela.Attach (lbl, 0, 1, 0, 1);
		tabela.Attach (lbl2, 1, 2, 0, 1);
		tabela.Attach (lbl3, 2, 3, 0, 1);
		lbl.Show ();
		lbl2.Show ();
		lbl3.Show ();
		uint inc = 2;
		for (int i = 0; i < automato.Count; i++) {
			string[] p = automato[i];
			Label lbl4 = new Gtk.Label (p[0]);
			Label lbl5 = new Gtk.Label (p[1]);
			Label lbl6 = new Gtk.Label (p[2]);
			tabela.Attach (lbl4, 0, 1, (uint)i+1, inc);
			tabela.Attach (lbl5, 1, 2, (uint)i+1, inc);
			tabela.Attach (lbl6, 2, 3, (uint)i+1, inc);
			lbl4.Show ();
			lbl5.Show ();
			lbl6.Show ();
			inc++;
		}
		tabela.Show ();
	}

	protected void OnAutomatoAction1Activated (object sender, EventArgs e) {
        Crud crud = new Crud("Automato");
        crud.Store<List<string[]>>(automato);
	}

	protected void OnAutomatoActionActivated (object sender, EventArgs e) {
		Crud crud = new Crud("Automato");
		crud.Load<List<string[]>>(automato);
	}

	protected void OnDeterminizarAutmatoActionActivated (object sender, EventArgs e) {
		Automato atm = new Automato (automato);
	}
}
