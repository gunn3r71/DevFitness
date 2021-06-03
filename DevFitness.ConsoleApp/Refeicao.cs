using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFitness.ConsoleApp
{
    class Refeicao
    {
        public Refeicao(string descricao, int calorias)
        {
            this.Descricao = descricao;
            this.Calorias = calorias;
        }

        public string Descricao { get; private set; }
        public int Calorias { get; private set; }

        public override string ToString()
        {
            return $"{this.Descricao} possui {this.Calorias} calorias!";
        }
    }
}
