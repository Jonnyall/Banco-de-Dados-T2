using System;
using System.Collections.Generic;
using Raven.Client.Documents;

namespace Jojo_Banco_de_Dados
{
    class Program
    {
        static void Main (string[] args)
        {
            // Programa principal.

            // Criando documentação.
            var documentStore = new DocumentStore()
            {
                Database = "T2-BD2",
                Urls = new [] { "http://127.0.0.1:8080" }
            }.Initialize();

            using (var session = documentStore.OpenSession())
            {
                var diretor1 = new Diretor
                {
                    Nome = "Maria Clara",
                    Filmes = new List<Filme>() {
                        new Filme()
                        {
                            Titulo = "Chapeuzinho Vermelho",
                            Duracao = 180,
                            Orcamento = 40000F,
                            Roteiro = new Roteiro()
                            {
                                Titulo = "Conto infantil",
                                Enredo = "Era uma vez...",
                                Elenco = "Chapeuzinho Vermelho: Fulana, Lobo Mau: Cicrano",
                                Cenas = new List<Cena> {
                                    new Cena()
                                    {
                                        EfeitosEspeciais = true,
                                        Duracao = 5,
                                        Locacao = "Estúdio A",
                                    },
                                    new Cena()
                                    {
                                        EfeitosEspeciais = true,
                                        Duracao = 6,
                                        Locacao = "Estúdio B",
                                    }
                                }
                            }
                        }
                    }
                };

                var diretor2 = new Diretor
                {
                    Nome = "Jhonatan",
                    Filmes = new List<Filme>() {
                        new Filme()
                        {
                            Titulo = "Star Wars",
                            Duracao = 240,
                            Orcamento = 40000F,
                            Roteiro = new Roteiro()
                            {
                                Titulo = "Star Wars",
                                Enredo = "Numa galáxia muito distante...",
                                Elenco = "Luke: Joaozinho, Darth Vader: Marcelo",
                                Cenas = new List<Cena> {
                                    new Cena()
                                    {
                                        EfeitosEspeciais = false,
                                        Duracao = 2,
                                        Locacao = "Parque",
                                    },
                                    new Cena()
                                    {
                                        EfeitosEspeciais = false,
                                        Duracao = 10,
                                        Locacao = "Garagem",
                                    }
                                }
                            }
                        }
                    }
                };

                var diretor3 = new Diretor
                {
                    Nome = "Lucas",
                    Filmes = new List<Filme>() {
                        new Filme()
                        {
                            Titulo = "Liga da Justiça",
                            Duracao = 120,
                            Orcamento = 40000F,
                            Roteiro = new Roteiro()
                            {
                                Titulo = "Liga da Justiça",
                                Enredo = "Era uma vez...",
                                Elenco = "Batman: Bruno, Superman: Rodrigo",
                                Cenas = new List<Cena> {
                                    new Cena()
                                    {
                                        EfeitosEspeciais = true,
                                        Duracao = 4,
                                        Locacao = "Porão",
                                    },
                                    new Cena()
                                    {
                                        EfeitosEspeciais = false,
                                        Duracao = 8,
                                        Locacao = "Estúdio A",
                                    }
                                }
                            }
                        },
                        new Filme()
                        {
                            Titulo = "Vingadores",
                            Duracao = 180,
                            Orcamento = 150000F,
                            Roteiro = new Roteiro()
                            {
                                Titulo = "Avengers",
                                Enredo = "Após Thanos...",
                                Elenco = "Thanos: Roberto, Homem de ferro: Junior",
                                Cenas = new List<Cena> {
                                    new Cena()
                                    {
                                        EfeitosEspeciais = false,
                                        Duracao = 10,
                                        Locacao = "Sala C",
                                    },
                                    new Cena()
                                    {
                                        EfeitosEspeciais = true,
                                        Duracao = 12,
                                        Locacao = "Sala C",
                                    }
                                }
                            }
                        }
                    }
                };

                var diretor4 = new Diretor
                {
                    Nome = "Luis",
                };

                session.Store(diretor1);
                session.Store(diretor2);
                session.Store(diretor3);
                session.Store(diretor4);
                session.SaveChanges();
            }
        }
    }
}

// Classes

class Diretor
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public List<Filme> Filmes { get; set; }
}

class Filme
{
    //public string Id { get; set; }
    public string Titulo { get; set; }
    public int Duracao { get; set; }
    public float Orcamento { get; set; }
    public Roteiro Roteiro { get; set; }
}

class Roteiro
{
    //public string Id { get; set; }
    public string Titulo { get; set; }
    public string Enredo { get; set; }
    public string Elenco { get; set; }
    public List<Cena> Cenas { get; set; }
}

class Cena
{
    //public string Id { get; set; }
    public bool EfeitosEspeciais { get; set; }
    public int Duracao { get; set; }
    public string Locacao { get; set; }
}

