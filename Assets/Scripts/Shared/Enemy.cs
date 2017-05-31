using UnityEngine;
using Zenject;

[System.Serializable]
public class Enemy
{
    public int Level;
    public EnemyClass Class;
    public Vector2 Position;

    public Enemy(int level, EnemyClass @class, Vector2 position)
    {
        Level = level;
        Class = @class;
        Position = position;
    }

    public class Factory : Factory<int, EnemyClass, Vector2, Enemy> { }

    //public class CreateEnemySignal : Signal<Enemy, CreateEnemySignal> { }
}

public enum EnemyClass
{
    Pawn, // Static spaceship
    Rogue, // Dodge bullets and shoot back
    Assassin // Follows player agressively
}
