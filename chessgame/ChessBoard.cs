using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace chessgame
{
    public class ChessBoard
    {
        private readonly Pieces[,] pieces = new Pieces[8, 8];

        public static ChessBoard Initial()
        {
            ChessBoard board = new ChessBoard();
            board.AddStartPieces();
            return board;
        }

        public Pieces this[int row, int column]
        {
            get => pieces[row, column];
            set => pieces[row, column] = value;
        }

        private void AddStartPieces()
        {
            this[0, 0] = new Rook(PieceColor.black);
            this[0, 1] = new knight(PieceColor.black);
            this[0, 2] = new Bishop(PieceColor.black);
            this[0, 3] = new Queen(PieceColor.black);
            this[0, 4] = new King(PieceColor.black);
            this[0, 5] = new Bishop(PieceColor.black);
            this[0, 6] = new knight(PieceColor.black);
            this[0, 7] = new Rook(PieceColor.black);

            this[7, 0] = new Rook(PieceColor.white);
            this[7, 1] = new knight(PieceColor.white);
            this[7, 2] = new Bishop(PieceColor.white);
            this[7, 3] = new Queen(PieceColor.white);
            this[7, 4] = new King(PieceColor.white);
            this[7, 5] = new Bishop(PieceColor.white);
            this[7, 6] = new knight(PieceColor.white);
            this[7, 7] = new Rook(PieceColor.white);

            for (int i = 0; i < 8; i++)
            {
                this[1, i] = new Pawn(PieceColor.black);
                this[6, i] = new Pawn(PieceColor.white);
            }
        }

        public bool IsInsideBoard(int row, int col)
        {
            return row >= 0 && row < 8 && col >= 0 && col < 8;
        }
    }

}
