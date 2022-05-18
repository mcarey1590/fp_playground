namespace FP_Playground;

public class Character
{
    public Guid Id { get; }
    public string Name { get; init; }
    public int Armor { get; init; } = 1;
    public int Health { get; private set; } = 100;

    public Character(Guid id)
    {
        Id = id;
        Name = "Player " + id;
    }

    /// <summary>
    /// Do damage to character
    /// </summary>
    /// <param name="damage"></param>
    /// <returns>Health of character after damage is taken</returns>
    public int Damage(int damage)
    {
        var damageTaken = Math.Max(damage - Armor, 0);
        Health -= damageTaken;
        Console.WriteLine($"{Name} took {damageTaken} damage!");
        return Health;
    }
}

public class Game
{
    public List<Character> Characters { get; } = new();

    public Game AddCharacter(string name)
    {
        var newCharacter = new Character(Guid.NewGuid()) {Armor = 10, Name = name};
        // newCharacter.Armor = 5;
        // newCharacter.Health = 6;
        // newCharacter.Name = "Bob";
        Characters.Add(newCharacter);

        return this;
    }

    public void PrintCharacters()
    {
        foreach (var characterString in Characters.Select(character =>
                     $"{character.Name} ({character.Id})\n\tArmor: {character.Armor}\n\tHealth: {character.Health}"))
        {
            Console.WriteLine(characterString);
        }
    }
}