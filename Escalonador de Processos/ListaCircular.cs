﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escalonador_de_Processos
{
    class ListaCircular : IEstruturaDados
    {
        #region Atributos
        public Elemento Atual { get; set; }
        public Elemento Anterior { get; set; }
        #endregion

        #region Construtor
        public ListaCircular()
        {
            this.Atual = new Elemento(null);
            this.Anterior = this.Atual; //o anterior é igual ao atual
            this.Atual.Proximo = this.Atual; //apontador do atual aponta para o próprio atual
        }
        #endregion

        #region Métodos
        public void Inserir(IDado dado)
        {
            Elemento novo = new Elemento(dado);

            this.Anterior.Proximo = novo;
            novo.Proximo = this.Atual;
            if (this.Vazia())
                this.Atual = novo;
            else
                this.Anterior = novo;
        }

        public IDado Retirar()
        {
            if (this.Vazia())
                return null;

            Elemento aux = this.Atual;
            this.Anterior.Proximo = aux.Proximo;
            this.Atual = aux.Proximo;
            aux.Proximo = null;

            if (this.Vazia())
                this.Atual.Proximo = this.Atual;

            return aux.MeuDado;
        }

        public bool Vazia()
        {
            return Atual == Anterior;
        }

        public override string ToString()
        {
            if (Vazia())
                return null;
            else
            {
                StringBuilder result = new StringBuilder();
                Elemento aux = Atual;

                result.AppendLine(aux.MeuDado.ToString());
                aux = aux.Proximo.Proximo;

                while (aux.MeuDado != Atual.MeuDado)
                {
                    result.AppendLine(aux.MeuDado.ToString());
                    aux = aux.Proximo;
                }

                return result.ToString();
            }
        }
        #endregion
    }
}
