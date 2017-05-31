using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelEditorUI : IInitializable
{
    [Inject]
    LevelEditor editor;
    
    #region Dialogs
    [Inject(Id = "dialog_new")] Dialog dialogNew;
    [Inject(Id = "lines")] Slider linesSlider;
    [Inject(Id = "columns")] Slider columnsSlider;
    [Inject(Id = "create_level-btn")] Button createLevelButton;

    [Inject(Id = "dialog_open")] Dialog dialogOpen;
    [Inject(Id = "open_level-btn")] Button openLevelButton;
    #endregion

    #region Menu
    [Inject(Id = "menu-create")] Button enemyCreateButton;
    [Inject(Id = "menu-reset")] Button enemyResetButton;
    [Inject(Id = "enemy-level")] Slider enemyLevelSlider;
    [Inject(Id = "enemy-class")] Dropdown enemyClassDropdown;
    #endregion

    public void Initialize()
    {
        createLevelButton.onClick.AddListener(() =>
        {
            editor.New((int)linesSlider.value, (int)columnsSlider.value);
        });

        enemyCreateButton.onClick.AddListener(() =>
        {
            editor.CreateEnemy((int)enemyLevelSlider.value, enemyClassDropdown.value);
        });

        enemyResetButton.onClick.AddListener(() =>
        {
            editor.ResetNode();
        });
    }
    
    public void SetNode(Node node)
    {
        enemyCreateButton.interactable = node != null;
        enemyResetButton.interactable = node != null;
    }


    public void Reset()
    {
        enemyCreateButton.interactable = false;
        enemyResetButton.interactable = false;
    }
}
