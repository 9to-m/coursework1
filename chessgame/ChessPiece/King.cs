using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
    public class King : Pieces
    {
        public King(PieceColor color) : base(PieceType.King, color)
        {

        }

        public override bool IsValidMove(ChessSquare sourceSquare, ChessSquare destSquare, ChessSquare[][] board)
        {
            int sourceRow = sourceSquare.Row;
            int sourceDest = sourceSquare.Column;
            int destRow = destSquare.Row;
            int destDest = destSquare.Column;
            
            int rowDiff = Math.Abs(destRow - sourceRow);
            int colDiff = Math.Abs(destRow - sourceRow);

            if (Color == PieceColor.white)
            {
                if(rowDiff > 1 || colDiff > 1)
                {
                    return false;
                }
            }
            else //when the color = black
            {
                if(rowDiff > 1 || colDiff > 1)
                {
                    return false;
                }
            }

            //castling...

            return true;
        }
    }
}
