using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	private float m_ItemSpeed;

	private void Start() {
		m_ItemSpeed = GameManager.m_GameManager.m_ItemSpeed;
	}

	private void Update() {
		transform.Translate(new Vector3(0, m_ItemSpeed * Time.deltaTime, 0), Space.World);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		m_ItemSpeed = 0;
		GetComponent<Collider2D>().enabled = false;
		GetComponent<Animator>().SetTrigger("Collided");

		if(other.tag == "Player"){
			other.GetComponent<Animator>().SetTrigger("DamagedTrigger");
			GameManager.m_GameManager.RemoveCherry();
		}
	}

	public void Deactivate(){
		Destroy(gameObject);
	}
}
