using System.Collections.Generic;
using UnityEngine;
using Zenject;

[System.Serializable]
public class Level
{
    #region Fields
    [SerializeField] Vector2 gridDimension;
    [SerializeField] string name;
    [SerializeField] List<Enemy> Enemies;
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
    public string Name { get { return name; } }
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

    #endregion
}
