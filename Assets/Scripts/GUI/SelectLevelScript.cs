using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectLevelScript : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public string Hint;
    public Text HintText;
    public Vector3 OriginalScale;
    public Vector3 TargetScale;
    public Vector3 CurrentScale;
    public bool Selected;

    void Start()
    {
        OriginalScale = transform.localScale;
        TargetScale = transform.localScale;
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
        CurrentScale = transform.localScale;
        var newX = Mathf.SmoothStep(CurrentScale.x, TargetScale.x, Time.fixedUnscaledDeltaTime * 20f);
        CurrentScale.x = newX;
        CurrentScale.y = newX;
        transform.localScale = CurrentScale;
    }

    public void OnSelect(BaseEventData eventData)
    {
        TargetScale = OriginalScale + new Vector3(.2f, .2f);
        if (HintText != null)
        {
            HintText.text = Hint;
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        TargetScale = OriginalScale;
    }

    public IEnumerator SelectButton()
    {
        yield return null;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(GetComponent<Button>().gameObject);
    }
}
