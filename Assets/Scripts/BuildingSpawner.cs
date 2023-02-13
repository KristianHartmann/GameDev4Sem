using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject unitPrefab;
    public float spawnInterval = 1.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(SpawnUnit());
        }
    }

    private IEnumerator SpawnUnit()
    {
        while (true)
        {
            Instantiate(unitPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
