using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pet : AnimatedObject, IDropHandler
{
    public int happiness {get; private set;}
    public int hunger {get; private set;}

    public List<Sprite> greetingAnim = new List<Sprite>();
    public List<Sprite> idleAnim = new List<Sprite>();
    public List<Sprite> walkingAnim = new List<Sprite>();
    public List<Sprite> feedingAnim = new List<Sprite>();

    private bool direction = false;
    private float target = 0f;
    private bool moving = false;
    private float totalIdleTime = 2f;
    private float currentIdleTime = 0f;
    private float movementSpeed = 0.5f;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Pet got given something");
        if (eventData.pointerDrag != null)
        {
            Debug.Log("Test");
        }
    }

    public void Start()
    {
        AddIndependant(this.greetingAnim);
        AddAnim(this.idleAnim);
        AddAnim(this.walkingAnim);
        AddIndependant(this.feedingAnim);
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
        if((CurrentAnim() == 2 && this.moving == false) || (CurrentAnim() == 1 && this.currentIdleTime >= this.totalIdleTime))
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
        else if (this.currentIdleTime < this.totalIdleTime && CurrentAnim() == 1)
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
        this.moving = false;
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