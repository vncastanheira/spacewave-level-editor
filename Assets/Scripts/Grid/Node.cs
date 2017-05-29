using UnityEngine;
using Zenject;

public class Node : MonoBehaviour
{
    [Inject]
    public void Constructor(Vector2 position)
    {
        transform.position = new Vector3(position.x, position.y, -1);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public class Factory : Factory<Vector2, Node> { }
}
