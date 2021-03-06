﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escalonador_de_Processos
{
    class Processos : IDado
    {
        #region Atributos
        public int PID { get; private set; }
        public string Nome { get; private set; }
        public int Prioridade { get; private set; }
        public int QtdeCiclos { get; set; }

        // public int TempoCPU { get; set; } //Talvez no futuro :)
        #endregion

        #region Construtor
        public Processos(int PID, string nome, int prioridade, int qtdeCiclos)
        {
            this.PID = PID;
            this.Nome = nome;
            this.Prioridade = prioridade;
            this.QtdeCiclos = qtdeCiclos;           
        }
        #endregion

        #region Métodos
        public void DiminuirQtdeCiclos(int quantCiclos)
        {
            this.QtdeCiclos -= quantCiclos;
        }
        public void DiminuirPrioridade()
        {
            if (this.Prioridade < 10)
                this.Prioridade++;
        }
        public void AumentarPrioridade()
        {
            if (this.Prioridade > 1)
                this.Prioridade--;
        }
        #endregion

        #region Métodos Interface
        public override string ToString()
        {
            return string.Format(" PID: {0} Nome: {1} Prioridade: {2} Quantidade de Ciclos: {3}.", this.PID, this.Nome, this.Prioridade, this.QtdeCiclos);
        }
        #endregion
    }
}
