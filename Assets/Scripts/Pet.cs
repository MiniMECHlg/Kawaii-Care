using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pet : MonoBehaviour
{
    public int happiness {get; private set;}
    public int hunger {get; private set;}

    private bool animate = false;
    private int animVal = 0;
    private int nextAnimVal = 0;
    private int currentFrame = 0;
    public List<Sprite> greetingAnim = new List<Sprite>();
    public List<Sprite> idleAnim = new List<Sprite>();
    public List<Sprite> walkingAnim = new List<Sprite>();
    public List<Sprite> feedingAnim = new List<Sprite>();
    public List<List<Sprite>> Anims = new List<List<Sprite>>();
    private float frameTime = 1/4f;
    private float currentTime = 0f;

    private bool direction = false;
    private float target = 0f;
    private bool moving = false;
    private float totalIdleTime = 2f;
    private float currentIdleTime = 0f;
    private float movementSpeed = 0.5f;


    public SpriteRenderer self;

    public void ChangeCurrentAnim(int animValue)
    {
        if (this.animVal == 0 || this.animVal == 3)
        {
            this.nextAnimVal = animValue;
        }
        else
        {
            this.currentFrame = 0;
            this.animVal = animValue;
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
                this.self.sprite = Anims[this.animVal][this.currentFrame];
            }
            else
            {
                this.currentFrame = this.currentFrame + 1;
                this.self.sprite = Anims[this.animVal][this.currentFrame];
            }
        }
    }

    public void Start()
    {
        Anims.Add(this.greetingAnim);
        Anims.Add(this.idleAnim);
        Anims.Add(this.walkingAnim);
        Anims.Add(this.feedingAnim);
        this.animate = true;
        this.animVal = 0;
        ChangeCurrentAnim(1);
        this.happiness = 65;
        this.hunger = 65;
    }

    public void Update()
    {
        if (this.animate == true)
        {
            AnimCycle();
        }
        PetMovmentController();
        MovePet();
    }

    private void PetMovmentController()
    {
        if((this.animVal == 2 && this.moving == false) || (this.animVal == 1 && this.currentIdleTime >= this.totalIdleTime))
        {
            int nextAnim = Random.Range(0,2);
            if (nextAnim == 0)
            {
                ChangeCurrentAnim(1);
                this.currentIdleTime = 0;
            }
            else
            {
                this.target = Random.Range(-2.5f, 2.5f);
                if (this.target >= this.transform.position.x)
                {
                    this.direction = false;
                    this.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    this.direction = true;
                    this.GetComponent<SpriteRenderer>().flipX = true;
                }
                this.moving = true;
                ChangeCurrentAnim(2);
            }
        }
    }

    private void MovePet()
    {
        if(this.moving == true)
        {
            if (this.direction == false)
            {
                if (this.transform.position.x < this.target)
                {
                    this.transform.position = new Vector3((this.transform.position.x + movementSpeed * Time.deltaTime), this.transform.position.y);
                }
                else
                {
                    this.moving = false;
                }
            }
            else
            {
                if (this.transform.position.x > this.target)
                {
                    this.transform.position = new Vector3((this.transform.position.x - movementSpeed * Time.deltaTime), this.transform.position.y);
                }
                else
                {
                    this.moving = false;
                }
            }
        }
        else if (this.currentIdleTime < this.totalIdleTime && this.animVal == 1)
        {
            this.currentIdleTime = this.currentIdleTime + Time.deltaTime;
        }
    }

    public bool Feed(int points)
    {
        if (this.hunger == 100)
        {
            return false;
        }
        else if ((this.hunger + points) > 100)
        {
            this.hunger = 100;
        }
        else
        {
            this.hunger = this.hunger + points;
        }
        ChangeCurrentAnim(3);
        ChangeCurrentAnim(1);
        return true;
    }

    public void Play(int points)
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

    public void Tick()
    {
        if ((this.happiness != 0))
        {
            this.happiness = this.happiness - 1;
        }
        if ((this.hunger != 0))
        {
            this.hunger = this.hunger - 1;
        }
    }
}