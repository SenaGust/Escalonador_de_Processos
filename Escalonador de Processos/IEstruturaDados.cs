﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escalonador_de_Processos
{
    interface IEstruturaDados
    {
        void Inserir(IDado dado);
        IDado Retirar();
        bool Vazia();
        string ToString();
    }
}
