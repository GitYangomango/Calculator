using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Operandocs;

namespace Pilacs
{
    class Pila
    {
        private Operando first;
        private int nnodi;

        public Pila()
        {
            nnodi = 0;
        }

        public void Push(String valore)
        {
            Operando a = new Operando(valore);

            if (nnodi == 0)
            {
                first = a;
                nnodi++;
            }
            else
            {
                a.SetNext(first);
                first = a;
                nnodi++;
            }
        }
        public String Pop()
        {
            Operando p;
            if (nnodi == 0)
                return "Lista vuota";
            p = first;
            first = p.GetNext();
            nnodi--;
            return p.GetValore();
        }
        public String toString()
        {
            String s = "";
            Operando p;
            p = first;
            if (p == null)
                s = "Non ci sono numeri";
            else
            {
                while (p != null)
                {
                    s = s + p.GetValore();
                    p = p.GetNext();
                }
            }
            return s;
        }
    }
}
