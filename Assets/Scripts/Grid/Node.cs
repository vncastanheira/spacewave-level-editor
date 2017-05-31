using UnityEngine;
using Zenject;

public class Node : MonoBehaviour
{
    public Material selectedMaterial;
    public Material unselectedMaterial;
    MeshRenderer mRenderer;

    [Inject]
    public void Constructor(Vector2 position)
    {
        transform.position = new Vector3(position.x, position.y, 0);
        mRenderer = GetComponent<MeshRenderer>();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void MarkAsSelected()
    {
        mRenderer.material = selectedMaterial;
    }

    public void MarkAsUnselected(Node node)
    {
        mRenderer.material = unselectedMaterial;
    }

    #region Zenject

    public class Factory : Factory<Vector2, Node> { }

    public class SelectNodeSignal: Signal<Node, SelectNodeSignal> { }

    #endregion
}
