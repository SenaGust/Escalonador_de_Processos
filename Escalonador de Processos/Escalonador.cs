﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escalonador_de_Processos
{
    class Escalonador
    {
        static private int ID = 1000;

        static public int GetID()
        {            
            ID = ++ID;

            return ID;
        }
    }
}
