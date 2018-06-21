using UnityEngine;
using UnityEngine.EventSystems;

public class RefocusUi : MonoBehaviour
{

    public GameObject DefaultGameObject;

    void Awake()
    {
        if (DefaultGameObject != null)
        {
            EventSystem.current.SetSelectedGameObject(DefaultGameObject);
        }
    }

	// Update is called once per frame
	void Update () {
	    if (EventSystem.current.currentSelectedGameObject == null)
	    {
            EventSystem.current.SetSelectedGameObject(DefaultGameObject.gameObject);
	    } else if (EventSystem.current.currentSelectedGameObject != DefaultGameObject)
	    {
	        DefaultGameObject = EventSystem.current.currentSelectedGameObject;
	    }
	}
}
