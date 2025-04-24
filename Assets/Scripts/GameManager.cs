using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI score;
    public int scoreCount;
    public GameObject MainMenu;
    public GameObject Creature;
    public bool GameStart;
    public int spawnTimer;

    public TextMeshProUGUI lifeCounter;
    public int lives;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(GameStart) {
            spawnTimer++;
            if(spawnTimer > 100) {
                spawnTimer = 0;
                int spawns = Random.Range(1, 3);
                for(int i = 0; i < spawns; i++) {
                    int Z = Random.Range(-1, 1);
                    if (Z == 0) {
                        Z++;
                    }
                    Instantiate(Creature, new Vector3(Random.Range(-20, 20), 0.5f, 18 * Z), Quaternion.identity);
                }
            }
        }
    }

    public void StartGame()
    {
        MainMenu.SetActive(false);
        GameStart = true;
        lives = 3;
        lifeCounter.text = "Lives: " + lives;
        scoreCount = 0;
        score.text = "Score: " + scoreCount;
    }

    public void GameOver()
    {
        GameStart = false;
        MainMenu.SetActive(true);
        player.transform.position = new Vector3(0, 1.5f, 0);
        player.transform.rotation = Quaternion.identity;
    }

    public void addScore(int Added)
    {
        scoreCount += Added;
        score.text = score.text = "Score: " + scoreCount;
        if(scoreCount%50 == 0) {
            lives++;
            lifeCounter.text = "Lives: " + lives;
        }
    }

    public void PlayerHurt()
    {
        lives--;
        lifeCounter.text = "Lives: " + lives;
        if(lives == 0) {
            GameOver();
        }
    }
}
