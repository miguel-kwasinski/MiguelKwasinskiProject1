using Microsoft.Data.SqlClient;
using System;

using System.Threading;

namespace trab1
{
    class Manipulacao
    {   //instanciando as classes--------------------------------------------------------------------------------------------------------------------------

        SqlCommand cmd = new SqlCommand();
        Conexao conexao = new Conexao();
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //Cadastrar--------------------------------------------------------------------------------------------------------------------------
        public void CadastrarProd()
        {
            Console.Clear();
            Produtos prod = new Produtos();
            Console.Write("Digite o Nome do produto:  ");
            prod.NomeProd = Console.ReadLine().ToUpper();
            Console.Write("\nDigite a quantidade de {0} para o cadastro: ", prod.NomeProd);
            prod.QuantidadeProd = int.Parse(Console.ReadLine());
            Console.Write("\nDigite o preço: R$");
            prod.PrecoProd = double.Parse(Console.ReadLine());

         
            cmd.CommandText = "insert into Produto (NomeProd,QuantidadeProd,PrecoProd) values (@NomeProd,@QuantidadeProd,@PrecoProd)";
            cmd.Parameters.AddWithValue("@NomeProd",prod.NomeProd);
            cmd.Parameters.AddWithValue("@QuantidadeProd", prod.QuantidadeProd);
            cmd.Parameters.AddWithValue("@PrecoProd", prod.PrecoProd);

            try
            {
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
               Console.Clear();
            Console.WriteLine("Produto cadastrado");
            Thread.Sleep(2000);
            Console.Clear();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //Alterar-------------------------------------------------------------------------------------------------------------------------------------

        //Nome=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        public void AlterarNomeProduto(string nome, string nomenovo)
        {
        
            cmd.CommandText = "update Produto set NomeProd = @NomeNovo where NomeProd = @NomeProd";
            cmd.Parameters.AddWithValue("@NomeProd", nome);
            cmd.Parameters.AddWithValue("@NomeNovo",nomenovo);

            try
            {
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery(); 
                conexao.Desconectar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        //Quantidade=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        public void AlterarQuantidadeProduto(string nome,int quantidade)
        {
        
            
                cmd.CommandText = "update Produto set QuantidadeProd = @quantidade where NomeProd = @NomeProd";
                cmd.Parameters.AddWithValue("@NomeProd", nome);
                cmd.Parameters.AddWithValue("@quantidade", quantidade);   

            try
            {
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //Preço=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        public void AlterarPrecoProduto(string nome, double NovoProd)
        {
       
            cmd.CommandText = "update Produto set PrecoProd = @NovoPreco where NomeProd = @NomeProd";
            cmd.Parameters.AddWithValue("@NomeProd", nome);
            cmd.Parameters.AddWithValue("@NovoPreco", NovoProd);

            try
            {
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        //todo o produto=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        public void AlterarTudoProduto(AlterProd troca)
        {
            
            cmd.CommandText = "update Produto set NomeProd = @NovoNome,QuantidadeProd = @QuantidadeProd,PrecoProd = @PrecoProd where NomeProd = @NomeProd";
            cmd.Parameters.AddWithValue("@NovoNome", troca.NovoNome);
            cmd.Parameters.AddWithValue("@NomeProd", troca.NomeProd);
            cmd.Parameters.AddWithValue("@QuantidadeProd", troca.QuantidadeProd);
            cmd.Parameters.AddWithValue("@PrecoProd", troca.PrecoProd);
            
           

            try
            {
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        }
        //--------------------------------------------------------------------------------------------------

        //Deletar-------------------------------------------------------------------------------------------
        public void DeletarProd(string nomeprod)
        {
            cmd.CommandText = "delete from Produto where NomeProd = @nomeprod";
            cmd.Parameters.AddWithValue("@NomeProd",nomeprod);

            try
            {
                cmd.Connection = conexao.Conectar();
                cmd.ExecuteNonQuery();
                conexao.Desconectar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //----------------------------------------------------------------------------------------------

        //Select--------------------------------------------------------------------------------------

        //Selecionar Tabela=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        public void SelecionarTabela()
        {

            string SelecionarTabela = "select * from Produto ORDER BY id ASC ";
            cmd.CommandText = SelecionarTabela;

            try
            {
                cmd.Connection = conexao.Conectar();
                var i = cmd.ExecuteReader();

                Console.WriteLine("LISTAGEM GERAL DE PRODUTOS");
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine(String.Format("{0,5}{1,10}{2,15}  {3,-8}", "CÓDIGO|", "PRODUTO|", "QUANTIDADE|","PREÇO"));
                Console.WriteLine("--------------------------------------------------------------");
                while (i.Read())
                {
                    Console.WriteLine(String.Format("{0,5} {1,10}{2, 15}    R${3, -10}", i[0], i[1], i[2], i[3] ));
                }
                conexao.Desconectar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        //Selecionar quantidade-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        public int SelectQuantidade(string nomeprod)
        {

            int quant = 0;
            cmd.CommandText = "select QuantidadeProd from Produto where NomeProd = @NomeProd";
            cmd.Parameters.AddWithValue("@NomeProd", nomeprod);

            try
            {
                cmd.Connection = conexao.Conectar();
                var i = cmd.ExecuteReader();
                
                
                while (i.Read())
                {
                     quant = Convert.ToInt32(i[0]);
                }
                conexao.Desconectar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return quant;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        public bool SelectProd(string nomeprod)
        {
            bool res = false;


            cmd.CommandText = "DECLARE @VAL INT SET @VAL =0 IF EXISTS ( select NomeProd from Produto where NomeProd = @procurar )BEGIN set @VAL =1 END else begin set @VAL = 0 end Select @VAL";
            cmd.Parameters.AddWithValue("@procurar", nomeprod);

            try
            {
                cmd.Connection = conexao.Conectar();
                 int i = Convert.ToInt32(cmd.ExecuteScalar());
                conexao.Desconectar();
                if (i == 1)
                {
                    res = true;
                }
                else
                {
                    res = false;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
         
            return res;
           
        }
        //--------------------------------------------------------------------------------------
    }
}
