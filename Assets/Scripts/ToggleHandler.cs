using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleHandler : MonoBehaviour
{
    public static bool ExplosionHandler = false;
    public static bool FriendlyZone = false;
    public static bool DeadlyZone = false;
    public static bool BarrierZone = false;

    public void ExplosionToggle()
    {
        ExplosionHandler = !ExplosionHandler;
    }

    public void FriendlyZoneToggle()
    {
        FriendlyZone = !FriendlyZone;
    }

    public void DeadlyZoneToggle()
    {
        DeadlyZone = !DeadlyZone;
    }

    public void BarrierZoneToggle()
    {
        BarrierZone = !BarrierZone;
    }

    public static void ResetToggles()
    {
        ExplosionHandler = false;
        FriendlyZone = false;
        DeadlyZone = false;
        BarrierZone = false;
    }
}
