using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
    public class Rook : Pieces
    {
        public Rook(PieceColor color) : base(PieceType.Rook, color)
        {

        }

        public override bool IsValidMove(ChessSquare sourceSquare, ChessSquare destSquare, ChessSquare[][] board)
        {
            return true;
        }

    }
}
