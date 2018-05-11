using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {

	private float m_Speed;

	private void Start() {
		m_Speed = GameManager.m_GameManager.m_ItemSpeed;
	}

	private void Update() {
		transform.Translate(new Vector3(0, m_Speed * Time.deltaTime, 0), Space.World);
		if(GameManager.m_GameManager.m_Killed){
			GetComponent<Collider2D>().enabled = false;
			GetComponent<Animator>().SetTrigger("Collided");
			m_Speed = 0;
		}
	}
	
	private void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
			GetComponent<Collider2D>().enabled = false;
			GetComponent<Animator>().SetTrigger("Collect");
			GameManager.m_GameManager.AddGem();
			m_Speed = 0;
		}

		if(other.name == "Collidable"){
			GetComponent<Collider2D>().enabled = false;
			GetComponent<Animator>().SetTrigger("Collided");
			m_Speed = 0;
		}
	}
	
	public void Deactivate(){
		Destroy(gameObject);
	}
}
