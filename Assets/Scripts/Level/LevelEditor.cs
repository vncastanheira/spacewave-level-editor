using UnityEngine;
using Zenject;

/// <summary> Main editor class </summary>
public sealed class LevelEditor
{
    [Inject]
    Settings settings;

    Level _currentLevel;
    [Inject] Level.Factory _levelfactory;
    public Level CurrentLevel { get { return _currentLevel; } }

    #region Signals
    [Inject] Level.CreatedLevelSignal _createdLevelSignal;
    #endregion

    public void New(int lines, int columns)
    {
        _currentLevel = _levelfactory.Create(lines, columns);
        _createdLevelSignal.Fire();

        //var levelJson = JsonUtility.ToJson(_currentLevel);
        //System.IO.File.WriteAllText(settings.LevelFolderLocation + "temp." + settings.LevelExtensionName, levelJson);
    }

    public void Open() { }

    public void Save() { }
}
