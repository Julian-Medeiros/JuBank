
using jubank.Modelos.ADM.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jubank.Modelos.ADMs.Utilitario
{
    public class GerenciadorDeBonificacao
    {
        private double _totalBonificacao;

        public void Registrar(Funcionario funcionario)
        {
            _totalBonificacao += funcionario.getBonificacao();
        }

        public double GetTotalBonificacao()
        {
            return _totalBonificacao;
        }

    }
}
