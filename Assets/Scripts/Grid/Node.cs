using UnityEngine;
using Zenject;

public class Node : MonoBehaviour
{
    #region Materials
    public Material selectedMaterial;
    public Material unselectedMaterial;
    MeshRenderer mRenderer;
    #endregion

    #region References and Injection
    [Inject] LevelEditor _editor;
    Enemy enemyRef;

    public TextMesh Label;
    #endregion

    [Inject]
    public void Constructor(Vector2 position)
    {
        transform.position = new Vector3(position.x, position.y, 0);
        mRenderer = GetComponent<MeshRenderer>();
    }

    /// <summary>
    /// Mak this node with visual indication 
    /// that is currently selected by the editor
    /// </summary>
    public void MarkAsSelected()
    {
        mRenderer.material = selectedMaterial;
    }

    /// <summary>
    /// Mak this node with visual indication 
    /// that is currently unselected selected by the editor
    /// </summary>
    /// <param name="node">Useless parameter because I don't know how to use Signals properly</param>
    public void MarkAsUnselected(Node node)
    {
        mRenderer.material = unselectedMaterial;
    }

    public void SetEnemy(Enemy enemy)
    {
        enemyRef = enemy;
        Label.text = enemy.Class.ToString().Substring(0, 1) + enemy.Level;
    }

    public void ResetEnemy()
    {
        enemyRef = null;
        Label.text = string.Empty;
    }

    /// <summary>
    /// Nuke this gameobject to hell
    /// </summary>
    public void Destroy()
    {
        Destroy(gameObject);
    }

    #region Zenject

    public class Factory : Factory<Vector2, Node> { }

    public class SelectNodeSignal : Signal<Node, SelectNodeSignal> { }

    public class ResetNodeSignal : Signal<ResetNodeSignal> { }


    #endregion
}
