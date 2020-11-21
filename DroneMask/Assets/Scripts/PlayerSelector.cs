using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField]
    private GameObject player_1;

    [SerializeField]
    private GameObject player_2;

    [SerializeField]
    private GameObject CameraDroneBackground;

    private MonobitEngine.MonobitView player_1_MonobitView;
    private MonobitEngine.MonobitView player_2_MonobitView;

    void Start()
    {
    }

    void Update()
    {
        if (player_1 != null)
        {
            player_1_MonobitView = player_1.GetComponent<MonobitEngine.MonobitView>();
            if (player_1_MonobitView.isMine)
            {
                CameraDroneBackground.SetActive(true);
            }
        }
        else
        {
            player_1 = GameObject.Find("Player_1(Clone)");
        }


        if (player_2 != null)
        {
            player_2_MonobitView = player_2.GetComponent<MonobitEngine.MonobitView>();
            if (player_2_MonobitView.isMine)
            {
                CameraDroneBackground.SetActive(false);
            }
        }
        else
        {
            player_2 = GameObject.Find("Player_2(Clone)");
        }
    }
}
