using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {
	public int quit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("joystick button 3"))Application.LoadLevel("Level 1");
		if(Input.GetKeyDown("joystick button 1"))Application.Quit();
	
	}
	void OnMouseEnter(){
		renderer.material.color=Color.red;
		animation.Play("ResizeUp");
	}
	void OnMouseExit(){
		renderer.material.color=Color.white;
		animation.Play("ResizeDown");
	}
	void OnMouseUp(){
		if(quit==1)Application.Quit();
		else Application.LoadLevel("Level 1");
	}
	
}
