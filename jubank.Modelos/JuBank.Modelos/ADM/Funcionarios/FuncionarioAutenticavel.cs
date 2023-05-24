using JuBank.Modelos.ADM.SistemaInterno;
using JuBank.Modelos.JuBank.Modelos.ADM.Utilitario;

namespace JuBank.Modelos.ADM.Funcionarios
{
    public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel
    {
        private AutenticacaoUtil autenticacao = new AutenticacaoUtil();
        public string Senha { get; set; }
        public FuncionarioAutenticavel(double salario, string cpf)
            : base(salario, cpf)
        {

        }
        public bool Autenticar(string senha)
        {
            return this.autenticacao.ValidarSenha(this.Senha, senha);
        }
    }
}
