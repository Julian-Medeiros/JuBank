namespace JuBank.Modelos.Conta
{
	public class ContaCorrente
	{
		private int _numero_agencia;
		private string _conta;
		private double saldo;
		public Cliente Titular { get; set; }
		public int NumeroAgencia
		{
			get
			{
				return _numero_agencia;
			}
			set
			{
				if (value > 0)
				{
					_numero_agencia = value;
				}
			}
		}
		public string NumeroConta
		{
			get
			{
				return _conta;
			}
			set
			{
				if (value != null)
				{
					_conta = value;
				}
			}
		}
		public double Saldo
		{
			get
			{
				return saldo;
			}
			set
			{
				if (!(value < 0.0))
				{
					saldo = value;
				}
			}
		}
		public static int TotalDeContasCriadas { get; set; }

        public List<string> ChavesPix = new List<string>();
        public bool Sacar(double valor)
		{
			if (saldo < valor)
			{
				return false;
			}
			if (valor < 0.0)
			{
				return false;
			}
			saldo -= valor;
			return true;
		}
		public void Depositar(double valor)
		{
			if (!(valor < 0.0))
			{
				saldo += valor;
			}
		}
		public bool Transferir(double valor, ContaCorrente destino)
		{
			if (saldo < valor)
			{
				return false;
			}
			if (valor < 0.0)
			{
				return false;
			}
			saldo -= valor;
			destino.saldo += valor;
			return true;
		}
		public ContaCorrente(int numero_agencia)
		{
			NumeroAgencia = numero_agencia;
			NumeroConta = Guid.NewGuid().ToString().ToUpper().Substring(0, 8);
			Titular = new Cliente();
			TotalDeContasCriadas++;
		}
        public ContaCorrente(int numeroAgencia, string numeroConta)
        {
            NumeroAgencia = numeroAgencia;
			NumeroConta = numeroConta;
            Titular = new Cliente();
            TotalDeContasCriadas++;
        }
        private ContaCorrente()
        {

        }
		
        public override string ToString()
		{
			if (ChavesPix.Count() <= 0)
			{
				return $"===  Dados da Conta  === \n" +
					   $"Número da Conta: {this.NumeroConta} \n" +
					   $"Saldo da Conta: {this.Saldo} \n" +
					   $"Titular da Conta: {this.Titular.Nome} \n" +
					   $"CPF do Titular: {this.Titular.Cpf} \n" +
					   $"Profissão do Titular: {this.Titular.Profissao} \n\n" +
					   $">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> \n";
			}
			else
			{
                return $"===  Dados da Conta  === \n" +
					   $"Número da Conta: {this.NumeroConta} \n" +
					   $"PIX: {string.Join(", ", this.ChavesPix)} \n" +
					   $"Saldo da Conta: {this.Saldo} \n" +
					   $"Titular da Conta: {this.Titular.Nome} \n" +
					   $"CPF do Titular: {this.Titular.Cpf} \n" +
					   $"Profissão do Titular: {this.Titular.Profissao} \n\n" +
					   $">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> \n";
            }
        }

    }

}