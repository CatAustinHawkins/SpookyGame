using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatManager : MonoBehaviour
{
    public float PlayerAttackSpeed;
    public float PlayerDamage;
    public float PlayerDefense;
    public float PlayerHealth;

    public float EnemyDamage;
    public float EnemyHealth;

    public float Experience;

    public float randomnumber;

    public float timer;
    public bool timeractive;

    public TextMeshProUGUI EnemyHealthText;
    public TextMeshProUGUI PlayerHealthText;

    public GameObject CombatUI; 


    void Update()
    {
        if(timeractive)
        {
            timer = timer + 1 * Time.deltaTime;
        }

        if(timer > 2)
        {
            timeractive = false;
            timer = 0;
        }
    }

    public void CombatBegin()
    {

    }


    public void FightButton()
    {
        EnemyHealth = EnemyHealth - PlayerDamage;
        EnemyHealthText.text = EnemyHealth.ToString() + " /100";

        if(EnemyHealth < 0 || EnemyHealth == 0)
        {
            EnemyKilled();
        }

        PlayerHealth = PlayerHealth - EnemyDamage;
        PlayerHealthText.text = PlayerHealth.ToString() + " /100";
    }

    public void ActButton()
    {

    }

    public void ItemButton()
    {

    }

    public void SpareButton()
    {
        randomnumber = Random.Range(1, 3);

        if(randomnumber > 1)
        {

        }
        else
        {

        }
    }


    public void EnemyKilled()
    {
        CombatUI.SetActive(false);
        
    }

    public void PlayerKilled()
    {

    }


}
