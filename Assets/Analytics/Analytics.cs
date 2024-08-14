using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class InitWithDefault : MonoBehaviour
{
    async void Start()
    {
        print(Time.frameCount + ") " + "await UnityServices.InitializeAsync();");
		await UnityServices.InitializeAsync();

		AskForConsent();
    }

	void AskForConsent()
	{
        print(Time.frameCount + ") " + "void AskForConsent1()");
		// ... show the player a UI element that asks for consent.

        ConsentGiven();
	}

	void ConsentGiven()
	{
        print(Time.frameCount + ") " + "void ConsentGiven()");
		AnalyticsService.Instance.StartDataCollection();

        print(Time.frameCount + ") " + "AnalyticsService.Instance.StartDataCollection();");

	}
}