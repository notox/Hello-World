using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {
	
	public float SpeedFactor = 1.0f;
	public float JumpFactor = 1.0f;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public float GetSpeedFactor(){
		return SpeedFactor;
	}
	public float GetJumpFactor(){
		return JumpFactor;
	}
}
