using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

	public List<GameObject> m_SpawnPoints;
	public GameObject m_CherryPrefab;
	public GameObject m_GemPrefab;
	public GameObject m_SpikePrefab;

	public IEnumerator SpawnSpike(){
		while(true){
			int spawnpointindex = Random.Range(0, m_SpawnPoints.Count);

			Instantiate(m_SpikePrefab, m_SpawnPoints[spawnpointindex].transform.position, m_SpikePrefab.transform.rotation);
			yield return new WaitForSeconds(GameManager.m_GameManager.m_SpikeSpawnRate);
		}
	}

	public IEnumerator SpawnItem(){
		while(true){
			yield return new WaitForSeconds(GameManager.m_GameManager.m_ItemSpawnRate);
			int spawnpointindex1 = Random.Range(0, m_SpawnPoints.Count);
			int spawnpointindex2 = Random.Range(0, m_SpawnPoints.Count);

			if(GameManager.m_GameManager.m_PlayerCherries < 3)
				Instantiate(m_CherryPrefab, m_SpawnPoints[spawnpointindex1].transform.position, Quaternion.identity);

			Instantiate(m_GemPrefab, m_SpawnPoints[spawnpointindex2].transform.position, Quaternion.identity);
		}
	}
}
