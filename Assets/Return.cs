using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour
{
    public GameObject menuToClose;

    public void ReturnUI()
    {
        menuToClose.SetActive(false);
    }
}
