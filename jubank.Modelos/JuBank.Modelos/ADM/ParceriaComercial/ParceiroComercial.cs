using JuBank.Modelos.ADM.SistemaInterno;
using JuBank.Modelos.JuBank.Modelos.ADM.Utilitario;

namespace JuBank.Modelos.ADM.Utilitario
{
    public class ParceiroComercial : IAutenticavel
    {
        private AutenticacaoUtil autenticacao = new AutenticacaoUtil();
        public string Senha { get; set; }
        public bool Autenticar(string senha)
        {
            return this.autenticacao.ValidarSenha(this.Senha, senha);
        }
    }
}
