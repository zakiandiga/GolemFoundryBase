using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static FMOD.Studio.EventInstance musicHandler;
    [FMODUnity.EventRef] public string musicPath;


    void Start()
    {
        musicHandler = FMODUnity.RuntimeManager.CreateInstance(musicPath);
        musicHandler.start();
        musicHandler.release();

        //TEMPORARY
        AreaIdentify(1);
    }

    private void OnEnable()
    {
        SceneHandler.OnSceneLoaded += SceneLoadAudioHandler;
    }

    private void OnDisable()
    {
        SceneHandler.OnSceneLoaded -= SceneLoadAudioHandler;
    }

    public void SceneLoadAudioHandler(string scene, int portal)
    {
        switch (scene)
        {
            case "IndoorDesigner":
                AreaIdentify(1);
                break;
            case "TerrainTransfer":
                AreaIdentify(0);
                break;
            case "MineDesigner":
                AreaIdentify(2);
                break;
            case "TitleScreen":
                AreaIdentify(3);
                break;
        }        
    }

    public void AreaIdentify (float area)
    {
        musicHandler.setParameterByName("Area", area);
    }

    private void OnDestroy()
    {
        musicHandler.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    
}
