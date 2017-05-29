using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Range(0, 1)]
    public float speed;
    public float horizontalLimit;
    public float verticalLimit;

    float horizontal;
    float vertical;

	void Update () {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        transform.Translate(horizontal * speed, vertical * speed, 0.0f);
        
        var x = transform.position.x;
        var y = transform.position.y;
        transform.position = new Vector3(Mathf.Clamp(x, -horizontalLimit, horizontalLimit), Mathf.Clamp(y, -verticalLimit, verticalLimit), -10);
    }
}
