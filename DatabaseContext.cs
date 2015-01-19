using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_Projekt
{
    static class DatabaseContext
    {
        private static IOEntities context = new IO_Projekt.IOEntities();

        public static IOEntities getContext()
        {
            return context;
        }
    }
}
