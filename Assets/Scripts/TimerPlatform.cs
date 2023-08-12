using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPlatform : MonoBehaviour
{
    public GameObject MaximumCollider;
    public GameObject MinimumCollider;
    public PlatformLimitter Limitter;
    public SliderJoint2D SliderJoint;

    void Start()
    {
        Limitter.PlatformCollided += OnPlatformCollided;
    }

    private void OnPlatformCollided(GameObject collidedWith) {
        
        if (collidedWith == MaximumCollider) {
            SliderJoint.angle = 90;
            MinimumCollider.SetActive(true);
            MaximumCollider.SetActive(false);
        } else if (collidedWith == MinimumCollider) {
            SliderJoint.angle = -90;
            MinimumCollider.SetActive(false);
            MaximumCollider.SetActive(true);
        } 
        
    }

    void OnDestroy() {
        Limitter.PlatformCollided -= OnPlatformCollided;
    }
}
