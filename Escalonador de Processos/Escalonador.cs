﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Escalonador_de_Processos
{
    class Escalonador
    {
        #region Atributos
        public IEstruturaDados[] Todos { get; private set; }
        public int TempoTotal { get; private set; }
        public int Quantum { get; set; }
        public int TempoTerminoEsperado { get; private set; }
        #endregion

        #region Construtor
        public Escalonador()
        {
            //Instanciando todas as listas
            this.Todos = new Fila[10];
            for (int pos = 0; pos < Todos.Length; pos++)
            {
                Todos[pos] = new Fila();
            }

            //Definindo outros atributos
            this.TempoTotal = 0;
        }
        #endregion

        #region Métodos
        public void Run(int quantum)
        {
            this.Quantum = quantum;
            int pos = 0;
            while (!Vazio() && pos < 10)
            {
                Console.WriteLine("\t\tProcessando Lista de Processos com Prioridade " + (pos + 1));
                
                while (!Todos[pos].Vazia())
                {
                    Processos processo = (Processos)(Todos[pos].Retirar());
                    Console.WriteLine("Processando: " + processo.ToString());
                    if (Process(processo, ref pos) > 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Processo Finalizado");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        AdicionarProcesso(processo);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Processo não Finalizado");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine("Estado Fila " + (pos+1) + " \n" + Todos[pos].ToString());
                }
                pos++;
            }

            Console.WriteLine("\nO total de ciclos utilizado pelos processos é de " + this.TempoTotal + " sendo que deveria usar " + this.TempoTerminoEsperado);
        }

        //public int Processar(Processos processo)
        //{
        //    //int quantidadeTempo = processo.QtdeCiclos - this.Quantum;
        //    //int tempoTotalQuantum = this.Quantum * 500;
        //    //return Process(processo);
        //    //if (quantidadeTempo == 0)
        //    //{
        //    //    //processo finalizado -> retirar o processo da fila
        //    //    //processo.DiminuirQtdeCiclos(this.Quantum); 
        //    //    //Thread.Sleep(tempoTotalQuantum); 
        //    //    //TempoTotal += Quantum;
        //    //    Process(processo);

        //    //    return 1;
        //    //}
        //    //else if(quantidadeTempo < 0)
        //    //{
        //    //    //processo finalizado antes do tempo -> retirar o processo da fila
        //    //    //processo.DiminuirQtdeCiclos(processo.QtdeCiclos);
        //    //    //tempoTotalQuantum *= processo.QtdeCiclos / this.Quantum; //redefinição do quantum gasto
        //    //    //Thread.Sleep(tempoTotalQuantum);
        //    //    //TempoTotal += processo.QtdeCiclos;
        //    //    Process(processo);

        //    //    return 1;
        //    //}
        //    //else//quantidade > 0
        //    //{
        //    //    //processo não finalizou -> Continua na fila

        //    //    //processo.DiminuirQtdeCiclos(this.Quantum);
        //    //    //Thread.Sleep(tempoTotalQuantum);
        //    //    //TempoTotal += Quantum;
        //    //    Process(processo);

        //    //    //mudar Prioridade??? ----> retirar da lista, mudar a prioridade e adicionar ao escalonador

        //    //    if (TempoTotal >= TempoDeEsperaMaximo)
        //    //        processo.AumentarPrioridade();
        //    //    else
        //    //        processo.DiminuirPrioridade();

        //    //    return -1;
        //    //}
        //}

        private int Process(Processos process, ref int pos)
        {
            int aux = 1;

            while (aux <= Quantum && process.QtdeCiclos > 0)
            {
                process.DiminuirQtdeCiclos(1);
                //Thread.Sleep(1000);
                TempoTotal++;
                aux++;
            }

            if (process.QtdeCiclos == 0)
                return 1;
            else
            {
                //Gambiarra no tempo de espera maximo
                if (TempoTotal >= TempoTerminoEsperado * 3/4)
                {
                    process.AumentarPrioridade();
                    pos--;
                }
                else
                    process.DiminuirPrioridade();

                return -1;
            }
        }

        public void AdicionarProcesso(Processos processo)
        {
            if (processo.QtdeCiclos <= 10)
                TempoTerminoEsperado += processo.QtdeCiclos;
            else
                TempoTerminoEsperado += 10;

            switch (processo.Prioridade)
            {
                case 1: Todos[0].Inserir(processo); break;
                case 2: Todos[1].Inserir(processo); break;
                case 3: Todos[2].Inserir(processo); break;
                case 4: Todos[3].Inserir(processo); break;
                case 5: Todos[4].Inserir(processo); break;
                case 6: Todos[5].Inserir(processo); break;
                case 7: Todos[6].Inserir(processo); break;
                case 8: Todos[7].Inserir(processo); break;
                case 9: Todos[8].Inserir(processo); break;
                case 10: Todos[9].Inserir(processo); break;
                default: break;
            }
        }

        public bool Vazio()
        {
            return Todos[0].Vazia() && Todos[1].Vazia() && Todos[2].Vazia() && Todos[3].Vazia() && Todos[4].Vazia() && Todos[5].Vazia() && Todos[6].Vazia() && Todos[7].Vazia() && Todos[8].Vazia() && Todos[9].Vazia();
        }

        public override string ToString()
        {
            StringBuilder auxImpressao = new StringBuilder();

            for (int pos = 0; pos < Todos.Length; pos++)
            {
                auxImpressao.AppendLine("\tPrioridade " + (pos + 1));
                auxImpressao.AppendLine(Todos[pos].ToString());
            }

            return auxImpressao.ToString();
        }
        #endregion
    }
}
