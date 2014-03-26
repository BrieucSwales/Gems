using UnityEngine;
using System.Collections;

public class exit : MonoBehaviour {

	public GameObject entry;
	public GameObject player1;
	public GameObject player2;
	private bool _teleportPlayers;
	private bool _triggerPlayers;

	void OnTriggerEnter2D(Collider2D other)
	{	
		if(other.tag == "Player" && this.tag == "Exit"){
			_triggerPlayers = true;
		}

		if(other.tag == "Player" && this.tag == "Entrance"){
			Debug.Log ("toto");
			_teleportPlayers = true;
		}
	}

	void Update()
	{
		if(Input.GetButton("Fire1") ||  Input.GetButton("Fire1Player2"))
		{
			if(_triggerPlayers){
				player1.transform.position = entry.transform.position;
				player2.transform.position = entry.transform.position;
				_triggerPlayers = false;
			}
		}	

		if(Input.GetButton("Fire2") ||  Input.GetButton("Fire2Player2"))
		{
			if(_teleportPlayers){
				player1.transform.position = entry.transform.position;
				player2.transform.position = entry.transform.position;
				_teleportPlayers = false;
			}
			
		}	
	}
}
