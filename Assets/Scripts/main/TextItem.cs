using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextItem : MonoBehaviour {

    [SerializeField]
    private RectTransform canvasRectTfm;
    [SerializeField]
    private Transform targetTfm;

    private RectTransform myRectTfm;
    private Vector3 offset = new Vector3(-1f, 0f, 0);

	void Start () {
        myRectTfm = GetComponent<RectTransform>();
	}
	void Update () {
        Vector2 pos;
        Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, targetTfm.position + offset);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTfm, screenPos, Camera.main, out pos);
        pos.Scale(new Vector2(0.05f, 0.05f));
        myRectTfm.position = pos;
	}
}
