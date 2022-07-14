using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Food : AnimatedObject, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public List<Sprite> idleAnim = new List<Sprite>();
    public int foodVal;
    private bool onPet = false;

    private void Awake()
    {
        this.rectTransform = GetComponent<RectTransform>();
        this.canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Start()
    {
        AddAnim(idleAnim);
    }

    public void Update()
    {
        if (this.animate == true)
        {
            AnimCycle();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //temp
        Debug.Log("OnEndDrag");
        FindObjectOfType<UIManager>().EatFood(this.foodVal);
        this.rectTransform.anchoredPosition = new Vector2(0,0);
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

}
