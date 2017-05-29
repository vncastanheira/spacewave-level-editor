using UnityEngine;
using Zenject;

/// <summary> Main editor class </summary>
public sealed class LevelEditor
{

    [Inject]
    Settings settings;

    Level _currentLevel;
    public Level CurrentLevel { get { return _currentLevel; } }

    public void New(int lines, int columns)
    {
        _currentLevel = ScriptableObject.CreateInstance<Level>();
        //var levelJson = JsonUtility.ToJson(_currentLevel);
        //System.IO.File.WriteAllText(settings.LevelFolderLocation + "temp." + settings.LevelExtensionName, levelJson);
    }

    public void Open() { }

    public void Save() { }
}
