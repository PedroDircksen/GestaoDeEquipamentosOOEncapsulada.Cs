using System;
using System.Collections.Generic;

namespace GestaoDeEquipamentosOOEncapsulada
{
    class Program
    {
        static void Main(string[] args)
        {
            String opcaoMenuPrincipal, opcaoMenuEquipamento, opcaoMenuChamado;


            Console.WriteLine("Gerenciamento 2.0");
            while (true)
            {
                Console.Clear();
                opcaoMenuPrincipal = Menu();
                if (opcaoMenuPrincipal != "1" && opcaoMenuPrincipal != "2" && opcaoMenuPrincipal != "S")
                {
                    MensagemOpcaoInvalida();
                    continue;
                }
                if (opcaoMenuPrincipal.Equals("S"))
                    break;

                switch (opcaoMenuPrincipal)
                {
                    case "1":

                        while (true)
                        {
                            Console.Clear();

                            opcaoMenuEquipamento = MenuEquipamentos();
                            if (opcaoMenuEquipamento != "1" && opcaoMenuEquipamento != "2" && opcaoMenuEquipamento != "3" && opcaoMenuEquipamento != "4" && opcaoMenuEquipamento != "S")
                            {
                                MensagemOpcaoInvalida();
                                continue;
                            }
                            if (opcaoMenuEquipamento.Equals("S"))
                                break;

                            switch (opcaoMenuEquipamento)
                            {
                                case "1":

                                    Console.Clear();
                                    Servicos.CadastrarEquipamento();
                                    break;

                                case "2":

                                    Console.Clear();
                                    if (Servicos.countEquipamentos == 0)
                                    {
                                        Console.WriteLine("Não há itens no inventário.");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Servicos.VisualizarInventario();
                                        Console.ReadLine();
                                    }
                                    break;

                                case "3":

                                    Console.Clear();
                                    if (Servicos.countEquipamentos == 0)
                                    {
                                        Console.WriteLine("Não há itens no inventário.");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Servicos.EditarEquipamento();
                                    }
                                    break;

                                case "4":

                                    Console.Clear();
                                    if (Servicos.countEquipamentos == 0)
                                    {
                                        Console.WriteLine("Não há itens no inventário.");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Servicos.ExcluirEquipamento();
                                    }
                                    break;
                            }
                        }
                        break;

                    case "2":
                        if (Servicos.countEquipamentos == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Primeiro adicione um equipamento, depois crie um chamado.");
                            Console.ReadLine();
                        }
                        else
                        {
                            while (true)
                            {
                                Console.Clear();
                                opcaoMenuChamado = MenuChamados();
                                if (opcaoMenuChamado != "1" && opcaoMenuChamado != "2" && opcaoMenuChamado != "3" && opcaoMenuChamado != "4" && opcaoMenuChamado != "S")
                                {
                                    MensagemOpcaoInvalida();
                                    continue;
                                }
                                if (opcaoMenuChamado.Equals("S"))
                                    break;

                                switch (opcaoMenuChamado)
                                {
                                    case "1":

                                        Console.Clear();
                                        Servicos.CadastrarChamado();
                                        break;

                                    case "2":

                                        Console.Clear();
                                        if (Servicos.countChamados == 0)
                                        {
                                            Console.WriteLine("Não há chamados registrados.");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            Servicos.VisualizarChamados();
                                            Console.ReadLine();
                                        }
                                        break;

                                    case "3":

                                        Console.Clear();
                                        if (Servicos.countChamados == 0)
                                        {
                                            Console.WriteLine("Não há chamados registrados.");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            Servicos.EditarChamado();
                                        }
                                        break;

                                    case "4":

                                        Console.Clear();
                                        if (Servicos.countChamados == 0)
                                        {
                                            Console.WriteLine("Não há chamados registrados.");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            Servicos.ExcluirChamado();
                                        }
                                        break;
                                }

                            }
                        }
                        break;

                    default:
                        if (opcaoMenuPrincipal != "S")
                        {
                            MensagemOpcaoInvalida();
                        }
                        break;
                }

            }

        }

        private static void MensagemOpcaoInvalida()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Opção inválida, tente novamente.");

            Console.ResetColor();

            Console.ReadLine();
        }

        private static String Menu()
        {
            Console.WriteLine("\nInventário Disponível");
            Console.WriteLine("1 - Controle de Equipamentos");
            Console.WriteLine("2 - Controle de Chamados");
            Console.WriteLine("S - Sair");
            String opcao1 = Console.ReadLine().ToUpper();
            return opcao1;
        }

        private static String MenuEquipamentos()
        {
            Console.WriteLine("Controle de Equipamentos");
            Console.WriteLine("1 - Registrar Equipamento");
            Console.WriteLine("2 - Visualizar Equipamentos");
            Console.WriteLine("3 - Editar um Equipamento");
            Console.WriteLine("4 - Excluir um Equipamento");
            Console.WriteLine("S - Voltar");
            String opcao2 = Console.ReadLine().ToUpper();
            return opcao2;
        }

        private static String MenuChamados()
        {
            Console.WriteLine("Controle de Chamados");
            Console.WriteLine("1 - Registrar um Chamados");
            Console.WriteLine("2 - Visualizar Chamados");
            Console.WriteLine("3 - Editar um Chamado");
            Console.WriteLine("4 - Excluir um Chamado");
            Console.WriteLine("S - Voltar");
            String opcao3 = Console.ReadLine().ToUpper();
            return opcao3;
        }

    }
}
