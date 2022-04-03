using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dog : AnimalBehaviour
{
    //- VARS


    //- MAIN METHODS
    private void Awake() 
    {
        // Set speed
        speed = 5.0f;
    }

    public override void OnCollisionEnter(Collision other)
    {
        // If collides with a Fox
        if(other.gameObject.CompareTag("Fox"))
        {
            DestroyPrey(other.gameObject);
            // Sometimes Dog is destroyed too
            if (Random.Range(0, 10) > 6) {
                Destroy(gameObject);
            }
        }
        // Load overrided parent method
        base.OnCollisionEnter(other);
    }
    

    //- OTHER METHODS
    //* Do action to Dog
    protected override void DoAction()
    {
        Debug.Log("[DoAction] Action Dog");
        animatorAnimal.SetBool("Sit_b", true);
        speed = 0.0001f;
        StartCoroutine(stopDogAction());
    }

    IEnumerator stopDogAction()
    {
        yield return new WaitForSeconds(2.0f);
        animatorAnimal.SetBool("Sit_b", false);
        yield return new WaitForSeconds(2.5f);
        speed = 5.0f;
    }
}
