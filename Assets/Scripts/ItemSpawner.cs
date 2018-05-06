using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour {

	public List<GameObject> m_SpawnPoints;
	public List<GameObject> m_ItemPrefabs;

	private void Start() {
		StartCoroutine(SpawnItem());
	}

	private IEnumerator SpawnItem(){
		while(true){
			int spawnpointindex = Random.Range(0, m_SpawnPoints.Count);
			int itemprefabindex = Random.Range(0, m_ItemPrefabs.Count);

			Instantiate(m_ItemPrefabs[itemprefabindex], m_SpawnPoints[spawnpointindex].transform.position, m_ItemPrefabs[itemprefabindex].transform.rotation);
			yield return new WaitForSeconds(GameManager.m_ItemSpawnRate);
		}
	}
}
