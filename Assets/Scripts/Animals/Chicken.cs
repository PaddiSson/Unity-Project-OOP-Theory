using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chicken : AnimalBehaviour
{
    //- VARS
    private SpawnManager spawnManager;
    [SerializeField] private bool hasLaid;
    private float timeBeforeLaying = 30.0f;

    
    //- MAIN METHODS
    private void Awake() 
    {
        // Set Defaults
        speed = 2.5f;
        hasLaid = false;
    }

    private void Start() 
    {
        // Init SpawnManager
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    public override void OnCollisionEnter(Collision other) 
    {
        // If collides with another Chicken
        if(other.gameObject.CompareTag("Chicken"))
        {
            Debug.Log($"[OnCollisionEnter] Spawned Chick - Collision between {gameObject.GetInstanceID()} and {other.gameObject.GetInstanceID()}");
            
            bool hasOtherLaid = other.gameObject.GetComponent<Chicken>().hasLaid;
            // Check if both Chicken hasn't laid a Chick
            if (!hasLaid && !hasOtherLaid)
            {
                // Spawn a Chick
                spawnManager.SpawnAnimal(spawnManager.chickPrefab, transform.position);
                // Reset hasLaid for Chicken after X seconds
                StartCoroutine(ResetLaying());
                
                // Set hasLaid to TRUE
                hasLaid = true;
                other.gameObject.GetComponent<Chicken>().hasLaid = true;
            }           
        }
        // Load overrided parent method
        base.OnCollisionEnter(other);
    }

    //* Reset hasLaid for Chicken after X seconds
    IEnumerator ResetLaying() 
    {
        yield return new WaitForSeconds(timeBeforeLaying);
        // Set hasLaid to FALSE for next collision between two Chicken
        hasLaid = false;
    }


    //- OTHER METHODS
    //* Do action to Chicken
    protected override void DoAction()
    {
        Debug.Log("[DoAction] Action Chicken");
        speed = 0.0001f;
        animatorAnimal.SetFloat("Speed_f", speed);
        animatorAnimal.SetBool("Eat_b", true);
        StartCoroutine(stopChickenAction());
    }

    IEnumerator stopChickenAction()
    {
        yield return new WaitForSeconds(4.0f);
        animatorAnimal.SetBool("Eat_b", false);
        speed = 2.5f;
        animatorAnimal.SetFloat("Speed_f", speed);
        
    }
}
