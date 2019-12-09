using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public AudioClip mainAudio;
    public AudioClip winAudio;
    public AudioClip loseAudio;
    public AudioSource mainMusicSource;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;

    private Lighting lighting;
    private Particles particles;
    private Particles2 particles2;
    private BG_Scroller bG_Scroller;
    private bool gameWon;
    private bool gameOver;
    private bool restart;
    private int score;

    private int activateLights = 1;
    private float newScrollSpeed = -5.0f;
    private float speed = 50.0f;
    private float speed2 = 50.0f;

    void Start()
    {
        gameWon = false;
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        particles = GameObject.FindObjectOfType<Particles>();
        particles2 = GameObject.FindObjectOfType<Particles2>();
        bG_Scroller = GameObject.FindObjectOfType<BG_Scroller>();
        lighting = GameObject.FindObjectOfType<Lighting>();
        mainMusicSource.clip = mainAudio;
        mainMusicSource.Play();
        mainMusicSource.loop = true;
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'space' for Restart";
                restart = true;
                break;
            }
            
            else if (gameWon)
            {
                restartText.text = "Press 'space' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if(score >= 100)
        {
            GameWon();
        }
    }

    public void GameOver()
    {
        
        gameOverText.text = "Game Over";
        gameOver = true;
        SadMusic();
    }

    public void GameWon()
    {
        gameOverText.text = "You Win! Game created by Steven Ulloa!";
        gameWon = true;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        GameObject.Destroy(enemy);

        HappyMusic();

        particles.UpdateSpeed(speed);
        particles2.UpdateSpeed2(speed2);
        bG_Scroller.UpdateScrollSpeed(newScrollSpeed);
        lighting.UpdateLights(activateLights);
    }

    void SadMusic()
    {
        if (gameOver)
        {
            mainMusicSource.clip = loseAudio;
            mainMusicSource.Play();
        }
    }

    void HappyMusic()
    {
        if (gameWon)
        {
            mainMusicSource.clip = winAudio;
            mainMusicSource.Play();
        }
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}