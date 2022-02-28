using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : BaseUnit
{
    [SerializeField] private GameObject spawnObject;
    private GameObject targetObject;

    protected new void FixedUpdate()    //POLIMORPHISM
    {
        base.FixedUpdate();
        if (isSelected && isMouseClick0)
        {
            SpawnUnit();
        }
    }

    private void SpawnUnit()
    {
        if (clickedTarget.collider != null)
        {
            //if there was a cliced target
            targetObject = clickedTarget.collider.gameObject;
            //check if we hit ground and we cliced near the castle
            if (targetObject.CompareTag("Ground") && (clickedTarget.point.x - transform.position.x <= 1) && (clickedTarget.point.y - transform.position.y <= 1))
            {
                Instantiate(spawnObject, clickedTarget.point, transform.rotation);
            }    
        }
        isMouseClick0 = false;
    }
}
