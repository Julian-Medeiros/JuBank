
namespace JuBank.Modelos.JuBank.Modelos.ADM.Utilitario
{
    internal class AutenticacaoUtil
    {
        public bool ValidarSenha(string senhaVerdadeira, string senhaTentativa)
        {
            return senhaVerdadeira.Equals(senhaTentativa);
        }
    }
}
