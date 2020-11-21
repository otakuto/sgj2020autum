using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonobitEngine;

public class Matching : MonobitEngine.MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MonobitNetwork.autoJoinLobby = true;
		MonobitNetwork.ConnectServer( "DroneMask_v1.0" );
		Application.runInBackground = true;
    }

    // Update is called once per frame
    void Update()
    {
        if( MonobitNetwork.isConnect && MonobitNetwork.inRoom && MonobitNetwork.clientCountInRoom == 2 )
		{
			if( initialized == false )
			{
				if( MonobitNetwork.isHost )
				{
					MonobitNetwork.Instantiate( "prefab/Player_1", Vector3.zero, Quaternion.identity, 0 );
				}
				else
				{
					MonobitNetwork.Instantiate( "prefab/Player_2", Vector3.zero, Quaternion.identity, 0 );
				}
				initialized = true;
			}
		}
    }

	void OnGUI()
	{
		if( MonobitNetwork.isConnect )
		{
			if( !MonobitNetwork.inRoom )
			{
				GUILayout.BeginHorizontal();
 
				// ルーム名の入力
				GUILayout.Label("RoomName : ");
				roomName = GUILayout.TextField(roomName, GUILayout.Width(200));
 
				// ボタン入力でルーム作成
				RoomSettings roomSettings = new RoomSettings()
				{
					maxPlayers = 2,
					isVisible = true,
					isOpen = true
				};
				if ( GUILayout.Button("Create Room", GUILayout.Width(150)))
				{
					MonobitNetwork.CreateRoom(roomName, roomSettings, null );
				}
 
				GUILayout.EndHorizontal();

				foreach( RoomData room in MonobitNetwork.GetRoomData() )
				{
					string strRoomInfo = string.Format( "{0}({1}/{2}" ,
														room.name, room.playerCount,
														(room.maxPlayers == 0) ? "-" : room.maxPlayers.ToString() );
					if( GUILayout.Button( "Enter Room: " + strRoomInfo ) )
					{
						MonobitNetwork.JoinRoom( room.name );
					}
				}
			}
			else
			{
				GUILayout.BeginHorizontal();
 
				if ( GUILayout.Button("Leave Room", GUILayout.Width(150)))
				{
					MonobitNetwork.LeaveRoom();
				}
 
				GUILayout.EndHorizontal();
			}
		}
	}

	void OnDestroy()
	{
		MonobitEngine.MonobitNetwork.DisconnectServer();
	}

	string roomName;

	bool initialized = false;
}
