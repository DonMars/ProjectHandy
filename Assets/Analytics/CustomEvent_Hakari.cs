using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Unity.Services.Analytics
{
    public class CacasRecogidas : Event
    {
        public CacasRecogidas() : base("CacasRecogidas")
        {
        }

        public float myFloat { set { SetParameter("cacasRecogidas", value); } }
    }

    public class CustomEvent_Hakari : MonoBehaviour
    {
        // Start is called before the first frame update
        public void ContarCacas()
        {
            CacasRecogidas CacasRecogidas = new CacasRecogidas
            {
                myFloat = GameManager.Instance.goldenPoop
            };

            AnalyticsService.Instance.RecordEvent(CacasRecogidas);
        }

        //public void ContarCacas()
        //{
        //    MyEventCustom MyEventCustom = new MyEventCustom
        //    {
        //        myString = this.m_StringData,
        //        myInt = this.m_IntData,
        //        myBool = true
        //    };

        //    AnalyticsService.Instance.RecordEvent(MyEventCustom);
        //}
    }
}