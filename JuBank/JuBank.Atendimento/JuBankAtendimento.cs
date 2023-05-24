using JuBank.Modelos.Conta;
using jubank_ATENDIMENTO.jubank.Exceptions;
using Newtonsoft.Json;
using System.Xml.Serialization;
using JuBank.GeradorChavePix;


namespace JuBank.jubank.Atendimento
{
    internal class JuBankAtendimento
    {
        private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>(){
          new ContaCorrente(95, "123456-X"){Saldo=100,Titular = new Cliente{Cpf="11111",Nome ="Henrique",Profissao="Dev"}},
          new ContaCorrente(95, "951258-X"){Saldo=200,Titular = new Cliente{Cpf="22222",Nome ="Pedro",Profissao="Designer"}},
          new ContaCorrente(94, "987321-W"){Saldo=60,Titular = new Cliente{Cpf="33333",Nome ="Marisa",Profissao="Professor"}}
        };
        public void AtendimentoCliente()
        {
            try
            {
                char opcao = '0';
                while (opcao != '9')
                {
                    Console.Clear();
                    Console.WriteLine("===============================");
                    Console.WriteLine("===        Atendimento        ===");
                    Console.WriteLine("===  1 - Cadastrar Conta      ===");
                    Console.WriteLine("===  2 - Listar Contas        ===");
                    Console.WriteLine("===  3 - Remover Conta        ===");
                    Console.WriteLine("===  4 - Ordenar Contas       ===");
                    Console.WriteLine("===  5 - Pesquisar Conta      ===");
                    Console.WriteLine("===  6 - Exportar Contas JSON ===");
                    Console.WriteLine("===  7 - Exportar Contas XML  ===");
                    Console.WriteLine("===  8 - Cadastrar PIX        ===");
                    Console.WriteLine("===  9 - Sair do Sistema      ===");
                    Console.WriteLine("===============================");
                    Console.WriteLine("\n\n");
                    Console.Write("Digite a opção desejada: ");
                    try
                    {
                        opcao = Console.ReadLine()[0];
                    }
                    catch (Exception excecao)
                    {

                        throw new JuBankException(excecao.Message);
                    }

                    switch (opcao)
                    {
                        case '1':
                            CadastrarConta();
                            break;
                        case '2':
                            ListarContas();
                            break;
                        case '3':
                            RemoverConta();
                            break;
                        case '4':
                            OrdenarContas();
                            break;
                        case '5':
                            PesquisarContas();
                            break;
                        case '6':
                            ExportarContasJSON();
                            break;
                        case '7':
                            ExportarContasXML();
                            break;
                        case '8':
                            CadastrarChavePix();
                            break;
                        case '9':
                            EncerrarAplicacao();
                            break;
                        default:
                            Console.WriteLine("Opcao não implementada.");
                            break;
                    }
                }
            }
            catch (JuBankException excecao)
            {
                Console.WriteLine($"{excecao.Message}");
            }            
        }
        private void CadastrarConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===   CADASTRO DE CONTAS    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.WriteLine("=== Informe dados da conta ===");

            Console.Write("Número da Agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine());

            ContaCorrente conta = new ContaCorrente(numeroAgencia);
            Console.WriteLine($"O número da sua conta é: {conta.NumeroConta}");

            Console.Write("Informe o saldo inicial: ");
            conta.Saldo = double.Parse(Console.ReadLine());

            Console.Write("Informe nome do Titular: ");
            string nome = Console.ReadLine();
            while (nome.Length < 3)
            {
                Console.Write("O nome deve conter mais de 3 letras: \n");
                nome = Console.ReadLine();
            }
            conta.Titular.Nome = nome;

            Console.Write("Informe CPF do Titular: ");
            conta.Titular.Cpf = Console.ReadLine();

            Console.Write("Informe Profissão do Titular: ");
            conta.Titular.Profissao = Console.ReadLine();

            _listaDeContas.Add(conta);
            Console.WriteLine("... Conta cadastrada com sucesso! ...");
            Console.ReadKey();
        }
        private void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===     LISTA DE CONTAS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            if (_listaDeContas.Count <= 0)
            {
                Console.WriteLine("... Não há contas cadastradas! ...");
                Console.ReadKey();
                return;
            }
            foreach (ContaCorrente item in _listaDeContas)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
        private void RemoverConta()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===   REMOÇÃO DE CONTAS    ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");

            if (_listaDeContas.Count == 0)
            {
                Console.WriteLine($"Não existem contas registradas \n" +
                                  $"Pressione Enter para continuar");
                Console.ReadLine();
                return;
            }

