using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public static int hp = 60;

	public void damage(int dmg)
    {
        hp -= dmg;
        if(hp <= 0)
        {
             GameObject explozie = Instantiate(Resources.Load("FlareMobile", typeof(GameObject))) as GameObject;
             explozie.transform.position = transform.position;
             Destroy(gameObject);
             Destroy(explozie, 2);
        }
    }
}
