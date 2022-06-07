using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    private int happiness;
    private int hunger;

    public void feed(int points)
    {
        if ((this.hunger + points) > 100)
        {
            this.hunger = 100;
        }
        else
        {
            this.hunger = this.hunger + points;
        }
    }

    public void play(int points)
    {
        if ((this.happiness + points) > 100)
        {
            this.happiness = 100;
        }
        else
        {
            this.happiness = this.happiness + points;
        }
    }
}