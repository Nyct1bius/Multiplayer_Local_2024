using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        DisableSelf();
    }

    private IEnumerator DisableSelf()
    {
        yield return new WaitForSeconds(0.5f);

        this.gameObject.SetActive(false);
    }
}
