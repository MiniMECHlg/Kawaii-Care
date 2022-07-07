using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image heart;
    public Text heartText;
    public Image food;
    public Text foodText;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        heart.fillAmount = gameManager.pets[gameManager.currentPet].happiness/100f;
        heartText.text = gameManager.pets[gameManager.currentPet].happiness.ToString() + "%";
        food.fillAmount = gameManager.pets[gameManager.currentPet].hunger/100f;
        foodText.text = gameManager.pets[gameManager.currentPet].hunger.ToString() + "%";
    }
}
