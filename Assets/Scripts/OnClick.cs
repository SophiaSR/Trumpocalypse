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
        bool randomPos = Random.Range(0, 2) == 0;
        
        Factory.WorldPower wp = Factory.Instance.generateAndRemove();
        if (!wp.met) {
            GameObject.Find("Correct").transform.GetChild(0).GetComponent<Text>().text = wp.a1R;
            GameObject.Find("Wrong").transform.GetChild(0).GetComponent<Text>().text = wp.a1W;
            GameObject.Find("Question").GetComponent<Text>().text = wp.q1;
            
        }
        else
        {
            GameObject.Find("Correct").transform.GetChild(0).GetComponent<Text>().text = wp.a2R;
            GameObject.Find("Wrong").transform.GetChild(0).GetComponent<Text>().text = wp.a2W;
            GameObject.Find("Question").GetComponent<Text>().text = wp.q2;
        }

        if (this.gameObject.name.Equals("Correct"))
        {
            wp.addScore(1);
        }
        else
        {
            wp.addScore(-1);
        }

        if (randomPos)
        {
            GameObject.Find("Correct").transform.localPosition = new Vector3(200, 0, 0);
            GameObject.Find("Wrong").transform.localPosition = new Vector3(-200, 0, 0);
        }

        else
        {
            GameObject.Find("Correct").transform.localPosition = new Vector3(-200, 0, 0);
            GameObject.Find("Wrong").transform.localPosition = new Vector3(200, 0, 0);
        }
    }
}
