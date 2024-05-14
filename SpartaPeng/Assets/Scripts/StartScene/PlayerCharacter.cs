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

    private Player player; // Player 오브젝트의 Reference

    void Start()
    {
        // Player 오브젝트를 태그로 찾아서 player 변수에 할당합니다.
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null && playerObject.activeSelf)
        {
            player = playerObject.GetComponent<Player>();
            if (player == null)
            {
                Debug.LogWarning("Player 오브젝트를 찾을 수 없습니다. MainScene에 Player 오브젝트가 있는지 확인해주세요.");
                return;
            }
        }
        else
        {
            Debug.LogError("Player 오브젝트가 비활성화되어 있습니다.");
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
            Debug.LogError("Player가 찾을 수 없습니다.");
        }
    }

    public void OpenCharacterSelectPanel()
    {
        playerSelectPanel.SetActive(true);
    }

    public void SelectCharacter1()
    {
        if (player != null) // player가 null이 아닌지 확인
        {
            PlayerPrefs.SetInt(Player.PLAYER_CHARACTER, 1);
            Debug.Log("1번");
            UpdateCharacterImage();
            player.SetPlayerCharacter(PlayerCharacterType.ONE); // 변경된 부분
            playerSelectPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Player가 설정되지 않았습니다.");
        }
    }

    public void SelectCharacter2()
    {
        if (player != null) // player가 null이 아닌지 확인
        {
            PlayerPrefs.SetInt(Player.PLAYER_CHARACTER, 2);
            Debug.Log("2번");
            UpdateCharacterImage();
            player.SetPlayerCharacter(PlayerCharacterType.TWO); // 변경된 부분
            playerSelectPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Player가 설정되지 않았습니다.");
        }
    }
}