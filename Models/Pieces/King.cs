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
    class King : Piece
    {
        public King(Sprite2D sprite, int row, int col, ChessColor color, Board board)
            : base(sprite, row, col, color, board)
        {
            ChessPiece = ChessPiece.King;
        }

        #region ChessMethods
        public override void CalculateLegalMoves()
        {
            legals.Clear();
            for (int i = Math.Max(0, Row - 1); i <= Math.Min(7, Row + 1); i++)
            {
                for (int j = Math.Max(0, Col - 1); j <= Math.Min(7, Col + 1); j++)
                {
                    if (i == Row && Col == j) continue;
                    if(board.IsLegalMove(this, i, j))
                    {
                        AddLegalMove(i, j);
                    }
                }
            }
            //RocadeLeft
            if(NumberOfMoves == 0 && board.IsEmpty(Row, 1) && board.IsEmpty(Row, 2) && board.IsEmpty(Row, 3) 
                && board.IsLegalMove(this, Row, 4) && board.IsLegalMove(this, Row, 3) && board.IsLegalMove(this, Row, 2) && !board.IsEmpty(Row, 0))
            {
                Piece p = board.GetPiece(Row, 0);
                if(p.NumberOfMoves == 0)
                {
                    AddCastlingMove(p, 2, 3);
                }
            }
            //RocadeRight
            if (NumberOfMoves == 0 && board.IsEmpty(Row, 5) && board.IsEmpty(Row, 6)
                && board.IsLegalMove(this, Row, 4) && board.IsLegalMove(this, Row, 5) && board.IsLegalMove(this, Row, 6) && !board.IsEmpty(Row, 7))
            {
                Piece p = board.GetPiece(Row, 7);
                if (p.NumberOfMoves == 0)
                {
                    AddCastlingMove(p, 6, 5);
                }
            }
        }

        public override bool SetsCheck()
        {
            for (int i = Math.Max(0, Row - 1); i <= Math.Min(7, Row + 1); i++)
            {
                for (int j = Math.Max(0, Col - 1); j <= Math.Min(7, Col + 1); j++)
                {
                    if (i == Row && Col == j) continue;
                    if (board.IsEmpty(i, j)) continue;
                    Piece p = board.GetPiece(i, j);
                    if(p.ChessColor != ChessColor && p.ChessPiece == ChessPiece.King)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected void AddCastlingMove(Piece p, int col, int secol)
        {
            Button b = new Button(new Sprite2D(legalsTexture, new Rectangle(col * Constants.TILESIZE, Row * Constants.TILESIZE, Constants.TILESIZE, Constants.TILESIZE), Color.DarkSlateGray));
            b.Click += (s, e) => { Move(Row, col); p.Move(Row, secol); };
            b.Hover += (s, e) => { b.Color = Color.Black; };
            b.UnHover += (s, e) => { b.Color = Color.DarkSlateGray; };
            legals.Add(b);
        }
        #endregion
    }
}
