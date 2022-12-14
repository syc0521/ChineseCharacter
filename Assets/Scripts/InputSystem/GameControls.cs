//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/InputSystem/GameControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @GameControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""f2773bcc-a8d5-4b7e-bab3-4aac8fa30e77"",
            ""actions"": [
                {
                    ""name"": ""MouseLeft"",
                    ""type"": ""Button"",
                    ""id"": ""461d0791-0d4f-46f0-90a4-799dfbfeb82a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseRight"",
                    ""type"": ""Button"",
                    ""id"": ""b81c3149-39b5-4d01-848f-a8c56279aa66"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseDrag"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e79492ea-497b-4f3e-98f5-1935047088e1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MouseRoll"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2c22ad19-b060-48c0-9763-9043abe3f437"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""de895e11-6439-49cd-8206-399d5704336e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a476f582-15f2-490e-bf56-3b00b20a9fb4"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""282183c1-03ba-4475-81a4-e195a65f8834"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5293a304-50b6-497b-94d2-21330e73b1ea"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseDrag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab170fe7-284a-4a0d-81cf-9415babeb810"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseRoll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b84d003-ea08-4a7f-8291-bb076ea7038d"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_MouseLeft = m_GamePlay.FindAction("MouseLeft", throwIfNotFound: true);
        m_GamePlay_MouseRight = m_GamePlay.FindAction("MouseRight", throwIfNotFound: true);
        m_GamePlay_MouseDrag = m_GamePlay.FindAction("MouseDrag", throwIfNotFound: true);
        m_GamePlay_MouseRoll = m_GamePlay.FindAction("MouseRoll", throwIfNotFound: true);
        m_GamePlay_Exit = m_GamePlay.FindAction("Exit", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_MouseLeft;
    private readonly InputAction m_GamePlay_MouseRight;
    private readonly InputAction m_GamePlay_MouseDrag;
    private readonly InputAction m_GamePlay_MouseRoll;
    private readonly InputAction m_GamePlay_Exit;
    public struct GamePlayActions
    {
        private @GameControls m_Wrapper;
        public GamePlayActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseLeft => m_Wrapper.m_GamePlay_MouseLeft;
        public InputAction @MouseRight => m_Wrapper.m_GamePlay_MouseRight;
        public InputAction @MouseDrag => m_Wrapper.m_GamePlay_MouseDrag;
        public InputAction @MouseRoll => m_Wrapper.m_GamePlay_MouseRoll;
        public InputAction @Exit => m_Wrapper.m_GamePlay_Exit;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @MouseLeft.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseLeft;
                @MouseLeft.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseLeft;
                @MouseLeft.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseLeft;
                @MouseRight.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseRight;
                @MouseRight.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseRight;
                @MouseRight.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseRight;
                @MouseDrag.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseDrag;
                @MouseDrag.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseDrag;
                @MouseDrag.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseDrag;
                @MouseRoll.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseRoll;
                @MouseRoll.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseRoll;
                @MouseRoll.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMouseRoll;
                @Exit.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnExit;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseLeft.started += instance.OnMouseLeft;
                @MouseLeft.performed += instance.OnMouseLeft;
                @MouseLeft.canceled += instance.OnMouseLeft;
                @MouseRight.started += instance.OnMouseRight;
                @MouseRight.performed += instance.OnMouseRight;
                @MouseRight.canceled += instance.OnMouseRight;
                @MouseDrag.started += instance.OnMouseDrag;
                @MouseDrag.performed += instance.OnMouseDrag;
                @MouseDrag.canceled += instance.OnMouseDrag;
                @MouseRoll.started += instance.OnMouseRoll;
                @MouseRoll.performed += instance.OnMouseRoll;
                @MouseRoll.canceled += instance.OnMouseRoll;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    public interface IGamePlayActions
    {
        void OnMouseLeft(InputAction.CallbackContext context);
        void OnMouseRight(InputAction.CallbackContext context);
        void OnMouseDrag(InputAction.CallbackContext context);
        void OnMouseRoll(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
    }
}
