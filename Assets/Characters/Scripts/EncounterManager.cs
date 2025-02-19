﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;



public class EncounterManager : MonoBehaviour
{
    public UnityEvent onEnterEncounter;
    public UnityEvent onExitEncounter;

    ParticleSystem p;

    [SerializeField]
    float battleEntryDelay = 3.0f;

    public void EnterEncounter()
    {
        StartCoroutine(DelayBattle());
    }

    IEnumerator DelayBattle()
    {
        onEnterEncounter.Invoke();
        yield return new WaitForSeconds(battleEntryDelay);
        transform.root.gameObject.SetActive(false);
        SceneManager.LoadScene("BattleScene");
    }

    public void ExitEncounter()
    {
        onExitEncounter.Invoke();

        Invoke("DelayedEnterScene", battleEntryDelay);

    }

    public void DelayedEnterScene()
    {
        transform.root.gameObject.SetActive(true);
        // In a full game, your code should remember the player's last area and return there
        SceneManager.LoadScene("Overworld");

    }
}
