using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    Dino dino;
    EnemySpawn enemySpawn;
    GroundMovement groundMovement;
    Cactus cactus;

    public bool gameOver = false;

    public float timeToIncreaseDifficulty = 0;
    public float interval = 5f;

    public GameObject gameOverPanel;

    public Text scoreText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        
        dino = FindObjectOfType<Dino>();
        enemySpawn = FindObjectOfType<EnemySpawn>();
        groundMovement = FindObjectOfType<GroundMovement>();
        cactus = FindObjectOfType<Cactus>();
    }


    // Update is called once per frame
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Atribuição desnecessária de um valor", Justification = "<Pendente>")]
    void Update()
    {
        if (!gameOver)
        {
            if (Physics2D.OverlapBoxAll(dino.transform.position, Vector2.one * 0.3f, 0, LayerMask.GetMask("Enemy")).Length > 0)
            {
                gameOverPanel.SetActive(true);
                scoreText.enabled = false;
                gameOver = true;
                enemySpawn.stopSpawn = true;
                groundMovement.speed = 0;
                cactus.speed = 0;
            }

            if(Time.time >= timeToIncreaseDifficulty)
            {
                groundMovement.speed += 0.2f;
                enemySpawn.speed += 0.2f;

                score += 100;
                scoreText.text = score.ToString("D6");

                timeToIncreaseDifficulty = Time.time + interval;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
                gameOverPanel.SetActive(false);
                scoreText.enabled = true;
            }
        }
        
    }
}
