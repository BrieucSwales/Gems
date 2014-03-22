using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagersGems : MonoBehaviour {

	public List<GameObject> gems; 
	private int newGemsInArray = 0;

	void Awake()
	{
		gems = new List<GameObject>();
	}

	public void createGems(GameObject gems, Vector3 pos, Quaternion angle)
	{
		GameObject gemObject = Instantiate(gems, pos, angle) as GameObject;

		Gems gem = gemObject.GetComponent<Gems>();
		gem.onDestroy += OnGemDestroyed;

		this.gems.Add( gemObject );
	}

	void OnGemDestroyed( GameObject gem )
	{
		this.gems.Remove( gem );
	}
}
