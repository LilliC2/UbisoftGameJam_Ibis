//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Multiplayer/PlayerControls.inputactions
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

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""bf8f7e86-8e2f-43b1-9cf8-5d6dbb85adb6"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3a1a7e42-a23b-4c52-89a2-5bf233bfb714"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Move Ibis Head"",
                    ""type"": ""Value"",
                    ""id"": ""3388aa6d-b775-4348-8369-5aba944c6001"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""ResetIbisHeadRotations"",
                    ""type"": ""Button"",
                    ""id"": ""50fb276d-3bcc-4fd0-a5bc-52ac9072d35e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pick Up and Drop Item"",
                    ""type"": ""Button"",
                    ""id"": ""a893eb2b-620c-4483-948b-fb0251a45b3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Honk"",
                    ""type"": ""Button"",
                    ""id"": ""dd09bd39-557a-48dc-8df1-2e4165fff7a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""4923c020-e7e9-49fd-a89d-17e57ad00644"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""7f2dafb3-df8f-4fba-9f6b-28ed01063fb4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""UpEmote"",
                    ""type"": ""Button"",
                    ""id"": ""712caa58-ed80-46d1-aa6e-458eee899819"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""DownEmote"",
                    ""type"": ""Button"",
                    ""id"": ""fd23535c-8fa8-44b3-8ab2-2507f043da6f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LeftEmote"",
                    ""type"": ""Button"",
                    ""id"": ""7badbc56-0d47-4e1e-9011-4b6ba24b8570"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RightEmote"",
                    ""type"": ""Button"",
                    ""id"": ""4915c48b-8274-4a6d-a649-387cabd762a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""aa816561-c1e8-4989-b5dd-ef875e534647"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD 2D Vector"",
                    ""id"": ""e1a4f393-1f08-4fb5-adb2-b9a97f9ce75c"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ba19503f-f843-4217-8498-38d447a61d04"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""dc37f7c5-f956-46f6-99d1-2874531d2ae7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9afaa98b-52bc-45e4-9d8e-980c313e3ab0"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ee1ca30d-16de-4f2c-9e96-5fbead57acd4"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c9d879a7-2a55-45a5-a0ef-76fbbe898558"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Ibis Head"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""161911c9-29b4-48ae-842c-8e9c992e4ca6"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ResetIbisHeadRotations"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow Key 2D Vector"",
                    ""id"": ""c22ba64a-8518-4e0e-8904-8694dc9d5a76"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Ibis Head"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e8712164-be31-4019-87aa-bab7efd54461"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Ibis Head"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a8df18b0-5c56-4bbf-8dc2-eed2ec47b96f"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Ibis Head"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4872b6a9-1ca0-4a69-8caf-a7ea1bf1fd6c"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Ibis Head"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""cb668f25-dabe-431f-bfbb-a6d9e58409e8"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Ibis Head"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""08142e33-ec82-49e8-ae89-5e5430574b63"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pick Up and Drop Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bee242b4-619e-46d0-8e3c-29f4383507bc"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pick Up and Drop Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44e74467-58a5-4426-8a5c-2785d7ab1ccb"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Honk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d521a3e-6b48-4e73-87fe-7ca0e216f047"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Honk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9ca6433e-5e8f-41f4-aef1-6b05888d2519"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f46c1814-61b3-449b-96b3-51cfbb122cd9"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a13594a-18a1-492d-a4d4-839fbb7293c2"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""881e4772-ab17-4387-a7f1-37cbe0d11acd"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8b34abd-efd4-4165-9acf-347477539d3e"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UpEmote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd38c744-e759-4468-a0c0-e742b1e1dcbc"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""DownEmote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""11778329-84f8-4780-9074-5b08bb8f6c1d"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftEmote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e5f021a-eeae-4f38-bba5-f1cc88c5a083"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightEmote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""98156836-f5a3-4292-90cc-db9cde4b2081"",
            ""actions"": [
                {
                    ""name"": ""ReadyUP"",
                    ""type"": ""Button"",
                    ""id"": ""ae4efb8d-c2fc-4348-9be7-6853779f92c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""916446d6-cd95-447e-af5c-513f138b8ce6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Move Ibis Head"",
                    ""type"": ""Value"",
                    ""id"": ""1610af81-a408-4b62-97c9-d091da030f00"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7374af8d-48c3-4411-b673-731a6f1bed7f"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReadyUP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8fde33d-0454-42dc-a24c-a24052c52d3c"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReadyUP"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""053d046e-25c6-4f3a-b258-39adbe2cafa8"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD 2D Vector"",
                    ""id"": ""e96e234d-5800-4f3d-9b65-751491723131"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c9052181-0285-48d8-ac22-c560997d75ac"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""7ff17883-c642-4a8d-8b1a-da377840d3a9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b5c3ab80-1a2f-4c40-a0cd-548b0796c821"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""765bd5b6-fced-43f6-8398-4bb16116ff7a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b27c7a3c-7535-43fa-8b0f-1dd221154142"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Ibis Head"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow Key 2D Vector"",
                    ""id"": ""d65a077d-2759-4467-ae92-1cf1cbf32b49"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Ibis Head"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""dfbb4d06-c3e8-41bc-84ab-dece92120d69"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Ibis Head"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""99808e13-8fe4-4d6b-91a3-1c412dcded4b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Ibis Head"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""eb1207c3-6a6e-49ef-b3c9-c5cfb01072fc"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Ibis Head"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""538b92f0-ae46-4c6f-a133-debf81cfbf99"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Ibis Head"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_MoveIbisHead = m_Gameplay.FindAction("Move Ibis Head", throwIfNotFound: true);
        m_Gameplay_ResetIbisHeadRotations = m_Gameplay.FindAction("ResetIbisHeadRotations", throwIfNotFound: true);
        m_Gameplay_PickUpandDropItem = m_Gameplay.FindAction("Pick Up and Drop Item", throwIfNotFound: true);
        m_Gameplay_Honk = m_Gameplay.FindAction("Honk", throwIfNotFound: true);
        m_Gameplay_Attack = m_Gameplay.FindAction("Attack", throwIfNotFound: true);
        m_Gameplay_Throw = m_Gameplay.FindAction("Throw", throwIfNotFound: true);
        m_Gameplay_UpEmote = m_Gameplay.FindAction("UpEmote", throwIfNotFound: true);
        m_Gameplay_DownEmote = m_Gameplay.FindAction("DownEmote", throwIfNotFound: true);
        m_Gameplay_LeftEmote = m_Gameplay.FindAction("LeftEmote", throwIfNotFound: true);
        m_Gameplay_RightEmote = m_Gameplay.FindAction("RightEmote", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_ReadyUP = m_UI.FindAction("ReadyUP", throwIfNotFound: true);
        m_UI_Movement = m_UI.FindAction("Movement", throwIfNotFound: true);
        m_UI_MoveIbisHead = m_UI.FindAction("Move Ibis Head", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_MoveIbisHead;
    private readonly InputAction m_Gameplay_ResetIbisHeadRotations;
    private readonly InputAction m_Gameplay_PickUpandDropItem;
    private readonly InputAction m_Gameplay_Honk;
    private readonly InputAction m_Gameplay_Attack;
    private readonly InputAction m_Gameplay_Throw;
    private readonly InputAction m_Gameplay_UpEmote;
    private readonly InputAction m_Gameplay_DownEmote;
    private readonly InputAction m_Gameplay_LeftEmote;
    private readonly InputAction m_Gameplay_RightEmote;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @MoveIbisHead => m_Wrapper.m_Gameplay_MoveIbisHead;
        public InputAction @ResetIbisHeadRotations => m_Wrapper.m_Gameplay_ResetIbisHeadRotations;
        public InputAction @PickUpandDropItem => m_Wrapper.m_Gameplay_PickUpandDropItem;
        public InputAction @Honk => m_Wrapper.m_Gameplay_Honk;
        public InputAction @Attack => m_Wrapper.m_Gameplay_Attack;
        public InputAction @Throw => m_Wrapper.m_Gameplay_Throw;
        public InputAction @UpEmote => m_Wrapper.m_Gameplay_UpEmote;
        public InputAction @DownEmote => m_Wrapper.m_Gameplay_DownEmote;
        public InputAction @LeftEmote => m_Wrapper.m_Gameplay_LeftEmote;
        public InputAction @RightEmote => m_Wrapper.m_Gameplay_RightEmote;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @MoveIbisHead.started += instance.OnMoveIbisHead;
            @MoveIbisHead.performed += instance.OnMoveIbisHead;
            @MoveIbisHead.canceled += instance.OnMoveIbisHead;
            @ResetIbisHeadRotations.started += instance.OnResetIbisHeadRotations;
            @ResetIbisHeadRotations.performed += instance.OnResetIbisHeadRotations;
            @ResetIbisHeadRotations.canceled += instance.OnResetIbisHeadRotations;
            @PickUpandDropItem.started += instance.OnPickUpandDropItem;
            @PickUpandDropItem.performed += instance.OnPickUpandDropItem;
            @PickUpandDropItem.canceled += instance.OnPickUpandDropItem;
            @Honk.started += instance.OnHonk;
            @Honk.performed += instance.OnHonk;
            @Honk.canceled += instance.OnHonk;
            @Attack.started += instance.OnAttack;
            @Attack.performed += instance.OnAttack;
            @Attack.canceled += instance.OnAttack;
            @Throw.started += instance.OnThrow;
            @Throw.performed += instance.OnThrow;
            @Throw.canceled += instance.OnThrow;
            @UpEmote.started += instance.OnUpEmote;
            @UpEmote.performed += instance.OnUpEmote;
            @UpEmote.canceled += instance.OnUpEmote;
            @DownEmote.started += instance.OnDownEmote;
            @DownEmote.performed += instance.OnDownEmote;
            @DownEmote.canceled += instance.OnDownEmote;
            @LeftEmote.started += instance.OnLeftEmote;
            @LeftEmote.performed += instance.OnLeftEmote;
            @LeftEmote.canceled += instance.OnLeftEmote;
            @RightEmote.started += instance.OnRightEmote;
            @RightEmote.performed += instance.OnRightEmote;
            @RightEmote.canceled += instance.OnRightEmote;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @MoveIbisHead.started -= instance.OnMoveIbisHead;
            @MoveIbisHead.performed -= instance.OnMoveIbisHead;
            @MoveIbisHead.canceled -= instance.OnMoveIbisHead;
            @ResetIbisHeadRotations.started -= instance.OnResetIbisHeadRotations;
            @ResetIbisHeadRotations.performed -= instance.OnResetIbisHeadRotations;
            @ResetIbisHeadRotations.canceled -= instance.OnResetIbisHeadRotations;
            @PickUpandDropItem.started -= instance.OnPickUpandDropItem;
            @PickUpandDropItem.performed -= instance.OnPickUpandDropItem;
            @PickUpandDropItem.canceled -= instance.OnPickUpandDropItem;
            @Honk.started -= instance.OnHonk;
            @Honk.performed -= instance.OnHonk;
            @Honk.canceled -= instance.OnHonk;
            @Attack.started -= instance.OnAttack;
            @Attack.performed -= instance.OnAttack;
            @Attack.canceled -= instance.OnAttack;
            @Throw.started -= instance.OnThrow;
            @Throw.performed -= instance.OnThrow;
            @Throw.canceled -= instance.OnThrow;
            @UpEmote.started -= instance.OnUpEmote;
            @UpEmote.performed -= instance.OnUpEmote;
            @UpEmote.canceled -= instance.OnUpEmote;
            @DownEmote.started -= instance.OnDownEmote;
            @DownEmote.performed -= instance.OnDownEmote;
            @DownEmote.canceled -= instance.OnDownEmote;
            @LeftEmote.started -= instance.OnLeftEmote;
            @LeftEmote.performed -= instance.OnLeftEmote;
            @LeftEmote.canceled -= instance.OnLeftEmote;
            @RightEmote.started -= instance.OnRightEmote;
            @RightEmote.performed -= instance.OnRightEmote;
            @RightEmote.canceled -= instance.OnRightEmote;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private List<IUIActions> m_UIActionsCallbackInterfaces = new List<IUIActions>();
    private readonly InputAction m_UI_ReadyUP;
    private readonly InputAction m_UI_Movement;
    private readonly InputAction m_UI_MoveIbisHead;
    public struct UIActions
    {
        private @PlayerControls m_Wrapper;
        public UIActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @ReadyUP => m_Wrapper.m_UI_ReadyUP;
        public InputAction @Movement => m_Wrapper.m_UI_Movement;
        public InputAction @MoveIbisHead => m_Wrapper.m_UI_MoveIbisHead;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void AddCallbacks(IUIActions instance)
        {
            if (instance == null || m_Wrapper.m_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_UIActionsCallbackInterfaces.Add(instance);
            @ReadyUP.started += instance.OnReadyUP;
            @ReadyUP.performed += instance.OnReadyUP;
            @ReadyUP.canceled += instance.OnReadyUP;
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @MoveIbisHead.started += instance.OnMoveIbisHead;
            @MoveIbisHead.performed += instance.OnMoveIbisHead;
            @MoveIbisHead.canceled += instance.OnMoveIbisHead;
        }

        private void UnregisterCallbacks(IUIActions instance)
        {
            @ReadyUP.started -= instance.OnReadyUP;
            @ReadyUP.performed -= instance.OnReadyUP;
            @ReadyUP.canceled -= instance.OnReadyUP;
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @MoveIbisHead.started -= instance.OnMoveIbisHead;
            @MoveIbisHead.performed -= instance.OnMoveIbisHead;
            @MoveIbisHead.canceled -= instance.OnMoveIbisHead;
        }

        public void RemoveCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IUIActions instance)
        {
            foreach (var item in m_Wrapper.m_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public UIActions @UI => new UIActions(this);
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMoveIbisHead(InputAction.CallbackContext context);
        void OnResetIbisHeadRotations(InputAction.CallbackContext context);
        void OnPickUpandDropItem(InputAction.CallbackContext context);
        void OnHonk(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnUpEmote(InputAction.CallbackContext context);
        void OnDownEmote(InputAction.CallbackContext context);
        void OnLeftEmote(InputAction.CallbackContext context);
        void OnRightEmote(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnReadyUP(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnMoveIbisHead(InputAction.CallbackContext context);
    }
}
