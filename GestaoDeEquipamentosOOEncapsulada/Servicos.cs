using System;
using System.Collections.Generic;

namespace GestaoDeEquipamentosOOEncapsulada
{
    class Servicos
    {
        public static int countEquipamentos = 0;
        public static int countChamados = 0;
        public static List<string> listaEquipamentos = new List<string>(100);
        public static List<string> listaChamados = new List<string>(100);
        public static List<string> listaItens = new List<string>(100);
        public static void CadastrarEquipamento()
        {

            bool nomeInvalido = false;
            Equipamentos equip = new Equipamentos();

            do
            {
                nomeInvalido = false;
                Console.Write("Digite o nome do equipamento: ");
                equip.Nome = Console.ReadLine();
                if (equip.Nome.Length < 6)
                {
                    nomeInvalido = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nome inválido. No mínimo 6 caracteres");
                    Console.ResetColor(); ;
                }

            } while (nomeInvalido);


            Console.Write("Digite o preço do equipamento: ");
            equip.Preco = Convert.ToDouble(Console.ReadLine());

            Console.Write("Digite o número do equipamento: ");
            equip.NumeroDeSerie = Console.ReadLine();

            bool dataInvalida;
            do
            {
                dataInvalida = false;
                try
                {
                    Console.Write("Digite a data de fabricação do equipamento: ");
                    equip.Data = Convert.ToDateTime(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Data inválida, tente novamente");
                    dataInvalida = true;
                }
            }
            while (dataInvalida);

            Console.Write("Digite o fabricante do equipamento: ");
            equip.Fabricante = Console.ReadLine();

            equip.Id = countEquipamentos;
            countEquipamentos++;
            listaEquipamentos.Add($"\nNome do equipamento: {equip.Nome}\nPreço do equipamento: {equip.Preco}\nNúmero de série: {equip.NumeroDeSerie}\nData de fabricação: {equip.Data.ToString("dd/MM/yyyy")}\nFabricante: {equip.Fabricante}");
            listaItens.Add(equip.Nome);
        }
        public static void VisualizarInventario()
        {
            int i = 0;
            foreach (var item in listaEquipamentos)
            {
                Console.WriteLine("\nID: " + i + item);
                i++;
            }
        }
        public static void EditarEquipamento()
        {
            if(listaEquipamentos==null)
            {
                Console.WriteLine("Ainda não há itens no inventário.");
                Console.ReadLine();
            }
            else
            {
                VisualizarInventario();
                Console.Write("\nDigite o ID do chamado que deseja editar: ");
                int idEscolhido = Convert.ToInt32(Console.ReadLine());
                bool nomeInvalido = true;
                string nome;

                do
                {
                    nomeInvalido = false;
                    Console.Write("Digite o nome do equipamento: ");
                    nome = Console.ReadLine();
                    if (nome.Length < 6)
                    {
                        nomeInvalido = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nome inválido. No mínimo 6 caracteres");
                        Console.ResetColor(); ;
                    }

                } while (nomeInvalido);


                Console.Write("Digite o preço do equipamento: ");
                double preco = Convert.ToDouble(Console.ReadLine());

                Console.Write("Digite o número do equipamento: ");
                string numeroDeSerie = Console.ReadLine();

                bool dataInvalida;
                DateTime data = DateTime.MinValue;
                do
                {
                    dataInvalida = false;
                    try
                    {
                        Console.Write("Digite a data de fabricação do equipamento: ");
                        data = Convert.ToDateTime(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Data inválida, tente novamente");
                        dataInvalida = true;
                    }
                }
                while (dataInvalida);

                Console.Write("Digite o fabricante do equipamento: ");
                string fabricante = Console.ReadLine();

                for (int i = 0; i < countEquipamentos; i++)
                {
                    if (i == idEscolhido)
                    {
                        listaEquipamentos.RemoveAt(i);
                        listaItens.RemoveAt(i);
                        listaEquipamentos.Add($"\nNome do equipamento: {nome}\nPreço do equipamento: {preco}\nNúmero de série: {numeroDeSerie}\nData de fabricação: {data.ToString("dd/MM/yyyy")}\nFabricante: {fabricante}");
                        listaItens.Add(nome);
                    }
                }
            }
        }
        public static void ExcluirEquipamento()
        {
            VisualizarInventario();
            Console.Write("\nDigite o ID do equipamento que deseja excluir: ");
            int idEscolhido = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 0; i < listaEquipamentos.Count; i++)
            {
                if (i == idEscolhido)
                {
                    listaEquipamentos.RemoveAt(i);
                    listaItens.RemoveAt(i);
                }
            }
            countEquipamentos = countEquipamentos - 1;
        }
        public static void CadastrarChamado()
        {
            Chamados chamado = new Chamados();
            TimeSpan diasEmAberto;

            VisualizarInventario();
            Console.Write("\nDigite o ID do equipamento para manutenção: ");

            int numeroEscolhido = Convert.ToInt32(Console.ReadLine());


            Console.Write("Digite o titulo do chamado: ");
            chamado.Titulo = Console.ReadLine();

            Console.Write("Digite a descricao do chamado: ");
            chamado.Descricao = Console.ReadLine();

            bool dataInvalida;
            do
            {
                dataInvalida = false;
                try
                {
                    Console.Write("Digite a data da abertura do chamado equipamento: ");
                    chamado.DataAbertura = Convert.ToDateTime(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Data inválida, tente novamente");
                    dataInvalida = true;
                }
            }
            while (dataInvalida);

            chamado.Equipamento = listaItens[numeroEscolhido];
            countChamados++;
            diasEmAberto = DateTime.Now - chamado.DataAbertura;
            listaChamados.Add($"\nTítulo: {chamado.Titulo}\nDescrição: {chamado.Descricao}\nEquipamento: {chamado.Equipamento}\nData de abertura: {chamado.DataAbertura.ToString("dd/MM/yyyy")}\nDias em aberto: {diasEmAberto.ToString("dd")}");
        }
        public static void VisualizarChamados()
        {
            int i = 0;
            foreach (var item in listaChamados)
            {
                if (item != null)
                {
                    Console.WriteLine("\nID: " + i + " :" + item);
                    i++;
                }
            }
        }
        public static void EditarChamado()
        {
            TimeSpan diasEmAberto;
            VisualizarChamados();
            Console.WriteLine("\nDigite o ID do chamado que deseja editar: ");
            int numeroEscolhido = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o titulo do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descricao do chamado: ");
            string descricao = Console.ReadLine();
            

            bool dataInvalida;
            DateTime dataAbertura = DateTime.MinValue;
            do
            {
                dataInvalida = false;
                try
                {
                    Console.Write("Digite a data de abertura do chamado: ");
                    dataAbertura = Convert.ToDateTime(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Data inválida, tente novamente");
                    dataInvalida = true;
                }
            }
            while (dataInvalida);

            diasEmAberto = DateTime.Now - dataAbertura;
            string equipamento = listaItens[numeroEscolhido];
            listaChamados.RemoveAt(numeroEscolhido);

            listaChamados.Add($"\nTítulo: {titulo}\nDescrição: {descricao}\nEquipamento: {equipamento}\nData de abertura: {dataAbertura.ToString("dd/MM/yyyy")}\nDias em aberto: {diasEmAberto.ToString("dd")}");

            Console.WriteLine("Chamado registrado com sucesso!");
            Console.ReadLine();
        }
        public static void ExcluirChamado()
        {
            VisualizarChamados();
            Console.Write("\nDigite o ID do chamado que deseja excluir: ");
            int idEscolhido = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < listaChamados.Count; i++)
            {
                if (i == idEscolhido)
                {
                    listaChamados.RemoveAt(i);
                    listaItens.RemoveAt(i);
                }
            }
            countChamados = countChamados - 1;
        }
    }
}
