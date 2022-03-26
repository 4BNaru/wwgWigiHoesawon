
using System;
using Kinel.VideoPlayer.Scripts;
using Kinel.VideoPlayer.Scripts.Playlist;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class MasterOnlySystem : UdonSharpBehaviour
{
    [SerializeField] private KinelVideoScript videoPlayer;
    [SerializeField] private GameObject masteronlyObject;

    public void FixedUpdate()
    {
        if (!videoPlayer)
            return;

        if (!masteronlyObject)
            return;

        if (Networking.LocalPlayer.isMaster && masteronlyObject.activeSelf)
            masteronlyObject.SetActive(false);

        if (videoPlayer.masterOnly && !Networking.LocalPlayer.isMaster)
            masteronlyObject.SetActive(true);
                
        if (!videoPlayer.masterOnly && !Networking.LocalPlayer.isMaster)
            masteronlyObject.SetActive(false);
    }
}
