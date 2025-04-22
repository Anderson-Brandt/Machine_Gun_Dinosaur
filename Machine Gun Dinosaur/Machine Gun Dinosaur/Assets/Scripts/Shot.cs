using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        if(transform.position.x >= 10)
        {
            Destroy(gameObject);
        }

        if(gameObject != null)
        {
            Destroy(gameObject, 2f);
        }
        
    }
}
