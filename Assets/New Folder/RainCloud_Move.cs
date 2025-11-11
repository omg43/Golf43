using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCloud_Move : MonoBehaviour
{
    private bool ShouldMove => canMove;
    private bool ShouldStop => transform.position == newPos && IsMove;


    [SerializeField] private KeyCode SwitchButton;
    [SerializeField] private bool IsMove;
    [SerializeField] private int numVillager;
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] Villagers;
    [SerializeField] private GameObject activeVillager;
    [SerializeField] private bool canMove;
    [SerializeField] private Vector3 newPos;

    [SerializeField] private GameObject partictle;


    void Start()
    {
        //activeVillager = Villagers[Random.Range(0, Villagers.Length)];
        numVillager = Random.Range(0, Villagers.Length);
    }

    // Update is called once per frameu
    void Update()
    {
        Move();
        isPlace();
        if (Input.GetKeyDown(SwitchButton) && !IsMove)
        {
            canMove = true;
            newPos = Villagers[numVillager].transform.position;
            newPos.y += 16;
            IsMove = true;
            partictle.SetActive(false);
        }
    }
    private void isPlace()
    {
        if(ShouldStop)
        {
            numVillager++;
            IsMove = false;
            canMove = false;
            partictle.SetActive(true);
            if (numVillager > Villagers.Length - 1)
            {
                numVillager = 0;
            }
        }
    }
    private void Move()
    {
        if (ShouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPos, speed);
        }
    }
}
