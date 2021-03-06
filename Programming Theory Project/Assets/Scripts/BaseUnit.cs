using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUnit : MonoBehaviour
{
    //selection marker
    [SerializeField] private GameObject selectMarkerObject;
    private bool isMarkerOn = false;
    private GameObject marker;

    protected string owner = null;
    public string Owner         //ENCAPSULATION
    {
        get { return owner; }
    }
    protected bool isSelected = false;
    public bool IsSelected
    {
        set { isSelected = value; }
    }
    //data about clicked target (if is)
    protected RaycastHit clickedTarget;
    public RaycastHit ClickedTarget
    {
        set { clickedTarget = value; }
    }
    protected bool isMouseClick0 = false;
    public bool IsMouseClick0
    {
        set { isMouseClick0 = value; }
    }

    //unit data
    protected int maxHealth;
    protected int currentHealth;


    protected void FixedUpdate()
    {
        //put on off selection marker
        if ((isSelected && !isMarkerOn) || (!isSelected && isMarkerOn))
        {
            SelectMarker();
        }
    }

    private void SelectMarker()     //ABSTRACTION
    {
        if (isSelected)
        {
            marker = Instantiate(selectMarkerObject, transform);
            isMarkerOn = true;
        }
        else
        {
            Destroy(marker);
            isMarkerOn = false;
        }
    }

    public void ChangeHealth(int f_amount)
    {
        currentHealth += f_amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            Destroy(gameObject);           
        }
    }

}
