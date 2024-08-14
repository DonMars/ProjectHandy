using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Unity.Services.Analytics
{
    public class MyEventCustom : Event
    {
        public MyEventCustom() : base("MyEventCustom")
        {
        }

        public string myString { set { SetParameter("myString", value); } }
        public int myInt { set { SetParameter("myInt", value); } }
        public bool myBool { set { SetParameter("myBool", value); } }
    }

    public class CustomEvent_Hakari : MonoBehaviour
    {
        public bool m_Parameters = false;

        public int m_IntData = 0;

        public string m_StringData = "nada";

        // Start is called before the first frame update
        void OnEnable()
        {
            if (this.m_Parameters)
            {
                // NOTE: this will show up on the dashboard as an invalid event, unless
                // you have created a schema that matches it.
                MyEventCustom MyEventCustom = new MyEventCustom
                {
                    myString = this.m_StringData,
                    myInt = this.m_IntData,
                    myBool = true
                };

                AnalyticsService.Instance.RecordEvent(MyEventCustom);
            }
            else
            {
                AnalyticsService.Instance.RecordEvent("NoParams");
            }
        }
    }
}