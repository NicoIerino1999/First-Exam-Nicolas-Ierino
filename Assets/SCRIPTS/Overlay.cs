using UnityEngine;
using UnityEngine.InputSystem;

public class PressToStart : MonoBehaviour
{
    [SerializeField] private GameObject overlay; 
    [SerializeField] private PlayerController player; 

    private bool started = false;

    private void Update()
    {
        if (!started && Keyboard.current.anyKey.wasPressedThisFrame)
        {
            overlay.SetActive(false); 
            player.enabled = true;    
            started = true;
        }
    }
}