using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]

public class DeadCube : MonoBehaviour {
	
	void Awake(){
		collider.isTrigger = true;	
	}
	
	void OnTriggerStay( Collider other) {
		if ( other.gameObject.tag == "Player" ) 
			if ( PlayerControl.player != null )
				PlayerControl.OnDead();
	}
	
}
