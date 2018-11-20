using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBehavior : MonoBehaviour {

	[SerializeField] private GameObject FpsPlayer;
	
	public void heal() {
		FpsPlayer.GetComponent<Target>().currentHp = FpsPlayer.GetComponent<Target>().maxHp;
     	}
}
