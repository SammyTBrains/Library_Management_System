using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeletePrefabButton : MonoBehaviour
{
    public void DeleteButtonFunction()
    {
        DeleteButton.Instance.DeleteButtonActivity();
    }

    public void DeleteButtonActivityLB()
    {
        Text bName = this.gameObject.transform.GetChild(1).GetComponent<Text>();
        Text author = this.gameObject.transform.GetChild(2).GetComponent<Text>();
        Text date = this.gameObject.transform.GetChild(3).GetComponent<Text>();

        DBFunction.Instance.SetDeleteLBData(bName.text, author.text, date.text, this.gameObject);
    }

    public void DeleteButtonActivityBT_L()
    {
        Text bName = this.gameObject.transform.GetChild(1).GetComponent<Text>();
        Text author = this.gameObject.transform.GetChild(2).GetComponent<Text>();
        Text nameOStudent = this.gameObject.transform.GetChild(3).GetComponent<Text>();
        Text matricNo = this.gameObject.transform.GetChild(4).GetComponent<Text>();
        Text department = this.gameObject.transform.GetChild(5).GetComponent<Text>();
        Text date = this.gameObject.transform.GetChild(6).GetComponent<Text>();

        DBFunction.Instance.SetDeleteLBT_LData(bName.text, author.text, nameOStudent.text, matricNo.text, department.text, date.text, this.gameObject);
    }
}
