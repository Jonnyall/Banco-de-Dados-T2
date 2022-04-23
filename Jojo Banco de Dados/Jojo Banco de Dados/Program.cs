using System;
using System.Collections.Generic;
using Raven.Client.Documents;


/// Variavies Global
/// URL 
/// DATABASE

public class Global
	{
	public static string URL = "http://127.0.0.1:8080";
	public static string DATABASE = "JojoNET";
	}


namespace Jojo_Banco_de_Dados
{
	class Program
	{
		static void Main(string[] args)
		{
			//Programa Principal.
			BD.insere();
		}
	}

}

// Classes
class Diretor
{
	public string Id { get; set; }
	public string Nome { get; set; }
	public List<string> Filmes { get; set; }
}

class Filme
{
	public string Id { get; set; }
	public string Titulo { get; set; }
	public int Duracao { get; set; }
	public float Orcamento { get; set; }
	public string Roteiro { get; set; }
}

class Roteiro
{
	public string Id { get; set; }
	public string Titulo { get; set; }
	public string Enredo { get; set; }
	public string Elenco { get; set; }
	public List<string> Cenas { get; set; }
}

class Cena
{
	public string Id { get; set; }
	public bool EfeitosEspeciais { get; set; }
	public int Duracao { get; set; }
	public string Locacao { get; set; }
}


class BD
{
	static public void inicializa()
	{
		// Criando documentação.
		var documentStore = new DocumentStore()
		{
			Database = Global.DATABASE,
			Urls = new[] { Global.URL }
		}.Initialize();

		using (var session = documentStore.OpenSession())
		{
			//Criando os Diretores.
			var diretor_1 = new Diretor { Nome = "Maria Clara", Filmes = new List<string>() };
			var diretor_2 = new Diretor { Nome = "Jhonatan", Filmes = new List<string>() };
			var diretor_3 = new Diretor { Nome = "Lucas", Filmes = new List<string>() };
			var diretor_4 = new Diretor { Nome = "Luis", Filmes = new List<string>() };

			//Guardando todos os diretores no banco de dados.
			session.Store(diretor_1); session.Store(diretor_2); session.Store(diretor_3); session.Store(diretor_4);



			//Criando os Filmes.
			var filme_1 = new Filme { Titulo = "Chapeuzinho Vermelho", Duracao = 180, Orcamento = 40000F, Roteiro = null };
			var filme_2 = new Filme { Titulo = "Star Wars", Duracao = 240, Orcamento = 40000F, Roteiro = null };
			var filme_3 = new Filme { Titulo = "Liga da Justiça", Duracao = 120, Orcamento = 40000F, Roteiro = null };
			var filme_4 = new Filme { Titulo = "Vingadores", Duracao = 180, Orcamento = 150000F, Roteiro = null };

			//Guardando todos os filmes no banco de dados.
			session.Store(filme_1); session.Store(filme_2); session.Store(filme_3); session.Store(filme_4);



			//Criando todos os Roteiros.
			var rote_1 = new Roteiro { Titulo = "Conto infantil", Enredo = "Era uma vez...", Elenco = "Chapeuzinho Vermelho: Fulana, Lobo Mau: Cicrano", Cenas = new List<string>() };
			var rote_2 = new Roteiro { Titulo = "Star Wars", Enredo = "Numa galáxia muito distante...", Elenco = "Luke: Joaozinho, Darth Vader: Marcelo", Cenas = new List<string>() };
			var rote_3 = new Roteiro { Titulo = "Liga da Justiça", Enredo = "Era uma vez...", Elenco = "Batman: Bruno, Superman: Rodrigo", Cenas = new List<string>() };
			var rote_4 = new Roteiro { Titulo = "Avengers", Enredo = "Após Thanos...", Elenco = "Thanos: Roberto, Homem de ferro: Junior", Cenas = new List<string>() };

			//Guardando todos os roteiros no banco de dados.
			session.Store(rote_1); session.Store(rote_2); session.Store(rote_3); session.Store(rote_4);



			//Criando todos as Cenas.
			var cena_1 = new Cena { EfeitosEspeciais = true, Duracao = 5, Locacao = "Estúdio A" };
			var cena_2 = new Cena { EfeitosEspeciais = true, Duracao = 6, Locacao = "Estúdio B" };
			var cena_3 = new Cena { EfeitosEspeciais = false, Duracao = 2, Locacao = "Parque" };
			var cena_4 = new Cena { EfeitosEspeciais = false, Duracao = 10, Locacao = "Garagem" };
			var cena_5 = new Cena { EfeitosEspeciais = true, Duracao = 4, Locacao = "Porão" };
			var cena_6 = new Cena { EfeitosEspeciais = false, Duracao = 8, Locacao = "Estúdio A" };
			var cena_7 = new Cena { EfeitosEspeciais = false, Duracao = 10, Locacao = "Sala C" };
			var cena_8 = new Cena { EfeitosEspeciais = true, Duracao = 12, Locacao = "Sala C" };

			//guardando todos as Cenas no banco de dados.
			session.Store(cena_1); session.Store(cena_2); session.Store(cena_3); session.Store(cena_4); session.Store(cena_5); session.Store(cena_6); session.Store(cena_7); session.Store(cena_8);



			//"Linkando" Filmes a Diretores.
			diretor_1.Filmes.Add(filme_1.Id);

			diretor_2.Filmes.Add(filme_2.Id);

			diretor_3.Filmes.Add(filme_3.Id);
			diretor_3.Filmes.Add(filme_4.Id);



			//"Linkando" Roteiro a Filmes.
			filme_1.Roteiro = rote_1.Id;

			filme_2.Roteiro = rote_2.Id;

			filme_3.Roteiro = rote_3.Id;

			filme_4.Roteiro = rote_4.Id;



			//"Linkando" Cena a Roteiro.
			rote_1.Cenas.Add(cena_1.Id);
			rote_1.Cenas.Add(cena_2.Id);

			rote_2.Cenas.Add(cena_3.Id);
			rote_2.Cenas.Add(cena_4.Id);

			rote_3.Cenas.Add(cena_5.Id);
			rote_3.Cenas.Add(cena_6.Id);

			rote_4.Cenas.Add(cena_7.Id);
			rote_4.Cenas.Add(cena_8.Id);



			//Finalmente, Salvando as auterações.
			session.SaveChanges();
		}
	}

