using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelInfo : MonoBehaviour
{
    [Inject] LevelEditor _editor;

    public Text title;
    public Text size;

    public void SetInfo()
    {
        title.text = _editor.CurrentLevel.Name;
        size.text = string.Format("[ L: {0} - C: {1} ]", _editor.CurrentLevel.GridDimension.y, _editor.CurrentLevel.GridDimension.x);
    }
}
