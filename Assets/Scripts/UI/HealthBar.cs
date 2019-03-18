using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image[] healthBar;
    public int maxHealth;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    TestHealthBarInputKeys();
    //    HealthBounds();
    //    DisplayHealthBars(health);
    //}

    //enforces lower and upper limits of health
    void HealthBounds()
    {
        if(health < 0)
            health = 0;
        if(health > maxHealth)
            health = maxHealth;
    }

    //displays health bars based on percent health remaining (later ones disappear first)
    public void DisplayHealthBars(int h)
    {
        health = h;
        for(int i = 0; i < h; i++)
        {
            healthBar[i].enabled = true;
        }

        for(int i = h; i < healthBar.Length; i++)
        {
            healthBar[i].enabled = false;
        }
    }

    //testing
    //adds health equal to number key pressed ("0" = 10) or subtracts if pressing left alt
    //affects max health if pressing left shift
    void TestHealthBarInputKeys()
    {
        int healthMod = -1;
        if(Input.GetKey("left alt"))
            healthMod = 1;

        if(!Input.GetKey("left shift"))
        {
            if(Input.GetKeyDown("1"))
                health += 1 * healthMod;
            if(Input.GetKeyDown("2"))
                health += 2 * healthMod;
            if(Input.GetKeyDown("3"))
                health += 3 * healthMod;
            if(Input.GetKeyDown("4"))
                health += 4 * healthMod;
            if(Input.GetKeyDown("5"))
                health += 5 * healthMod;
            if(Input.GetKeyDown("6"))
                health += 6 * healthMod;
            if(Input.GetKeyDown("7"))
                health += 7 * healthMod;
            if(Input.GetKeyDown("8"))
                health += 8 * healthMod;
            if(Input.GetKeyDown("9"))
                health += 9 * healthMod;
            if(Input.GetKeyDown("0"))
                health += 10 * healthMod;
        }
        else
        {
            if(Input.GetKeyDown("1"))
                maxHealth += 1 * healthMod;
            if(Input.GetKeyDown("2"))
                maxHealth += 2 * healthMod;
            if(Input.GetKeyDown("3"))
                maxHealth += 3 * healthMod;
            if(Input.GetKeyDown("4"))
                maxHealth += 4 * healthMod;
            if(Input.GetKeyDown("5"))
                maxHealth += 5 * healthMod;
            if(Input.GetKeyDown("6"))
                maxHealth += 6 * healthMod;
            if(Input.GetKeyDown("7"))
                maxHealth += 7 * healthMod;
            if(Input.GetKeyDown("8"))
                maxHealth += 8 * healthMod;
            if(Input.GetKeyDown("9"))
                maxHealth += 9 * healthMod;
            if(Input.GetKeyDown("0"))
                maxHealth += 10 * healthMod;
        }
    }
}
