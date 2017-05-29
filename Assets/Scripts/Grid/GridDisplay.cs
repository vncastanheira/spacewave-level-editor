using UnityEngine;
using Zenject;

public class GridDisplay : MonoBehaviour {

    [Inject] LevelEditor editor;
    [Inject] Node.Factory nodeFactory;

    public void Create()
    {
        for (int x = 0; x < editor.CurrentLevel.GridDimension.x; x++)
        {
            for (int y = 0; y < editor.CurrentLevel.GridDimension.y; y++)
            {
                nodeFactory.Create(new Vector2(x, y));
            }
        }
    }
}
