using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Quotes_Pac : MonoBehaviour
{




    public string type = "";
    public int age = 0;
    public string gender = "";

    [Serializable]
    public class policyHolder
    {
        public string type;
        public int age;
        public string gender;
        public termModulde term;
        public benefitsModule benefits;
    }


    [Serializable]
    public class termModulde
    {
        public string unit;
        public int value;
    }

    [Serializable]
    public class benefitsModule
    {
        public bool death;
        public bool disability;
        public string hospitalisation;
    }






    public void GetQuote()
    {
        if (string.IsNullOrEmpty(type))
        {
            throw new Exception("type cannot be empty");
        }

        else if (string.IsNullOrEmpty(gender))
        {
            throw new Exception("gender cannot be empty");
        }

        if (age < 18 || age == 0)
        {
            throw new Exception("The policy hodler needs to be above 18yrs and cannot be 0yrs old");

        }

        StartCoroutine(QuoteIEnumerator());
    }



    IEnumerator QuoteIEnumerator()
    {
        Auth Auth = new Auth();
        string URL = Auth.RootURL + "/quotes";
        string authKey = Auth.GetAuthKey();

        WWWForm form = new WWWForm();
        form.AddField("type", "root_pac");
        form.AddField("age", 30);
        form.AddField("gender", "male");

        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        www.SetRequestHeader("AUTHORIZATION", authKey);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("API Request failed");
            Debug.Log(www.error);
            Debug.Log(www.downloadHandler.text);

        }
        else
        {
            if (www.isDone)
            {
                Debug.Log("API request successfull");
                policyHolder policyholder = JsonUtility.FromJson<policyHolder>(www.downloadHandler.text);

                Debug.Log(policyholder.type);
            }
        }
    }
}
