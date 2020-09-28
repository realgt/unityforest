using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DynamicDoF : MonoBehaviour
{
    Ray raycast;
    RaycastHit hit;
    bool isHit;
    float hitDistance;

    public PostProcessVolume volume;
    DepthOfField depthOfField;

    private void Start()
    {
        volume.profile.TryGetSettings(out depthOfField);
    }
    // Update is called once per frame
    public void Update()
    {
        raycast = new Ray(transform.position, transform.forward * 100);
        isHit = false;

        if (Physics.Raycast(raycast, out hit, 100f))
        {
            isHit = true;
            hitDistance = Vector3.Distance(transform.position, hit.point);
        }
        else
        {
            if (hitDistance < 100f)
            {
                hitDistance++;
            }
        }

        SetFocus();
    }

    void SetFocus()
    {
        depthOfField.focusDistance.value = hitDistance;
    }

    private void OnDrawGizmos()
    {
        if (isHit)
        {
            Gizmos.DrawSphere(hit.point, 0.1f);
            UnityEngine.Debug.DrawRay(transform.position, transform.forward * Vector3.Distance(transform.position, hit.point));

        }
        else
        {
            UnityEngine.Debug.DrawRay(transform.position, transform.forward * 100f);
        }
    }
}
