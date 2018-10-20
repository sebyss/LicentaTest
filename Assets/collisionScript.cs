using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player")
        {
                col.transform.GetComponent<HealthScript>().damage(30);
                
                if(HealthScript.hp <= 0)
            {
                scoreScript.scoreVal += 10;
                Destroy(gameObject);
            }

            
            if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
            {
                GameObject nava1 = Instantiate(Resources.Load("nava1", typeof(GameObject))) as GameObject;
                GameObject nava2 = Instantiate(Resources.Load("nava2", typeof(GameObject))) as GameObject;
                GameObject nava3 = Instantiate(Resources.Load("nava3", typeof(GameObject))) as GameObject;
                GameObject nava4 = Instantiate(Resources.Load("nava4", typeof(GameObject))) as GameObject;

            }

           
        }
        
    }

}
