using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{

    private LineRenderer lr;
    // Use this for initialization
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


        Quaternion rotatieCam = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = rotatieCam;

        RaycastHit hit;

        lr.transform.rotation = Camera.main.transform.rotation;
        lr.transform.position = Camera.main.transform.position;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider)
            {
                if (hit.collider.transform.tag == "Player")
                {
                    GameObject explozie = Instantiate(Resources.Load("FlareMobile", typeof(GameObject))) as GameObject;
                    explozie.transform.position = transform.position;
                    Destroy(hit.collider.gameObject);
                    Destroy(explozie, 2);

                    //Destroy(gameObject);

                    scoreScript.scoreVal += 10;
                    if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
                    {
                        GameObject nava1 = Instantiate(Resources.Load("nava1", typeof(GameObject))) as GameObject;
                        GameObject nava2 = Instantiate(Resources.Load("nava2", typeof(GameObject))) as GameObject;
                        GameObject nava3 = Instantiate(Resources.Load("nava3", typeof(GameObject))) as GameObject;
                        GameObject nava4 = Instantiate(Resources.Load("nava4", typeof(GameObject))) as GameObject;

                    }

                    //Destroy(gameObject);
                }
                lr.SetPosition(0, hit.point);
            }
        }
        else    lr.SetPosition(0, transform.forward * 10);
        //Destroy(gameObject);
    }


         

}

