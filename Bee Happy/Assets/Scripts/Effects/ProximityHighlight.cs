using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityHighlight : MonoBehaviour {

    public GameObject highlighter;

	public void TriggeredHighlight(GameObject toHighlight)
    {
        highlighter.GetComponent<Transform>().SetParent(toHighlight.GetComponent<Transform>());
        highlighter.SetActive(true);
    }


}
