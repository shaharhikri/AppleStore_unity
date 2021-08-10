using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoors : MonoBehaviour
{   
    public GameObject LeftDoor;
    public float LeftDoor_closed_pos;
    public float LeftDoor_opened_pos;

    public GameObject RightDoor;
    public float RightDoor_closed_pos;
    public float RightDoor_opened_pos;
    float speed;

    public bool playerIsHere;
    // Start is called before the first frame update
    void Start()
    {
        playerIsHere = false; //todo
        speed = 2f;

        RightDoor_closed_pos = RightDoor.transform.position.x;
        LeftDoor_closed_pos = LeftDoor.transform.position.x;

        LeftDoor_opened_pos = LeftDoor_closed_pos + 3;
        RightDoor_opened_pos = RightDoor_closed_pos - 3;
    }

    // Update is called once per frame
    void Update()
    {
        float dx = speed * Time.deltaTime;

        if (playerIsHere)
        {
            if (RightDoor.transform.position.x > RightDoor_opened_pos)
                RightDoor.transform.Translate(new Vector3(-dx, 0, 0));

            if (LeftDoor.transform.position.x < LeftDoor_opened_pos)
                LeftDoor.transform.Translate(new Vector3(+dx, 0, 0));
        }
        else
        {
            if (RightDoor.transform.position.x < RightDoor_closed_pos)
                RightDoor.transform.Translate(new Vector3(+dx, 0, 0));

            if (LeftDoor.transform.position.x > LeftDoor_closed_pos)
                LeftDoor.transform.Translate(new Vector3(-dx, 0, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.CompareTo("Player")==0)
            playerIsHere = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.CompareTo("Player")==0)
        {
            playerIsHere = false;
        }
    }
}
