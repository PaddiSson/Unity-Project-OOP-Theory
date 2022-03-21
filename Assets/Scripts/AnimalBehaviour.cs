using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimalBehaviour : MonoBehaviour
{
    //- VARS
    // Speed (Property get; set; )
    private float speed = 3.0f;
    public float Speed 
    {
        get { return speed; }
        set {
            if (value > 0)
            {
                speed = value;
            }
            else 
            {
                Debug.Log($"Error! You can't set a negative movement speed. (value: {value})");
            }
        }
    }
    // OutOfBounds
    private float xRange = 10;
    private float zRange = 10;

    //- MAIN METHODS
    void Update() {
        //* Move the entity
        Move();
    }

    //- OTHERS METHODS
    //* Move the entity
    private void Move()
    {
        //* Change the movement direction to another if go out the area
        OutOfBouds();
        // Move the entity forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    //* Change the movement direction to another if go out the area
    private void OutOfBouds()
    {
        if (transform.position.x > xRange || transform.position.x < -xRange
         || transform.position.z > zRange || transform.position.z < -zRange)
        {

            Debug.Log($"Out of bounds! x[{transform.position.x}] z[{transform.position.z}]");
            transform.Rotate(0, Random.Range(100, 361), 0);
        }
    }

    //* Do action to the entity
    protected abstract void DoAction();



}
