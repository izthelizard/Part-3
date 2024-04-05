using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//child class of player
public class PinkMush : player
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
        //if hydration is at 0 then the dehydration animation plays for the mushroom
        if (hydration == 0)
        {
            animator.SetTrigger("dehydration");
        }
    }
    //override the mouse down code, so that a different animation plays when the character is by the plant
    protected override void OnMouseDown()
    {
        //if hydration is set to 10 then the watering trigger plays
        hydration = 10;
        animator.SetTrigger("watering");
    }
    //the coroutine code for the hydration drain
    IEnumerator PlantLife()
    {
        //if hydration is greater than 0 than the hydration goes down by 1 each second.
        while (hydration > 0)
        {
            hydration -= 1;
            yield return new WaitForSeconds(1f);
        }

    }

}
