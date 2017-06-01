using UnityEngine;
using System.IO;
using Zenject;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelFileInfo : MonoBehaviour
{
    public Text Label;
    Button button;

    FileInfo fileInfo;
    LevelEditor levelEditor;
    
    [Inject]
    public void Constructor(FileInfo info, LevelEditor editor)
    {
        fileInfo = info;
        levelEditor = editor;

        Label.text = info.Name;
        button.onClick.AddListener(LoadLevel);
    }

    void LoadLevel()
    {
        levelEditor.Open(fileInfo);
    }

    public class Factory : Factory<FileInfo, LevelFileInfo> { }
}
