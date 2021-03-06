﻿using System;
using System.Collections.Generic;


namespace JARVIS.Models
{
    public class Alimento
    {
        public Alimento(int id, string nome, double valorNutricional, DateTime validade)
        {
            idAlimento = id;
            Nome = nome;
            ValorNutricional = valorNutricional;
            Validade = validade;
        }

        public Alimento() { }

        public int idAlimento { get; set; }
        public String Nome { get; set; }
        public double ValorNutricional { get; set; }
        public DateTime Validade { get; set; }
        public bool IsChecked { get; set; }
        public int alternativo { get; set; }
        public string Quantidade { get; set; }


        public bool Indispensavel()
        {
            return false; //definir
        }


        public bool temAlternativa()
        {
            if (alternativo > 0) return true;
            else return false;
        }


        public class ListaAlimentos
        {
            public List<Alimento> Alimentos { get; set; }
        }
    }

}