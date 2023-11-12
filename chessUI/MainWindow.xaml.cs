using chessgame;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace chessUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        private ImageLoader imageLoader = new ImageLoader();
        private BitmapImage[] pieceImages = new BitmapImage[12];
        private ChessBoard board;

        private Dictionary<(PieceType, PieceColor), string> pieceImageMappings = new Dictionary<(PieceType, PieceColor), string>
        {
            {(PieceType.Pawn, PieceColor.black), "black pawn.png" },
            {(PieceType.Rook, PieceColor.black), "black rook.png" },
            {(PieceType.Knight, PieceColor.black), "black knight.png" },
            {(PieceType.Bishop, PieceColor.black), "black bishop.png" },
            {(PieceType.Queen, PieceColor.black), "black queen.png" },
            {(PieceType.King, PieceColor.black), "black king.png" },
            {(PieceType.Pawn, PieceColor.white), "white pawn.png" },
            {(PieceType.Rook, PieceColor.white), "white rook.png" },
            {(PieceType.Knight, PieceColor.white) , "white knight.png" },
            {(PieceType.Bishop, PieceColor.white) , "white bishop.png" },
            {(PieceType.Queen, PieceColor.white) , "white queen.png" },
            {(PieceType.King, PieceColor.white) , "white king.png" },
        };
        public MainWindow()
        {
            InitializeComponent();

            //load the chess piece images
            string[] imageNames = new string[] { "black pawn.png", "black rook.png", "black knight.png", "black bishop.png", "black queen.png", "black king.png", "white pawn.png", "white rook.png", "white knight.png", "white bishop.png", "white queen.png", "white king.png" };
            pieceImages = imageLoader.LoadImages(imageNames);


            //initialize the chess board
            board = ChessBoard.Initial();

            //populate the chessboard on the UI
            InitializeChessboardUI();
        }

        private void InitializeChessboardUI()
        {
            for(int row = 0; row < 8; row++)
            {
                for(int col =0; col < 8; col++)
                {
                   
                    Image PieceImage = new Image();

                    //determine the piece type and color
                    Pieces piece = board[row, col];
                   
                    if(piece != null)
                    {
                        string imageFileName = pieceImageMappings[(piece.Type, piece.Color)];
                        string imageUri = $"pack://application:,,,/resources/{imageFileName}";
                        BitmapImage imageSource = new BitmapImage(new Uri(imageUri));

                        PieceImage.Source = imageSource;
                    }
                    //set the row and column positions for the piece on the chess board
                    Grid.SetRow(PieceImage, row);
                    Grid.SetColumn(PieceImage, col);

                    //Add the piece image to the UniformGrid and the pieceImages array
                    PieceGrid.Children.Add(PieceImage);
                    
                   
                }
            }
        }

        
    }
}
