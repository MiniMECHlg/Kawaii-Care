using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedObject : MonoBehaviour
{
    private float frameTime = 1/4f;
    public bool animate = true;
    private int animVal = 0;
    private int nextAnimVal = 0;
    private int currentFrame = 0;
    private float currentTime = 0f;
    private List<List<Sprite>> anims = new List<List<Sprite>>();
    private List<int> independantAnims = new List<int>();
    public bool sprite = true;

    public SpriteRenderer self;
    public Image selfI;

    public void Start()
    {
        this.animVal = 0;
    }

    public void Update()
    {
        if (this.animate == true)
        {
            AnimCycle();
        }
    }

    public void AddAnim(List<Sprite> Anim)
    {
       this.anims.Add(Anim);
    }

    public int CurrentAnim()
    {
        return this.animVal;
    }

    public void AddIndependant(List<Sprite> Anim)
    {
        this.independantAnims.Add(this.anims.Count);
        AddAnim(Anim);
    }

    public void ChangeCurrentAnim(int animValue)
    {
        if (this.independantAnims.Contains(this.animVal))
        {
            this.nextAnimVal = animValue;
        }
        else
        {
            this.currentFrame = 0;
            this.animVal = animValue;
            this.nextAnimVal = animValue;
        }
        AnimCycle();
    }

    public void AnimCycle()
    {
        this.currentTime = this.currentTime + Time.deltaTime;
        if(this.currentTime >= this.frameTime)
        {
            this.currentTime = 0;
            if(this.currentFrame + 1 == anims[this.animVal].Count)
            {
                this.currentFrame = 0;
                this.animVal = this.nextAnimVal;

                if (this.sprite == true)
                {
                    this.self.sprite = anims[this.animVal][this.currentFrame];
                }
                else
                {
                    this.selfI.sprite = anims[this.animVal][this.currentFrame];
                }
                
            }
            else
            {
                this.currentFrame = this.currentFrame + 1;
                if (this.sprite == true)
                {
                    this.self.sprite = anims[this.animVal][this.currentFrame];
                }
                else
                {
                    this.selfI.sprite = anims[this.animVal][this.currentFrame];
                }
            }
        }
    }
}