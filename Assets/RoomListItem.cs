using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    RoomInfo roomInfo;

    public void SetUp(RoomInfo _info) { 
    
        roomInfo = _info;
        text.text = _info.Name;

    }
    public void OnClick() {
        print("Onclick olurmu?");
        Launcher.Instance.JoinRoom(roomInfo);

    }
}
