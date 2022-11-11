using System;

namespace Atividade
{
    /*Criar uma agenda eletrônica que armazene em um vetor de registro as
    seguintes informações sobre uma pessoa: Situação(inteiro), nome, telefone,
    empresa em que trabalha.
    Criar um Menu com as seguintes opções:
    1-Adicionar Contato
    2-Excluir Contato
    3-Listar todos os Contatos
    4-Alterar Contato
    5- Listar dados de um determinado contato
    6-Sair
    Observações: Dimensionar o vetor para no máximo 30 elementos.Permitir que
    o usuário possa cadastrar de 1 até 30 elementos.Quando for adicionar um
    contato novo atribuir 1 para o vetor situação. Para excluir, adicionar zero ao
    vetor situação, e na opção listar deve-se listar todos aqueles em que a situação
    seja diferente de zero.*/
    class Program
    {
        public struct contato
        {
            public int situacao;
            public string nome;
            public string telefone;
            public string empresa;
        }

        static void Main(string[] args)
        {
            int menu;
            int i = 0;
            int numeroVezesNovo = 0;
            int numeroVezes = 0;
            contato[] contato = new contato[30];
            do
            {
                Console.WriteLine("***Agenda Online***");
                Console.WriteLine("Menu:\n1 - Adicionar Contato\n2 - Excluir Contato\n3 - Listar Todos os Contatos" +
                    "\n4 - Alterar Contato\n5 - Listar Dados de um Determinado Contato\n6 - Sair");
                menu = int.Parse(Console.ReadLine());
                validaMenu(ref menu);
                switch (menu)
                {
                    case 1: conta(ref i); adicionarContato(ref contato, ref numeroVezes, ref i, ref numeroVezesNovo); break;
                    case 2: excluirContato(ref contato, ref i, ref numeroVezesNovo); break;
                    case 3: listarContatos(ref contato, ref i, ref numeroVezesNovo); break;
                    case 4: alterarContato(ref contato, ref i, ref numeroVezesNovo); break;
                    case 5: dadoContato(ref contato, ref i, ref numeroVezesNovo); break;
                }
            } while (menu != 6 && i < 30);
        }
        static void validaMenu(ref int m)
        {
            while (m < 1 || m > 6)
            {
                Console.WriteLine("Opção Inválida, escolha um número entre 1 e 6\n" +
                    "Menu:\n1 - Adicionar Contato\n2 - Excluir Contato\n3 - Listar Todos os Contatos" +
                    "\n4 - Alterar Contato\n5 - Listar Dados de um Determinado Contato\n6 - Sair");
                m = int.Parse(Console.ReadLine());
            }
        }
        static void conta(ref int i)
        {
            i += 1;
        }
        static void validaSituacao(ref int s)
        {
            while (s != 0 && s != 1)
            {
                Console.WriteLine("Situação Inválida: Coloque 1 para Ativo e 0 para Inativo");
                s = int.Parse(Console.ReadLine());
            }
        }
        static void adicionarContato(ref contato[] contato, ref int numeroVezes, ref int i, ref int numeroVezesNovo)
        {
            numeroVezesNovo = i - 1;
            Console.WriteLine("Situação: 1 para Ativo / 0 para Inativo");
            contato[numeroVezesNovo].situacao = int.Parse(Console.ReadLine());
            validaSituacao(ref contato[numeroVezesNovo].situacao);
            Console.WriteLine("Nome:");
            contato[numeroVezesNovo].nome = Console.ReadLine();
            Console.WriteLine("Telefone:");
            contato[numeroVezesNovo].telefone = Console.ReadLine();
            Console.WriteLine("Empresa:");
            contato[numeroVezesNovo].empresa = Console.ReadLine();
            Console.WriteLine("Pressione qualquer tecla para limpar a tela");
            Console.ReadKey();
            Console.Clear();
        }
        static void excluirContato(ref contato[] contato, ref int i, ref int numeroVezesNovo)
        {
            int igual = 1;
            numeroVezesNovo = i - 1;
            string excluaNome;
            Console.WriteLine("Informe o nome da pessoa em que quer excluir seu contato");
            excluaNome = Console.ReadLine();
            for (int p = 0; p <= numeroVezesNovo; p++)
            {
                if (excluaNome == contato[p].nome)
                {
                    contato[p].situacao = 0;
                    igual = 0;
                }
                break;
            }
            if (igual == 1)
            {
                Console.WriteLine("Não existe nenhum contato com esse nome\nTente Novamente!");
            }
            Console.WriteLine("Pressione qualquer tecla para limpar a tela");
            Console.ReadKey();
            Console.Clear();
        }
        static void listarContatos(ref contato[] contato, ref int i, ref int numeroVezesNovo)
        {
            numeroVezesNovo = i - 1;
            Console.WriteLine("Situação   |      Nome       |    Telefone    | Empresa");
            for (int p = 0; p <= numeroVezesNovo; p++)
            {
                if (contato[p].situacao == 1)
                {
                    Console.WriteLine(contato[p].situacao + "            " + contato[p].nome + "             " +
                    contato[p].telefone + "               " + contato[p].empresa);
                }
            }
            Console.WriteLine("Pressione qualquer tecla para limpar a tela");
            Console.ReadKey();
            Console.Clear();
        }
        static void alterarContato(ref contato[] contato, ref int i, ref int numeroVezesNovo)
        {
            int igual = 1;
            numeroVezesNovo = i - 1;
            string alteraContato;
            Console.WriteLine("Informe o nome da pessoa em que quer alterar seu contato");
            alteraContato = Console.ReadLine();
            for (int p = 0; p <= numeroVezesNovo; p++)
            {
                if (alteraContato == contato[p].nome)
                {
                    Console.WriteLine("Situação: 1 para Ativo/0 para Inativo");
                    contato[p].situacao = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nome:");
                    contato[p].nome = Console.ReadLine();
                    Console.WriteLine("Telefone:");
                    contato[p].telefone = Console.ReadLine();
                    Console.WriteLine("Empresa:");
                    contato[p].empresa = Console.ReadLine();
                    igual = 0;
                }
            }
            if (igual == 1)
            {
                Console.WriteLine("Não existe nenhum contato com esse nome\nTente Novamente!");
            }
            Console.WriteLine("Pressione qualquer tecla para limpar a tela");
            Console.ReadKey();
            Console.Clear();
        }
        static void dadoContato(ref contato[] contato, ref int i, ref int numeroVezesNovo)
        {
            int igual = 1;
            numeroVezesNovo = i - 1;
            string listaDados;
            Console.WriteLine("Informe o nome da pessoa em que quer listar seus dados");
            listaDados = Console.ReadLine();
            for (int p = 0; p <= numeroVezesNovo; p++)
            {
                if (listaDados == contato[p].nome)
                {
                    Console.WriteLine("Situação   |      Nome       |    Telefone    | Empresa");
                    Console.WriteLine(contato[p].situacao + "            " + contato[p].nome + "             " +
                    contato[p].telefone + "               " + contato[p].empresa);
                    igual = 0;
                }
            }
            if (igual == 1)
            {
                Console.WriteLine("Não existe nenhum contato com esse nome\nTente Novamente!");
            }
            Console.WriteLine("Pressione qualquer tecla para limpar a tela");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
