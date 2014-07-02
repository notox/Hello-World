using UnityEngine;
using System.Collections;

//#define DISTANCE_INFINITE 10000f

public class CameraControl : MonoBehaviour {
	
	public float FixedZ = 0;
	public float VelocityRelate = 0.2f ;
	public float HeightRelate = 0.05f;
	public float PositionRelate = 0.05f;
	
	
	public Vector3 wanted_position;
	
	public float Height = 0f;
	
	// Use this for initialization
	void Start () {
		if ( FixedZ == 0 )
			FixedZ = Camera.main.transform.position.z ;
	}
	
	// Update is called once per frame
	void Update () {
		GetWantedPosition();
		SetPosition();
	}
	
	void GetWantedPosition(){
		if ( PlayerControl.player == null )
			return ;
		Ray ray = new Ray(PlayerControl.player.transform.position , Vector3.down );
		RaycastHit hit;
		float height = 10000f;
		if ( Physics.Raycast( ray , out hit ))
		{
			if ( hit.distance < height )
				height = hit.distance;
		}
		if ( height != 10000f )
			Height = height;
		
		wanted_position = PlayerControl.player.transform.position;
		
		wanted_position.z = FixedZ;
		
		wanted_position.z += FixedZ * ( PlayerControl.player.rigidbody.velocity.magnitude * VelocityRelate );
		
		wanted_position.z += FixedZ * Height * HeightRelate;
		
	}
	void SetPosition(){
		Camera.main.transform.position = Camera.main.transform.position * ( 1- PositionRelate ) + wanted_position * PositionRelate;
			
	}
}
