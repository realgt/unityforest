using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Characters.ThirdPerson;

public class SwitchCamera : MonoBehaviour
{
    
    public Camera tps;
    public Camera fps;
    bool isFps = true;
    DepthOfField depthOfField;
    public PostProcessVolume fpsvolume;

    // Start is called before the first frame update
    void Start()
    {
        fpsvolume.profile.TryGetSettings(out depthOfField);
        fps.enabled = isFps;
        tps.enabled = !isFps;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            isFps = !isFps;
            fps.enabled = isFps;            
            tps.enabled = !isFps;

            fpsvolume.isGlobal = fps.enabled;
        }

    }
}
