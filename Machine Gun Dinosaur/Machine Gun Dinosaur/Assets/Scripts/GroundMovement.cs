using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public Sprite[] groundSprites;

    public SpriteRenderer[] grounds;

    public float speed = 8;

    Vector2 endPosition = new Vector2(-18.66f, -2.89f);
    Vector2 startPosition = new Vector2(27f, -2.89f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < grounds.Length; i++)
        {
            grounds[i].transform.position += Vector3.left * speed * Time.deltaTime;
            if (grounds[i].transform.position.x <= endPosition.x)
            {
                grounds[i].transform.position = startPosition;
                grounds[i].sprite = groundSprites[Random.Range(0, groundSprites.Length)];
            }
        }
    }
}
