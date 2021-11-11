using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Mobile", menuName = "Scripts/TestProperties")]
public class MobileProperties: ScriptableObject
{

    static bool mobileControls = false;

    public void ActivateMobileControl(bool activate)
    {
        mobileControls = activate;
    }

    public bool isMobile()
    {
        return mobileControls;
    }
}
