using System;
using System.Collections.Generic;

namespace Trabalho1 {
	public class Automato {
		private List<string[]> automato;

		private string procuraEstadoInicial() {
			string estadoInicial = "";
			for (int i = 0; i < automato.Count; i++) {
				string[] particao = automato[i];
				string estado = particao[0];
				if (estado.Contains ("+")) {
					estadoInicial = estado;
					break;
				} else {
					if (i == automato.Count - 1 && !estado.Contains ("+")) {
						Console.WriteLine ("não tem estado inicial");
					}
				}
			}
			return estadoInicial;
		}

		private List<string> procuraEstadoFinal() {
			List<string> estadosFinais = new List<string>();
			for (int i = 0; i < automato.Count; i++) {
				string[] particao = automato[i];
				string estado1 = particao[0];
				string estado2 = particao[2];
				if (estado1.Contains ("*")) {
					if (!estadosFinais.Contains(estado1)) {
						estadosFinais.Add (estado1);
					}
				} else if (estado2.Contains ("*")) {
					if (!estadosFinais.Contains(estado2)) {
						estadosFinais.Add (estado2);
					}
				}
			}
			return estadosFinais;
		}

		private bool eNaoDeterministico() {
			for (int i = 0; i < automato.Count; i++) {
				string[] particao = automato[i];
				if (particao [1] == "&") {
					return true;
				} else {
					for (int j = 0; j < i; j++) {
						string[] particao2 = automato [j];
						if (particao [0] == particao2 [0] && particao [1] == particao2 [1]) {
							return true;
						}
					}
				}
			}
			return false;
		}

		private List<string[]> trasicoesNaoDeterministicas() {
			List<string[]> transicoes = new List<string[]>();
			for (int i = 0; i < automato.Count; i++) {
				string[] particao = automato[i];
				if (particao[1] == "&") {
					string[] transicao1 = {particao [0], particao [1], particao [2]};
					transicoes.Add (transicao1);
				}
				for (int j = 0; j < i; j++) {
					string[] particao2 = automato [j];
					if (particao [0] == particao2 [0] && particao [1] == particao2 [1]) {
						string[] transicao2 = {particao [0], particao [1], particao [2]};
						string[] transicao3 = {particao2 [0], particao2 [1], particao2 [2]};
						transicoes.Add (transicao2);
						transicoes.Add (transicao3);
					}
				}
			}
			return transicoes;
		}

		public Automato (List<string[]> atm) {
			automato = atm;
			Console.WriteLine ("Estado inicial: "+procuraEstadoInicial ());
			for (int i = 0; i < procuraEstadoFinal().Count; i++) {
				Console.WriteLine ("Estado Final: " + procuraEstadoFinal () [i]);
			}
			eNaoDeterministico ();
			for (int i = 0; i < trasicoesNaoDeterministicas().Count; i++) {
				string[] particao = trasicoesNaoDeterministicas () [i];
				Console.WriteLine ("Transições não-determinísticas: " + particao[0]+" "+particao[1]+" "+particao[2]);
			}
			for (int i = 0; i < trasicoesNaoDeterministicas().Count; i++) {
				string[] particao = trasicoesNaoDeterministicas () [i];
				for (int j = 0; j < i; j++) {
					string[] particao2 = trasicoesNaoDeterministicas () [j];
					if (particao [0] == particao2 [0] && particao [1] == particao2 [1]) {
						Console.WriteLine ("União de Estados: "+particao[2]+particao2[2]);
					}
				}
			}
		}

		public List<string[]> getAutomato() {
			return automato;
		}
	}
}