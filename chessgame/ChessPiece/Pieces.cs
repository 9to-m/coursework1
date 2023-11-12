using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
   
    public abstract class Pieces
    {
        public PieceType Type { get; }
        public PieceColor Color { get; }
        public bool HasMoved { get; set; } = false;

        protected Pieces(PieceType type, PieceColor color)
        {
            Type = type;
            Color = color;
        }

        //to check if a move is valid
        public abstract bool IsValidMove(ChessSquare sourceSquare, ChessSquare destSquare, ChessSquare[][] board);
    }
}
