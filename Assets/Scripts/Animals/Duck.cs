using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Duck : AnimalBehaviour
{
    //- VARS
    private SpawnManager spawnManager;

    
    //- MAIN METHODS
    private void Awake() 
    {
        // Set speed
        speed = 1.5f;
    }


    //- OTHER METHODS
    //* Do action to Duck
    protected override void DoAction()
    {
        Debug.Log("[DoAction] Action Duck");
    }
}
