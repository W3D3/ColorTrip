using UnityEngine;
using UnityEngine.EventSystems;

public class RefocusUi : MonoBehaviour
{

    private GameObject _lastSelectedGameObject;

    void Start()
    {
        _lastSelectedGameObject = EventSystem.current.firstSelectedGameObject ?? new GameObject();
    }

	// Update is called once per frame
	void Update () {
	    if (EventSystem.current.currentSelectedGameObject == null)
	    {
            EventSystem.current.SetSelectedGameObject(_lastSelectedGameObject);
	    } else if (_lastSelectedGameObject != null && _lastSelectedGameObject != EventSystem.current.currentSelectedGameObject)
	    {
	        _lastSelectedGameObject = EventSystem.current.currentSelectedGameObject;
	    }
	}
}
