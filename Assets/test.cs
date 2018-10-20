using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
      
        Camera cam = Camera.main;
      
     float pos = (cam.nearClipPlane + 0.01f);
      
     transform.position = cam.transform.position + cam.transform.forward * pos;
     transform.LookAt (cam.transform);
     transform.Rotate (90.0f, 0.0f, 0.0f);
      
     float h = (Mathf.Tan(cam.fov* Mathf.Deg2Rad*0.5f)*pos*2f) /10.0f;
      
     transform.localScale = new Vector3(h*cam.aspect,1.0f, h);

    }
}
