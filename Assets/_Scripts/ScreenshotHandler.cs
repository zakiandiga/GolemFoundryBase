using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScreenshotHandler : MonoBehaviour
{
    [SerializeField] private InputActionReference screenShot;

    private string timeStamp;
    private string fileName;
    private string savePath;

    void Start()
    {
        screenShot.action.Enable();
    }

    private void OnDestroy()
    {
        screenShot.action.Disable();
    }

    public void TakeScreenShot()
    {
        ScreenCapture.CaptureScreenshot(savePath);
        Debug.Log("Data path = " + Application.persistentDataPath);
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (screenShot.action.triggered)
        {
            timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HHmmss");
            fileName = "ss-" + timeStamp + ".png";
            savePath = Application.persistentDataPath+"/Screenshots/" + fileName;
            TakeScreenShot();
        }
    }
}
