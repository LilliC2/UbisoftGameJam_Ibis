using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : Behaviour //inherits from
{
    //unquie to this project

    //protected static SceneController _SC { get { return SceneController.INSTANCE; } }
    protected static GameManager _GM { get { return GameManager.INSTANCE; } }

    protected static NPCSpawner _NPC { get { return NPCSpawner.INSTANCE; } }
    protected static DespawnMannager _DM { get { return DespawnMannager.INSTANCE; } }
    protected static SeagullControllerMannager _SC { get { return SeagullControllerMannager.INSTANCE; } }
    protected static ItemSpawner _IS { get { return ItemSpawner.INSTANCE; } }

    protected static MainMenu _MM { get { return MainMenu.INSTANCE; } }
    protected static UIManager _UI { get { return UIManager.INSTANCE; } }
    protected static VFXManager _VFXM { get { return VFXManager.INSTANCE; } }
    protected static AudioManager _AM { get { return AudioManager.INSTANCE; } }

}
//
// Instanced GameBehaviour
//
public class GameBehaviour<T> : GameBehaviour where T : GameBehaviour
{
    static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("GameBehaviour<" + typeof(T).ToString() + "> not instantiated!\nNeed to call Instantiate() from " + typeof(T).ToString() + "Awake().");
            return _instance;
        }
    }
    //
    // Instantiate singleton
    // Must be called first thing on Awake()
    protected bool Instantiate()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Instance of GameBehaviour<" + typeof(T).ToString() + "> already exists! Destroying myself.\nIf you see this when a scene is LOADED from another one, ignore it.");
            DestroyImmediate(gameObject);
            return false;
        }
        _instance = this as T;
        return true;
    }

}
