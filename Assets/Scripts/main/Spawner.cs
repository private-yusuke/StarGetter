using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	/*
	public GameObject starPrefab;
	public float delayTime = 0f;
	public float intervalTime = 2f;


	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnStar", delayTime, intervalTime);
	}
	
	// Update is called once per frame
	void SpawnStar() {
		Transform t = transform;
		Instantiate (starPrefab, transform.position, transform.rotation);
	}

	void Update () {
		
	}
	*/

	/*
	0: Star
	1: Enemy
	*/
	public List<GameObject> starPrefabs = new List<GameObject> ();
	public List<GameObject> enemyPrefabs = new List<GameObject> ();
	public List<GameObject> itemPrefabs = new List<GameObject> ();
	public float durationTime = 1f;
	public float prevLevel = 1;

	Gui gui;

	void Start() {
		gui = FindObjectOfType<Gui>();
		StartCoroutine (SpawnStar ());
		StartCoroutine (SpawnEnemy ());
		StartCoroutine (SpawnItem ());
	}

	IEnumerator SpawnStar() {
		while (true) {
			Spawn (starPrefabs);
			yield return new WaitForSeconds (gui.getDelayTime() + Random.Range (0, durationTime));
		}
	}

	IEnumerator SpawnEnemy() {
		while (true) {
			float tmp = gui.getEnemySpawnProbability ();
			if (gui.isMoreStar)
				tmp /= 10;
			if (tmp > Random.value) {
				Spawn (enemyPrefabs);
			}
			yield return new WaitForSeconds (gui.getDelayTime() + Random.Range (0, durationTime));
		}
	}

	IEnumerator SpawnItem() {
		while (true) {
			if (gui.getItemSpawnProbability () > Random.value) {
				Spawn (itemPrefabs);
			}
			yield return new WaitForSeconds (gui.getDelayTime() + Random.Range (0, durationTime));
		}
	}

	void Spawn(List<GameObject> list) {
		int rand = (int)(Random.value * list.Count);
		GameObject obj = Instantiate (list [rand], transform.position, transform.rotation);

		obj.transform.position = new Vector3 (
			transform.position.x + Random.Range (0, 9),
			transform.position.y,
			transform.position.z);
		obj.GetComponent<FallenSprite> ().speed = gui.getSpeed ();
	}
}
