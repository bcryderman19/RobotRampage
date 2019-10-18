using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pickups;

    // Update is called once per frame
    void Update()
    {
        
    }

    //1 random pickup at set position
    void spawnPickup()
    {
        //Instantiate a random pickup
        GameObject pickup = Instantiate(pickups[Random.Range(0, pickups.Length)]);
        pickup.transform.position = transform.position;
        pickup.transform.parent = transform;
    }

    //2 wait 20 seconds before calling spawnPickup
    IEnumerator respawnPickup()
    {
        yield return new WaitForSeconds(20);
        spawnPickup();
    }

    //3 spawns a pickup as soon as game begins
    private void Start()
    {
        spawnPickup();
    }

    //4 starts coroutine
    public void PickupWasPickedUP()
    {
        StartCoroutine("respawnPickup");
    }
}
