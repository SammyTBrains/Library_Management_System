using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateButton : MonoBehaviour
{
    public void UpdateButtonActivityLB()
    {
        Text bName = this.gameObject.transform.GetChild(1).GetComponent<Text>();
        Text author = this.gameObject.transform.GetChild(2).GetComponent<Text>();
        Text date = this.gameObject.transform.GetChild(3).GetComponent<Text>();
      
        DBFunction.Instance.UpdateLBData(bName.text, author.text, date.text);
    }

    public void UpdateButtonActivityBT_L()
    {
        Text bName = this.gameObject.transform.GetChild(1).GetComponent<Text>();
        Text author = this.gameObject.transform.GetChild(2).GetComponent<Text>();
        Text nameOStudent = this.gameObject.transform.GetChild(3).GetComponent<Text>();
        Text matricNo = this.gameObject.transform.GetChild(4).GetComponent<Text>();
        Text department = this.gameObject.transform.GetChild(5).GetComponent<Text>();
        Text date = this.gameObject.transform.GetChild(6).GetComponent<Text>();

        DBFunction.Instance.UpdateLBT_LData(bName.text, author.text, nameOStudent.text, matricNo.text, department.text, date.text);
    }
}
