using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    struct SpawnTime
    {
        public float instantiateTime;
        public float interval;
        public float variation;
    }

    public float flyingMax = 2f;
    public float flyingMin = -1f;

    public float speed = 8;

    public Sprite[] cactusSprites;

    public GameObject cactoPrefab;
    public GameObject flyEnemyPrefab;

    public bool stopSpawn = false;

    SpawnTime cactus;
    SpawnTime flyEnemy;

    // Start is called before the first frame update
    void Start()
    {
        cactus.instantiateTime = 0;
        cactus.interval = 2;
        cactus.variation = 0.5f;

        flyEnemy.instantiateTime = 0;
        flyEnemy.interval = 1;
        flyEnemy.variation = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > cactus.instantiateTime && !stopSpawn)
        {
            GameObject obj = Instantiate(cactoPrefab, new Vector3(10.22f, -2.27f), Quaternion.identity);
            obj.GetComponent<SpriteRenderer>().sprite = cactusSprites[Random.Range(0, cactusSprites.Length)];
            obj.AddComponent<BoxCollider2D>();
            obj.GetComponent<Cactus>().speed = speed;
            cactus.instantiateTime = Time.time + Random.Range(cactus.interval - cactus.variation, cactus.interval + cactus.variation);
        }

        if (Time.time > flyEnemy.instantiateTime && !stopSpawn)
        {
            GameObject obj = Instantiate(flyEnemyPrefab, new Vector3(10.22f, Random.Range(flyingMax, flyingMin)), Quaternion.identity);
            flyEnemy.instantiateTime = Time.time + Random.Range(flyEnemy.interval - flyEnemy.variation, flyEnemy.interval + flyEnemy.variation);
        }
    }
}
