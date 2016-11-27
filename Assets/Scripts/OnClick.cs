using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnClick : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void clicked()
    {
        Factory.WorldPower wp = Factory.Instance.generateAndRemove();
        if (!wp.met) {
            GameObject.Find("Correct").transform.GetChild(0).GetComponent<Text>().text = wp.a1;
        }
        else
        {
            GameObject.Find("Correct").transform.GetChild(0).GetComponent<Text>().text = wp.a2;
        }
    }
}
