using System;

namespace Jojo_Banco_de_Dados
{
    class Program
    {
        static void Main(string[] args)
        {
            //Programan princiapl.

            //Criando documentação.
            var documentStore = new DocumentStore();
            documentStore.Url = "http://127.0.0.1:8080";
            documentStore.Initialize();

            using (var session = documentStore.OpenSession("JojoNET"))
            {
                var t1_cena = new Cena
                {
                    ID_CENA = 0123,
                    EFEITOS_ESPECIAIS = true
                };

                var t2_cena = new Cena
                {
                    ID_CENA = 050,
                    EFEITOS_ESPECIAIS = true
                };

                session.Store(t1_cena);
                session.Store(t2_cena);
                session.SaveChanges();
            }
        }
    }
}

//Criando as Classes.

class Cena
{
    //Id da Cena.
    public int ID_CENA { get; set; }

    //Se a Cena  tem Efeitos especiais.
    public bool EFEITOS_ESPECIAIS { get; set; }
}

class Roteiro
{
    //Id do Roteiro
    public int ID_ROTEIRO { get; set; }

    //Enredo
    public string ENREDO { get; set; }

    //Elenco
    public string ELENCO { get; set; }

    //Titulo do Roteiro
    public string TITULO_ROTEIRO { get; set; }
}