using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnClick : MonoBehaviour
{
    public Sprite endImage;
    public bool first = true;
    public int score = -2;
    Factory.WorldPower wp;

   
    //called when a button is clicked
    public void clicked()
    {
       
        if (wp != null)
        {
            GameObject go = EventSystem.current.currentSelectedGameObject;
            //checks to see which button is clicked
            if (go.Equals(GameObject.Find("Enter")))
            {
                if (GameObject.Find("Feet").GetComponent<Dropdown>().value == 2)
                {
                    score += wp.addScore(1);
                }
                else
                {
                    score += wp.addScore(-1);
                }

            }
            else if (go.Equals(GameObject.Find("Correct")))
            {

                score += wp.addScore(1);
            }
            else if (go.Equals(GameObject.Find("Wrong")))
            {
                score += wp.addScore(-1);
            }



            GameObject.Find("Score").GetComponent<Text>().text = "Score: " + score;

        }

        //sets "correct" and "wrong" buttons active, sets dropdown and "enter" button inactive
        if (!GameObject.Find("Panel").transform.GetChild(1).gameObject.activeInHierarchy)
        {
            GameObject.Find("Panel").transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("Panel").transform.GetChild(2).gameObject.SetActive(true);
            GameObject.Find("Panel").transform.GetChild(3).gameObject.SetActive(false);
            GameObject.Find("Panel").transform.GetChild(4).gameObject.SetActive(false);
            GameObject.Find("Panel").transform.GetChild(5).gameObject.SetActive(false);
        }

        //which of the two buttons will be on which side
        bool randomPos = Random.Range(0, 2) == 0;

        GameObject.Find("Question").GetComponent<Text>().fontSize = 60;

        //sets wp to the next WorldPower
        wp = Factory.Instance.generateAndRemove();

        //If we are out of World Powers, then end the game
        if (wp == null)
        {
            GameObject.Find("Panel").GetComponent<Image>().sprite = endImage;
            GameObject.Find("Question").GetComponent<Text>().text = "The End";
            GameObject.Find("Panel").transform.GetChild(1).gameObject.SetActive(false);
            GameObject.Find("Panel").transform.GetChild(2).gameObject.SetActive(false);
            GameObject.Find("Panel").transform.GetChild(3).gameObject.SetActive(false);
            GameObject.Find("Panel").transform.GetChild(4).gameObject.SetActive(false);
            GameObject.Find("Panel").transform.GetChild(5).gameObject.SetActive(false);
        }

        else
        {
            //which question to ask 
            if (!wp.met)
            {
                GameObject.Find("Correct").transform.GetChild(0).GetComponent<Text>().text = wp.a1R;
                GameObject.Find("Wrong").transform.GetChild(0).GetComponent<Text>().text = wp.a1W;
                GameObject.Find("Question").GetComponent<Text>().text = wp.q1;
                GameObject.Find("Question").GetComponent<Text>().text = wp.leader + " of " + wp.name + " is asking: " + wp.q1;

                //sets dropdown active if North Korea height question
                if (wp.name.Equals("North Korea"))
                {
                    GameObject.Find("Wrong").SetActive(false);
                    GameObject.Find("Correct").SetActive(false);
                    GameObject.Find("Panel").transform.GetChild(3).gameObject.SetActive(true);
                    GameObject.Find("Panel").transform.GetChild(4).gameObject.SetActive(true);
                    GameObject.Find("Panel").transform.GetChild(5).gameObject.SetActive(true);
                }
            }
            else
            {
                GameObject.Find("Correct").transform.GetChild(0).GetComponent<Text>().text = wp.a2R;
                GameObject.Find("Wrong").transform.GetChild(0).GetComponent<Text>().text = wp.a2W;
                GameObject.Find("Question").GetComponent<Text>().text = wp.leader + " of " + wp.name + " is asking: " + wp.q2;
            }


            //puts buttons in different positions, if they are active
            if (randomPos && GameObject.Find("Panel").transform.GetChild(1).gameObject.activeInHierarchy)
            {

                GameObject.Find("Correct").transform.localPosition = new Vector3(200, -100, 0);
                GameObject.Find("Wrong").transform.localPosition = new Vector3(-200, -100, 0);
            }

            else if (GameObject.Find("Panel").transform.GetChild(1).gameObject.activeInHierarchy)
            {
                GameObject.Find("Correct").transform.localPosition = new Vector3(-200, -100, 0);
                GameObject.Find("Wrong").transform.localPosition = new Vector3(200, -100, 0);
            }

            //sets background image
            GameObject.Find("Panel").GetComponent<Image>().sprite = wp.image;



        }
    }
}
