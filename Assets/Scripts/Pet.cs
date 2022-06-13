using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pet : MonoBehaviour
{
    private int happiness;
    private int hunger;

    private bool animate = false;
    private int animVal = 1;
    private int nextAnimVal = 1;
    private int currentFrame = 0;
    public List<Sprite> greetingAnim = new List<Sprite>();
    public List<Sprite> idleAnim = new List<Sprite>();
    public List<Sprite> walkingAnim = new List<Sprite>();
    public List<Sprite> feedingAnim = new List<Sprite>();
    public List<List<Sprite>> Anims = new List<List<Sprite>>();
    private float frameTime = 1/4f;
    private float currentTime = 0f;

    public SpriteRenderer self;

    public Image heart;
    public Text heartText;

    public void ChangeCurrentAnim(int animVal)
    {
        this.nextAnimVal = animVal;
        if (this.animVal == 0 || this.animVal == 3)
        {
            Debug.Log("This should do nothing");
        }
        else
        {
            this.animVal = this.nextAnimVal;
        }
    }

    public void AnimCycle()
    {
        this.currentTime = this.currentTime + Time.deltaTime;
        if(this.currentTime >= this.frameTime)
        {
            this.currentTime = 0;
            if(this.currentFrame + 1 == Anims[this.animVal].Count)
            {
                this.currentFrame = 0;
                if(this.animVal == 0 || this.animVal == 3)
                {
                    this.animVal = this.nextAnimVal;
                }
            }
            else
            {
                this.currentFrame = this.currentFrame + 1;
            }
            this.self.sprite = Anims[this.animVal][this.currentFrame];
        }
    }

    public void Start()
    {
        Anims.Add(this.greetingAnim);
        Anims.Add(this.idleAnim);
        Anims.Add(this.walkingAnim);
        Anims.Add(this.feedingAnim);
        this.animate = true;
        this.animVal = 1;
        this.happiness = 65;
    }

    public void Update()
    {
        if (this.animate == true)
        {
            AnimCycle();
        }
        this.heart.fillAmount = this.happiness/100f;
        this.heartText.text = this.happiness.ToString() + "%";
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