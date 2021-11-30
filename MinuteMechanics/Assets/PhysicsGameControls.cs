// GENERATED AUTOMATICALLY FROM 'Assets/PhysicsGameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PhysicsGameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PhysicsGameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PhysicsGameControls"",
    ""maps"": [
        {
            ""name"": ""PlayerMovement"",
            ""id"": ""5918c80d-f67d-4526-857f-d769c93203c2"",
            ""actions"": [
                {
                    ""name"": ""Pitch"",
                    ""type"": ""Value"",
                    ""id"": ""21bc1512-8d02-4154-aa8f-41fd322bb75a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CamRotate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""284b940d-aaac-429f-be6f-a9ed4b287a70"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""194d9415-93ea-49fd-9a0f-ef300a71b19e"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4 Controller"",
                    ""action"": ""Pitch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43d0ef27-10d8-4ba6-88f3-32934e8ab9d6"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PS4 Controller"",
                    ""action"": ""CamRotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PS4 Controller"",
            ""bindingGroup"": ""PS4 Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerMovement
        m_PlayerMovement = asset.FindActionMap("PlayerMovement", throwIfNotFound: true);
        m_PlayerMovement_Pitch = m_PlayerMovement.FindAction("Pitch", throwIfNotFound: true);
        m_PlayerMovement_CamRotate = m_PlayerMovement.FindAction("CamRotate", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // PlayerMovement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Pitch;
    private readonly InputAction m_PlayerMovement_CamRotate;
    public struct PlayerMovementActions
    {
        private @PhysicsGameControls m_Wrapper;
        public PlayerMovementActions(@PhysicsGameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pitch => m_Wrapper.m_PlayerMovement_Pitch;
        public InputAction @CamRotate => m_Wrapper.m_PlayerMovement_CamRotate;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Pitch.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPitch;
                @Pitch.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPitch;
                @Pitch.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnPitch;
                @CamRotate.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamRotate;
                @CamRotate.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamRotate;
                @CamRotate.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamRotate;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pitch.started += instance.OnPitch;
                @Pitch.performed += instance.OnPitch;
                @Pitch.canceled += instance.OnPitch;
                @CamRotate.started += instance.OnCamRotate;
                @CamRotate.performed += instance.OnCamRotate;
                @CamRotate.canceled += instance.OnCamRotate;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);
    private int m_PS4ControllerSchemeIndex = -1;
    public InputControlScheme PS4ControllerScheme
    {
        get
        {
            if (m_PS4ControllerSchemeIndex == -1) m_PS4ControllerSchemeIndex = asset.FindControlSchemeIndex("PS4 Controller");
            return asset.controlSchemes[m_PS4ControllerSchemeIndex];
        }
    }
    public interface IPlayerMovementActions
    {
        void OnPitch(InputAction.CallbackContext context);
        void OnCamRotate(InputAction.CallbackContext context);
    }
}
