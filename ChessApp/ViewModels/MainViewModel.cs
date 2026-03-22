using System.Collections.ObjectModel;
using ChessApp.Models;

namespace ChessApp.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private ChessPiece _selectedPiece;
        private int _targetRow;
        private int _targetColumn;
        private string _message;

        public ObservableCollection<ChessPiece> Pieces { get; }

        public ChessPiece SelectedPiece
        {
            get => _selectedPiece;
            set
            {
                _selectedPiece = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedPieceType));
                OnPropertyChanged(nameof(SelectedPieceColor));
                OnPropertyChanged(nameof(CurrentPosition));
            }
        }

        public string SelectedPieceType => SelectedPiece?.GetType().Name ?? string.Empty;

        public string SelectedPieceColor => SelectedPiece?.Color ?? string.Empty;

        public string CurrentPosition => SelectedPiece?.PositionText ?? string.Empty;

        public int TargetRow
        {
            get => _targetRow;
            set
            {
                _targetRow = value;
                OnPropertyChanged();
            }
        }

        public int TargetColumn
        {
            get => _targetColumn;
            set
            {
                _targetColumn = value;
                OnPropertyChanged();
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            Pieces = new ObservableCollection<ChessPiece>
            {
                new Queen("Белый", 4, 4),
                new Rook("Чёрный", 1, 1),
                new Bishop("Белый", 3, 3)
            };

            _selectedPiece = Pieces[0];
            _targetRow = 5;
            _targetColumn = 5;
            _message = "Выберите фигуру и выполните ход.";
        }

        public void MoveSelectedPiece()
        {
            if (SelectedPiece == null)
            {
                Message = "Фигура не выбрана.";
                return;
            }

            bool moveResult = SelectedPiece.MoveTo(TargetRow, TargetColumn);

            if (moveResult)
            {
                Message = $"Ход выполнен. Новая позиция: {SelectedPiece.PositionText}.";
            }
            else
            {
                Message = $"Ход невозможен для фигуры {SelectedPieceType} в клетку ({TargetRow}, {TargetColumn}).";
            }

            OnPropertyChanged(nameof(CurrentPosition));
        }
    }
}