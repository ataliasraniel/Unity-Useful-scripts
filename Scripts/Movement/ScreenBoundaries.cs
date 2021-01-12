using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBoundaries : MonoBehaviour
{
    public float speed;

    public Vector2 boundaries;
    private void Start()
    {
        boundaries = new Vector2(Camera.main.aspect * Camera.main.orthographicSize,
            Camera.main.orthographicSize);
    }
    private void Update()
    {
        boundaries = new Vector2(Camera.main.aspect * Camera.main.orthographicSize,
            Camera.main.orthographicSize);

        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        transform.Translate(input * speed * Time.deltaTime);
        Vector3 clampVector = transform.position;
        clampVector.x = Mathf.Clamp(clampVector.x, -boundaries.x + 0.5f, boundaries.x - 0.5f);
        clampVector.z = Mathf.Clamp(clampVector.z, -boundaries.y + 0.5f, boundaries.y - 0.5f);
        transform.position = clampVector;

    }
}
