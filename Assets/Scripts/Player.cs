using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    [SerializeField] float paddingLeft = 0.05f;
    [SerializeField] float paddingRight = 0.95f;
    [SerializeField] float paddingTop = 0.8f;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        SetUpMoveBoundaries();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        Move();
    }

    void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(paddingLeft,0,0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(paddingRight,0,0)).x;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0,0,0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0,paddingTop,0)).y;
    }

    void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    
}
