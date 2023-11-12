using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
    public class Bishop : Pieces
    {
        public Bishop(PieceColor color) : base(PieceType.Bishop, color)
        {

        }

        public override bool IsValidMove(ChessSquare sourceSquare, ChessSquare destSquare, ChessSquare[][] board)
        {
            return true;
        }
    }
}
