using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public float scrollSpeed = 2f;
    private Vector3 startPos;
    private float backgroundWidth; // Automatically set width

    void Start()
    {
        startPos = transform.position;
        backgroundWidth = GetComponent<SpriteRenderer>().bounds.size.x; // Get the actual width
    }
    void Update()
    {
        // Move background left at a fixed speed
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        // Reset position when it moves fully off-screen
        if (transform.position.x <= startPos.x - backgroundWidth)
        {
            transform.position = startPos;
        }
    }
}

