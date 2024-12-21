using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOFinal.Models
{
    public static class CategoriaManager
    {
        public static Categoria? GetById(int id)
        {
            if (Enum.IsDefined(typeof(Categoria), id))
            {
                return (Categoria)id;
            }
            return null;
        }
    }
}
