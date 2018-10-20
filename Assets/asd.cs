using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class asd : MonoBehaviour {

    

    // Use this for initialization
    void Start () {

        float height = Camera.main.orthographicSize * 2.0f;
        float width = height / Screen.height * Screen.width;
        this.transform.localScale = new Vector3(width / 10, 1.0f, height / 10);

    }
	
	// Update is called once per frame
	void Update () {

        

    }

}
