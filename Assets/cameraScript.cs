using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class cameraScript : MonoBehaviour
{
    public GameObject cameraPlane;



    // Use this for initialization
    void Start()
    {

        float height = Camera.main.orthographicSize * 2.0f;
        float width = height / Screen.height * Screen.width;
        this.transform.localScale = new Vector3(width / 10, 1.0f, height / 10);


        if (Application.isMobilePlatform)
        {
            GameObject cameraP = new GameObject("CamParent");
            cameraP.transform.position = this.transform.position;
            this.transform.parent = cameraP.transform;
            cameraP.transform.Rotate(Vector3.right, 90);

        }

        Input.gyro.enabled = true;



        WebCamTexture cameras = new WebCamTexture(3840,2160,300);
        cameraPlane.GetComponent<MeshRenderer>().material.mainTexture = cameras;
        cameras.Play();

        
        //========================Fire



    }

    public void manualLaserFire()
    {
        
            GameObject laser = Instantiate(Resources.Load("laserRay", typeof(GameObject))) as GameObject;
            Rigidbody rb = laser.GetComponent<Rigidbody>();
            laser.transform.rotation = Camera.main.transform.rotation;
            laser.transform.position = Camera.main.transform.position;
            rb.AddForce(Camera.main.transform.forward * 500f);
        
        GetComponent<AudioSource>().Play();

    }

    bool ispress = false;

    public void OnMouseDown()
    {
        ispress = true;
    }

    public void OnMouseUp()
    {
        ispress = false;
    }

    public void autoLaserFire()
    {
        GameObject laser = Instantiate(Resources.Load("lsr2", typeof(GameObject))) as GameObject;

        Rigidbody rb = laser.GetComponent<Rigidbody>();
        laser.transform.rotation = Camera.main.transform.rotation;
        laser.transform.position = Camera.main.transform.position;
        rb.AddForce(Camera.main.transform.forward * 5000f);
       // Destroy(laser);
        //Destroy(gameObject);

        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rotatieCam = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
        this.transform.localRotation = rotatieCam;

        if (ispress)
        {
            autoLaserFire();
        }
    }
}
