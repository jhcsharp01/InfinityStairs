using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectManager : MonoBehaviour
{
    //Animator Controller�� Inspector���� ��Ʈ�ѷ� ������ ������ �� ���Ǵ� Ÿ��
    //��Ÿ�ӿ��� ��Ʈ�ѷ��� �ٲٰų� �ִϸ��̼��� ������ ��
    //RuntimeAnimatorController ������Ʈ�� ���� ���

    public RuntimeAnimatorController[] animatorControllers;

    public Sprite[] sprites;

    public GameObject Player;

    public Button CharacterButton;

    public int current_idx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current_idx = 0;
        CharacterButton.onClick.AddListener(CharacterSelect);
 
    }

    public void CharacterSelect()
    {
       current_idx = (current_idx + 1) % animatorControllers.Length;
      SpawnCharacter(current_idx);
    }

    private void SpawnCharacter(int idx)
    {
        Animator animator = Player.GetComponent<Animator>();
        if (Player != null)
        {
            animator.runtimeAnimatorController = animatorControllers[idx];
            Player.GetComponent<SpriteRenderer>().sprite = sprites[idx];
        }
        else
        {
            Debug.Log("�ִϸ����� ������Ʈ�� �����ϴ�.");
        }

        
    }
}
