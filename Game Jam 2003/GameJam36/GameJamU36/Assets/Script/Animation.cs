using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Animation : MonoBehaviour {
	
	public GameObject PictureMesh;
	
	public enum ColorType{ Normal , BlackWhite , Colorful };
	static public ColorType color_type = ColorType.Normal;
	public int color_type_size = 3;
	
	int frame = 0;
	float changeFrameTime = 0.0f;
	public float animationDelay = 0.5f;
	public List<Texture> ColorFrames = new List<Texture>();
	public List<Texture> WBFrames = new List<Texture>();
	
	public bool IfFixedRotation = true;
	private Quaternion InitRotation;
	
	// Use this for initialization
	void Start () {
		if ( PictureMesh == null )
		{
			enabled = false;
			return ;
		}
		PictureMesh.transform.parent = transform;
		if ( PictureMesh.GetComponent<Collider>() )
			PictureMesh.GetComponent<Collider>().enabled = false;
		InitRotation = PictureMesh.transform.rotation;
		
	}
	
	// Update is called once per frame
	void Update() {
		if (Time.time > changeFrameTime && ColorFrames.Count > 0 ) {
			
			changeFrameTime = Time.time + animationDelay;
			frame = (frame + 1) % ColorFrames.Count;
			switch( color_type )
			{
			case ColorType.Colorful:
				PictureMesh.renderer.material.mainTexture = ColorFrames[frame];
				break;
			case ColorType.BlackWhite:
				PictureMesh.renderer.material.mainTexture = WBFrames[frame];
				break;
			case ColorType.Normal:
				PictureMesh.renderer.material.mainTexture = ColorFrames[frame];
				break;
			};
		}
		if ( IfFixedRotation )
			PictureMesh.transform.rotation = InitRotation;
	}
	
	static public void SetColorStyle( ColorType type ){
		color_type = type;
	}
	
}
