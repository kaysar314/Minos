using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {
	
	public Texture2D texture;

	public Gun gunScript;
	private GameObject gun;
	public Player player;

	void OnGUI()
	{
		if (player.hasItem == 1){
			Rect rect = new Rect(Screen.width/2 - (texture.width/2),Screen.height/2 - texture.height/2 ,texture.width, texture.height);
			GUI.DrawTexture(rect, texture);
		}
	}
}