using System.Collections;

using UnityEngine;
using UnityEngine.UI;

// Namespace declaration specific to VrGamesDev.
namespace VrGamesDev
{

    /// <summary>
    /// A public class named Example_Combat that inherits from VRG_Base.
    /// This class control the damage of heal of a simple combat
    /// 
    /// This script likely represents a basic combat system where a character 
    /// can take damage and heal, with health values and actions controlled 
    /// by UI buttons. It also demonstrates fetching configuration data 
    /// remotely, which is a useful feature for games that require live 
    /// updates or tuning without deploying new versions.
    /// 
    /// </summary>
    
    public class Example_Combat : VRG_Base
    {
        // Serialized fields for remote configuration keys. These keys are used to fetch values from a remote config.
        [Header("From: Remote - Keys")]
        [SerializeField] private string m_AttackRemoteKey = "A_Simple_Combat.Attack";
        [SerializeField] private string m_HealRemoteKey = "A_Simple_Combat.Heal";
        [SerializeField] private string m_HealthRemoteKey = "A_Simple_Combat.Health";

        // Serialized fields for game parameter values like attack, heal, and max health.
        // These values are initialized and later updated from the remote configuration.
        [Header("From: Remote - Values")]
        [SerializeField] private int m_Attack = 1;
        [SerializeField] private int m_Heal = 1;
        [SerializeField] private int m_MaxHealth = 1;

        // Serialized fields for the current health of the player and a graphical representation of the health.
        [Header("From: Combat")]
        [SerializeField] private int m_Health = 1;
        [SerializeField] private VRG_GraphicalNumber m_HealthDisplay = null;

        // UI elements for attack and heal actions.
        [SerializeField] private Button m_buttonAttack = null;
        [SerializeField] private Button m_buttonHeal = null;

        // Array of Transforms that should be activated (made visible) when the player die.
        [Header("From: OnLoad")]
        /// <summary>
        /// Array of the transform to activate <em>setActive(true)</em>
        /// </summary>
        [Tooltip("Array of the transform to activate setActive(true)")]
        [SerializeField] protected Transform[] m_Activate = null;

        // Coroutine called after the object initialization.
        // It fetches combat-related values from a remote configuration system.
        protected override IEnumerator Do()
        {
            // Wait for the remote configuration to be validated.
            yield return VRG_Remote.IsValid();

            // Update attack, heal, and health values from the remote configuration.
            this.m_Attack    = VRG_Remote.GetInt(this.m_AttackRemoteKey);
            this.m_Heal      = VRG_Remote.GetInt(this.m_HealRemoteKey);

            // Sets both current and maximum health to the value from the remote config.
            this.m_MaxHealth = 
            this.m_Health    = this.m_Health = VRG_Remote.GetInt(this.m_HealthRemoteKey);

            this.m_buttonAttack.interactable = true;
            this.m_buttonHeal.interactable = true;
            
            // Update the graphical health display.
            this.m_HealthDisplay.SetNumber(this.m_Health);

            // Waits until the next frame.
            yield return null;
        }

        // Method called to simulate taking damage.
        // Decreases health by the attack value and updates UI and state accordingly.
        public void Damage()
        {
            this.m_Health -= this.m_Attack;

            // If health drops to 0 or below, disable interaction and activate certain GameObjects.
            if (this.m_Health <= 0)
            {
                this.m_Health = 0;
                this.m_buttonAttack.interactable = false;
                this.m_buttonHeal.interactable = false;

                foreach (Transform child in this.m_Activate)
                {
                    if (child != null)
                    {
                        child.gameObject.SetActive(true);
                    }
                }
            }

            // Update the graphical health display.
            this.m_HealthDisplay.SetNumber(this.m_Health);
        }

        // Method called to simulate healing.
        // Increases health by the heal value without exceeding max health, and updates the health display.
        public void Heal()
        {
            this.m_Health += this.m_Heal;

            if (this.m_Health > this.m_MaxHealth)
            {
                this.m_Health = this.m_MaxHealth;
            }

            // Update the graphical health display.
            this.m_HealthDisplay.SetNumber(this.m_Health);
        }
    }
}
