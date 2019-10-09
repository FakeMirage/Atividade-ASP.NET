using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEste.Models;

namespace TEste
{
    public class Repositorio
    {
        public DocumentStore store { get; set; }
        public Repositorio()
        {
            store = new DocumentStore
            {
                Urls = new[]
            {
                "http://localhost:8080"
            },
                Database = "TEste"
            };
            store.Initialize();
        }
        public string Cadastrar(Cliente cliente)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                session.Store(cliente);
                session.SaveChanges();
            }
            return Convert.ToString(cliente.id);
        }

        public List<Cliente> Listar()
        {
            using (IDocumentSession session = store.OpenSession())
            {
               return session.Query<Cliente>().ToList();
            }
        }

        public void Deletar(Cliente cliente)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                session.Delete(cliente);
                session.SaveChanges();
            }
        }

        public List<Cliente> Pesquisar(Cliente cliente)
        {
            using (IDocumentSession session = store.OpenSession())
            {
                List<Cliente> clientes = session
                .Query<Cliente>()
                .Search(u => u.nome, "a*")
                .ToList();
                return clientes;
            }
        }
    }
}



