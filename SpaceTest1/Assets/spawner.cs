using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] planes;
    //public Transform[] points;
    public GameObject player;
    public Camera view;
    public float spawnDistance;
    public float beat = (60/130)*2;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion playerRotation = player.transform.rotation;
        Vector3 point = new Vector3();
        point = view.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), spawnDistance));



        if (timer > beat)
        {
             Instantiate(planes[Random.Range(0, 2)], point, playerRotation );
            //plane.transform.localPosition = Vector3.zero;
            //plane.transform.Rotate(transform.forward,90 * Random.Range(0,4));
            timer -= beat;

        }
        timer += Time.deltaTime;
    }
}
