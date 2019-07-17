using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess.Models.Pieces
{
    class Pawn : Piece
    {
        public Pawn(Sprite2D sprite, int row, int col, ChessColor color, Board board)
            : base(sprite, row, col, color, board)
        {
            ChessPiece = ChessPiece.Pawn;
        }

        #region ChessMethods
        public override void CalculateLegalMoves()
        {
            legals.Clear();
            if (NumberOfMoves == 0)
            {
                if (ChessColor == ChessColor.White && board.IsEmpty(5, Col) && board.IsEmpty(4, Col))
                {
                    if (board.IsLegalMove(this, 4, Col))
                    {
                        AddLegalMove(4, Col);
                    }
                }
                else if (ChessColor == ChessColor.Black && board.IsEmpty(2, Col) && board.IsEmpty(3, Col))
                {
                    if (board.IsLegalMove(this, 3, Col))
                    {
                        AddLegalMove(3, Col);
                    }
                }
            }
            if (ChessColor == ChessColor.White && board.IsEmpty(Row - 1, Col))
            {
                if (board.IsLegalMove(this, Row - 1, Col))
                {
                    AddLegalMove(Row - 1, Col);
                }
            }
            else if (ChessColor == ChessColor.Black && board.IsEmpty(Row + 1, Col))
            {
                if (board.IsLegalMove(this, Row + 1, Col))
                {
                    AddLegalMove(Row + 1, Col);
                }
            }
            if (Col != 0)
            {
                if (ChessColor == ChessColor.White && !board.IsEmpty(Row - 1, Col - 1) && board.GetPiece(Row - 1, Col - 1).ChessColor != ChessColor)
                {
                    if (board.IsLegalMove(this, Row - 1, Col - 1))
                    {
                        AddLegalMove(Row - 1, Col - 1);
                    }
                }
                else if (ChessColor == ChessColor.Black && !board.IsEmpty(Row + 1, Col - 1) && board.GetPiece(Row + 1, Col - 1).ChessColor != ChessColor)
                {
                    if (board.IsLegalMove(this, Row + 1, Col - 1))
                    {
                        AddLegalMove(Row + 1, Col - 1);
                    }
                }
            }
            if (Col != 7)
            {
                if (ChessColor == ChessColor.White && !board.IsEmpty(Row - 1, Col + 1) && board.GetPiece(Row - 1, Col + 1).ChessColor != ChessColor)
                {
                    if (board.IsLegalMove(this, Row - 1, Col + 1))
                    {
                        AddLegalMove(Row - 1, Col + 1);
                    }
                }
                else if (ChessColor == ChessColor.Black && !board.IsEmpty(Row + 1, Col + 1) && board.GetPiece(Row + 1, Col + 1).ChessColor != ChessColor)
                {
                    if (board.IsLegalMove(this, Row + 1, Col + 1))
                    {
                        AddLegalMove(Row + 1, Col + 1);
                    }
                }
            }
            //En passant
            if (Col != 0)
            {
                if (Row == 3 && ChessColor == ChessColor.White && !board.IsEmpty(Row, Col - 1) && board.IsEmpty(Row - 1, Col - 1))
                {
                    Piece p = board.GetPiece(Row, Col - 1);
                    if (p.ChessColor != ChessColor && p.NumberOfMoves == 1 && board.LastPieceMoved == p && p.ChessPiece == ChessPiece.Pawn && board.IsLegalMove(this, Row - 1, Col - 1, p))
                    {
                        AddEnPassantMove(p, Row - 1, Col - 1);
                    }
                }
                else if (Row == 4 && ChessColor == ChessColor.Black && !board.IsEmpty(Row, Col - 1) && board.IsEmpty(Row + 1, Col - 1))
                {
                    Piece p = board.GetPiece(Row, Col - 1);
                    if (p.ChessColor != ChessColor && p.NumberOfMoves == 1 && board.LastPieceMoved == p && p.ChessPiece == ChessPiece.Pawn && board.IsLegalMove(this, Row + 1, Col - 1, p))
                    {
                        AddEnPassantMove(p, Row + 1, Col - 1);
                    }
                }
            }
            if (Col != 7)
            {
                if (Row == 3 && ChessColor == ChessColor.White && !board.IsEmpty(Row, Col + 1) && board.IsEmpty(Row - 1, Col + 1))
                {
                    Piece p = board.GetPiece(Row, Col + 1);
                    if (p.ChessColor != ChessColor && p.NumberOfMoves == 1 && board.LastPieceMoved == p && p.ChessPiece == ChessPiece.Pawn && board.IsLegalMove(this, Row - 1, Col + 1, p))
                    {
                        AddEnPassantMove(p, Row - 1, Col + 1);
                    }
                }
                else if (Row == 4 && ChessColor == ChessColor.Black && !board.IsEmpty(Row, Col + 1) && board.IsEmpty(Row + 1, Col + 1))
                {
                    Piece p = board.GetPiece(Row, Col + 1);
                    if (p.ChessColor != ChessColor && p.NumberOfMoves == 1 && board.LastPieceMoved == p && p.ChessPiece == ChessPiece.Pawn && board.IsLegalMove(this, Row + 1, Col + 1, p))
                    {
                        AddEnPassantMove(p, Row + 1, Col + 1);

                    }
                }
            }
        }

        public override bool SetsCheck()
        {
            if (Col != 0)
            {
                if (ChessColor == ChessColor.White && !board.IsEmpty(Row - 1, Col - 1) && board.GetPiece(Row - 1, Col - 1).ChessColor != ChessColor && board.GetPiece(Row - 1, Col - 1).ChessPiece == ChessPiece.King)
                {
                    return true;
                }
                else if (ChessColor == ChessColor.Black && !board.IsEmpty(Row + 1, Col - 1) && board.GetPiece(Row + 1, Col - 1).ChessColor != ChessColor && board.GetPiece(Row + 1, Col - 1).ChessPiece == ChessPiece.King)
                {
                    return true;
                }
            }
            if (Col != 7)
            {
                if (ChessColor == ChessColor.White && !board.IsEmpty(Row - 1, Col + 1) && board.GetPiece(Row - 1, Col + 1).ChessColor != ChessColor && board.GetPiece(Row - 1, Col + 1).ChessPiece == ChessPiece.King)
                {
                    return true;
                }
                else if (ChessColor == ChessColor.Black && !board.IsEmpty(Row + 1, Col + 1) && board.GetPiece(Row + 1, Col + 1).ChessColor != ChessColor && board.GetPiece(Row + 1, Col + 1).ChessPiece == ChessPiece.King)
                {
                    return true;
                }
            }
            return false;
        }

        protected void AddEnPassantMove(Piece p, int r, int c)
        {
            Button b = new Button(new Sprite2D(legalsTexture, new Rectangle(c * Constants.TILESIZE, r * Constants.TILESIZE, Constants.TILESIZE, Constants.TILESIZE), Color.DarkSlateGray));
            b.Click += (s, e) => { p.Move(r, c); Move(r, c);  };
            b.Hover += (s, e) => { b.Color = Color.Black; };
            b.UnHover += (s, e) => { b.Color = Color.DarkSlateGray; };
            legals.Add(b);
        }
        #endregion
    }
}
