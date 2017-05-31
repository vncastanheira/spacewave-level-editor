using Zenject;

[System.Serializable]
public class Enemy {
    public int Level { get; set; }
    public EnemyClass Class { get; set; }
    
    public Enemy(int level, EnemyClass @class)
    {
        Level = level;
        Class = @class;
    }

    public class Factory : Factory<int, EnemyClass, Enemy> { }

    //public class CreateEnemySignal : Signal<Enemy, CreateEnemySignal> { }
}

public enum EnemyClass
{
    Pawn, // Static spaceship
    Rogue, // Dodge bullets and shoot back
    Assassin // Follows player agressively
}
