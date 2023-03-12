using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    public int gold;

    void Awake ()
    {
        Debug.Log(this);
 
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    
    public void AddGold(int goldToAdd)
    {
        gold += goldToAdd;
    }
}
