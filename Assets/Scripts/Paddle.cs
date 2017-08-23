using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
    public float minX, maxX;

	float mousePosInBlocks;
	private ball lopta;
	
	void Start ()
	{
		lopta = GameObject.FindObjectOfType<ball>();
	}
	
	void Update () {
		if(!autoPlay) {	
			MoveWithMouse();
		}else {
			AutoPlay();
		}
	}
	
	void MoveWithMouse () {
	
		Vector3 paddlePos = new Vector3(0.5f,this.transform.position.y, 0f);
	
		mousePosInBlocks = Input.mousePosition.x/Screen.width*16;
		
		paddlePos.x = Mathf.Clamp(mousePosInBlocks,minX,maxX);
		
		this.transform.position = paddlePos;
	}
	
	void AutoPlay() {
		Vector3 paddlePos = new Vector3(0.5f,this.transform.position.y, 0f);
		Vector3 ballPos = lopta.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		this.transform.position = paddlePos;
	}
}
