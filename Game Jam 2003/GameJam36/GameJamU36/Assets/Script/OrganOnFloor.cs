using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]

public class OrganOnFloor : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		collider.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTrigger(){
		
		
			
	}
}
