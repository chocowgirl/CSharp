using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo20Genericite02.Models
{
    public class Usine<T> : IBatiment where T: IUnite, new() // The Usine creates Ts, where T is a IUnité type only that doesn't have it's own constructor
    {
        protected U Produire<U>() where U : T, new()
        {
            return new U();
        }
    }
}
