using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseTest : MonoBehaviour, IDragHandler
    , IBeginDragHandler, IEndDragHandler
{
    public Renderer rend;

    void OnMouseDown()
    {
        print("OnMouseDown");
    }

    public Vector3 rotate = new Vector3(0, 1, 0);
    void OnMouseDrag()
    {
        transform.Rotate(rotate);
        //rend.material.color -= Color.white * Time.deltaTime;
    }

    public Vector2 offsetDrag;
    Vector3 dragStartPosition;
    public void OnBeginDrag(PointerEventData eventData)
    {
        dragStartPosition = transform.position;
        Vector2 pos = new Vector2(dragStartPosition.x
            , dragStartPosition.y);

        offsetDrag = pos - eventData.pressPosition;

        GetComponent<Image>().raycastTarget = false;
        transform.SetAsLastSibling();
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position + offsetDrag;
    }

    //internal void ResetPosition()
    //{
    //    transform.position = dragStartPosition;
    //}

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<Image>().raycastTarget = true;
    }

    //void Start()
    //{
    //    rend = GetComponent<Renderer>();
    //}

    //// The mesh goes red when the mouse is over it...
    //void OnMouseEnter()
    //{
    //    rend.material.color = Color.red;
    //}

    //// ...the red fades out to cyan as the mouse is held over...
    //void OnMouseOver()
    //{
    //    rend.material.color -= new Color(0.1F, 0, 0) * Time.deltaTime;
    //}

    //// ...and the mesh finally turns white when the mouse moves away.
    //void OnMouseExit()
    //{
    //    rend.material.color = Color.white;
    //}
}
