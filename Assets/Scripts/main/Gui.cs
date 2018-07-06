using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gui : MonoBehaviour {

    private Text scoreText;
    public Text itemText;
    private float itemDurationTime;
    public List<AudioClip> audioClip = new List<AudioClip>();
    public ResultGui rg;
    AudioSource audioSource;
	int score = 0;
	int previousHp = 100;
	int hp = 100;
	int previousScore = 0;
	int previousLevel = 1;
	float speed = 0.05f;
	public bool isSlow = false;
	public bool isMoreStar = false;
	public bool isOkusuri = false;
    private bool wasOkusuri = false;
	float delayTime = 0.5f;
	float enemySpawnProbability = 0.1f;
	float itemSpawnProbability = 0.01f;
	int level = 1;

	// Use this for initialization
	void Start () {
		this.scoreText = this.GetComponent<Text> ();
		this.scoreText.text = "Score: 0\nLevel: 1\nHP: " + hp;
        this.audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (previousScore != score || previousHp != hp)
			UpdateText ();
		if (previousLevel != level) {
			speed = speed * 1.075f;
			delayTime *= 0.95f;
			enemySpawnProbability *= 1.2f;
			itemSpawnProbability *= 1.11f;
			hp = Mathf.Min (150, hp + 20);
			previousLevel = level;
        }
        if(isOkusuri) {
            if(!wasOkusuri) {
                wasOkusuri = true;
                itemText.gameObject.SetActive(true);
                itemDurationTime = 3;
            }
            itemText.text = itemDurationTime.ToString("F2");
        } else {
            if(wasOkusuri) {
                wasOkusuri = false;
                itemText.gameObject.SetActive(false);
            }
        }
        itemDurationTime -= Time.deltaTime;
	}

	public void AddPoint(int point) {
        this.score += isOkusuri ? point * 2 : point;
        int new_level = Mathf.Max((int)(Mathf.Sqrt(this.score / 10)), 1);
        if(new_level != level) {
            level = new_level;
            audioSource.PlayOneShot(audioClip[0]);
        }
	}

	public int GetPoint() {
		return this.score;
	}

	public void AddHP(int v) {
		this.hp += v;
	}

	public int getHP() {
		return hp;
	}

	public int getLevel() {
		return this.level;
	}

	public float getSpeed() {
		float tmp = speed;
		if (isSlow)
			tmp /= 4;
		if (isMoreStar)
			tmp *= 2;
		return tmp;
	}

	public float getDelayTime() {
		float tmp = delayTime;
		if (isSlow)
			tmp *= 2;
		if (isMoreStar)
			tmp /= 10;
		return tmp;
	}

	public float getEnemySpawnProbability() {
		return enemySpawnProbability;
	}

	public float getItemSpawnProbability() {
		return itemSpawnProbability;
	}

	void UpdateText() {
        this.scoreText.text = "Score: " + score + "\nLevel: " + level +
            "\nHP: " + hp + "\nEXP: " + score / 10 + "/" + (int)Mathf.Pow(level + 1, 2) + "\n" +
            "Lv. Upまであと" + ((int)Mathf.Pow(level + 1, 2) * 10 - score) + "pt";
		previousScore = score;
		previousHp = hp;
	}

	public void SlowStage() {
		StartCoroutine (SlowStage_ ());
	}
	IEnumerator SlowStage_() {
		isSlow = true;
		yield return new WaitForSeconds (2);
		isSlow = false;
	}
	public void MoreStar() {
		StartCoroutine (MoreStar_ ());
	}
	IEnumerator MoreStar_() {
		isMoreStar = true;
		yield return new WaitForSeconds (2);
		isMoreStar = false;
	}
	public void Okusuri() {
		StartCoroutine (Okusuri_ ());
	}
	IEnumerator Okusuri_() {
		isOkusuri = true;
		yield return new WaitForSeconds (3);
		isOkusuri = false;
	}
    public void OnPlayerDead() {
        StartCoroutine(OnPlayerDead_());
    }
    IEnumerator OnPlayerDead_() {
        Debug.Log("called OnPlayerDead()");
        yield return new WaitForSeconds(1);
        Debug.Log("YES!");
        rg.OnPlayerDead();
        audioSource.PlayOneShot(audioClip[1]);
    }
}