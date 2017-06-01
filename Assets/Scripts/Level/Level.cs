using System.Collections.Generic;
using UnityEngine;
using Zenject;

[System.Serializable]
public class Level
{
    #region Fields
    [SerializeField] Vector2 gridDimension;
    [SerializeField] string name;
    [SerializeField] public List<Enemy> Enemies;
    #endregion

    #region Properties
    /// <summary> Set the grid matrix</summary>
    public Vector2 GridDimension
    {
        get
        {
            return gridDimension;
        }

        private set
        {
            gridDimension = value;
        }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    #endregion

    public Level(int lines, int columns)
    {
        gridDimension = new Vector2(columns, lines);
        name = "untitled";
        Enemies = new List<Enemy>();
    }

    #region Zenject

    //Level creation factory
    public class Factory : Factory<int, int, Level> { };

    //Signals when a new Level is created
    public class CreatedLevelSignal : Signal<CreatedLevelSignal> { }

    // Rejects the given title (because it's empty) and send the current saved title
    public class RejectTitleSignal : Signal<string, RejectTitleSignal> { }

    #endregion
}
