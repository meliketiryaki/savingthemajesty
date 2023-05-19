using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttondrag : MonoBehaviour
{
    private bool isSelected;

    void Update(){
        if(isSelected==true){
            Vector2 cursorPos= Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position= new Vector2(cursorPos.x,cursorPos.y);
        }
        if(Input.GetMouseButtonUp(0)){
            isSelected=false;
        }
    }   

    private void OnMouseOver(){
        if(Input.GetMouseButtonDown(0)){
            isSelected=true;
        }
    }
}
