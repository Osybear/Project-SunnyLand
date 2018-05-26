using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

	private float m_Speed;

	private void Start() {
		m_Speed = GameManager.singleton.m_SpikeSpeed;
	}

	private void Update() {
		transform.Translate(new Vector3(0, m_Speed * Time.deltaTime, 0), Space.World);
		if(GameManager.singleton.m_Killed){
			GetComponent<Collider2D>().enabled = false;
			GetComponent<Animator>().SetTrigger("Collided");
			m_Speed = 0;
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Player"){
			other.GetComponent<Animator>().SetTrigger("Damaged");
			GameManager.singleton.RemoveCherry();
			SoundManager.singleton.PlayAudio("SpikeHitPlayer");
			GetComponent<Collider2D>().enabled = false;
			GetComponent<Animator>().SetTrigger("Collided");
			m_Speed = 0;
		}

		if(other.name == "Collidable"){
			SoundManager.singleton.PlayAudio("SpikeHitGround");
			GetComponent<Collider2D>().enabled = false;
			GetComponent<Animator>().SetTrigger("Collided");
			m_Speed = 0;
		}
	}

	public void Deactivate(){
		Destroy(gameObject);
	}
}
