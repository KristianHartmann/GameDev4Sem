using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitSelector : MonoBehaviour
{
    public List<GameObject> units;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "Player")
                {
                    if(!units.Contains(hit.collider.gameObject))
                    {
                        if(Input.GetKey(KeyCode.LeftShift))
                        {
                            units.Add(hit.collider.gameObject);
                        }
                        else
                        {
                            units.Clear();
                            units.Add(hit.collider.gameObject);
                        }
                        
                    }
                }
                Debug.Log(hit.collider.gameObject.name);
                if(hit.collider.tag == "Ground"){
                    units.Clear();
                }
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "Ground")
                {
                    foreach(GameObject unit in units)
                    {
                        unit.GetComponent<NavMeshAgent>().SetDestination(hit.point);
                    }
                }
            }
        }
    }
}
