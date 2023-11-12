using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace chessgame
{
    public enum PieceColor
    {
        none,
        white,
        black
    }

    public static class Player
    {
        public static PieceColor opponent(this PieceColor player)
        {
            switch (player)
            {
                case PieceColor.white:
                    return PieceColor.black;
                case PieceColor.black:
                    return PieceColor.white;
                default: 
                    return PieceColor.none;
            }
            
        }
    }
}
