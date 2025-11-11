using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField] private KeyCode SpawnButton;
    [SerializeField] private GameObject stonePref;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(SpawnButton))
        {
            Instantiate(stonePref,transform.position,Quaternion.identity);
        }
    }
}
