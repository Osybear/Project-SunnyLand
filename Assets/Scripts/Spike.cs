using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

	private float m_Speed;

	private void Update() {
		transform.Translate(new Vector3(0, m_Speed * Time.deltaTime, 0), Space.World);
		if(GameManager.singleton.m_Killed){
			GetComponent<Collider2D>().enabled = false;
			GetComponent<Animator>().SetTrigger("Destroy");
			m_Speed = 0;
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		m_Speed = 0;
		GetComponent<Collider2D>().enabled = false;
		GetComponent<Animator>().SetTrigger("Destroy");

		if(other.tag == "Player"){
			other.GetComponent<Animator>().SetTrigger("Damage");
			GameManager.singleton.RemoveCherry();
		}
	}

	public void Destroy(){
		Destroy(gameObject);
	}

	public void SetSpeed(float Speed){
		m_Speed = Speed;
	}
}
