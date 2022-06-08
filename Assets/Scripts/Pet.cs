using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pet : MonoBehaviour
{
    private int happiness;
    private int hunger;

    private int animVal = 0;
    private int nextAnimVal = 0;
    private int totalFrames = 0;
    private itn currentFrame = 1;
    public List<Sprite> greetingAnim = new List<Sprite>();
    public List<Sprite> idleAnim = new List<Sprite>();
    public List<Sprite> walkingAnim = new List<Sprite>();
    public List<Sprite> feedingAnim = new List<Sprite>();

    public void changeCurrentAnim(int animVal)
    {
        
    }

    public void animCycle()
    {

    }

    public void start()
    {
        changeCurrentAnim(0);
        animCycle();
    }

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