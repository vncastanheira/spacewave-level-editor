[System.Serializable]
public class Enemy {
    public int Health { get; set; }
    public int Barrier { get; set; }
    public EnemyClass Class { get; set; } 
}

public enum EnemyClass
{
    Pawn, // Static spaceship
    Rogue, // Dodge bullets and shoot back
    Assassin // Follows player agressively
}
