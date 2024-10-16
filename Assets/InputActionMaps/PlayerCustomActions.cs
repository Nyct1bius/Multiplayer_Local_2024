//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputActionMaps/PlayerCustomActions.inputactions
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

public partial class @PlayerCustomActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerCustomActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerCustomActions"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""70fb6bab-25ca-49e3-aee6-45b2aade4597"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""e9a10bd5-cd85-4fe3-89a9-1ca54cb51d71"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Camera1"",
                    ""type"": ""Button"",
                    ""id"": ""336c5063-ec30-443f-ac70-6468798f31a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Camera2"",
                    ""type"": ""Button"",
                    ""id"": ""6eec81b2-9f74-47b6-a3f6-85940d100159"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Camera3"",
                    ""type"": ""Button"",
                    ""id"": ""0f19afa9-b0ee-4db0-b56f-dd689b16b0f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f3dfd58e-0ac3-47ad-b067-8ddde381f5aa"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c02b16fd-832b-4acd-b58b-890faf4a544e"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc6c4532-dc60-4887-b59a-a142dea1a058"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f08f362-eb18-4c4e-9316-3e2aa2a721aa"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_Move = m_Main.FindAction("Move", throwIfNotFound: true);
        m_Main_Camera1 = m_Main.FindAction("Camera1", throwIfNotFound: true);
        m_Main_Camera2 = m_Main.FindAction("Camera2", throwIfNotFound: true);
        m_Main_Camera3 = m_Main.FindAction("Camera3", throwIfNotFound: true);
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

    // Main
    private readonly InputActionMap m_Main;
    private List<IMainActions> m_MainActionsCallbackInterfaces = new List<IMainActions>();
    private readonly InputAction m_Main_Move;
    private readonly InputAction m_Main_Camera1;
    private readonly InputAction m_Main_Camera2;
    private readonly InputAction m_Main_Camera3;
    public struct MainActions
    {
        private @PlayerCustomActions m_Wrapper;
        public MainActions(@PlayerCustomActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Main_Move;
        public InputAction @Camera1 => m_Wrapper.m_Main_Camera1;
        public InputAction @Camera2 => m_Wrapper.m_Main_Camera2;
        public InputAction @Camera3 => m_Wrapper.m_Main_Camera3;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void AddCallbacks(IMainActions instance)
        {
            if (instance == null || m_Wrapper.m_MainActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MainActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Camera1.started += instance.OnCamera1;
            @Camera1.performed += instance.OnCamera1;
            @Camera1.canceled += instance.OnCamera1;
            @Camera2.started += instance.OnCamera2;
            @Camera2.performed += instance.OnCamera2;
            @Camera2.canceled += instance.OnCamera2;
            @Camera3.started += instance.OnCamera3;
            @Camera3.performed += instance.OnCamera3;
            @Camera3.canceled += instance.OnCamera3;
        }

        private void UnregisterCallbacks(IMainActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Camera1.started -= instance.OnCamera1;
            @Camera1.performed -= instance.OnCamera1;
            @Camera1.canceled -= instance.OnCamera1;
            @Camera2.started -= instance.OnCamera2;
            @Camera2.performed -= instance.OnCamera2;
            @Camera2.canceled -= instance.OnCamera2;
            @Camera3.started -= instance.OnCamera3;
            @Camera3.performed -= instance.OnCamera3;
            @Camera3.canceled -= instance.OnCamera3;
        }

        public void RemoveCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMainActions instance)
        {
            foreach (var item in m_Wrapper.m_MainActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MainActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MainActions @Main => new MainActions(this);
    public interface IMainActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnCamera1(InputAction.CallbackContext context);
        void OnCamera2(InputAction.CallbackContext context);
        void OnCamera3(InputAction.CallbackContext context);
    }
}
