//----------------------------------------------------------------------------------
// Allows to randomize the animation of Waypoint mover
// Just attach it to any object with collider and  chose which animation you want to randomize when actor enters the  trigger-zone.
//----------------------------------------------------------------------------------

#pragma strict

enum AnimationToChange {Idle, Move, Jump}


var animationToChange: AnimationToChange;

//----------------------------------------------------------------------------------
function Start () 
{
  if (!gameObject.GetComponent.<Collider>().isTrigger) gameObject.GetComponent.<Collider>().isTrigger = true;

}

//----------------------------------------------------------------------------------
function OnTriggerEnter (other : Collider) 
 {
    var characterActions: CharacterActions = other.GetComponent.<CharacterActions>(); 
	if (characterActions)
	  switch (animationToChange)
	   {
	      case AnimationToChange.Idle :
	      	characterActions.RandomizeIdle();
	      break;

	      case AnimationToChange.Move :
	     	 characterActions.RandomizeMove();
	      break;

	      case AnimationToChange.Jump :
	      	characterActions.RandomizeJump();
	      break;
	   }

 }
 //----------------------------------------------------------------------------------