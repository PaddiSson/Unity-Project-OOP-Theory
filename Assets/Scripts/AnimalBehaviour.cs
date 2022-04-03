using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AnimalBehaviour : MonoBehaviour
{
    //- VARS
    // Speed (Property get; set; )
    [SerializeField] protected float _speed;
    protected Rigidbody rbAnimal;
    protected Animator animatorAnimal;
    public float speed 
    {
        get { return _speed; }
        set {
            if (value > 0)
            {
                _speed = value;
            }
            else 
            {
                Debug.Log($"Error! You can't set a negative movement speed. (value: {value})");
            }
        }
    }
    

    //- MAIN METHODS
    private void Awake() {
        // Set default speed
        speed = 4.5f;
    }

    private void Start() 
    {
        // Init
        rbAnimal = GetComponent<Rigidbody>();
        animatorAnimal = GetComponent<Animator>();
        // Set the default movement direction (Rotate)
        RotateEntity();
        StartCoroutine(DoActionRandomTime());
    }

    private void FixedUpdate() 
    {
        // Move the entity
        MoveEntity();
    }

    private void OnTriggerEnter(Collider other) 
    {
        //Debug.Log($"[OnTriggerEnter] Out of bounds - x[{Mathf.Round(transform.position.x)}] z[{Mathf.Round(transform.position.z)}]");
        // Change the movement direction (Rotate) to another
        RotateEntity();
    }

    public virtual void OnCollisionEnter(Collision other) 
    {
        // Change the movement direction (Rotate) to another
        RotateEntity();
    }


    //- OTHER METHODS
    //* Move the entity
    private void MoveEntity()
    {
        Vector3 movement = Vector3.forward * speed * Time.deltaTime;
        transform.Translate(movement, Space.Self);
    }

    //* Change the movement direction (Rotate) to another
    private void RotateEntity()
    {
        //float rotation = transform.rotation.y + 180 + Random.Range(-90, 90);
        float rotation = Random.Range(160, 240);
        //Debug.Log($"[RotateEntity] Rotation : {rotation}");
        transform.Rotate(new Vector3(0, rotation, 0));
    }

    //* Destroy an object (designated as "prey")
    protected void DestroyPrey(GameObject gameObject)
    {
        Debug.Log($"[DestroyPrey] {gameObject.name}");
        Destroy(gameObject);
    }

    //* Do action to the entity
    protected abstract void DoAction();

    IEnumerator DoActionRandomTime()
    {
        Debug.Log("[DoActionRandomTime] Trying action...");
        // Infinite Coroutine
        while(true){
            // randomly do action
            if (Random.Range(0, 10) > 5)
            {
                Debug.Log("[DoActionRandomTime] Action");
                DoAction();
            }
            yield return new WaitForSeconds(6.0f);
        }
    }


}
