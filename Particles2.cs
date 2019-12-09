using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles2 : MonoBehaviour
{

    private ParticleSystem ps;
    public float currentSpeed2 = 1.0f;
    private GameController gameController;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        gameController = GameObject.FindObjectOfType<GameController>();
    }


    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = currentSpeed2;
    }

    public void UpdateSpeed2(float speed2)
    {
        currentSpeed2 += speed2;
    }
}
