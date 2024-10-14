using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public enum EndReason
    {
        checkmate,
        stalemate, 
        FiftyMoveRule,       //quy tac 50 nuoc
        InsufficentMaterial, //het quan de chieu
        ThreefoldRepetition  //1 vi tri xuat hien 3 lan
    }
}
