using System;
using UnityEngine;
using Zenject;

public class GridDisplay : MonoBehaviour {

    [Inject] LevelEditor editor;
    [Inject] Node.Factory nodeFactory;

    private event Action RemoveNodes;

    public void Create()
    {
        if (RemoveNodes != null)
        {
            RemoveNodes.Invoke();
            RemoveNodes = null;
        }

        for (int x = 0; x < editor.CurrentLevel.GridDimension.x; x++)
        {
            for (int y = 0; y < editor.CurrentLevel.GridDimension.y; y++)
            {
                var node = nodeFactory.Create(new Vector2(x, y));
                node.transform.SetParent(transform);
                RemoveNodes += node.Destroy;
            }
        }

        transform.position = new Vector3(-(editor.CurrentLevel.GridDimension.x / 2), -(editor.CurrentLevel.GridDimension.y / 2), -10);
    }
}
