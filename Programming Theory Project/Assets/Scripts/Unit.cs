using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : BaseUnit
{
    protected GameObject targetObject;

    protected new void FixedUpdate()
    {
        base.FixedUpdate();

        if (clickedTarget.collider != null)
        {
            //if there was a cliced target
            targetObject = clickedTarget.collider.gameObject;
            //check if we hit ground
            if (targetObject.CompareTag("Ground"))
            {
                MoveUnit();
            }
        }
    }

    protected void MoveUnit()
    {
        //move unit to target position
        gameObject.transform.position = clickedTarget.point;
    }
}
