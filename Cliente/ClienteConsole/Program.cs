using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabalho.Modelo;
using Trabalho.Dao;

namespace ClienteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 9;

            while (opcao != 7)
            {
                Console.Clear();
                Console.WriteLine("******Menu******");
                Console.WriteLine("1 - Inserir");
                Console.WriteLine("2 - Remover");
                Console.WriteLine("3 - Modificar");
                Console.WriteLine("4 - Pesquisar por ID");
                Console.WriteLine("5 - Pesquisar por nome");
                Console.WriteLine("6 - Pesquisar todos");
                Console.WriteLine("7 - Sair");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Inserir();
                        break;
                    case 2:
                        Remover();
                        break;
                    case 3:
                        Modificar();
                        break;
                    case 4:
                        PesquisarPorID();
                        break;
                    case 5:
                        PesquisarPorNome();
                        break;
                    case 6:
                        PesquisarTodos();
                        break;
                }
            }
        }

        public static void Inserir()
        {
            Console.Clear();
            Cliente cliente = new Cliente();
            ClienteDao clientedao = new ClienteDao();
            Console.WriteLine("Informe o nome do cliente");
            cliente.nome = Console.ReadLine();
            Console.WriteLine("Informe o telefone do cliente");
            cliente.telefone = Convert.ToInt32(Console.ReadLine());
            clientedao.Inserir(cliente);
            Console.WriteLine("Cliente inserido com sucesso");
            Console.ReadKey();
        }
        public static void Remover()
        {
            Console.Clear();
            Cliente cliente = new Cliente();
            ClienteDao clientedao = new ClienteDao();
            Console.WriteLine("Informe o id do cliente que deseja remover");
            cliente.idCliente = Convert.ToInt32(Console.ReadLine());
            clientedao.Remover(cliente);
            Console.WriteLine("Cliente removido com sucesso");
            Console.ReadKey();
        }
        public static void Modificar()
        {
            Console.Clear();
            Cliente cliente = new Cliente();
            ClienteDao clientedao = new ClienteDao();
            Console.WriteLine("Informe o id do cliente que deseja modificar");
            cliente.idCliente = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Informe o nome do cliente");
            cliente.nome = Console.ReadLine();
            Console.WriteLine("Informe o telefone do cliente");
            cliente.telefone = Convert.ToInt32(Console.ReadLine());
            clientedao.Modificar(cliente);
            Console.WriteLine("Cliente modificado com sucesso");
            Console.ReadKey();
        }
        public static void PesquisarPorID()
        {
            Console.Clear();
            Cliente cliente = new Cliente();
            ClienteDao clientedao = new ClienteDao();
            int x;
            Console.WriteLine("Informe o id do cliente que deseja pesquisar");
            x = Convert.ToInt32(Console.ReadLine());
            cliente = clientedao.PesquisarPorId(x);
            Console.WriteLine("Cliente: {0} Telefone: {1}", cliente.nome, cliente.telefone);
            Console.ReadKey();
        }
        public static void PesquisarPorNome()
        {
            Console.Clear();
            List<Cliente> clientes = new List<Cliente>();
            ClienteDao clientedao = new ClienteDao();
            String x;
            Console.WriteLine("Informe o nome do cliente que deseja pesquisar");
            x = Console.ReadLine();
            clientes = clientedao.PesquisarPorNome(x);
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine("Id: {0} Cliente: {1} Telefone: {2}", cliente.idCliente, cliente.nome, cliente.telefone);
            }
            Console.ReadKey();
        }
        public static void PesquisarTodos()
        {
            Console.Clear();
            List<Cliente> clientes = new List<Cliente>();
            ClienteDao clientedao = new ClienteDao();
            clientes = clientedao.PesquisarTodos();
            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine("Id: {0} Cliente: {1} Telefone: {2}", cliente.idCliente, cliente.nome, cliente.telefone);
            }
            Console.ReadKey();
        }
    }
    
}
