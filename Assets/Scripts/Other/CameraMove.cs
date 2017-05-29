using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Range(0, 1)]
    public float speed;

    float horizontal;
    float vertical;

	void Update () {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        transform.Translate(horizontal * speed, vertical * speed, 0.0f);
        
        var x = transform.position.x;
        var y = transform.position.y;
        transform.position = new Vector3(Mathf.Clamp(x, -5, 5), Mathf.Clamp(y, -5, 5), -10);
    }
}
