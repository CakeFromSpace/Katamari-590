// GENERATED AUTOMATICALLY FROM 'Assets/Prefabs/Player Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Controller"",
            ""id"": ""4683899c-72d2-4237-9bbc-a923eae528ab"",
            ""actions"": [
                {
                    ""name"": ""LeftMoveTank"",
                    ""type"": ""Value"",
                    ""id"": ""f0d33ccf-0f65-4511-a13b-99cede6e60d4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightMoveTank"",
                    ""type"": ""Value"",
                    ""id"": ""01104634-0a1d-483a-b0b2-7c65c245da66"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spin"",
                    ""type"": ""Button"",
                    ""id"": ""d1353c6e-5481-446c-b79e-8d5fa8bb36e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""3e343b13-091a-407c-9fc0-b8d198186c8c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""01faaa21-abeb-4e76-a090-59ea0db6c37d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""LeftMoveTank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""fee57d79-2dfa-4947-823f-6e930d2dbbee"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftMoveTank"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1199c31e-8ca7-4c90-ab33-4e307792ac4d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LeftMoveTank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6d5dcd7e-8791-4ce2-a6c7-efd0759e5089"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LeftMoveTank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""54116b30-5630-4e6f-8dfd-d402b4038c2e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LeftMoveTank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""10849ce2-f7b7-42ef-91ce-d5a45d152d21"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""LeftMoveTank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3ec3ffb8-011f-4611-9a02-35183ea7ebd2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Spin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4fe8e4b-2cdd-4c40-b00c-d645793e2f61"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Spin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb9de7af-1eb7-4a3f-9c11-d28fbc3ac4df"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59a65c15-c556-4f5a-b18b-f27536b68dd4"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6348fda-5419-48b0-a46e-766b91e64a2c"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""RightMoveTank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""de301fbc-8689-47dc-b8cb-d8e6a5bf628e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightMoveTank"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a20e681f-a0de-4e08-b28d-ee8bb5b5de77"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RightMoveTank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fd2a4d8d-1acd-4343-a45b-d48ed9c11662"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RightMoveTank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f9ca324c-9ab2-427a-9f0d-0ac469b72839"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RightMoveTank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ddc90973-78e9-495d-952f-8799d42f7999"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RightMoveTank"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
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
        // Controller
        m_Controller = asset.FindActionMap("Controller", throwIfNotFound: true);
        m_Controller_LeftMoveTank = m_Controller.FindAction("LeftMoveTank", throwIfNotFound: true);
        m_Controller_RightMoveTank = m_Controller.FindAction("RightMoveTank", throwIfNotFound: true);
        m_Controller_Spin = m_Controller.FindAction("Spin", throwIfNotFound: true);
        m_Controller_Pause = m_Controller.FindAction("Pause", throwIfNotFound: true);
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

    // Controller
    private readonly InputActionMap m_Controller;
    private IControllerActions m_ControllerActionsCallbackInterface;
    private readonly InputAction m_Controller_LeftMoveTank;
    private readonly InputAction m_Controller_RightMoveTank;
    private readonly InputAction m_Controller_Spin;
    private readonly InputAction m_Controller_Pause;
    public struct ControllerActions
    {
        private @PlayerControls m_Wrapper;
        public ControllerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftMoveTank => m_Wrapper.m_Controller_LeftMoveTank;
        public InputAction @RightMoveTank => m_Wrapper.m_Controller_RightMoveTank;
        public InputAction @Spin => m_Wrapper.m_Controller_Spin;
        public InputAction @Pause => m_Wrapper.m_Controller_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Controller; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllerActions set) { return set.Get(); }
        public void SetCallbacks(IControllerActions instance)
        {
            if (m_Wrapper.m_ControllerActionsCallbackInterface != null)
            {
                @LeftMoveTank.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnLeftMoveTank;
                @LeftMoveTank.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnLeftMoveTank;
                @LeftMoveTank.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnLeftMoveTank;
                @RightMoveTank.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnRightMoveTank;
                @RightMoveTank.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnRightMoveTank;
                @RightMoveTank.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnRightMoveTank;
                @Spin.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSpin;
                @Spin.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSpin;
                @Spin.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnSpin;
                @Pause.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_ControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftMoveTank.started += instance.OnLeftMoveTank;
                @LeftMoveTank.performed += instance.OnLeftMoveTank;
                @LeftMoveTank.canceled += instance.OnLeftMoveTank;
                @RightMoveTank.started += instance.OnRightMoveTank;
                @RightMoveTank.performed += instance.OnRightMoveTank;
                @RightMoveTank.canceled += instance.OnRightMoveTank;
                @Spin.started += instance.OnSpin;
                @Spin.performed += instance.OnSpin;
                @Spin.canceled += instance.OnSpin;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public ControllerActions @Controller => new ControllerActions(this);
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IControllerActions
    {
        void OnLeftMoveTank(InputAction.CallbackContext context);
        void OnRightMoveTank(InputAction.CallbackContext context);
        void OnSpin(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
