using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGUI : MonoBehaviour {
    public GameObject scoreCanvas;
    public Text rankingTextLeft;
    public Text rankingTextRight;

    // Assume that the range of the ranking is from 1st to 10th
    public void LoadRanking() {
        StartCoroutine(Score.GetScores(scores => {
            rankingTextLeft.text = rankingTextRight.text = "Loading...";
            if(scores == null) {
                rankingTextLeft.text = "ランキングを読み込めませんでした。";
                rankingTextRight.text = "";
            }
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            for (int i = 0; i < scores.Count; i++) {
                Debug.Log("score: " + scores[i].score + ", name: " + scores[i].name + ", createdAt: " + scores[i].createdAt);
                if(i < scores.Count/2) {
                    sb.Append(i+1);
                    sb.Append("位:\t\t");
                    sb.Append(scores[i].name);
                    sb.Append("\t");
                    sb.Append(scores[i].score);
                    sb.Append("点");
                    sb.Append("\n");
                } else if(i < 9) {
                    sb2.Append(i+1);
                    sb2.Append("位:\t\t");
                    sb2.Append(scores[i].name);
                    sb2.Append("\t");
                    sb2.Append(scores[i].score);
                    sb2.Append("点");
                    sb2.Append("\n");
                } else {
                    sb2.Append(i + 1);
                    sb2.Append("位:\t");
                    sb2.Append(scores[i].name);
                    sb2.Append("\t");
                    sb2.Append(scores[i].score);
                    sb2.Append("点");
                    sb2.Append("\n");
                }
            }
            rankingTextLeft.text = sb.ToString();
            rankingTextRight.text = sb2.ToString();
        }));
    }

    public void OnClickScore() {
        if(scoreCanvas.activeSelf) {
            scoreCanvas.SetActive(false);
        } else {
            scoreCanvas.SetActive(true);
            LoadRanking();
        }
    }
}
