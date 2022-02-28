using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : BaseUnit        //INHERITANCE
{
    protected GameObject targetObject;
    protected float unitSpeed = 1;

    protected new void FixedUpdate()    //POLIMORPHISM
    {
        base.FixedUpdate();

        if ((clickedTarget.collider != null) && isMouseClick0)
        {
            //if there was a cliced target
            targetObject = clickedTarget.collider.gameObject;
            //check if we hit ground
            if (targetObject.CompareTag("Ground"))
            {
                StopCoroutine(MoveUnit());
                StartCoroutine(MoveUnit());
            }
            isMouseClick0 = false;
        }
    }

    IEnumerator MoveUnit()
    {
        Vector3 f_startPosition = gameObject.transform.position;
        Vector3 f_whereToGo = clickedTarget.point;
        Vector3 f_movingVector = clickedTarget.point - gameObject.transform.position;
        float f_lenghtOfRoad = f_movingVector.magnitude;
        float t_time = 0;

        while (gameObject.transform.position != f_whereToGo)
        {
            t_time += Mathf.Clamp(Time.deltaTime * unitSpeed / f_lenghtOfRoad, 0, 1);
            //move unit to target position
            gameObject.transform.position = Vector3.Lerp(f_startPosition, f_whereToGo, t_time);

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
