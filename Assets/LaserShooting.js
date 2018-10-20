#pragma strict
 
var impact : Transform;
var distance : float = 100;
var cover: Transform;
 private var allowfire : boolean = true;
 //Sets the boolean allow fire to be checked/true
 
function Update () {
 var up = transform.TransformDirection(Vector3.forward);
 //Sets the direction of the variable up, usefull because shortenned.
   var hit : RaycastHit;
   //Declares variable hit.    
   Debug.DrawRay(transform.position, up * distance, Color.red);
   //Vizualizes the ray(draws) so you can see it.
       
       if(Physics.Raycast(transform.position, up, hit, distance)){
       //Checks if ray we casted hit an object (distance is the length of a ray).
 
    if(Input.GetMouseButton(0)&&(allowfire)){
    //Checks if we pressed left mouse button, and if the boolean allow fire is checked.
    //if so:
           
               
     
      Instantiate(impact, hit.point, transform.rotation);
      //It spawns impact Transform on the position of the collision of ray and object.
      Fake();
      //Calls function Fake.

}
}
}
function Fake(){

allowfire = false;
//Sets the boolean fire to be unchecked.
Instantiate(cover, transform.position, transform.rotation);
//Spawns cover Transform on the position of the object that the script is attached to.
//It Waits for the amount of seconds that are stated in the firerate float, before it continues calling the script. 
 allowfire = true;
 //Sets the boolean fire to be checked.
}