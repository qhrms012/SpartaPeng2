using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{
    public GameObject playerSelectPanel;
    public Image playerCharacterImage;
    public Sprite characterSprite1;
    public Sprite characterSprite2;

    private Player player; // Player ������Ʈ�� Reference

    void Start()
    {
        // Player ������Ʈ�� �±׷� ã�Ƽ� player ������ �Ҵ��մϴ�.
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null && playerObject.activeSelf)
        {
            player = playerObject.GetComponent<Player>();
            if (player == null)
            {
                Debug.LogWarning("Player ������Ʈ�� ã�� �� �����ϴ�. MainScene�� Player ������Ʈ�� �ִ��� Ȯ�����ּ���.");
                return;
            }
        }
        else
        {
            Debug.LogError("Player ������Ʈ�� ��Ȱ��ȭ�Ǿ� �ֽ��ϴ�.");
            return;
        }

        UpdateCharacterImage();
    }

    void UpdateCharacterImage()
    {
        if (player != null)
        {
            if (!PlayerPrefs.HasKey(Player.PLAYER_CHARACTER) || PlayerPrefs.GetInt(Player.PLAYER_CHARACTER) == 1)
            {
                playerCharacterImage.sprite = characterSprite1;
            }
            else
            {
                playerCharacterImage.sprite = characterSprite2;
            }
        }
        else
        {
            Debug.LogError("Player�� ã�� �� �����ϴ�.");
        }
    }

    public void OpenCharacterSelectPanel()
    {
        playerSelectPanel.SetActive(true);
    }

    public void SelectCharacter1()
    {
        if (player != null) // player�� null�� �ƴ��� Ȯ��
        {
            PlayerPrefs.SetInt(Player.PLAYER_CHARACTER, 1);
            Debug.Log("1��");
            UpdateCharacterImage();
            player.SetPlayerCharacter(PlayerCharacterType.ONE); // ����� �κ�
            playerSelectPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Player�� �������� �ʾҽ��ϴ�.");
        }
    }

    public void SelectCharacter2()
    {
        if (player != null) // player�� null�� �ƴ��� Ȯ��
        {
            PlayerPrefs.SetInt(Player.PLAYER_CHARACTER, 2);
            Debug.Log("2��");
            UpdateCharacterImage();
            player.SetPlayerCharacter(PlayerCharacterType.TWO); // ����� �κ�
            playerSelectPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Player�� �������� �ʾҽ��ϴ�.");
        }
    }
}