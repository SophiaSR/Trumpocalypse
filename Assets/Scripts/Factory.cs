using UnityEngine;
using System.Collections;

public class Factory : Singleton<Factory>
{
    public ArrayList powers = new ArrayList();
    public class WorldPower
    {
        
        public string leader;
        public string q1;
        public string q2;
        public string a1;
        public string a2;
        public int score;
        public bool met;
        public WorldPower(string leader, string q1, string q2, string a1, string a2, int score)
        {
            this.leader = leader;
            this.q1 = q1;
            this.q2 = q2;
            this.a1 = a1;
            this.a2 = a2;
            this.score = score;
            met = true;
            
        }
        

        
    }

	void Start() { 
        WorldPower russia = new WorldPower("President Putin","What is my, the Great Putin, prized color?", "Did we start the Ukrainian conflict?", "Red", "No",  2);
        powers.Add(russia);

        WorldPower middleEast = new WorldPower("King Abdullah","Is our flag, Saudi Arabia's, blue?", "Are you smart or stupid?", "No", "Stupid", -2);
        powers.Add(middleEast);

        WorldPower mexico = new WorldPower("President Nieto", "How do you view illegal immigrants?", "Will you tear down the wall?","Right away", "As people",  -2);
        powers.Add(mexico);

        WorldPower china = new WorldPower("President Xi Jinping", "How many stars on our flag?", "Are we communist?","Five", "Yes", 0);
        powers.Add(china);

        WorldPower northKorea = new WorldPower("Leader Kim Jong-un", "Am I above or below 6 feet?", "Are we over or under South Korea?", "Above", "Above",  -1);
        powers.Add(northKorea);

        WorldPower canada = new WorldPower("Prime Minister Trudeau","What topping do you put on your pancakes?", "Are you smart or stupid?","maple syrup", "Smart", 0);
        powers.Add(canada);

        WorldPower EU = new WorldPower("President Tusk","What is our currency?", "Was Brexit a good idea?", "Euro", "No", 1);
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
