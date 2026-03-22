using System;

namespace ChessApp.Models
{
    public abstract class ChessPiece
    {
        public string Color { get; set; }

        public int Row { get; protected set; }

        public int Column { get; protected set; }

        protected ChessPiece(string color, int row, int column)
        {
            Color = color;
            SetPosition(row, column);
        }

        public string PositionText => $"({Row}, {Column})";

        public string DisplayInfo => $"{GetType().Name} ({Color}) {PositionText}";

        public bool MoveTo(int newRow, int newColumn)
        {
            if (!IsInsideBoard(newRow, newColumn))
            {
                return false;
            }

            if (Row == newRow && Column == newColumn)
            {
                return false;
            }

            if (!CanMoveTo(newRow, newColumn))
            {
                return false;
            }

            Row = newRow;
            Column = newColumn;
            return true;
        }

        protected abstract bool CanMoveTo(int newRow, int newColumn);

        protected bool IsInsideBoard(int row, int column)
        {
            return row >= 1 && row <= 8 && column >= 1 && column <= 8;
        }

        private void SetPosition(int row, int column)
        {
            if (!IsInsideBoard(row, column))
            {
                throw new ArgumentOutOfRangeException(nameof(row), "Координаты должны быть в пределах от 1 до 8.");
            }

            Row = row;
            Column = column;
        }
    }
}