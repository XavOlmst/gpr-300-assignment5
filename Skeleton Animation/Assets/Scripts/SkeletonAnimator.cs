using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimator : MonoBehaviour
{
    [SerializeField] private SkeletonNode animationNode;
    [SerializeField] private Vector3 rotationAnimationRates;
    
    void Update()
    {
        animationNode.LocalRotation += rotationAnimationRates * Time.deltaTime;
    }
}
