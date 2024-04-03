using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

[ExecuteInEditMode]
public class SkeletonNode : MonoBehaviour
{
    SkeletonNode(int parentIndex)
    {
        ParentIndex = parentIndex;
    }

    public Vector3 LocalPosition;
    public Vector3 LocalRotation;
    public Vector3 LocalScale = new(1, 1, 1);

    private Matrix4x4 _rotationMatrix;
    private Matrix4x4 _translateMatrix;
    private Matrix4x4 _scaleMatrix;

    private void Update()
    {
        transform.position = globalTransform.GetT();
        transform.rotation = globalTransform.GetR();
        transform.localScale = globalTransform.GetS();
    }

    [HideInInspector] public Matrix4x4 localTransform;
    [HideInInspector] public Matrix4x4 globalTransform;

    public void SetLocalTransform()
    {
        _translateMatrix = Matrix4x4.Translate(LocalPosition);
        _rotationMatrix = Matrix4x4.Rotate(Quaternion.Euler(LocalRotation));
        _scaleMatrix = Matrix4x4.Scale(LocalScale);

        localTransform = _translateMatrix * _rotationMatrix * _scaleMatrix;
    }

    public int ParentIndex;
}
