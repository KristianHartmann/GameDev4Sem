using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject unit; // The prefab of the unit object to spawn
    public float spawnDistance = 2.0f; // The distance from the collider to spawn the player
    public LayerMask spawnLayerMask; // The layer(s) that the player can be spawned on
    public float spawnDelay = 5.0f; // The delay between spawning units
    public int unitsPerClick = 1; // The number of units to spawn per click
    public Camera cam;
    private float spawnTimer = 0.0f; // The timer for spawning player objects
    private Queue<Vector3> unitSpawnQueue = new Queue<Vector3>(); // The queue of spawn positions for player objects

    private void Start()
    {

    }

    private void Update()
    {
        // Check if the mouse is over the building
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // If the queue has items and the timer has reached the spawn delay, spawn the next player object
        if (unitSpawnQueue.Count > 0 && spawnTimer >= spawnDelay)
        {
            // Get the next position from the queue
            Vector3 spawnPosition = unitSpawnQueue.Dequeue();

            // Check for a valid spawn point
            if (Physics.Raycast(spawnPosition + Vector3.up, Vector3.down, out hit, Mathf.Infinity, spawnLayerMask))
            {
                // Spawn the player at the hit point
                Instantiate(unit, hit.point, Quaternion.identity);
                Debug.Log("Spawned unit at " + hit.point);
                Debug.Log("Spawn queue size: " + unitSpawnQueue.Count);
            }

            // Reset the timer
            spawnTimer = 0.0f;
        }


        if (Physics.Raycast(ray, out hit) && hit.collider == GetComponent<BoxCollider>())
        {

            // Check if the shift key is held down
            bool shiftHeld = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);


            // If the left mouse button is clicked, add a player object to the queue
            if (Input.GetMouseButtonDown(0))
            {
                // Calculate a random offset to spawn the player
                Vector3 spawnOffset = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f)).normalized * spawnDistance;

                // Add the spawn position to the queue
                unitSpawnQueue.Enqueue(transform.position + spawnOffset);
                Debug.Log("Added unit to the queue. Spawn queue size: " + unitSpawnQueue.Count);

                // If the shift key is held down, add 4 more units to the queue
                if (shiftHeld)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        // Calculate a random offset to spawn the player
                        Vector3 shiftSpawnOffset = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f)).normalized * spawnDistance;

                        // Add the spawn position to the queue
                        unitSpawnQueue.Enqueue(transform.position + shiftSpawnOffset);
                    }
                    Debug.Log("Added 5 unit to the queue. Spawn queue size: " + unitSpawnQueue.Count);

                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                {
                    // Clear 5 players from the queue
                    for (int i = 0; i < 5 && unitSpawnQueue.Count > 0; i++)
                    {
                        unitSpawnQueue.Dequeue();
                    }
                    Debug.Log("Removed 5 units from the queue. Spawn queue size: " + unitSpawnQueue.Count);

                }
                else
                {
                    // Clear 1 player from the queue
                    if (unitSpawnQueue.Count > 0)
                    {
                        unitSpawnQueue.Dequeue();
                        Debug.Log("Removed 1 unit from the queue. Spawn queue size: " + unitSpawnQueue.Count);
                    }
                }
            }


        }
        // Increment the timer
        spawnTimer += Time.deltaTime;
    }

}
