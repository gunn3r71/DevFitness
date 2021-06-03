using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFitness.ConsoleApp
{
    class Comida : Refeicao
    {
        public Comida(string descricao, int calorias) : base(descricao,calorias)
        {
        }
    }
}
