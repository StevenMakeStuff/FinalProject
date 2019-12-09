using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{

    private ParticleSystem ps;
    public float currentSpeed = 1.0f;
    private GameController gameController;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    
    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = currentSpeed;
    }

    public void UpdateSpeed(float speed)
    {
        currentSpeed += speed;
    }
}
