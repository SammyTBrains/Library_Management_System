using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteButton : MonoBehaviour
{
    private static DeleteButton instance;
    public static DeleteButton Instance
    {
        get
        {
            if(instance == null)
            {
                Debug.Log("Delete Button is null!");
            }

            return instance;
        }
    }

    [SerializeField]
    private GameObject _deletePopUp;

    private void Awake()
    {
        instance = this;
    }

    public void DeleteButtonActivity()
    {
        _deletePopUp.SetActive(true);
    }

    public void DontDelete()
    {
        _deletePopUp.SetActive(false);
    }
}
