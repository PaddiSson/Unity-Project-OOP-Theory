using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chick : AnimalBehaviour
{
    //- VARS
    private SpawnManager spawnManager;

    
    //- MAIN METHODS
    private void Awake() 
    {
        // Set speed
        speed = 2.0f;
    }


    //- OTHER METHODS
    //* Do action to Chick
    protected override void DoAction()
    {

    }
}
