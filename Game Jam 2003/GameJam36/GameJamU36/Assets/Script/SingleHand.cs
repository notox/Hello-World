using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class SingleHand : MonoBehaviour {
	
	public GameObject HandMesh;
	public GameObject ArmMesh;
	
	public enum StateType{ Null , Throw , Adhere , Recive };
	public StateType state = StateType.Null;
	
	static public float PullK = 0.5f;
	static public float NormalLength = 1f;
	
	static public float ForceToPlayer = 75f;
	
	public float LengthLimitation = 35f;
	
	
	// Use this for initialization
	void Start () {
		if ( HandMesh == null )
		{
			Debug.Log("Can not find hand.");
			enabled = false;
			return;
		}
		
		if ( ArmMesh == null )
		{
			Debug.Log("Can not find arm.");
			enabled = false;
			return;
		}
		if ( ArmMesh.GetComponent<LineRenderer>() == null )
		{
			Debug.Log("Arm need a line renderer");
			enabled = false;
			return;
		}
		if ( PlayerControl.player == null )
		{
			Debug.Log("Can not find player");
			return;
		}
		rigidbody.useGravity = false;
		transform.position = PlayerControl.player.transform.position;
		//transform.position = Vector3.back * 10f;
	}
	
	// Update is called once per frame
	void Update () {
		switch ( state ){
		case StateType.Null:
			break;
		case StateType.Throw:
			AddGravity();
			CheckLength();
			UpdateArm();
			
			break;
		case StateType.Adhere:
			ForcePlayer();
			UpdateArm();
			break;
		case StateType.Recive:
			ForceBackToPlayer();
			UpdateArm();
			break;
		default:
			break;
		}
		
		//Debug.Log("state" + state );
		
	}
	
	void AddGravity(){
		rigidbody.AddForce( Vector3.up * PlayerControl.GravityAcceleration , ForceMode.Acceleration );
	}
	
	void CheckLength(){
		if( ( transform.position - PlayerControl.player.transform.position ).magnitude > LengthLimitation )
		{
			state = StateType.Recive;
		}
	}
	
	void UpdateArm(){
		ArmMesh.GetComponent<LineRenderer>().SetPosition( 0 , PlayerControl.player.transform.position );
		ArmMesh.GetComponent<LineRenderer>().SetPosition( 1 , transform.position );
	}
	
	void ForceBackToPlayer(){
		Vector3 to_player = PlayerControl.player.transform.position - transform.position;
		rigidbody.AddForce(  to_player.normalized *  ForceToPlayer);
	}
	
	void ForcePlayer(){
		Vector3 player_to = transform.position - PlayerControl.player.transform.position;
		float force = ( player_to.magnitude - NormalLength) * PullK;
		PlayerControl.player.rigidbody.AddForce( force * player_to , ForceMode.Force );
	}
	
	
	
	public void Push( Vector3 dir ){
		transform.position = PlayerControl.player.transform.position;
		rigidbody.velocity = dir.normalized * PlayerControl.HandPushspeed;
		state = StateType.Throw;
		Debug.Log("Push");
	}
	
	public void Recieve( )
	{
		state = StateType.Recive;
		Debug.Log("Recieve");
	}
	
/*	void OnCollisionEnter(Collision coll){
		if ( state == StateType.Throw )
		{
			foreach ( ContactPoint c in coll.contacts )
			{
				if ( c.otherCollider.tag == "LEVEL" )
				{
					state = StateType.Adhere;
				}
			}
		}
		if ( state == StateType.Recive )
		{
			foreach ( ContactPoint c in coll.contacts )
			{
				if ( c.otherCollider.tag == "Player" )
				{
					GameObject.Destroy( HandMesh );
					GameObject.Destroy( ArmMesh );
					GameObject.Destroy( this.gameObject );
				}
			}
		}
	}*/
	
	void  OnTriggerEnter(Collider other) {
		if ( state == StateType.Throw )
		{
			if ( other.gameObject.tag == "Ceiling" )
			{
				rigidbody.velocity = Vector3.zero;
				state = StateType.Adhere;
			}
		}
		if ( state == StateType.Recive )
		{
			if ( other.gameObject.tag == "Player" )
			{
					GameObject.Destroy( HandMesh );
					GameObject.Destroy( ArmMesh );
					GameObject.Destroy( this.gameObject );
				
			}
		}
	}
	
	void OnGUI(){
		
		GUILayout.Label("state " + state );
	}
	
}
