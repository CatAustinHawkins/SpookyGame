using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class CombatManager : MonoBehaviour
{
    public float PlayerDamage = 20;
    public float PlayerHealth;

    public float EnemyDamage = 10;
    public float EnemyHealth;
    public float EnemyPacificity;

    public float Experience;

    [Header("Timer")]
    public float timer;
    public bool timeractive;

    [Header("TextMeshPro Objects")]
    public TextMeshProUGUI EnemyHealthText;
    public TextMeshProUGUI PlayerHealthText;
    public TextMeshProUGUI FightUpdate;

    public GameObject PlayerTurnUI;
    public GameObject EnemyTurnUI;

    public GameObject CombatUI;

    public Button ActButtonUI;
    public Button FightButtonUI;
    public Button ItemButtonUI;
    public Button SpareButtonUI;

    public bool EnemysTurn;
    public bool PlayersTurn;

    public bool AndiFighting;
    public bool ToxFighting;
    public bool FayFighting;

    public bool Enemy1Fighting;
    public bool Enemy2Fighting;
    public bool Enemy3Fighting;


    Coroutine coroutine;

    public void CombatBegin()
    {
        CombatUI.SetActive(true);

        if(Random.Range(1,3) > 1)
        {
            PlayersTurn = true;
            EnemysTurn = false;
        }
        else
        {
            PlayersTurn = false;
            EnemysTurn = true;
            coroutine = StartCoroutine(CountdownTimer());
        }
    }


    public void FightButton()
    {
        EnemyHealth = EnemyHealth - PlayerDamage;
        EnemyHealthText.text = EnemyHealth.ToString() + " /100";
        FightUpdate.text = "Enemy took " + PlayerDamage.ToString() + " Damage!";

        if (EnemyHealth < 0 || EnemyHealth == 0)
        {
            EnemyKilled();
        }

        EnemysTurn = true;
        PlayersTurn = false;
        RoundChange();

    }

    public void ActButton()
    {
        EnemyPacificity = EnemyPacificity + Random.Range(35, 100);
        if(EnemyPacificity == 100 || EnemyPacificity > 100)
        {
            CombatEnd();
        }
        FightUpdate.text = "Enemy Pacificity is at " + EnemyPacificity.ToString() + "/100 !";

        EnemysTurn = true;
        PlayersTurn = false;
        RoundChange();

    }

    public void ItemButton()
    {
        FightUpdate.text = "you have no items.";

        EnemysTurn = true;
        PlayersTurn = false;
        RoundChange();
    }

    public void SpareButton()
    {
        if(Random.Range(1, 3) > 1)
        {
            CombatEnd();
        }
        
        FightUpdate.text = "Unsuccessful!";

        EnemysTurn = true;
        PlayersTurn = false;
        RoundChange();
    }


    public void EnemyKilled()
    {
        CombatEnd();

    }

    public void PlayerKilled()
    {

    }

    public void CombatEnd()
    {
        CombatUI.SetActive(false);
        Experience++;
    }

    public void RoundChange()
    {
        if(EnemysTurn)
        {
            coroutine = StartCoroutine(CountdownTimer());
            EnemyTurnUI.SetActive(true);
            PlayerTurnUI.SetActive(false);
            FightButtonUI.interactable = false;
            ActButtonUI.interactable = false;
            ItemButtonUI.interactable = false;
            SpareButtonUI.interactable = false;
        }

        if(PlayersTurn)
        {
            EnemyTurnUI.SetActive(false);
            PlayerTurnUI.SetActive(true);
            FightButtonUI.interactable = true;
            ActButtonUI.interactable = true;
            ItemButtonUI.interactable = true;
            SpareButtonUI.interactable = true;
        }
    }

    public void EnemyTurn()
    {
        PlayerHealth = PlayerHealth - EnemyDamage;
        PlayerHealthText.text = PlayerHealth.ToString() + " /100";
        FightUpdate.text = "Player took " + EnemyDamage.ToString() + " Damage!";
        PlayersTurn = true;
        EnemysTurn = false;
        RoundChange();
    }

    IEnumerator CountdownTimer()
    {
        yield return new WaitForSeconds(2);
        FightUpdate.text = " ";
        EnemyTurn();
    }
}
