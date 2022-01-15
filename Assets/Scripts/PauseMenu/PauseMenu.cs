using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

namespace PauseMenu
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject Pausemenu;

        public GameObject LocomotionSystem;

        public InputActionReference LeftTogglePauseRefrence = null;
        public InputActionReference RightTogglePauseRefrence = null;

        public XRRayInteractor ray_Right;
        public XRRayInteractor ray_Left;

        public bool RightTeleport;
        public bool LeftTeleport;
        
        public GameObject TeleportManagzerLeft;
        public GameObject TeleportManagzerRight;
        
        public static bool started;

        private void Awake()
        {
            started = false;
        
            LeftTogglePauseRefrence.action.started += Toggle;
            RightTogglePauseRefrence.action.started += Toggle;
        }

        private void OnDestroy()
        {
            LeftTogglePauseRefrence.action.started += Toggle;
            RightTogglePauseRefrence.action.started += Toggle;
        }
    
    
        private void Toggle(InputAction.CallbackContext context)
        {
            Debug.Log("Menu button is pressed");
            PauseMenuCheck();
        }

        public void PauseMenuCheck()
        {
            if (started == false)
            {
                Show();
                started = true;
            }
            else
            {
                Hide();
                started = false;
            }
        }
    

        public void Show()
        {
            Time.timeScale = 0f;

            ray_Right.enabled = true;
            ray_Left.enabled = true;

            LocomotionSystem.SetActive(false);

            TeleportManagzerLeft.SetActive(false);
            TeleportManagzerRight.SetActive(false);
            
            Pausemenu.SetActive(true);
        }

        public void Hide()
        {
            Time.timeScale = 1f;

            ray_Right.enabled = false;
            ray_Left.enabled = false;

            LocomotionSystem.SetActive(true);
            
            if (RightTeleport)
            {
                TeleportManagzerRight.SetActive(true);
            } 
            else 
            {
                if (LeftTeleport)
                {
                    TeleportManagzerLeft.SetActive(true);
                }
            }

            Pausemenu.SetActive(false);
        }
    
        public void MainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void Restart()
        {
            SceneManager.LoadScene(1);
        }
    }
}