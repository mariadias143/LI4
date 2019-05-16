using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LI4.Models
{
    public class Alimento
    {
        private int id;
        private float valorNutricional;
        private DateTime validade;
        private string nome;


        public Alimento(int id, string nome, float valorNutricional, DateTime validade)
        {
            this.id = id;
            this.SetNome(nome);
            this.valorNutricional = valorNutricional;
            this.SetValidade(validade);
        }

        public int getId()
        {
            return id;
        }

        public void setId( int value)
        {
            this.id=value;
        }

        public string GetNome()
        {
            return nome;
        }

        public void SetNome(string value)
        {
            nome = value;
        }

        public DateTime GetValidade()
        {
            return validade;
        }

        public void SetValidade(DateTime value)
        {
            validade = value;
        }

        public float GetValorNutricional()
        {
            return valorNutricional;
        }

        public void SetValorNutricional(float value)
        {
            valorNutricional = value;
        }


        public override bool Equals(object obj)
        {
            return obj is Alimento alimento &&
                   id == alimento.id &&
                   GetNome() == alimento.GetNome() &&
                   valorNutricional == alimento.valorNutricional &&
                   GetValidade() == alimento.GetValidade();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
