using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager singleton;

	public AudioSource m_CherryEat;
	public AudioSource m_CherrySplat;
	public AudioSource m_GemCollect;
	public AudioSource m_GemSmash;
	public AudioSource m_JumpArcade;
	public AudioSource m_SpikeHitGround;
	public AudioSource m_SpikeHitPlayer;

	private void Awake() {
		if(singleton != null)
             GameObject.Destroy(singleton);
         else
             singleton = this;
	}

	private void Update() {
	}

	public void PlayAudio(string name){
		switch(name){
			case "CherryEat":
				m_CherryEat.Play();
				break;
			case "CherrySplat":
				m_CherrySplat.Play();
				break;
			case "GemCollect":
				m_GemCollect.Play();
				break;
			case "GemSmash":
				m_GemSmash.Play();
				break;
			case "JumpArcade":
				m_JumpArcade.Play();
				break;
			case "SpikeHitGround":
				m_SpikeHitGround.Play();
				break;
			case "SpikeHitPlayer":
				m_SpikeHitPlayer.Play();
				break;
			default:
				Debug.LogError("no sound found");
				break;
		}
	}

	public void StopAudio(string name){
		switch(name){
			case "CherryEat":
				m_CherryEat.Stop();
				break;
			case "CherrySplat":
				m_CherrySplat.Stop();
				break;
			case "GemCollect":
				m_GemCollect.Stop();
				break;
			case "GemSmash":
				m_GemSmash.Stop();
				break;
			case "JumpArcade":
				m_JumpArcade.Stop();
				break;
			case "SpikeHitGround":
				m_SpikeHitGround.Stop();
				break;
			case "SpikeHitPlayer":
				m_SpikeHitPlayer.Stop();
				break;
			default:
				Debug.LogError("no sound found");
				break;
		}
	}
}
