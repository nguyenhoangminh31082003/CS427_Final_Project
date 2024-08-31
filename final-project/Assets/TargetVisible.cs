using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetVisible : MonoBehaviour
{    
    public Camera playerCam;

    public bool IsVisible(Vector3 point)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(playerCam);

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point)< 0)
            {
                return false;
            }
        }
        return true;
    }

    private void Update ()
    {
        GetComponent<SlenderManAI>().SetIsVisible(IsVisible(this.transform.position));
    }
}
