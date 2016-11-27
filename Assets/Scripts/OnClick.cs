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
        GameObject.Find("Correct").transform.GetChild(0).GetComponent<Text>().text = (Factory.Instance.powers[0] as Factory.WorldPower).a1;
    }
}
