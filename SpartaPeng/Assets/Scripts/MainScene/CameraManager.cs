using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject target;           // ī�޶� ���� ���
    public float moveSpeed;             // ī�޶� ���� �ӵ�
    private Vector3 targetPosition;     // ����� ���� ��ġ

    private string FOLDER_PATH = $"{Application.dataPath}/ScreenShots/";
    private string TOTAL_PATH => $"{FOLDER_PATH}/MyScreenShot_{DateTime.Now.ToString("MMdd_HHmmss")}.png";

    void Update()
    {
        if (target.gameObject != null)
        {
            // this�� ī�޶�
            // Z ���� ī�޶� ���� �״�� ����
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);

            // vectorA -> B���� T�� �ӵ��� �̵�
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    // ��ũ���� ���
    public void OnPosterRender()
    {
        Camera.main.orthographicSize = 10f;

        Texture2D screenTex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        Rect area = new Rect(0, 0f, Screen.width, Screen.height);
        screenTex.ReadPixels(area, 0, 0);

        try
        {
            // ������ �������� ������ ���� ����
            if (Directory.Exists(FOLDER_PATH) == false)
            {
                Directory.CreateDirectory(FOLDER_PATH);
            }

            // ��ũ���� ����
            File.WriteAllBytes(TOTAL_PATH, screenTex.EncodeToPNG());
        } catch (Exception e)
        {
            Debug.Log(e);
        }
        Destroy(screenTex);

        Camera.main.orthographicSize = 5f;
    }
}
