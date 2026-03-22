# Задание 2. Вариант 3. Иерархия шахматных фигур

Оконное приложение на C# (WPF), демонстрирующее работу иерархии классов шахматных фигур с использованием архитектуры **MVVM**.

---

## Описание проекта

В проекте реализована иерархия классов:

- Базовый класс: `ChessPiece` (Шахматная фигура)
- Производные классы:
  - `Queen` (Ферзь)
  - `Rook` (Ладья)
  - `Bishop` (Слон)

Каждая фигура имеет:
- цвет
- позицию на доске (строка, столбец)

И умеет выполнять ход с проверкой его корректности.

---

## Архитектура

Используется паттерн **MVVM (Model-View-ViewModel)**:

- **Models**
  - `ChessPiece`
  - `Queen`
  - `Rook`
  - `Bishop`

- **ViewModels**
  - `MainViewModel`
  - `ObservableObject`

- **Views**
  - `MainWindow.xaml`

---

## Иерархия классов

В программе реализована иерархия классов шахматных фигур.

Базовым классом является `ChessPiece`, который содержит общие свойства и поведение для всех фигур:
- `Color` — цвет фигуры  
- `Row`, `Column` — положение на доске  
- метод `MoveTo` — выполнение хода  

Метод `MoveTo` выполняет проверку координат и вызывает защищённый абстрактный метод:

```csharp
protected abstract bool CanMoveTo(int newRow, int newColumn);
```

## Технологии

- C#
- WPF (.NET 8)
- MVVM
- Data Binding
- ObservableCollection

---

## Структура проекта

ChessApp
│
├── Models
│   ├── ChessPiece.cs
│   ├── Queen.cs
│   ├── Rook.cs
│   └── Bishop.cs
│
├── ViewModels
│   ├── MainViewModel.cs
│   └── ObservableObject.cs
│
├── Views
│   ├── MainWindow.xaml
│   └── MainWindow.xaml.cs
│
├── App.xaml
├── App.xaml.cs
└── ChessApp.csproj

## Запуск проекта

### В Rider / Visual Studio

1. Открыть проект `ChessApp`
2. Убедиться, что установлен .NET 8
3. Запустить проект (`Run`)

---

### Через терминал

```bash
dotnet build
dotnet run
