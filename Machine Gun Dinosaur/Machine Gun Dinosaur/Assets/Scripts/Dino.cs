using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    Vector2 yVelocity;

    public float maxHeight = 1f;
    public float timeToPeak = 0.3f;

    public float jumoSpeed;
    public float gravity;

    public float groundPosition;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        gravity = (2 * maxHeight) / Mathf.Pow(timeToPeak, 2);
        jumoSpeed = gravity * timeToPeak;
        groundPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        yVelocity += gravity * Time.deltaTime * Vector2.down;

        if(transform.position.y <= groundPosition)
        {
            transform.position = new Vector3(transform.position.x, groundPosition, transform.position.z);
            yVelocity = Vector3.zero;
            isGrounded = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            yVelocity = jumoSpeed * Vector2.up;
            isGrounded = false;
        }

        transform.position += (Vector3)yVelocity * Time.deltaTime;
    }
}
