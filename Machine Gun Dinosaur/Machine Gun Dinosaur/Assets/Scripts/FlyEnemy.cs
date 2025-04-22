using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    public float speed = 10;

    public ParticleSystem explosionFlyEnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        Collider2D box = Physics2D.OverlapBox(transform.position, Vector2.one * 0.2f, 0, LayerMask.GetMask("Shot"));
        if(box != null)
        {
            Destroy(Instantiate(explosionFlyEnemyPrefab, transform.position, Quaternion.identity), 2);

            Destroy(box.gameObject);
            Destroy(gameObject);
        }

        if (transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }
}
