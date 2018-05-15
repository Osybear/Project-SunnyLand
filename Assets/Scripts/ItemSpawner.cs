using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

	public List<GameObject> m_SpawnPoints;
	public GameObject m_CherryPrefab;
	public GameObject m_GemPrefab;
	public GameObject m_SpikePrefab;
	public float m_SpikeSpeed = -3;

	private void Start() {
		StartCoroutine(OpenSpotSpawn());	
	}

	public IEnumerator OpenSpotSpawn(){
		while(true){
			int openspot = Random.Range(0, m_SpawnPoints.Count);
			for(int i = 0; i < m_SpawnPoints.Count; i++){
				if(i != openspot){	
					GameObject spike = Instantiate(m_SpikePrefab, m_SpawnPoints[i].transform.position, m_SpikePrefab.transform.rotation);
					spike.GetComponent<Spike>().SetSpeed(m_SpikeSpeed);
				}
			}
			yield return new WaitForSeconds(1);
		}
		Debug.Log("Enter");
	}

	public IEnumerator PairSpawn(){
		while(true){
			int startspot = Random.Range(0, m_SpawnPoints.Count);
			GameObject spike1 = Instantiate(m_SpikePrefab, m_SpawnPoints[startspot].transform.position, m_SpikePrefab.transform.rotation);
			spike1.GetComponent<Spike>().SetSpeed(m_SpikeSpeed);
			
			int adjacentspot = Random.Range(0,2);

			if(adjacentspot == 0){
				adjacentspot = startspot - 1;
			}else if(adjacentspot == 1){
				adjacentspot = startspot + 1;
			}

			if(adjacentspot == m_SpawnPoints.Count){
				adjacentspot = startspot - 1;
			}
			else if(adjacentspot == -1){
				adjacentspot = startspot + 1;
			}

			GameObject spike2 = Instantiate(m_SpikePrefab, m_SpawnPoints[adjacentspot].transform.position, m_SpikePrefab.transform.rotation);
			spike2.GetComponent<Spike>().SetSpeed(m_SpikeSpeed);
			yield return new WaitForSeconds(1);
		}
	}

	public IEnumerator RandomSpawn(){
		while(true){
			int index = Random.Range(0, m_SpawnPoints.Count);

			GameObject spike = Instantiate(m_SpikePrefab, m_SpawnPoints[index].transform.position, m_SpikePrefab.transform.rotation);
			spike.GetComponent<Spike>().SetSpeed(m_SpikeSpeed);
			yield return new WaitForSeconds(1);
		}
	}
}
