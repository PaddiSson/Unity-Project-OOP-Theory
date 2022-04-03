using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fox : AnimalBehaviour
{
    //- VARS


    //- MAIN METHODS
    public override void OnCollisionEnter(Collision other)
    {
        // If collides with a Chicken or a Chick
        if(other.gameObject.CompareTag("Chicken") || other.gameObject.CompareTag("Chick") || other.gameObject.CompareTag("Duck"))
        {
            DestroyPrey(other.gameObject);
        }
        
        // Load overrided parent method
        base.OnCollisionEnter(other);
    }


    //- OTHER METHODS
    //* Do action to Fox
    protected override void DoAction()
    {
        Debug.Log("[DoAction] Action Fox");
    }
}
