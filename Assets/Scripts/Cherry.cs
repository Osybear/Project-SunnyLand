using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour {

	private float m_Speed;

	private void Start() {
		m_Speed = GameManager.singleton.m_ItemSpeed;
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
			GetComponent<Collider2D>().enabled = false;
			GetComponent<Animator>().SetTrigger("Collect");
			GameManager.singleton.AddCherry();
			m_Speed = 0;
			SoundManager.singleton.PlayAudio("CherryEat");
		}

		if(other.name == "Collidable"){
			GetComponent<Collider2D>().enabled = false;
			GetComponent<Animator>().SetTrigger("Collided");
			m_Speed = 0;
			SoundManager.singleton.PlayAudio("CherrySplat");
		}
	}

	public void Deactivate(){
		Destroy(gameObject);
	}
}
