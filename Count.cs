using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    public countCSV rWallF;
    public countCSV rWallB;
    public countCSV rWallR;
    public countCSV rWallL;

    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider other) //OnCollisionEnter is called when objects collide with each other
    {
        if (other.gameObject.CompareTag("WallF"))
        {
            rWallF.GetComponent<countCSV>().wallF++;
        }
        if (other.gameObject.CompareTag("WallB"))
        {
            rWallB.GetComponent<countCSV>().wallB++;
        }
        if (other.gameObject.CompareTag("WallR"))
        {
            rWallR.GetComponent<countCSV>().wallR++;
        }
        if (other.gameObject.CompareTag("WallL"))
        {
            rWallL.GetComponent<countCSV>().wallL++;
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
