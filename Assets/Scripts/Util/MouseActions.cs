using UnityEngine;
using Zenject;

public class MouseActions : MonoBehaviour
{
    #region Signals
    [Inject] Node.SelectNodeSignal _selectNodeSignal;
    #endregion

    Ray ray;

    void Update()
    {
        // Try to select a node
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                var node = hit.collider.GetComponent<Node>();
                _selectNodeSignal.Fire(node);
                node.MarkAsSelected();
                Debug.Log("Got node on " + node.transform.localPosition);
            }
        }
        // Deselect the current node, if any
        else if(Input.GetMouseButtonDown(1))
        {
            _selectNodeSignal.Fire(null);
        }
    }

    private void OnDrawGizmos()
    {
        if(true)
        {
            Gizmos.DrawRay(ray);
        }
    }
}
