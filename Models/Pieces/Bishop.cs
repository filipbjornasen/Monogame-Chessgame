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
    class Bishop : Piece
    {
        public Bishop(Sprite2D sprite, int row, int col, ChessColor color, Board board)
            : base(sprite, row, col, color, board)
        {
            ChessPiece = ChessPiece.Bishop;
        }

        #region ChessMethods
        public override void CalculateLegalMoves()
        {
            legals.Clear();
            for (int i = 1; i <= Math.Min(Row, Col); i++)
            {
                if (board.IsLegalMove(this, Row - i, Col - i))
                {
                    AddLegalMove(Row - i, Col - i);
                }
                if (!board.IsEmpty(Row - i, Col - i)) break;
            }
            for (int i = 1; i <= 7 - Math.Max(Row, Col); i++)
            {
                if (board.IsLegalMove(this, Row + i, Col + i))
                {
                    AddLegalMove(Row + i, Col + i);
                }
                if (!board.IsEmpty(Row + i, Col + i)) break;
            }
            for (int i = 1; i <= Math.Min(Row, 7 - Col); i++)
            {
                if (board.IsLegalMove(this, Row - i, Col + i))
                {
                    AddLegalMove(Row - i, Col + i);
                }
                if (!board.IsEmpty(Row - i, Col + i)) break;
            }
            for (int i = 1; i <= Math.Min(7 - Row, Col); i++)
            {
                if (board.IsLegalMove(this, Row + i, Col - i))
                {
                    AddLegalMove(Row + i, Col - i);
                }
                if (!board.IsEmpty(Row + i, Col - i)) break;
            }
        }

        public override bool SetsCheck()
        {
            for (int i = 1; i <= Math.Min(Row, Col); i++)
            {
                if (board.IsEmpty(Row - i, Col - i)) continue;
                Piece p = board.GetPiece(Row - i, Col - i);
                if (p.ChessColor != ChessColor && p.ChessPiece == ChessPiece.King) return true;
                break;
            }
            for (int i = 1; i <= 7 - Math.Max(Row, Col); i++)
            {
                if (board.IsEmpty(Row + i, Col + i)) continue;
                Piece p = board.GetPiece(Row + i, Col + i);
                if (p.ChessColor != ChessColor && p.ChessPiece == ChessPiece.King) return true;
                break;
            }
            for (int i = 1; i <= Math.Min(Row, 7 - Col); i++)
            {
                if (board.IsEmpty(Row - i, Col + i)) continue;
                Piece p = board.GetPiece(Row - i, Col + i);
                if (p.ChessColor != ChessColor && p.ChessPiece == ChessPiece.King) return true;
                break;
            }
            for (int i = 1; i <= Math.Min(7 - Row, Col); i++)
            {
                if (board.IsEmpty(Row + i, Col - i)) continue;
                Piece p = board.GetPiece(Row + i, Col - i);
                if (p.ChessColor != ChessColor && p.ChessPiece == ChessPiece.King) return true;
                break;
            }
            return false;
        }
        #endregion
    }
}
