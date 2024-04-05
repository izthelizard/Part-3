using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//child class of player
public class RedMush : player
{
    //declare the float for the hydration levels and the max hydration levels it can be
    public float maxHydration = 10;
    public float hydration;


    private void Start()
    {
        //grab animation
        animator = GetComponent<Animator>();
        //hydration starts at max hydration
        hydration = maxHydration;
        //if they hydration is at max, then the coroutine starts
        if (hydration == maxHydration)
        {
            StartCoroutine(PlantLife());
        }

    }
    private void Update()
    {
        //if hydration is at 0 then the WATERING animation plays for the mushroom
        if (hydration == 0)
        {
            animator.SetTrigger("watering");
        }
    }
    //override the mouse down code, so that a different animation plays when the character is by the plant
    protected override void OnMouseDown()
    {
        //if hydration is set to 10 then the DEHYDRATION trigger plays
        hydration = 10;
        animator.SetTrigger("dehydration");
    }
    //the coroutine code for the hydration drain
    IEnumerator PlantLife()
    {
        //if hydration is greater than 0 than the hydration goes down by 2 each second.
        while (hydration > 0)
        {
            hydration -= 1;
            yield return new WaitForSeconds(2f);
        }

    }

}
