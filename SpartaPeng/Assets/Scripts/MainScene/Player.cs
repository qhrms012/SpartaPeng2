using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public const string PLAYER_NAME = "PlayerName";
    public const string PLAYER_CHARACTER = "PlayerCharacter";

    private string name;

    public Text playerNameText;

    public string Name { get { return name; } }

    void Start()
    {
        string playerName = PlayerPrefs.GetString("PlayerName");
        playerNameText.text = playerName;

        name = PlayerPrefs.GetString(PLAYER_NAME);
        if (!PlayerPrefs.HasKey(PLAYER_CHARACTER))
        {
            // PlayerPrefs�� �÷��̾� ĳ���Ͱ� ����Ǿ� ���� ���� ��� �⺻������ ����
            PlayerPrefs.SetInt(PLAYER_CHARACTER, 1);
        }
        SetPlayerCharacterAnimator((PlayerCharacterType)PlayerPrefs.GetInt(PLAYER_CHARACTER));
    }

    public void SetPlayerName(string name)
    {
        this.name = name;
        PlayerPrefs.SetString(PLAYER_NAME, name);
    }

    public void SetPlayerCharacter(PlayerCharacterType type)
    {
        SetPlayerCharacterAnimator(type);
        PlayerPrefs.SetInt(PLAYER_CHARACTER, (int)type);
    }

    private void SetPlayerCharacterAnimator(PlayerCharacterType type)
    {
        if (type == PlayerCharacterType.ONE)
        {
            transform.GetComponentInChildren<Animator>().runtimeAnimatorController
                = (RuntimeAnimatorController)Resources.Load("AnimController/PlayerCharacterImage");
        }
        else
        {
            transform.GetComponentInChildren<Animator>().runtimeAnimatorController
                = (RuntimeAnimatorController)Resources.Load("AnimController/PlayerCharacter2AnimController");
        }
    }
}