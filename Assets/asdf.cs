using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class asdf : EventTrigger {

	// Use this for initialization
	void Start () {
		
	}

    public override void OnUpdateSelected(BaseEventData data)
    {
        Debug.Log("OnUpdateSelected called.");
      
    }

    // Update is called once per frame
    void Update () {
		
	}
}
