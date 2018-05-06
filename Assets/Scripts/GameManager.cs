using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static float m_ItemSpeed;
	public static float m_ItemSpawnRate;
	public static int m_PlayerCherries; // health
	public static int m_PlayerGems;
	
	private void Awake() {
		m_PlayerCherries = 3;
		m_PlayerGems = 0;
		m_ItemSpeed = -4;
		m_ItemSpawnRate = 3;
	}

	private void Start() {
		InvokeRepeating("IncreaseItemSpeed", 0, 1);
		//InvokeRepeating("DecreaseItemSpawnRate", 0, 1);
	}

	private void IncreaseItemSpeed(){
		m_ItemSpeed -= .05f;
	}

	private void DecreaseItemSpawnRate(){
		m_ItemSpawnRate -= .05f;
	}
}
