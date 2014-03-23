using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManagersGems : MonoBehaviour {
	
	public List<GameObject> gems; 
	private Vector2 _randomGemPosition;
	private int _rangePosition = 1;
	
	void Awake()
	{
		gems = new List<GameObject>();
	}
	
	public void createGems(GameObject gems, Vector3 pos, Quaternion angle)
	{	
		_randomGemPosition = new Vector2(Random.Range(pos.x - _rangePosition, pos.x + _rangePosition), Random.Range(pos.y - _rangePosition, pos.y + _rangePosition));
		GameObject gemObject = Instantiate(gems, _randomGemPosition, angle) as GameObject;
		
		Gems gem = gemObject.GetComponent<Gems>();
		gem.onDestroy += OnGemDestroyed;

		this.gems.Add( gemObject );
	}
	
	void OnGemDestroyed( GameObject gem )
	{
		this.gems.Remove( gem );
	}
	
}
