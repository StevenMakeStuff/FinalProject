using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContactEShip : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    public int totalHealth;

    private GameController gameController;
    private AudioSource audioSource;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "Shield")
        {
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Bolt" && totalHealth == 2)
        {
            totalHealth -= 1;
            Destroy(other.gameObject);
        }

        else if (other.tag == "Player" && totalHealth == 2)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        else if (other.tag == "Player" && totalHealth <= 1)
        {
            gameController.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}