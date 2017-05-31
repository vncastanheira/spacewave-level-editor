using System;
using UnityEngine;
using Zenject;

/// <summary> Main editor class </summary>
public sealed class LevelEditor
{
    [Inject]
    Settings settings;

    #region Signals
    [Inject] Level.CreatedLevelSignal _createdLevelSignal;
    #endregion

    #region Level
    Level _currentLevel;
    [Inject] Level.Factory _levelfactory;
    public Level CurrentLevel { get { return _currentLevel; } }

    // Creates a new level
    public void New(int lines, int columns)
    {
        _currentLevel = _levelfactory.Create(lines, columns);
        _createdLevelSignal.Fire();

        var levelJson = JsonUtility.ToJson(_currentLevel);
        System.IO.File.WriteAllText(settings.LevelFolderLocation + "temp." + settings.LevelExtensionName, levelJson);
    }

    // Opens a level from the custom folder
    public void Open() { }

    // Saves the level currently being edited
    public void Save()
    {
        var levelJson = JsonUtility.ToJson(_currentLevel);
        System.IO.File.WriteAllText(settings.LevelFolderLocation + "untitled." + settings.LevelExtensionName, levelJson);
    }

    #endregion

    #region Level Editing

    Node _currentNode;
    [Inject] Enemy.Factory _enemyFactory;

    public void SetNode(Node node)
    {
        _currentNode = node;
    }

    public void ResetNode()
    {
        _currentNode.ResetEnemy();
    }

    public void CreateEnemy(int level, int classIndex)
    {
        var @class = (EnemyClass)Enum.GetValues(typeof(EnemyClass)).GetValue(classIndex);
        var enemy = _enemyFactory.Create(level, @class, _currentNode.Position);
        _currentLevel.Enemies.Add(enemy);
        _currentNode.SetEnemy(enemy);
    }
    
    #endregion
}
