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
    public bool Selected;

    void Start()
    {
        OriginalPosition = transform.position;
        TargetPosition = transform.position;
        OnEnable();
    }

    void OnEnable()
    {
        OnDeselect(null);
        if (Selected)
        {
            OnSelect(null);
            StartCoroutine(SelectButton());
        }
    }

    void Update()
    {
        CurrentPosition = transform.position;
        var newX = Mathf.SmoothStep(CurrentPosition.x, TargetPosition.x, Time.fixedUnscaledDeltaTime * 20f);
        CurrentPosition.x = newX;
        transform.position = CurrentPosition;
    }

    public void OnSelect(BaseEventData eventData)
    {
        TargetPosition = OriginalPosition + new Vector3(70, 0);
        if (HintText != null)
        {
            HintText.text = Hint;
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        TargetPosition = OriginalPosition;
    }

    public IEnumerator SelectButton()
    {
        yield return null;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GetComponent<Button>().gameObject);
    }
}
