using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
    public class ChessSquare
    {
        public int Row { get; }
        public int Column { get; }
        //public ChessPiece CurrentPiece { get; set; }

        //properties 'Row and 'Column' store the row and the column indices of the chess square

        public ChessSquare(int row, int column)
        {
            Row = row;
            Column = column;
        }

        //the constructor initializes a 'ChessSquare' object with the provided row and column indices

        public PieceColor SquareColor()
        {
            if ((Row + Column) % 2 == 0)
            {
                return PieceColor.white;
            }
            return PieceColor.black;
        }

        //return the color of the square, determine weather they are white or black.

        public override bool Equals(object obj)
        {
            return obj is ChessSquare square &&
                   Row == square.Row &&
                   Column == square.Column;
        }

        //provide custom quality comparision for ChessSquare object
        //it checks whether two 'ChessSquar' objects are equal by cmparing their row , column. 
        //if all these values are equal, the square are consindered equal

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Column);//method used to create a hash code based on the row and column
        }
        //this hash code is used when storing objects in hash-based collections like dictionaries


        public static bool operator ==(ChessSquare left, ChessSquare right)
        {
            return EqualityComparer<ChessSquare>.Default.Equals(left, right);
        }

        public static bool operator !=(ChessSquare left, ChessSquare right)
        {
            return !(left == right);
        }
        //overloads the equality operators to allow easy comparison between chesssqaure object
    }


}
