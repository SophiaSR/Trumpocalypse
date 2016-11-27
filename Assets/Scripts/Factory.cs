using UnityEngine;
using System.Collections;

public class Factory : Singleton<Factory>
{
    public ArrayList powers = new ArrayList();
    public class WorldPower
    {
        
        public string leader;

        public string name;

        public string q1;
        public string q2;

        public string a1R;
        public string a1W;
        public string a2R;
        public string a2W;

        public int score;
        public bool met;
        public WorldPower(string leader, string q1, string q2, string a1R, string a1W,string a2R, string a2W, int score)
        {
            this.leader = leader;
            this.q1 = q1;
            this.q2 = q2;
            this.a1R = a1R;
            this.a1W = a1W;
            this.a2R = a2R;
            this.a2W = a2W;
            this.score = score;
            met = true;
            
        }


        public int addScore(int possibleScore)
        {
            if(-2 < score && score < 2)
            {
                score += possibleScore;
            }

            else if(score == 2 && possibleScore < 0)
            {
                score += possibleScore;
            }
            else if(score == -2 && possibleScore > 0) 
            {
                score += possibleScore;
            }

            return score;
        }
        

        
    }

	void Start() { 
        WorldPower russia = new WorldPower("President Putin","What is my, the Great Putin, prized color?", "Did we start the Ukrainian conflict?", "Red","Gold", "No","Yes",  2);
        powers.Add(russia);

        WorldPower middleEast = new WorldPower("King Abdullah","Is our flag, Saudi Arabia's, blue?", "Are you smart or stupid?", "No","Yes", "Stupid","Smart", -2);
        powers.Add(middleEast);

        WorldPower mexico = new WorldPower("President Nieto", "How do you view illegal immigrants?", "Will you tear down the wall?", "As people", "As animals", "Right away","Probably not",   -2);
        powers.Add(mexico);

        WorldPower china = new WorldPower("President Xi Jinping", "How many stars on our flag?", "Are we communist?","Five","Six", "Yes","No", 0);
        powers.Add(china);

        WorldPower northKorea = new WorldPower("Leader Kim Jong-un", "What is my height?", "Are we over or under South Korea?", "6","5", "Over","Under",  -1);
        powers.Add(northKorea);

        WorldPower canada = new WorldPower("Prime Minister Trudeau","What topping do you put on your pancakes?", "Are you smart or stupid?","Maple Syrup","Butter", "Smart","Stupid", 0);
        powers.Add(canada);

        WorldPower EU = new WorldPower("President Tusk","What is our currency?", "Was Brexit a good idea?", "Euro","Pound", "No","Yes", 1);
        powers.Add(EU);


    }

    public WorldPower generateAndRemove()
    {
        int randomInt = Random.Range(0, powers.Count);
        WorldPower wp = powers[randomInt] as WorldPower;
        if (wp.met)
        {
            wp.met = false;
        }

        else
        {
            wp.met = true;
            powers.Remove(wp);


        }

        return wp;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
