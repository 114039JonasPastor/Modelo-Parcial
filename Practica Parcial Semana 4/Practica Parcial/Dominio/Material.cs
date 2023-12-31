﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Parcial.Dominio
{
    public class Material
    {
        public int Codigo
        {
            get; set;
        }
        public string Nombre
        {
            get; set;
        }
        public int Stock
        {
            get; set;
        }

        public Material(int codigo, string nombre, int stock)
        {
            this.Codigo = codigo;
            this.Stock = stock;
            this.Nombre = nombre;
        }

        public override string ToString()
        {
            return "Material: " + Nombre + " - Stock: " + Stock;
        }
    }
}