	static public void insere()
	{
		// Criando documentação.
		var documentStore = new DocumentStore()
		{
			Database = Global.DATABASE,
			Urls = new[] { Global.URL }
		}.Initialize();

		using (var session = documentStore.OpenSession())
		{
			//Criando o Diretor.
			var diretor = new Diretor { Nome = "Maria", Filmes = new List<string>() };

			//Criando os Filmes.
			var filme = new Filme { Titulo = "Como se Fosse a Primeira Vez", Duracao = 200, Orcamento = 40000F, Roteiro = null };

			//Criando os Roteiros.
			var rot = new Roteiro
			{
				Titulo = "Uma Comédia",
				Enredo = "O veterinário da Playboy, Henry, decide namorar Lucy ...",
				Elenco = "Adam SandlerHenry como Roth, Drew Barrymore como Lucy Whitmore ...",
				Cenas = new List<string>()
			};

			//Criando as Cenas
			var cena_1 = new Cena { EfeitosEspeciais = false, Duracao = 20, Locacao = "Praia" };
			var cena_2 = new Cena { EfeitosEspeciais = false, Duracao = 35, Locacao = "Chalé" };
			var cena_3 = new Cena { EfeitosEspeciais = false, Duracao = 35, Locacao = "Cafetaria" };

			//Salvando todas as instancias.
			session.Store(diretor);
			session.Store(filme);
			session.Store(rot);
			session.Store(cena_1);
			session.Store(cena_2);
			session.Store(cena_3);

			//Linkando as "Tabelas".
			diretor.Filmes.Add(filme.Id);
			filme.Roteiro = rot.Id;
			rot.Cenas.Add(cena_1.Id);
			rot.Cenas.Add(cena_2.Id);
			rot.Cenas.Add(cena_3.Id);


			//Salvando as alterações.
			session.SaveChanges();

		}
	}
}
