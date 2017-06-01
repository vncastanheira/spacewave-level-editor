using System;
using System.IO;
using UnityEngine;
using Zenject;

/// <summary> Main editor class </summary>
public sealed class LevelEditor
{
    [Inject] Settings settings;
    IFileManager<Level> fileManager;

    public LevelEditor(IFileManager<Level> manager)
    {
        fileManager = manager;
    }

    #region Signals
    [Inject] Level.CreatedLevelSignal _createdLevelSignal;
    [Inject] Level.RejectTitleSignal _rejectTitleSignal;
    [Inject] SaveWarningSignal _saveWarningSignal;
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
    public void Open(FileInfo fileInfo)
    {
        _currentLevel = fileManager.Open(fileInfo.FullName);
    }

    // Saves the level currently being edited
    public void Save()
    {
        if(_currentLevel == null)
        {
            _saveWarningSignal.Fire("Create a level before saving it.");
            return;
        }

        fileManager.Save(_currentLevel);
    }

    public void SetTitle(string title)
    {
        if (string.IsNullOrEmpty(title))
        {
            _rejectTitleSignal.Fire(_currentLevel.Name);
            return;
        }

        _currentLevel.Name = title;
    }

    #endregion

    #region Level Editing

    Node _currentNode;
    Enemy _currentEnemy;
    [Inject] Enemy.Factory _enemyFactory;

    public void SetNode(Node node)
    {
        _currentNode = node;
        _currentEnemy = node.Enemy;
    }

    public void ResetNode()
    {
        _currentLevel.Enemies.Remove(_currentEnemy);
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

    
    public class SaveWarningSignal : Signal<string, SaveWarningSignal> { }
}
