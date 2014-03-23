using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Trolley : MonoBehaviour {

	private int _score;
	public List<Sprite> spritesTrolley;
		
	void IncreaseScore(int value)
	{
		_score += value;
		Debug.Log (_score);
	}
	
	// Use this for initialization
	void Update () {
		if(_score > 1 && _score > 300)
			this.GetComponent<SpriteRenderer>().sprite = spritesTrolley[1];

		if(_score > 301 && _score > 600)
			this.GetComponent<SpriteRenderer>().sprite = spritesTrolley[2];

		if(_score > 601 && _score > 1000)
			this.GetComponent<SpriteRenderer>().sprite = spritesTrolley[3];

		if(_score > 1001 && _score > 1400)
			this.GetComponent<SpriteRenderer>().sprite = spritesTrolley[4];

		if(_score > 1401)
			this.GetComponent<SpriteRenderer>().sprite = spritesTrolley[5];

	}

}
