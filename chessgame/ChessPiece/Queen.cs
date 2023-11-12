using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{ 
    public class Queen : Pieces
    {
        public Queen(PieceColor color) : base(PieceType.Queen, color)
        {

        }

        public override bool IsValidMove(ChessSquare sourceSquare, ChessSquare destSquare, ChessSquare[][] board)
        {
            //...
            return true;
        }
    }
}
