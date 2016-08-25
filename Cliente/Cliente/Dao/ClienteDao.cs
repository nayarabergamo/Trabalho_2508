using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Trabalho.Modelo;

namespace Trabalho.Dao
{
    public class ClienteDao
    {
        public void Inserir(Cliente cliente)
        {
            FabricaConexoes connectionFactory = new FabricaConexoes();
            MySqlConnection connectionInsert = connectionFactory.GetConnection();

            String queryInserir = "INSERT INTO cliente(nome, telefone) values (@nome, @telefone)";
            connectionInsert.Open();
            MySqlCommand commandInserir = new MySqlCommand(queryInserir, connectionInsert);
            commandInserir.Prepare();
            commandInserir.Parameters.Add(new MySqlParameter("nome", cliente.nome));
            commandInserir.Parameters.Add(new MySqlParameter("telefone", cliente.telefone));
            commandInserir.ExecuteNonQuery();
            connectionInsert.Close();
        }
        public void Remover(Cliente cliente)
        {
            FabricaConexoes connectionFactory = new FabricaConexoes();
            MySqlConnection connectionRemover = connectionFactory.GetConnection();

            String query = "DELETE FROM cliente WHERE idcliente = @idCliente";
            connectionRemover.Open();
            MySqlCommand commandRemover = new MySqlCommand(query, connectionRemover);
            commandRemover.Prepare();
            commandRemover.Parameters.Add(new MySqlParameter("idcliente", cliente.idCliente));
            commandRemover.ExecuteNonQuery();
            connectionRemover.Close();
        }
        public void Modificar(Cliente cliente)
        {
            FabricaConexoes connectionFactory = new FabricaConexoes();
            MySqlConnection connection = connectionFactory.GetConnection();

            String queryModificar = "UPDATE cliente set nome=@nome, telefone=@telefone WHERE idcliente = @idCliente";
            connection.Open();
            MySqlCommand commandModificar = new MySqlCommand(queryModificar, connection);
            commandModificar.Prepare();
            commandModificar.Parameters.Add(new MySqlParameter("idProduto", cliente.idCliente));
            commandModificar.Parameters.Add(new MySqlParameter("nome", cliente.nome));
            commandModificar.Parameters.Add(new MySqlParameter("telefone", cliente.telefone));
            commandModificar.ExecuteNonQuery();
            connection.Close();
        }
        public Cliente PesquisarPorId(int idCliente)
        {
            Cliente cliente = new Cliente();
            FabricaConexoes connectionFactory = new FabricaConexoes();
            MySqlConnection connection = connectionFactory.GetConnection();
            String queryPesquisarId = "SELECT idcliente, nome, telefone FROM cliente WHERE idcliente = @idCliente";
            connection.Open();
            MySqlCommand commandPesquisaId = new MySqlCommand(queryPesquisarId, connection);
            commandPesquisaId.Prepare();
            commandPesquisaId.Parameters.Add(new MySqlParameter("idProduto", idCliente));
            MySqlDataReader readerPesquisaId = commandPesquisaId.ExecuteReader();
            if (readerPesquisaId.Read())
            {
                cliente.idCliente = Convert.ToInt32(readerPesquisaId["idcliente"]);
                cliente.nome = Convert.ToString(readerPesquisaId["nome"]);
                cliente.telefone = Convert.ToInt32(readerPesquisaId["telefone"]);
            }
            readerPesquisaId.Close();
            connection.Close();
            return cliente;
        }
        public List<Cliente> PesquisarPorNome(String nome)
        {
            List<Cliente> clientes = new List<Cliente>();
            FabricaConexoes connectionFactory = new FabricaConexoes();
            MySqlConnection connection = connectionFactory.GetConnection();
            String queryPesquisarId = "SELECT idcliente, nome, telefone FROM cliente WHERE nome = @nome";
            connection.Open();
            MySqlCommand commandPesquisaId = new MySqlCommand(queryPesquisarId, connection);
            commandPesquisaId.Prepare();
            commandPesquisaId.Parameters.Add(new MySqlParameter("nome", nome));
            MySqlDataReader readerPesquisaId = commandPesquisaId.ExecuteReader();
            while (readerPesquisaId.Read())
            {
                Cliente cliente = new Cliente();
                cliente.idCliente = Convert.ToInt32(readerPesquisaId["idcliente"]);
                cliente.nome = Convert.ToString(readerPesquisaId["nome"]);
                cliente.telefone = Convert.ToInt32(readerPesquisaId["telefone"]);
                clientes.Add(cliente);
            }
            readerPesquisaId.Close();
            connection.Close();
            return clientes;
        }
        public List<Cliente> PesquisarTodos()
        {
            List<Cliente> clientes = new List<Cliente>();
            FabricaConexoes connectionFactory = new FabricaConexoes();
            MySqlConnection connection = connectionFactory.GetConnection();
            String queryPesquisarId = "SELECT idcliente, nome, telefone FROM cliente";
            connection.Open();
            MySqlCommand commandPesquisaId = new MySqlCommand(queryPesquisarId, connection);
            commandPesquisaId.Prepare();
            MySqlDataReader readerPesquisaId = commandPesquisaId.ExecuteReader();
            while (readerPesquisaId.Read())
            {
                Cliente cliente = new Cliente();
                cliente.idCliente = Convert.ToInt32(readerPesquisaId["idcliente"]);
                cliente.nome = Convert.ToString(readerPesquisaId["nome"]);
                cliente.telefone = Convert.ToInt32(readerPesquisaId["telefone"]);
                clientes.Add(cliente);
            }
            readerPesquisaId.Close();
            connection.Close();
            return clientes;

        }
    }
}
