using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSwitch : MonoBehaviour
{
    private Light lighting;

    private SunState sunState;
    public enum SunState
    {
        on,
        off
    }

    private void Start()
    {
        lighting = GetComponent<Light>();
    }

    private void OnEnable()
    {
        //PlayerLocationSetter.OnPlayerRelocationSuccess += SunControllerCheck;
        SceneHandler.OnStart += LightCheck;
        SceneHandler.OnTransitionFinalized += SunControllerCheck;
        SunController.OnLightCheck += LightCheck;
    }

    private void OnDisable()
    {
        //PlayerLocationSetter.OnPlayerRelocationSuccess -= SunControllerCheck;
        SceneHandler.OnStart -= LightCheck;
        SceneHandler.OnTransitionFinalized -= SunControllerCheck;
        SunController.OnLightCheck -= LightCheck;
    }

    private void SunControllerCheck(string p)
    {
        //SunController.OnLightCheck += LightCheck;
    }

    private void LightCheck(int light)
    {
        if(light == 0)
        {
            lighting.enabled = false;
            //SunController.OnLightCheck -= LightCheck;
        }
        else if (light == 1 && !lighting.enabled)
        {
            lighting.enabled = true;
            //SunController.OnLightCheck -= LightCheck;
        }
    }
}
