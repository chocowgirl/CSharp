using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo11InterfaceFiltre.Models
{
    internal interface IPlaceable
    {
        void SetPosition(int posX, int posY, bool isHorizontal);
    }
}
