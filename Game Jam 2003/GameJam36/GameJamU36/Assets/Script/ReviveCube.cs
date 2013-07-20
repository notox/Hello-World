using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]


public class ReviveCube : MonoBehaviour {

	void Awake(){
		collider.isTrigger = true;	
	}
	
	void OnTriggerStay( Collider other) {
		if ( other.gameObject.tag == "Player" ) 
			PlayerControl.RevivePoint = transform.position;	
	}
}
