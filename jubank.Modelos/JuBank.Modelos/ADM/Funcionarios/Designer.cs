
namespace JuBank.Modelos.ADM.Funcionarios
{
    public class Designer : Funcionario
    {
        public Designer(string cpf) : base(3000, cpf)
        {
        }
        protected internal override void AumentarSalario()
        {
            this.Salario *= 1.11;
        }
        protected internal override double getBonificacao()
        {
            return this.Salario * 0.17;
        }
    }
}
