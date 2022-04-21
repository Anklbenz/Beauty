// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputReceiver : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputReceiver()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""5b4b8ab7-e2a9-41f4-93cd-3de91853011d"",
            ""actions"": [
                {
                    ""name"": ""DoubleTap"",
                    ""type"": ""Button"",
                    ""id"": ""4ad11a6f-9b39-4aad-b7d1-6b7194da09c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimatyTouch"",
                    ""type"": ""Button"",
                    ""id"": ""e7f3a906-d1fd-4e73-9bd5-0eaa96f23ac2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""PrimaryPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""11286c10-788f-4a37-a0e1-690d78cb185e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9b0aaafd-314b-49ae-a9e3-68b893f4045c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""MultiTap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DoubleTap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd51450f-27e0-4d9e-8710-b8e0117ccdde"",
                    ""path"": ""<Touchscreen>/primaryTouch/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimatyTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89bb5eff-c088-466a-b4e7-2a8c768501e5"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_DoubleTap = m_Touch.FindAction("DoubleTap", throwIfNotFound: true);
        m_Touch_PrimatyTouch = m_Touch.FindAction("PrimatyTouch", throwIfNotFound: true);
        m_Touch_PrimaryPosition = m_Touch.FindAction("PrimaryPosition", throwIfNotFound: true);
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

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_DoubleTap;
    private readonly InputAction m_Touch_PrimatyTouch;
    private readonly InputAction m_Touch_PrimaryPosition;
    public struct TouchActions
    {
        private @InputReceiver m_Wrapper;
        public TouchActions(@InputReceiver wrapper) { m_Wrapper = wrapper; }
        public InputAction @DoubleTap => m_Wrapper.m_Touch_DoubleTap;
        public InputAction @PrimatyTouch => m_Wrapper.m_Touch_PrimatyTouch;
        public InputAction @PrimaryPosition => m_Wrapper.m_Touch_PrimaryPosition;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @DoubleTap.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnDoubleTap;
                @DoubleTap.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnDoubleTap;
                @DoubleTap.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnDoubleTap;
                @PrimatyTouch.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimatyTouch;
                @PrimatyTouch.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimatyTouch;
                @PrimatyTouch.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimatyTouch;
                @PrimaryPosition.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryPosition;
                @PrimaryPosition.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnPrimaryPosition;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DoubleTap.started += instance.OnDoubleTap;
                @DoubleTap.performed += instance.OnDoubleTap;
                @DoubleTap.canceled += instance.OnDoubleTap;
                @PrimatyTouch.started += instance.OnPrimatyTouch;
                @PrimatyTouch.performed += instance.OnPrimatyTouch;
                @PrimatyTouch.canceled += instance.OnPrimatyTouch;
                @PrimaryPosition.started += instance.OnPrimaryPosition;
                @PrimaryPosition.performed += instance.OnPrimaryPosition;
                @PrimaryPosition.canceled += instance.OnPrimaryPosition;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    public interface ITouchActions
    {
        void OnDoubleTap(InputAction.CallbackContext context);
        void OnPrimatyTouch(InputAction.CallbackContext context);
        void OnPrimaryPosition(InputAction.CallbackContext context);
    }
}
