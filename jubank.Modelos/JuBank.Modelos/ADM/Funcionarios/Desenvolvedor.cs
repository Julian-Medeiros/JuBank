namespace JuBank.Modelos.ADM.Funcionarios
{
    public class Desenvolvedor : Funcionario
    {
        public Desenvolvedor(string cpf) : base(3000, cpf)
        {
        }
        protected internal override void AumentarSalario()
        {
            this.Salario *= 0.15;
        }
        protected internal override double getBonificacao()
        {
            return this.Salario * 0.1;
        }
    }
}
