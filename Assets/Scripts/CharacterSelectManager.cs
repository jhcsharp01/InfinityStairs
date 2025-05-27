using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectManager : MonoBehaviour
{
    //Animator Controller는 Inspector에서 컨트롤러 파일을 조작할 때 사용되는 타입
    //런타임에서 컨트롤러를 바꾸거나 애니메이션을 적용할 때
    //RuntimeAnimatorController 컴포넌트를 통해 등록

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
            Debug.Log("애니메이터 컴포넌트가 없습니다.");
        }

        
    }
}
