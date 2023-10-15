using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPlatform : MonoBehaviour
{
    public GameObject MaximumCollider;
    public GameObject MinimumCollider;
    public PlatformLimitter Limitter;
    public SliderJoint2D SliderJoint;

    public int StartAngle = -120;
    public int EndAngle = 60;

    void Start()
    {
        Limitter.PlatformCollided += OnPlatformCollided;
    }

    private void OnPlatformCollided(GameObject collidedWith) {
        
        if (collidedWith == MaximumCollider) {
            SliderJoint.angle = EndAngle;
            MinimumCollider.SetActive(true);
            MaximumCollider.SetActive(false);
        } else if (collidedWith == MinimumCollider) {
            SliderJoint.angle = StartAngle;
            MinimumCollider.SetActive(false);
            MaximumCollider.SetActive(true);
        } 
        
    }

    void OnDestroy() {
        Limitter.PlatformCollided -= OnPlatformCollided;
    }
}
