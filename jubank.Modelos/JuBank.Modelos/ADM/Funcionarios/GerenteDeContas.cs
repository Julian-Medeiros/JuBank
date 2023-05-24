
namespace JuBank.Modelos.ADM.Funcionarios
{
    public class GerenteDeConta : FuncionarioAutenticavel
    {
        public GerenteDeConta(string cpf) : base(4000, cpf)
        {
        }

        protected internal override void AumentarSalario()
        {
            this.Salario *= 1.05;
        }

        protected internal override double getBonificacao()
        {
            return this.Salario * 0.25;
        }
    }
}
