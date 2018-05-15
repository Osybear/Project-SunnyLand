using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	private float m_Speed;

	private void Start() {
		m_Speed = GameManager.m_GameManager.m_SpikeSpeed;
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
		m_Speed = 0;
		GetComponent<Collider2D>().enabled = false;
		GetComponent<Animator>().SetTrigger("Collided");

		if(other.tag == "Player"){
			other.GetComponent<Animator>().SetTrigger("Damaged");
			GameManager.m_GameManager.RemoveCherry();
		}
	}

	public void Deactivate(){
		Destroy(gameObject);
	}
}
