using BenchmarkDotNet.Running;
using FP_Playground;

// var summary = BenchmarkRunner.Run(typeof(Program).Assembly);

Game StartGame()
{
    var game = new Game()
        .AddCharacter("Marcus")
        .AddCharacter("Enes")
        .AddCharacter("Maggie")
        .AddCharacter("Garrett");

    var random = new Random();
    foreach (var character in game.Characters)
    {
        character.Damage(random.Next(5, 20));
    }
    // game.Characters = new List<Character>();
    game.PrintCharacters();
    return game;
}

var game = StartGame();