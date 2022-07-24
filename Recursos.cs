using System;



namespace trab1
{
    public class recursos
    {
        //Funções---------------------------------------------------------------------------------------------------

        //MenuPrincipal-----------------------------------------------------------------------------------------------------------------
        public void menuPrincipal()
        {
            Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒   Estoque   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");

            Console.WriteLine("");

            Console.WriteLine("");

            Console.WriteLine("╔═════════════════MENU DE OPÇÕES════════════════╗    ");

            Console.WriteLine("║ 1 Cadastrar                                   ║    ");

            Console.WriteLine("║                                               ║    ");

            Console.WriteLine("║ 2 Alterar                                     ║    ");

            Console.WriteLine("║                                               ║    ");

            Console.WriteLine("║ 3 Excluir                                     ║    ");

            Console.WriteLine("║                                               ║    ");

            Console.WriteLine("║ 4 Consultar                                   ║    ");

            Console.WriteLine("║                                               ║    ");

            Console.WriteLine("║ 5 SAIR                                        ║    ");

            Console.WriteLine("╚═══════════════════════════════════════════════╝    ");

            Console.WriteLine(" ");


            Console.Write("DIGITE UMA OPÇÃO : ");
        }
        //----------------------------------------------------------------------------------------------
        //MenuAlterar------------------------------------------------------------------------------------
        public void menuAlterar()
        {
            Console.Write("▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒   Estoque   ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");

            Console.WriteLine("");

            Console.WriteLine("");

            Console.WriteLine("╔═════════════════MENU DE OPÇÕES════════════════╗    ");

            Console.WriteLine("║ 1 alterar nome                                ║    ");

            Console.WriteLine("║                                               ║    ");

            Console.WriteLine("║ 2 Alterar quantidade                          ║    ");

            Console.WriteLine("║                                               ║    ");

            Console.WriteLine("║ 3 Alterar Preco                               ║    ");

            Console.WriteLine("║                                               ║    ");

            Console.WriteLine("║ 4 Alterar tudo                                ║    ");

            Console.WriteLine("║                                               ║    ");

            Console.WriteLine("║ 5 Voltar                                      ║    ");

            Console.WriteLine("╚═══════════════════════════════════════════════╝    ");

            Console.WriteLine(" ");


            Console.Write("DIGITE UMA OPÇÃO : ");
        }
        //-------------------------------------------------------------------------------------

        public int  OperacaoQuantidadeProduto(string NomeProd)
        {
            Manipulacao mn = new Manipulacao();
            int conta = 0;
            Console.Clear();

            int quant = mn.SelectQuantidade(NomeProd);

            Console.WriteLine("Deseja adicionar(+) ou retirar(-)");
            string leitura3 = Console.ReadLine().ToUpper();
            Console.Clear();

            //Adicionar=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-
            if (leitura3 == "+" || leitura3 == "ADICIONAR")
            {
                Console.WriteLine("A quantidade de {0} em estoque é de {1}", NomeProd, quant);
                Console.WriteLine(" ");
                Console.WriteLine("Digite a quantidade que deseja adicionar");
                conta = int.Parse(Console.ReadLine());
                quant += conta;
            }

            //Retirar=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
            else if (leitura3 == "-" || leitura3 == "RETIRAR")
            {
                Console.WriteLine("A quantidade de {0} em estoque é de {1}", NomeProd, quant);
                Console.WriteLine(" ");
                Console.WriteLine("Digite a quantidade que deseja retirar");
                conta = int.Parse(Console.ReadLine());
                quant -= conta;
                if (quant < 0) quant = 0;
            }
            return quant;
        }

        public string AlterNome()
        {
            Console.WriteLine("Digite o Nome do produto que deseja alterar ");
            string nomeprod = Console.ReadLine();
            return nomeprod;
        }
    }
    //Fim Funções---------------------------------------------------------------------------------------------------
    public class AlterProd : Produtos
    {
        public string NovoNome { get; set; }
    }
    public class Produtos
    {
        public string NomeProd { get; set; }
        public int QuantidadeProd { get; set; }
        public double PrecoProd { get; set; }
    }
}
