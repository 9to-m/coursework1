using System.Drawing;

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

}

public enum PieceType
{
    Pawn,
    Rook,
    Knight,
    Bishop,
    Queen,
    King
}
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

        if (Color == PieceColor.white)
        {
            //white pawns move forward(from lower rows to higher rows)
            if (sourceRow > destRow || rowDiff > 2 || colDiff > 1)
            {
                return false;
            }
            if (rowDiff == 2 && sourceRow != 6)
            {
                return false;
            }
            //pawn can move 2 squares only on their first move
        }
        else
        {
            //black pawn move forward, from higher rows to lower rows
            if (sourceRow < destRow || rowDiff > 2 || colDiff > 1)
            {
                return false;
            }
            if (rowDiff == 2 && sourceRow != 1)
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

public class King : Pieces
{
    public King(PieceColor color) : base(PieceType.King, color)
    {

    }

    public override bool IsValidMove(ChessSquare sourceSquare, ChessSquare destSquare, ChessSquare[][] board)
    {
        return true;
    }
}


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
