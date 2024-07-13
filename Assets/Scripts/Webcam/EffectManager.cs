using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

    protected int screenWidth;
    protected int screenHeight;
    
    // Use this for initialization
    protected void Awake() {

        screenWidth = Screen.width;
        screenHeight = Screen.height;

        // re-activate webcam
        if(WebcamHandler.instance)
            WebcamHandler.instance.ActivateWebcam();
    }
	
	// Update is called once per frame
	void Update () {

	}

    /// <summary>
    ///  To be called by child classes to go through the list of crosses.
    ///  Input to be mapped to screen size if useScreenSize is true
    /// </summary>
    /// <param name="useScreenSize"> Input to be mapped to screen size if true, or something else if false (e.g. an Image) </param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    protected void ProcessInput(bool useScreenSize, int width = 0, int height = 0)
    {
        //if (mouseMode)  // use mouse only
        //{
        //    HandlePoint(Input.mousePosition);
        //}
        //else
        HandlePoint(Input.mousePosition);   // Handle mouse position

        if (WebcamHandler.instance.IsWebcamActive())
        {
            foreach (Point point in WebcamInputReceiver.instance.GetCrossesList())
            {
                Point relativePt = WebcamInputReceiver.instance.CalculateRelativePoint(point, useScreenSize, width, height);
                
                HandlePoint(new Vector2(relativePt.x, relativePt.y));
            }
        }
        else
        {
            Debug.Log("Webcam is Inactive!");
        }
    }

    /// <summary>
    ///  To be overwritten by child classes, to use the converted point for an effect interaction
    /// </summary>
    /// <param name="point"></param>
    protected virtual void HandlePoint(Vector2 point)
    {

    }

}
