// GENERATED AUTOMATICALLY FROM 'Assets/Script/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""07f35f23-e3b4-45f3-b439-a928e4890d3f"",
            ""actions"": [
                {
                    ""name"": ""GripButton"",
                    ""type"": ""Button"",
                    ""id"": ""76b2f1aa-ccb2-4494-a3c9-b2f7ef064db8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TriggerButton"",
                    ""type"": ""Button"",
                    ""id"": ""82198c53-6b3a-4bcd-9d3a-bc866883c393"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""08bb75f2-4296-44c6-b7dd-05f6106acc8e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5205ff3b-389d-4fc1-b033-0f58408d16b8"",
                    ""path"": ""<XRSimulatedController>/gripButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Right Controller;Left Controller;Controller"",
                    ""action"": ""GripButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""225377ef-d74e-4f82-8625-d9dba589790f"",
                    ""path"": ""<XRInputV1::Oculus::OculusTouchControllerLeft>/grippressed"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": ""Controller;Right Controller;Left Controller"",
                    ""action"": ""GripButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c2acf45b-26ac-4663-a4f1-57db53514245"",
                    ""path"": ""<OpenVROculusTouchController>/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller;Right Controller;Left Controller"",
                    ""action"": ""GripButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4818dfb5-6745-4074-a10e-a0978c44c7e9"",
                    ""path"": ""<XRSimulatedController>/triggerButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Right Controller;Left Controller;Controller"",
                    ""action"": ""TriggerButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""193b1835-265f-4f0e-aef6-6b11f3811aa5"",
                    ""path"": ""<OpenVROculusTouchController>/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6818d84-0cc0-4b1b-8bbe-b5ff4a66c5c7"",
                    ""path"": ""<OpenVROculusTouchController>/thumbstickClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71afbe75-7365-4453-b2b7-0f195cafec8d"",
                    ""path"": ""<OculusTouchController>{RightHand}/thumbstickClicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Right Controller;Controller"",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""id"": ""f013f5ae-3d20-4b60-87ea-f58a8ef65cbc"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""7565e1ba-1860-4f21-9c3c-a37190986c92"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3b0b303e-f165-4687-a4cc-96e0bb863b86"",
                    ""path"": ""<Keyboard>/0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a6bb242-968b-4d2e-9bf8-2a7236312d86"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""keyboard"",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Right Controller"",
            ""bindingGroup"": ""Right Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>{RightHand}"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Left Controller"",
            ""bindingGroup"": ""Left Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<XRController>{LeftHand}"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""keyboard"",
            ""bindingGroup"": ""keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_GripButton = m_Player.FindAction("GripButton", throwIfNotFound: true);
        m_Player_TriggerButton = m_Player.FindAction("TriggerButton", throwIfNotFound: true);
        m_Player_Newaction = m_Player.FindAction("New action", throwIfNotFound: true);
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_Newaction = m_Keyboard.FindAction("New action", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_GripButton;
    private readonly InputAction m_Player_TriggerButton;
    private readonly InputAction m_Player_Newaction;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @GripButton => m_Wrapper.m_Player_GripButton;
        public InputAction @TriggerButton => m_Wrapper.m_Player_TriggerButton;
        public InputAction @Newaction => m_Wrapper.m_Player_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @GripButton.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGripButton;
                @GripButton.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGripButton;
                @GripButton.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGripButton;
                @TriggerButton.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTriggerButton;
                @TriggerButton.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTriggerButton;
                @TriggerButton.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTriggerButton;
                @Newaction.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @GripButton.started += instance.OnGripButton;
                @GripButton.performed += instance.OnGripButton;
                @GripButton.canceled += instance.OnGripButton;
                @TriggerButton.started += instance.OnTriggerButton;
                @TriggerButton.performed += instance.OnTriggerButton;
                @TriggerButton.canceled += instance.OnTriggerButton;
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_Newaction;
    public struct KeyboardActions
    {
        private @InputMaster m_Wrapper;
        public KeyboardActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Keyboard_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    private int m_RightControllerSchemeIndex = -1;
    public InputControlScheme RightControllerScheme
    {
        get
        {
            if (m_RightControllerSchemeIndex == -1) m_RightControllerSchemeIndex = asset.FindControlSchemeIndex("Right Controller");
            return asset.controlSchemes[m_RightControllerSchemeIndex];
        }
    }
    private int m_LeftControllerSchemeIndex = -1;
    public InputControlScheme LeftControllerScheme
    {
        get
        {
            if (m_LeftControllerSchemeIndex == -1) m_LeftControllerSchemeIndex = asset.FindControlSchemeIndex("Left Controller");
            return asset.controlSchemes[m_LeftControllerSchemeIndex];
        }
    }
    private int m_keyboardSchemeIndex = -1;
    public InputControlScheme keyboardScheme
    {
        get
        {
            if (m_keyboardSchemeIndex == -1) m_keyboardSchemeIndex = asset.FindControlSchemeIndex("keyboard");
            return asset.controlSchemes[m_keyboardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnGripButton(InputAction.CallbackContext context);
        void OnTriggerButton(InputAction.CallbackContext context);
        void OnNewaction(InputAction.CallbackContext context);
    }
    public interface IKeyboardActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
