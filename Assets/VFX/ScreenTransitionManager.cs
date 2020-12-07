using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Triggers screen animations as response to entering or exiting a scene
/// </summary>

public class ScreenTransitionManager : MonoBehaviour
{
    [SerializeField]
    Animator screenEffectsCanvasAnimator;
    private ScreenTransitionManager() { }
    private static ScreenTransitionManager instance;
    private ScreenTransitionManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = this;
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Subscribe to events
        var encounterMgr = SpawnPoint.player.GetComponent<EncounterManager>();
        encounterMgr.onEnterEncounter.AddListener(OnEnterEncounterHander);
        encounterMgr.onExitEncounter.AddListener(OnExitEncounterHander);
        SceneManager.sceneLoaded += OnEnterNewScene;

        //Ensure persistence and only one instance
        ScreenTransitionManager[] musicManagers = FindObjectsOfType<ScreenTransitionManager>();
        foreach (ScreenTransitionManager mgr in musicManagers)
        {
            if (mgr != Instance)
            {
                Destroy(mgr.gameObject);

            }
        }

        DontDestroyOnLoad(transform.root);
    }

    void OnEnterEncounterHander()
    {
        screenEffectsCanvasAnimator.Play("FadeToBlack");
        //screenEffectsCanvasAnimator.Play("FadeFromBlack");
    }
    void OnExitEncounterHander()
    {
        screenEffectsCanvasAnimator.Play("FadeToBlack");
    }

    void OnEnterNewScene(Scene newScene, LoadSceneMode newSceneMode)
    {
        screenEffectsCanvasAnimator.Play("FadeFromBlack");
    }
}
