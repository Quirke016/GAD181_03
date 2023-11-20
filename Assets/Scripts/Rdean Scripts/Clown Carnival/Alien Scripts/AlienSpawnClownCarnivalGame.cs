using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public class clowncarnival_ : MonoBehaviour
{

// The spawn locations of for the aliens
    public GameObject Spawn1; 
    public GameObject Spawn2;   
    public GameObject Spawn3;
    public GameObject Spawn4;
    public GameObject Spawn5;
    GameObject whatsSpawning;

// Gameobject to place alien prefab in

    public GameObject Alien;

    // Start is called before the first frame update
    void Start()
    {
        AlienSpawn(); // The alien spawn function being called

    }




    IEnumerator WaitTillAlienSpawn() // A function that determines how long until the next alien spawns in
    {
        yield return new WaitForSeconds(0.5f);
        AlienSpawn();
        Debug.Log("Alien spawned"); // Debugs out when another alien spawns in
    }
    





    public void AlienSpawn() // function that generates a random number between 1-5 which decides the spawn point for the alien
    {
        int randomnumber;
        randomnumber = Random.Range(1, 6);
        

        if (randomnumber ==1) // if statements setting multiple spawn point for aliens based on number rolled
        {
            whatsSpawning = Spawn1;

            Debug.Log("Alien 1 spawn"); // Debugs the spawn location and the number associated with it
        }

        if (randomnumber == 2)
        {
            whatsSpawning = Spawn2;
            Debug.Log("Alien 2 spawn");
        }
        
        if(randomnumber == 3)
        {
            whatsSpawning = Spawn3;
            Debug.Log("Alien 3 spawn");
        }

        if (randomnumber == 4)
        {
            whatsSpawning = Spawn4;
            Debug.Log("Alien 4 spawn");
        }

        if (randomnumber == 5)
        {
            whatsSpawning = Spawn5;
            Debug.Log("Alien 5 spawn");
        }

      

        Instantiate(Alien, whatsSpawning.transform.position, whatsSpawning.transform.rotation); // Instantiate that takes the alien prefab and duplicates it at the position of the spawn locations
        StartCoroutine( WaitTillAlienSpawn()); // corotuine that loops the alien spawn function
    }
    
    
    
   
    
    
    



}
