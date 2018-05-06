using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager m_GameManager;
	public float m_ItemSpeed = -4;
	public float m_ItemSpawnRate = 3;
	public int m_PlayerCherries = 3; // health
	public int m_PlayerGems = 0;
	public Text m_GemCount;
	public List<SpriteRenderer> m_CherryIndicators;

	private void Awake() {
		if(m_GameManager != null)
             GameObject.Destroy(m_GameManager);
         else
             m_GameManager = this;
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
	
	public void AddCherry(){
		m_PlayerCherries++;
	}

	public void RemoveCherry(){
		m_PlayerCherries--;
		m_CherryIndicators[m_PlayerCherries].color = new Color(0.5f, 0.5f, 0.5f);
	}

	public void AddGem(){
		m_PlayerGems++;
		if(m_PlayerGems < 10)
			m_GemCount.text = "00" + m_PlayerGems;
		else if(m_PlayerGems >= 10 && m_PlayerGems < 100)
			m_GemCount.text = "0" + m_PlayerGems;
		else if(m_PlayerGems >= 100)
			m_GemCount.text = "" + m_PlayerGems;
	}
}
