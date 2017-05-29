using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelEditorUI : IInitializable
{
    [Inject]
    LevelEditor editor;

    [Inject(Id = "lines")] Slider linesSlider;
    [Inject(Id = "columns")] Slider columnsSlider;

    [Inject(Id = "create_level-btn")] Button createLevelButton;
    [Inject(Id = "open_level-btn")] Button openLevelButton;

    #region Dialogs
    [Inject(Id = "dialog_new")] Dialog dialogNew;
    [Inject(Id = "dialog_open")] Dialog dialogOpen;
    #endregion

    public void Initialize()
    {
        Debug.Assert(editor != null, "editor was not injected");

        createLevelButton.onClick.AddListener(() =>
        {
            editor.New((int)linesSlider.value, (int)columnsSlider.value);
        });
    }
    
}
