using System;
using System.Threading;

namespace trab1
{
    class Program
    {
       
        static void Main(string[] args)
        {
        ini:
            Manipulacao mn = new Manipulacao();
            recursos rec = new recursos();
            string nomeprod = "";
            bool r ;

            rec.menuPrincipal();
            var leitura1 = Console.ReadLine();
       
            switch (leitura1)
            {
                case "1":
                 mn.CadastrarProd();
                    
                goto ini;
                

                case "2":
                   alter:
                    Console.Clear();
                    rec.menuAlterar();
                    string leitura2 = Console.ReadLine();
                    int quant = 0;

                    switch (leitura2)
                    {
                        //Mudar nome=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
                        case "1":
                            Console.Clear();
                            nomeprod = rec.AlterNome();
                            r = mn.SelectProd(nomeprod);
                            if (r)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Digite o novo nome ");
                                string novonome = Console.ReadLine().ToUpper();
                                mn.AlterarNomeProduto(nomeprod, novonome);

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Produto inválido");
                                Thread.Sleep(2000);
                            };

                    goto alter;

                        //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
                        //Mudar Quantidade=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
                        case "2":
                            Console.Clear();

                            nomeprod = rec.AlterNome();
                            r = mn.SelectProd(nomeprod);
                            if (r)
                            {
                                quant = rec.OperacaoQuantidadeProduto(nomeprod);
                                mn.AlterarQuantidadeProduto(nomeprod, quant);

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Produto inválido");
                                Thread.Sleep(2000);
                            };

                            goto alter;
                        //M=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
                        case "3":
                            Console.Clear();
                            nomeprod = rec.AlterNome();
                            r = mn.SelectProd(nomeprod);
                            if (r)
                            {
                                Console.Write("\nDigite o novo preço: ");
                                double preconovo = double.Parse(Console.ReadLine());
                                mn.AlterarPrecoProduto(nomeprod, preconovo);
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Produto inválido");
                                Thread.Sleep(2000); 
                            };
                            goto alter;
                        //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
                        //Mudar tudo-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
                        case "4":
                            Console.Clear();
                            AlterProd alterprod = new AlterProd();
                            alterprod.NomeProd = rec.AlterNome();
                            r = mn.SelectProd(alterprod.NomeProd);
                            if (r) 
                            { 
                                Console.Write("\nDigite o novo nome do produto:  ");
                                alterprod.NovoNome = Console.ReadLine().ToUpper();
                                Console.Write("Digite a nova quantidade de {0}: ", alterprod.NovoNome);
                                alterprod.QuantidadeProd = int.Parse(Console.ReadLine());
                                Console.Write("\nDigite o novo preço: ");
                                alterprod.PrecoProd = double.Parse(Console.ReadLine());
                                mn.AlterarTudoProduto(alterprod);
                            }   
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Produto inválido");
                                Thread.Sleep(2000); 
                            };
                            goto alter;
                        //-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
                        case "5":
                            Console.Clear();
                            goto ini;
                    }

                    goto ini;

                case "3":
                    Console.Clear();
                    Console.Write("Digite o nome do produto que deseja deletar: ");
                    nomeprod = Console.ReadLine().ToUpper();
                    r = mn.SelectProd(nomeprod);
                    if(r)
                    {
                        mn.DeletarProd(nomeprod);
                    }
                    else
                    {
                        Console.WriteLine("Produto Inválido");
                        Thread.Sleep(2000);
                        Console.Clear();
                        goto ini;
                    }
                    goto ini;
                

                case "4":
                    Console.Clear();
                    mn.SelecionarTabela();
                    Console.ReadKey();
                    Console.Clear();
                    goto ini;
                    

                case "5":
                    Environment.Exit(0);
                    break;

            }
            Console.Clear();
            Console.WriteLine("opção inválida");
            Thread.Sleep(2000);
            Console.Clear();
            goto ini;
        

         
           


        }
      
    }

}