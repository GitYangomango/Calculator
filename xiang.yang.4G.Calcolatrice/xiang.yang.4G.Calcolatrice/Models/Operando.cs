using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operandocs
{
    public class Operando
    {
        private String valore;
        private Operando next;

        public Operando(String valore)
        {
            this.valore = valore;
            next = null;
        }

        public String GetValore()
        {
            return valore;
        }
        public Operando GetNext()
        {
            return next;
        }
        public void SetNext(Operando p)
        {
            next = p;
        }
    }
}
