using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject selectedObject;
    private BaseUnit selectedObjectBaseUnit;
    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //checking for hit
            RaycastHit f_hit;
            Ray f_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //if we hit something

            if (Physics.Raycast(f_ray, out f_hit))
            {
                //if we hit own unit - select it
                if (f_hit.collider.gameObject.transform.CompareTag("OwnUnit")) 
                {
                    //if there wasour unit selected befor - deselect it
                    if (selectedObject != null)
                    {
                        selectedObjectBaseUnit.IsSelected = false;
                    }
                    selectedObject = f_hit.collider.gameObject;
                    selectedObjectBaseUnit = f_hit.collider.gameObject.transform.GetComponent<BaseUnit>();
                    selectedObjectBaseUnit.IsSelected = true;
                }
                //else if we have selected unit
                else if (selectedObject != null)
                {
                    //pass data about what we have clicked
                    selectedObjectBaseUnit.ClickedTarget = f_hit;
                }

            }
            else
            {
                //deselect
                if (selectedObjectBaseUnit != null)
                {
                    selectedObjectBaseUnit.IsSelected = false;
                    selectedObjectBaseUnit = null;
                    selectedObject = null;
                }
                
            }

        }
    }
}


