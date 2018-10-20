#pragma strict
var gun : Transform;
var projectile : GameObject;

   function FixedUpdate()
    {
          
        var lr : LineRenderer = gameObject.GetComponent.<LineRenderer>();
        //Finds line renderrer on this object. 
         
      
 
        lr.SetPosition(0, gun.transform.position);
       //Sets the 1st position of the line renderrer(end and start position).
        lr.SetPosition(1, projectile.transform.position);
       //Sets the 2nd position of the line renderrer(line renderrer will be drawn beetwen those 2 points(gun, projectile).
    }
    function Update(){
   
   
   gun = GameObject.FindWithTag ("end").transform;
   //sets the Transform on variable gun to be the object with a tag end.


    
    }
    //Script to create laser/line effect beetwen 2 random points.