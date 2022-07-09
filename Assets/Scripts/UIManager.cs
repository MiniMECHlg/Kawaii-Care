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
    public Animator bagAnim;
    private bool bagOpen = false;
    private List<int> foodAmounts = new List<int> {00,17,05,22};
    public List<Text> foodValues = new List<Text>();

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        for (int i = 0; i < foodAmounts.Count; i++)
        {
            foodValues[i].text = foodAmounts[i].ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        heart.fillAmount = gameManager.pets[gameManager.currentPet].happiness/100f;
        heartText.text = gameManager.pets[gameManager.currentPet].happiness.ToString() + "%";
        food.fillAmount = gameManager.pets[gameManager.currentPet].hunger/100f;
        foodText.text = gameManager.pets[gameManager.currentPet].hunger.ToString() + "%";
    }

    public void TriggerBag()
    {
        if (bagOpen == false)
        {
            bagAnim.SetTrigger("OpenInventory");
        }
        else
        {
            bagAnim.SetTrigger("CloseInventory");
        }
        bagOpen = !bagOpen;
    }

    public void EatFood(int foodVal)
    {
        int foodPoints = 10;
        if (foodAmounts[foodVal] > 0)
        {
            if (FindObjectOfType<PetManager>().Feed(foodPoints) == true)
            {
                foodAmounts[foodVal] = foodAmounts[foodVal] - 1;
                foodValues[foodVal].text = foodAmounts[foodVal].ToString();
            }
        }
    }
}