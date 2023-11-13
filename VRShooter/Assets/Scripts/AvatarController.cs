using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MapTransforms
{
    public Transform vrTarget;
    public Transform ikTarget;

    public Vector3 trackingPosOffset;
    public Vector3 trackingRotOffset;

    public void VRMapping()
    {
        ikTarget.position = vrTarget.TransformPoint(trackingPosOffset);
        ikTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotOffset);
    }



}
public class AvatarController : MonoBehaviour
{


    [SerializeField] private MapTransforms head;
    [SerializeField] private MapTransforms leftHand;
    [SerializeField] private MapTransforms rightHand;

    [SerializeField] private float turnSmoothness;
    [SerializeField] Transform ikHead;
    [SerializeField] Vector3 headBodyOffset;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = ikHead.position + headBodyOffset;
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(ikHead.forward, Vector3.up).normalized, Time.deltaTime * turnSmoothness);

        head.VRMapping();
        leftHand.VRMapping();
        rightHand.VRMapping();

    }
}
