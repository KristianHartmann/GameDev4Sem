using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShooter : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask guardLayerMask = new LayerMask();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, guardLayerMask))
            {

                var health = hit.transform.gameObject.GetComponentInParent<Health>();
                health.TakeDamage(20);
            }
        }
    }
}
