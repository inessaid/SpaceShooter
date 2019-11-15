using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    private bool _alive;
    public GameObject paintballPrefab;
    private GameObject _paintball;
    public GameObject Player;
    public float movementSpeed = 4;

    // Start is called before the first frame update
    void Start()
    {
        _alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_alive)
        {
            //transform.Translate(0, 0, speed * Time.deltaTime);

            transform.LookAt(Player.transform);
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }

        //enemy looking forward
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.35f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<Playerinfo>())
            {
                if (_paintball == null)
                {
                    _paintball = Instantiate(paintballPrefab) as GameObject;
                    _paintball.transform.position = transform.TransformPoint(Vector3.forward * 2f);
                    _paintball.transform.rotation = transform.rotation;
                }
            }
        

        }
    }
}
