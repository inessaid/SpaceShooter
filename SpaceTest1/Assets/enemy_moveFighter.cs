using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_moveFighter : MonoBehaviour
{

    public GameObject Player;
    public float rotationalDamp = 0.5f;
    public float movementSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(Player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(Player.transform);
        // transform.rotation = new Quaternion(rotx, roty, rotz, rotw);
        //transform.Rotate(transform.forward,90 * Random.Range(0,4));
        //transform.position += transform.forward * movementSpeed * Time.deltaTime;

        Turn();
        Move();
    }

    void Turn()
    {
        Vector3 pos = Player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);


    }
    void Move()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
}