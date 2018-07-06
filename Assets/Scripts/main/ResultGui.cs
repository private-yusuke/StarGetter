using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;

public class ResultGui : MonoBehaviour {

    public Gui gui;
    public Text scoreText;
    public Text rankText;
    public Text rankingText;
    public InputField nameInputField;
    public Button backButton;
	
    public void OnPlayerDead() {
        gameObject.SetActive(true);
        scoreText.text = "スコア: " + gui.GetPoint().ToString() + "点";

        StartCoroutine(Score.GetScores((scores) =>
        {
            ulong rank = 1;
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var s in scores)
            {
                if (s.score >= gui.GetPoint())
                {
                    rank++;
                }
                else
                {
                    break;
                }
            }
            if (rank > 10)
            {
                rankText.text = "圏外";
            }
            else
            {
                rankText.text = rank.ToString() + "位";
            }

            for (int i = 0; i < scores.Count; i++) {
                stringBuilder.Append(i+1);
                stringBuilder.Append("位:  ");
                stringBuilder.Append(scores[i].name);
                stringBuilder.Append("  ");
                stringBuilder.Append(scores[i].score);
                stringBuilder.Append("点");
                stringBuilder.Append("\n");
            }
            rankingText.text = stringBuilder.ToString();
        }));
    }

    public void OnClickBackButton() {
        StartCoroutine(_OnClickBackButton());
    }

    private bool alreadyClicked = false;
    public IEnumerator _OnClickBackButton()
    {
        if (!alreadyClicked)
        {
            alreadyClicked = true;
            if (nameInputField.text.Length > 10)
            {
                nameInputField.text = "";
                nameInputField.GetComponentInChildren<Text>().text = "名前は10文字以下で！";
            }
            else
            {
                backButton.interactable = false;
                Score score = new Score(gui.GetPoint(), nameInputField.text);

                yield return StartCoroutine(Score.Post(score));
                SceneManager.LoadScene("Title");
            }
        }
    }
}
