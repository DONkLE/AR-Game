using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class LightEstimation : MonoBehaviour
{
    [SerializeField]
    private ARCameraManager arCameraManager;

    [SerializeField]
    private Light lightSource;

    [SerializeField]
    private float brightnessValue;

    [SerializeField]
    private Color tempValue;

    [SerializeField]
    private Color colorCorrectionValue;

    [SerializeField]
    private Vector3 directionValue;

    private void OnEnable()
    {
        arCameraManager.frameReceived += FrameUpdated;
    }

    private void OnDisable()
    {
        arCameraManager.frameReceived -= FrameUpdated;
    }

    private void FrameUpdated(ARCameraFrameEventArgs args)
    {
        if(args.lightEstimation.averageMainLightBrightness.HasValue)
        {
            brightnessValue = args.lightEstimation.averageMainLightBrightness.Value;
            lightSource.intensity = brightnessValue;
        }

        if (args.lightEstimation.mainLightColor.HasValue)
        {
            tempValue = args.lightEstimation.mainLightColor.Value;
            lightSource.color = tempValue;
        }

       // if (args.lightEstimation.colorCorrection.HasValue)
       // {
       //     colorCorrectionValue = args.lightEstimation.colorCorrection.Value;
       // }

        if (args.lightEstimation.mainLightDirection.HasValue)
        {
            directionValue = args.lightEstimation.mainLightDirection.Value;
            lightSource.gameObject.transform.position = directionValue;
        }

       // if (args.lightEstimation.ambientSphericalHarmonics.HasValue)
       // {

       // }

       // if (args.lightEstimation.averageIntensityInLumens.HasValue)
       // {

       // }
    }

}
