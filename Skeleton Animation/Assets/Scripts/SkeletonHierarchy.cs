using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SkeletonHierarchy : MonoBehaviour
{
    [SerializeField] private List<SkeletonNode> _node;
    private uint _nodeCount = 0;

    private void Update()
    {
        foreach (SkeletonNode node in _node)
        {
            node.SetLocalTransform();
        }
        
        SolveFK(this);
    }

    private void SolveFK(SkeletonHierarchy skeletonHierarchy)
    {
        foreach (SkeletonNode node in skeletonHierarchy._node)
        {
            if (node.ParentIndex == -1)
            {
                node.globalTransform = node.localTransform;
            }
            else
            {
                node.globalTransform = skeletonHierarchy._node[(int)node.ParentIndex].globalTransform * node.localTransform;
            }
        }
    }

    public void AddNode(SkeletonNode newNode)
    {
        _nodeCount++;
        
        _node.Add(newNode);
    }
}
