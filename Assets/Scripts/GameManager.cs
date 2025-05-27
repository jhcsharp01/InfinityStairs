using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Character; //ĳ����
    public GameObject Platform; //����
    public Transform Platform_Parents; //���� ����� ��ġ

    public int platform_pos_idx = 0; //���� ��ġ�� ���� �ε��� ��
    public int character_pos_idx = 0; //ĳ���� ��ġ�� ���� �ε��� ��    
    public bool isPlaying = false; //���� ����

    //�÷��� ����Ʈ(��ġ�Ǿ��ִ� ��)
    private List<GameObject> Platform_List = new List<GameObject>();
    //�÷����� ���� üũ ����Ʈ (������ ��ġ)
    private List<int> Platform_Check_List = new List<int>();

    private void Start()
    {
        SetFlatform(); //���� ����
        Init(); //���� �ʱ�ȭ
    }

    private void Update()
    {
        //�÷��� �����
        if(isPlaying)
        {
            //������ ����� �׽�Ʈ������, ��ư�� ���� Ŭ������ ������ ����
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                Check_Platform(character_pos_idx, 1);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Check_Platform(character_pos_idx, 0);
            }
        }
    }

    private void Check_Platform(int idx, int direction)
    {
        //[üũ Ȯ�ο� �ڵ�]
        Debug.Log("�ε��� �� : " + idx + "/�÷��� : " + Platform_Check_List[idx] + "/���� : " + direction);

        //������ ���� ���
        if (Platform_Check_List[idx % 20] ==  direction)
        {

            //ĳ������ ��ġ ����
            character_pos_idx++;
            Character.transform.position = Platform_List[idx].transform.position
                + new Vector3(0f, 0.4f, 0f);

            //�ٴ� ����
            NextFlatform(platform_pos_idx);

        }
        else
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("���� ����"); //�����δ� UI�� ���� ������ ���� �г� Ȱ��ȭ
                                //���ھ� ����
                                
        isPlaying = false;
    }

    private void Init()
    {
        Character.transform.position = Vector3.zero;

        for (platform_pos_idx = 0; platform_pos_idx < 20; platform_pos_idx++)
        {
            NextPlatform(platform_pos_idx);
        }

        character_pos_idx = 0;
        isPlaying = true; //���Ŀ��� �÷��� ��ư�� ������ �� ����ǵ��� ��������� �մϴ�.

    }

    private void NextPlatform(int idx)
    {
        int pos = UnityEngine.Random.Range(0, 2);

        if(idx == 0)
        {
            //Platform_Check_List[idx] = pos;
            Platform_List[idx].transform.position = new Vector3(0, -0.5f,0);
        }
        else
        {
            if(platform_pos_idx < 20)
            {
                if (pos == 0)
                {
                    Platform_Check_List[idx] = pos;
                    Platform_List[idx].transform.position = Platform_List[idx - 1].transform.position + new Vector3(-1, 0.5f, 0);
                }
                else
                {
                    Platform_Check_List[idx] = pos;
                    Platform_List[idx].transform.position = Platform_List[idx - 1].transform.position + new Vector3(1, 0.5f, 0);
                }
            }
            else //�ε��� ������ ���� ���
            {
                //���� ����
                if (pos == 0)
                {     
                    if(idx % 20 == 0)
                    {
                        Platform_Check_List[19] = pos;
                        Platform_List[idx % 20].transform.position = Platform_List[19].transform.position + new Vector3(-1, 0.5f, 0);
                    }
                    else
                    {
                        Platform_Check_List[idx % 20] = pos;
                        Platform_List[idx % 20].transform.position = Platform_List[idx % 20].transform.position + new Vector3(-1, 0.5f, 0);
                    }
                }
                //������ ����
                else
                {
                    if (idx % 20 == 0)
                    {
                        Platform_Check_List[19] = pos;
                        Platform_List[idx % 20].transform.position = Platform_List[19].transform.position + new Vector3(1, 0.5f, 0);
                    }
                    else
                    {
                        Platform_Check_List[idx % 20] = pos;
                        Platform_List[idx % 20].transform.position = Platform_List[idx % 20].transform.position + new Vector3(1, 0.5f, 0);
                    }
                }
            }        
        }     
    }

    private void SetFlatform()
    {
        //������ ���ڸ�ŭ �÷��� ����
        for (int i = 0; i < 20; i++)
        { 
            GameObject plat = Instantiate(Platform, Vector3.zero, Quaternion.identity, Platform_Parents);
            Platform_List.Add(plat);
            Platform_Check_List.Add(0);
        }

    }
}
