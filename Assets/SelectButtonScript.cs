using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectButtonScript : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public string Hint;
    public Text HintText;
    public Vector3 OriginalPosition;
    public Vector3 TargetPosition;
    public Vector3 CurrentPosition;

    void Start()
    {
        OriginalPosition = transform.position;
        TargetPosition = transform.position;
        HintText.text = string.Empty;
    }

    void Update()
    {
        CurrentPosition = transform.position;
        var newX = Mathf.SmoothStep(CurrentPosition.x, TargetPosition.x, Time.deltaTime * 20f);
        CurrentPosition.x = newX;
        transform.position = CurrentPosition;
    }

    public void OnSelect(BaseEventData eventData)
    {
        TargetPosition = OriginalPosition + new Vector3(70, 0);
        HintText.text = Hint;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        TargetPosition = OriginalPosition;
    }
}
