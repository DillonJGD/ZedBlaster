using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        Move();
    }

    void Move()
    {
        var deltaX = Input.GetAxis("Horizontal");
        var deltaY = Input.GetAxis("Vertical");

        var newXPos = transform.position.x + deltaX * moveSpeed * Time.deltaTime;
        var newYPos = transform.position.y + deltaY * moveSpeed * Time.deltaTime;

        transform.position = new Vector2(newXPos, newYPos);
    }
}
