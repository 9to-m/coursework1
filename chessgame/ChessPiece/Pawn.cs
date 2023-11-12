using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
    public class Pawn : Pieces
    {
        public Pawn(PieceColor color) : base(PieceType.Pawn, color)
        {

        }

        public override bool IsValidMove(ChessSquare sourcesquare, ChessSquare destSquare, ChessSquare[][] board)
        {
            int sourceRow = sourcesquare.Row;
            int sourceCol = sourcesquare.Column;
            int destRow = destSquare.Row;
            int destCol = destSquare.Column;

            int rowDiff = Math.Abs(destRow - sourceRow);
            int colDiff = Math.Abs(destCol - sourceCol);

            if(Color == PieceColor.white)
            {
                //white pawns move forward(from lower rows to higher rows)
                if(sourceRow > destRow || rowDiff > 2 || colDiff > 1)
                {
                    return false;
                }
                if(rowDiff == 2 && sourceRow != 6)
                {
                    return false;
                }
                //pawn can move 2 squares only on their first move
            }
            else
            {
                //black pawn move forward, from higher rows to lower rows
                if(sourceRow < destRow || rowDiff > 2 || colDiff > 1)
                {
                    return false;
                }
                if(rowDiff == 2 && sourceRow != 1)
                {
                    return false;
                }
            }

            //capture diagonally
            //...

            //check for obstacles
            //...

            return true;
        }
    }

    
}
