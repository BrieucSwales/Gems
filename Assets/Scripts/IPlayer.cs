using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IPlayer {

	int Life {
		get;
		set;
	}

	float Speed {
		get;
		set;
	}

	/*
	List<T> Gems {

	}
	*/

	void Move();

	void Attack();

	void Die();

}
