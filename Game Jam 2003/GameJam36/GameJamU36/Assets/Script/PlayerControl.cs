using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]

public class PlayerControl : MonoBehaviour {
	
	static string ColliderTag = "LEVEL";
	
	public enum MoveDirection{ Left , Right };
	static public MoveDirection move_dir = MoveDirection.Right;
	
	private Vector3 LocateNormal = Vector3.up ;
	
	static private bool IfInAir = true;
	
	static public GameObject player = null;
	
	static public float GravityAcceleration = -5f;
	
	//right velocity
	public float HorizontalMaxSpeed = 5f;
	public float JumpVelocityUp = 10f; 
	
	
	//hands
	public GameObject HandPrefab;
	static public float HandPushspeed = 15f;
	public bool IfThrownHand = false;
	public KeyCode ThrowHandKey = KeyCode.H;
	//public List<GameObject> hands;
	public GameObject DealHand ;
	
	//locate plantform
	public Platform LocatePlatForm;
	
	//Impulse from wall
	public float ImpulseFromWallFactor = 0.1f;
	
	int IfInAirCount = 0;
	
	//Revive Point
	static public Vector3 RevivePoint = Vector3.zero;
	
	// Use this for initialization
	void Start () {
		if ( player == null )
			player = GameObject.FindGameObjectWithTag("Player");
		if ( player == null )
			Debug.Log("Can not find a player." );
		
		if ( player.rigidbody )
		{
			player.rigidbody.useGravity = false;
			player.rigidbody.isKinematic = false;
		}
		if ( HandPrefab == null )
		{
			Debug.Log("Can not find hand");
			enabled = false;
		}else{
			if ( HandPrefab.GetComponent<SingleHand>() == null )
			{
				Debug.Log("Can not find SingleHand in hand" );
				enabled = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ( ShouldGoRight() )
			GoRight();
		if ( ShouldGoLeft() )
			GoLeft();
		if ( ShouldJump() )
			Jump();
		if ( ShouldPushHand() )
			PushHand();
		SetVelocity();
		Smooth();
		
	}
	
	bool ShouldGoRight(){
		if ( Input.GetKey( KeyCode.RightArrow ) )
			return true;
		
		return false;
	}
	
	bool ShouldGoLeft(){
		if ( Input.GetKey( KeyCode.LeftArrow ) )
			return true;
		
		return false;
		
	}
	
	bool ShouldJump(){
			
		if ( !Input.GetKey( KeyCode.Space ) )
			return false;
		if ( IfInAir )
			return false;
			
		return true;
	}
	
	bool ShouldPushHand(){
		if ( !Input.GetKeyDown( KeyCode.H ) )
			return false;
		
		return true;
	}
	
	void GoRight(){
		move_dir = MoveDirection.Right;
	}
	
	void GoLeft(){
		move_dir = MoveDirection.Left;
	}
	
	void Jump(){
		float jump_fator = 1.0f;
		if ( LocatePlatForm != null )
			jump_fator = LocatePlatForm.GetJumpFactor();
		Vector3 velocity = player.rigidbody.velocity;
		velocity.y = JumpVelocityUp;
		player.rigidbody.velocity = velocity;
		IfInAir = true;
	}
	
	
	void PushHand(){
		if ( DealHand == null )
			DealHand = Instantiate( HandPrefab ) as GameObject;
		if ( DealHand.GetComponent<SingleHand>().state == SingleHand.StateType.Null )
		{
			Vector3 dir = new Vector3( 0.5f , 1f , 0f );
			DealHand.GetComponent<SingleHand>().Push( dir  );
		}else if ( DealHand.GetComponent<SingleHand>().state == SingleHand.StateType.Adhere )
		{
			DealHand.GetComponent<SingleHand>().Recieve();
			DealHand = null;
		}
		
	}
	
	void OnCollisionEnter(Collision coll){
		foreach ( ContactPoint c in coll.contacts )
		{
			if ( c.otherCollider.tag == ColliderTag )
			{
				if ( Vector3.Dot ( c.normal , Vector3.up ) > 0.1f )
				{
					LocateNormal = c.normal;
					LocateNormal.z = 0;
					LocateNormal.Normalize();
					IfInAir = false;
					LocatePlatForm =  c.otherCollider.GetComponent<Platform>() ;
				}
			}
		}
	}
	
	void OnCollisionStay( Collision coll ){
		foreach ( ContactPoint c in coll.contacts )
		{
			if ( c.otherCollider.tag == ColliderTag )
			{
				player.transform.position += c.normal * 0.002f;
			}
		}
			
	}
	
	void OnCollisionExit( Collision coll ){
		foreach ( ContactPoint c in coll.contacts )
		{
			if ( c.otherCollider.tag == ColliderTag )
			{
				IfInAir = true;
			}
		}
	}
	
	void SetVelocity(){
		/*
			Vector3 force = Vector3.zero;
		
			if ( move_dir == MoveDirection.Left )
				force = Vector3.left * 1f;
			if ( move_dir == MoveDirection.Right )
				force = Vector3.right * 1f;
			player.rigidbody.AddForce( force );
		*/
		//set direction move
		//if ( !IfInAir ){
		Vector3 vel_move = Vector3.zero;
		Vector3 vel_diff = Vector3.zero;
		Vector3 vel_grav = Vector3.zero;
		// if player touch a colider in upper
			
		float velocity_factor = 1.0f;
			float platform_speed = 0f;
			if ( LocatePlatForm != null )
			{
				velocity_factor = LocatePlatForm.GetSpeedFactor();
				platform_speed = LocatePlatForm.GetSpeed();
			}
			
		
		//for set the velocity directly
		LocateNormal = Vector3.up;
		if ( move_dir == MoveDirection.Left )
			vel_move= Vector3.Cross( LocateNormal , Vector3.back ) * (HorizontalMaxSpeed-platform_speed) * velocity_factor;
		else
			vel_move= Vector3.Cross( LocateNormal , Vector3.forward ) * (HorizontalMaxSpeed+platform_speed) * velocity_factor;
		//vel_diff = LocateNormal * 0.01f;
		
		if ( CheckIfInAir() ){
			vel_grav = player.rigidbody.velocity;
			vel_grav.x = vel_grav.z = 0f;
			vel_grav.y += GravityAcceleration * Time.deltaTime;
		}
		
		player.rigidbody.velocity = vel_move + vel_diff + vel_grav;
		
		//for force
		//if ( move_dir == MoveDirection.Right )
		//	player.rigidbody.AddForce( Vector3.right * 3f );
		//if ( move_dir == MoveDirection.Left )
		//	player.rigidbody.AddForce( Vector3.left * 3f );
		
		//player.rigidbody.AddForce( Vector3.up * GravityAcceleration , ForceMode.Acceleration );
		
		
		//limit the velocity
		Vector3 velocity = player.rigidbody.velocity;
		velocity.x = Mathf.Clamp( velocity.x , - HorizontalMaxSpeed * velocity_factor , HorizontalMaxSpeed * velocity_factor );
		velocity.z = 0;
		player.rigidbody.velocity = velocity;
		
	}
	
	bool CheckIfInAir(){
		if ( IfInAir == false )
			return false;
		if ( IfInAirCount < 3 )
			return false;
		return true;
	}
	
	void Smooth(){
		
		if ( IfInAir )
		{
			IfInAirCount ++;
		}else
			IfInAirCount = 0;
		
	}
	
	void OnGUI(){
		GUILayout.Label( "IfInAir" + CheckIfInAir() );	
		
	}
	
	static public void OnDead(){
		player.transform.position = RevivePoint;
		IfInAir = true;
	}
}
