# TetrisGame


## Description

This is an implementation of the classic Tetris game, developed in C# using Windows Forms. The project follows the MVC architecture principles, separating the game logic (model), graphical interface (view), and piece control (controller).

## Features

- Fully implemented Tetris pieces (I, O, T, S, Z, L, J)
- Piece rotation based on the Super Rotation System (SRS)
- Piece generation based on a predefined sequence from a file
- Proper handling of collisions and grid boundaries
- Fast piece drop functionality
- Detection and clearing of full lines
- Random or file-based piece generation
- "Wall Kick" system for improved rotation near edges
- User-friendly Windows Forms interface

## Technologies Used

- **Language:** C#
- **Framework:** .NET CORE 8.0 (Windows Forms)
- **Paradigm:** Object-Oriented Programming (OOP)
- **Architecture:** Model-View-Controller (MVC)

## Project Structure

```
TetrisGame/
│── TetrisGame.sln            # Visual Studio solution
│── README.md                 # Documentation
│── /TetrisGame/              # Main project directory
│   ├── /Processors/          # Game logic
│   │   ├── /Base/            # Abstract Piece class
│   │   ├── /Contracts/       # Interfaces
│   │   ├── /Implementations/ # Pieces and game logic implementation
│   ├── /Controllers/         # Game and piece controllers
│   ├── /Views/               # Graphical interface (Windows Forms)
│   ├── Program.cs            # Application entry point
```

## Installation & Setup

Clone this repository:

```sh
git clone https://github.com/BaladaRock/TetrisGame.git
```

Open the solution `TetrisGame.sln` in Visual Studio.

Run the project by pressing **Ctrl + F5** or clicking the **Start** button in Visual Studio.

## How to Play

🎮 **Controls:**

- ⬅️ & ➡️ - Move the piece left/right
- ⬇️ - Soft drop
- ⬆️ - Rotate piece clockwise
- **W** - Alternative rotation
- **S** - Soft drop

## Generating Pieces from a File

Instead of random generation, pieces can be read from a `pieces.txt` file containing 1000 predefined pieces.

**How to generate the file?**

```csharp
Game.GeneratePieceFile("pieces.txt");
```

**How to load pieces from the file?**

```csharp
Game.LoadPieceSequence("pieces.txt");
```

## Possible Improvements

📌 Implementing a scoring system  
📌 Adding a main menu and settings  
📌 Ability to save and load a game 
📌 Proper line cleanup handling 
📌 Multiplayer mode  

## Contributions

Contributions are welcome! To contribute:

1. **Fork** the repository.
2. Create a **new branch**: `git checkout -b feature-new`.
3. **Add your changes** and commit: `git commit -m "Add a new feature"`.
4. **Submit a Pull Request!**

## Author

👨‍💻 Andrei Dăian - [GitHub](https://github.com/BaladaRock/)