            Console.Write("Número da conta a ser removida: ");
            string numeroConta = Console.ReadLine();
            int i = 0;
            foreach (ContaCorrente conta in _listaDeContas)
            {
                if (conta.NumeroConta == numeroConta)
                {
                    _listaDeContas.Remove(conta);
                }
                if (i == 0)
                {
                    Console.WriteLine("Não há contas registradas");
                }
            }
            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadLine();
        }
        private void OrdenarContas()
        {
            _listaDeContas.Sort();
            Console.WriteLine("... Lista de Contas ordenadas ...");
            Console.ReadKey();
        }
        List<ContaCorrente> ConsultaPorCPFTitular(string cpf)
        {
            return (from conta in _listaDeContas
                    where conta.Titular.Cpf == cpf
                    select conta).ToList();
        }
        List<ContaCorrente> ConsultaPorNumeroConta(string? numeroConta)
        {
            return (from conta in _listaDeContas
                    where conta.NumeroConta == numeroConta
                    select conta).ToList();
        }
        List<ContaCorrente> ConsultaPorAgencia(int numeroAgencia)
        {
            return (from conta in _listaDeContas
                    where conta.NumeroAgencia == numeroAgencia
                    select conta).ToList();

        }
        private void PesquisarContas()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===    PESQUISAR CONTAS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");
            Console.Write("Deseja pesquisar por (1) NÚMERO DA CONTA, (2) CPF TITULAR ou" +
                " (3) Nº AGÊNCIA: ");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Console.Write("Informe o número da Conta: ");
                        string _numeroConta = Console.ReadLine();
                        var consultaConta = ConsultaPorNumeroConta(_numeroConta);
                        Console.WriteLine(consultaConta.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        Console.Write("Informe o CPF do Titular: ");
                        string _cpf = Console.ReadLine();
                        var consultaCpf = ConsultaPorCPFTitular(_cpf);
                        Console.WriteLine(consultaCpf.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        Console.Write("Informe o Nº da Agência: ");
                        int _numeroAgencia = int.Parse(Console.ReadLine());
                        var contasPorAgencia = ConsultaPorAgencia(_numeroAgencia);

                        Console.ReadKey();
                        break;
                    }
                default:
                    Console.WriteLine("Opção não implementada.");
                    break;
            }
        }
        private void ExportarContasJSON()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===     EXPORTAR CONTAS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");

            if (_listaDeContas.Count <= 0)
            {
                Console.WriteLine("... Não existem dados para exportação...");
                Console.ReadKey();
            }
            else
            {
                string json = JsonConvert.SerializeObject(_listaDeContas,
                    Formatting.Indented);
                try
                {
                    FileStream fs = new FileStream(@"d:\tmp\export\contas.json",
                        FileMode.Create);
                    using (StreamWriter streamWriter = new StreamWriter(fs))
                    {
                        streamWriter.WriteLine(json);
                    }
                    Console.WriteLine(@"Arquivo salvo em d:\tmp\export\");
                    Console.ReadKey();
                }
                catch (Exception excecao)
                {
                    throw new JuBankException(excecao.Message);
                    Console.ReadKey();
                }
            }
        }
        private void ExportarContasXML()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===     EXPORTAR CONTAS     ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");

            if (_listaDeContas.Count <= 0)
            {
                Console.WriteLine("... Não existem dados para exportação...");
                Console.ReadKey();
            }
            else
            {
                var contasXML = new XmlSerializer(typeof(List<ContaCorrente>));

                try
                {
                    FileStream fs = new FileStream(@"d:\tmp\export\contas.xml", 
                        FileMode.Create);
                    using (StreamWriter streamwriter = new StreamWriter(fs))
                    {
                        contasXML.Serialize(streamwriter, _listaDeContas);
                    }
                    Console.WriteLine(@"Arquivo salvo em c:\temp\export\");
                    Console.ReadKey();
                }
                catch (Exception excecao)
                {
                    throw new JuBankException(excecao.Message);
                    Console.ReadKey();
                }

            }
        }
        private void CadastrarChavePix()
        {
            Console.Clear();
            Console.WriteLine("===============================");
            Console.WriteLine("===      Cadastrar PIX      ===");
            Console.WriteLine("===============================");
            Console.WriteLine("\n");

            Console.Write("Número da conta para cadastrar PIX: ");
            string numeroConta = Console.ReadLine();
            try
            {
                ConsultaPorNumeroConta(numeroConta)
                foreach (var conta in _listaDeContas)
                {
                    if (numeroConta == conta.NumeroConta)
                    {
                        string pix = GeradorPix.GetChavePix();
                        conta.ChavesPix.Add(pix);
                        Console.WriteLine($"Pix {pix} gerado com sucesso para {conta.Titular.Nome}.");
                        break;
                    }
                }
            }
            catch (Exception excecao)
            {
                throw new JuBankException(excecao.Message);
                Console.ReadKey();
            }
            finally { Console.ReadKey(); }
        }
        private void EncerrarAplicacao()
        {
            Console.WriteLine("... Encerrando Aplicação ...");
            Console.ReadKey();
        }
    }
}
