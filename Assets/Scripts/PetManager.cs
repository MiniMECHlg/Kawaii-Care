using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetManager : MonoBehaviour
{
    private float statusTick = 10f;
    private float currentTime = 0f;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (currentTime >= statusTick)
        {
            currentTime = 0f;
            gameManager.pets[gameManager.currentPet].Tick();
        }
        currentTime = currentTime + Time.deltaTime;
    }

    public bool Feed(int foodPoints)
    {
        return gameManager.pets[gameManager.currentPet].Feed(foodPoints);
    }   
}
