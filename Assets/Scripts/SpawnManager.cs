using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    //- VARS
    [SerializeField] private GameObject foxPrefab;
    [SerializeField] private GameObject[] dogsPrefabs;
    [SerializeField] private GameObject[] chickensPrefabs;    
    [SerializeField] public GameObject chickPrefab;
    [SerializeField] private GameObject duckPrefab;
    private float spawnRange = 13.5f;


    //- MAIN METHODS
    private void Start() {
        // Spawn some animals on start
        for (int i = 0; i < 5; i++) {
            SpawnAnimal(chickensPrefabs[VariantChickenPrefab()]);
        }
        SpawnAnimal(dogsPrefabs[VariantDogPrefab()]);        
        SpawnAnimal(duckPrefab);
    }


    //- OTHER METHODS
    //* Spawn a preset Animal 
    public void SpawnAnimal(GameObject animalPrefab, Vector3 position)
    {
        Debug.Log($"[SpawnAnimal] {animalPrefab.name}");
        Instantiate(animalPrefab, position + new Vector3(0, 1, 0), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
    }
    public void SpawnAnimal(GameObject animalPrefab)
    {
        Debug.Log($"[SpawnAnimal] {animalPrefab.name}"); 
        // If is an animal with variant prefab
        if (animalPrefab.gameObject.tag == "Chicken") {
            animalPrefab = chickensPrefabs[VariantChickenPrefab()];
        }
        else if (animalPrefab.gameObject.tag == "Dog") {
            animalPrefab = dogsPrefabs[VariantDogPrefab()];
        }
        Instantiate(animalPrefab, GenerateSpawnPosition(), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
    }

    //* Kill all animals of one type
    public void KillAnimal(string animalTag)
    {
        GameObject[] animalsType = GameObject.FindGameObjectsWithTag(animalTag);
        foreach(GameObject animal in animalsType)
        {
            Destroy(animal);
        }
    }


    //* Generate a random Vector3 location
    private Vector3 GenerateSpawnPosition()
    {
        // Generate random location
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    private int VariantChickenPrefab() {
        int variant = Random.Range(0, chickensPrefabs.Length);
        return variant;
    }

    private int VariantDogPrefab() {
        int variant = Random.Range(0, dogsPrefabs.Length);
        return variant;
    }
}
