using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private void Start()
    {
        UnitSelections.Instance.unitList.Add(this.gameObject);
        Debug.Log(UnitSelections.Instance.unitList.Count + "name: " + this.gameObject.name);
    }

    private void OnDestroy()
    {
        UnitSelections.Instance.unitList.Remove(this.gameObject);
    }
}

    
