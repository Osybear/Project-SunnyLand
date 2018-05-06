using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {

	private float m_ItemSpeed;

	private void Start() {
		m_ItemSpeed = GameManager.m_ItemSpeed;
	}

	private void Update() {
		transform.Translate(new Vector3(0, m_ItemSpeed * Time.deltaTime, 0), Space.World);
	}
	
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
			GetComponent<Collider2D>().enabled = false;
			GetComponent<Animator>().SetTrigger("Collect");
			GameManager.m_PlayerGems++;	
			m_ItemSpeed = 0;
		}

		if(other.name == "Collidable"){
			GetComponent<Collider2D>().enabled = false;
			GetComponent<Animator>().SetTrigger("Collided");
			m_ItemSpeed = 0;
		}
	}
	
	public void Deactivate(){
		Destroy(gameObject);
	}
}
