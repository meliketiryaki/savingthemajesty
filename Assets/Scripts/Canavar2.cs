using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canavar2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float minY = 0f;
    public float maxY = 10f;

    private bool movingUp = true;

    private void Update()
    {
        if (movingUp)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            if (transform.position.y >= maxY)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            if (transform.position.y <= minY)
            {
                movingUp = true;
            }
        }
    }
}
