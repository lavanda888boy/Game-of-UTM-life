using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHandler : MonoBehaviour
{
    public static bool ExplosionHandler = false;
    public static bool ToxicZone = false;
    public static bool FriendlyZone = false;

    public void ExplosionToggle()
    {
        ExplosionHandler = !ExplosionHandler;
    }

    public void ToxicZoneToggle()
    {
        ToxicZone = !ToxicZone;
    }

    public void FriendlyZoneToggle()
    {
        FriendlyZone = !FriendlyZone;
    }

    public static void ResetToggles()
    {
        ExplosionHandler = false;
        ToxicZone = false;
        FriendlyZone = false;
    }
}
