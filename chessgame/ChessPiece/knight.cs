using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
    public class knight : Pieces
    {
        public knight(PieceColor color) : base(PieceType.Knight, color)
        {

        }

        public override bool IsValidMove(ChessSquare sourceSquare, ChessSquare destSquare, ChessSquare[][] board)
        {
            return true;
        }
    }
}
