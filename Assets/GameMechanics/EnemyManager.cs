using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour 
{
	public GameObject [] EnemyPrefabsList;

	private void Awake() 
	{
		
	}

	public void SpawnEnemy(Vector3 spawnPosition)
	{
		int enemyIndex = Random.Range(0,EnemyPrefabsList.Length);

		Instantiate(EnemyPrefabsList[enemyIndex],spawnPosition,Quaternion.identity);

	}
}
