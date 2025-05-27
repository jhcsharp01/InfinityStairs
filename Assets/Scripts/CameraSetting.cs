using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    public GameObject Target;

    private void Update()
    {
        if (Target != null)
        {
            transform.position = Target.transform.position + new Vector3(0, 2f, -10f);
        
        }

    }


}
