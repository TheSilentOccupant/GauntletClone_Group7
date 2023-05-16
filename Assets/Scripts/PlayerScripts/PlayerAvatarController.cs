using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatarController : MonoBehaviour
{
    [SerializeField]
    private GameObject _PlayerBody;
    [SerializeField]
    private GameObject _PlayerHead;

    public void ClassChange(PlayerTemplate currentClass)
    {
        _PlayerBody.GetComponent<MeshRenderer>().material.color = currentClass.PlayerBodyColor;
        _PlayerHead.GetComponent<MeshRenderer>().material.color = currentClass.PlayerHeadColor;
    }
}
