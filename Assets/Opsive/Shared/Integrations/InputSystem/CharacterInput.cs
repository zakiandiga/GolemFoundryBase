// GENERATED AUTOMATICALLY FROM 'Assets/Opsive/Shared/Integrations/InputSystem/CharacterInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CharacterInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CharacterInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterInput"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""82625206-f5a8-40ef-9a75-31930b243a7d"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3f8891d3-1ddf-4c95-932b-78931d46f70a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Vertical"",
                    ""type"": ""PassThrough"",
                    ""id"": ""2b8eaacd-e265-46c9-9c9b-a76a7ceda54a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse X"",
                    ""type"": ""PassThrough"",
                    ""id"": ""8b8886fa-b298-4789-bfff-9551be33a5d4"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse Y"",
                    ""type"": ""PassThrough"",
                    ""id"": ""46cf35fd-8ad5-4550-b147-a37c20766c6c"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire1"",
                    ""type"": ""Button"",
                    ""id"": ""2e6b07e4-7c76-4280-9981-37e59afe0402"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire2"",
                    ""type"": ""Button"",
                    ""id"": ""f2ba4b0d-c10c-49cd-95af-6f4f2b1c210f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bf80cade-3908-4c91-8b5d-2b41f96d6ee1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""4d03000e-a711-421b-8fe6-4a0c58afd51b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Change Speeds"",
                    ""type"": ""Button"",
                    ""id"": ""ae11e709-a63b-42d8-9dfa-68bfb80d37d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""9ba9e0c9-d352-41bb-a6e3-1769ca8da76f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""6f3b3740-4829-4925-aa23-b5e6844041e7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondaryUse"",
                    ""type"": ""Button"",
                    ""id"": ""8474fdb0-3416-4b95-ac64-1ab0541a41f1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grenade"",
                    ""type"": ""Button"",
                    ""id"": ""ff7ac812-620b-46b4-a78b-cf611a295392"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Equip First Item"",
                    ""type"": ""Button"",
                    ""id"": ""7fcc99d0-a3de-42bd-8bbe-717ff751504b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Equip Second Item"",
                    ""type"": ""Button"",
                    ""id"": ""c8e3713f-eac7-4e33-a81e-843fdb931eaf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Equip Third Item"",
                    ""type"": ""Button"",
                    ""id"": ""ee802b6b-d993-4c47-aa22-27e3f71c5c8e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Equip Fourth Item"",
                    ""type"": ""Button"",
                    ""id"": ""2c9a5d00-bee6-4416-be3c-7e1a6cd7c412"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Equip Fifth Item"",
                    ""type"": ""Button"",
                    ""id"": ""56845ae8-bb74-45f2-a80c-391bb16bed9d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Equip Sixth Item"",
                    ""type"": ""Button"",
                    ""id"": ""51d83d8d-a733-453c-86d3-0a474d3d777e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Equip Seventh Item"",
                    ""type"": ""Button"",
                    ""id"": ""23ee03c4-9ab8-4a17-b944-ba0bc53e0b72"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Equip Eighth Item"",
                    ""type"": ""Button"",
                    ""id"": ""f68cb13f-9ba8-4c96-8b16-5b0c7313b909"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Equip Ninth Item"",
                    ""type"": ""Button"",
                    ""id"": ""88d392b6-b0fe-4b7e-9591-532912e1d09e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Equip Next Item"",
                    ""type"": ""Button"",
                    ""id"": ""9beb1755-6e71-4107-b0bc-fecc75a3c194"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Equip Tenth Item"",
                    ""type"": ""Button"",
                    ""id"": ""f5755a65-4080-4788-a1b6-4011019f6b39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Equip Previous Item"",
                    ""type"": ""Button"",
                    ""id"": ""fe256b77-67cf-44b6-897d-213e36f3d258"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Toggle Item Equip"",
                    ""type"": ""Button"",
                    ""id"": ""e92f7d6f-c721-46ea-8a1c-22ac013591d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""5ae366a7-308d-4635-9ba9-3a80de5ffa80"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Toggle Perspective"",
                    ""type"": ""Button"",
                    ""id"": ""a32e9336-e933-435c-86d9-db27aa17c1a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse ScrollWheel"",
                    ""type"": ""Value"",
                    ""id"": ""433b27f5-b792-44ab-ba79-e7c8c080da4f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Lean"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9ddaf0ab-de61-48f8-b16f-9d9cfd2067bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Open Panel"",
                    ""type"": ""Button"",
                    ""id"": ""ecf3f50f-4040-4702-bed5-6d18596238eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Close Panel"",
                    ""type"": ""Button"",
                    ""id"": ""4bb0aa2b-32fc-4cee-881f-0089e59284fa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Next"",
                    ""type"": ""Button"",
                    ""id"": ""c09ec6d6-e353-4bde-a861-c6956be8627e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Previous"",
                    ""type"": ""Button"",
                    ""id"": ""3f2b06ce-1d78-43cd-ae3f-a8e880489a7d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""a55b02be-dade-411a-8533-073dd5343be1"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d71c05a1-8cdc-43a8-b52b-84943cad0259"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""146e9e98-c0d2-4977-aa21-b47b87786624"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""903e86a5-3b35-4f11-946e-40fd51d63020"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6ff54434-5f0c-440f-90d8-64c52c535461"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""fc679ac2-79f7-44b2-8a32-aea25b7f1374"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""462b80bd-8263-4afc-a8d6-1f58decd5905"",
                    ""path"": ""<Touchscreen>/position/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""2e56c60c-f1ce-498f-8598-30335516e06c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d3703c26-109f-4bc5-ba1d-581017b1116f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""077fe0ad-24c2-480f-84eb-daaba92c0479"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""3c01b9fd-8b5d-4f74-a452-ddb7f37e40f4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone"",
                    ""groups"": """",
                    ""action"": ""Vertical"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e0dd1723-cfc5-4682-a73b-616990ad9c22"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3b0b3977-7dfb-40bd-bdea-cc8ce2db8ebb"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""da332127-9d02-4f16-88a3-4e0ee697b935"",
                    ""path"": ""<Touchscreen>/position/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Vertical"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e2dc872-baff-4fcd-8178-0a104c89b955"",
                    ""path"": ""<Gamepad>/rightStick/x"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone,Scale(factor=1.5)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Mouse X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a33b125b-e60e-43c0-94d9-3279d2cd6331"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=0.5)"",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Mouse X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cf580763-581e-49b4-8cde-3dd7e08844cb"",
                    ""path"": ""<Touchscreen>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Mouse X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a276958e-275d-4e1b-a12d-04aac1cd5dab"",
                    ""path"": ""<Gamepad>/rightStick/y"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone,Scale(factor=1.5)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Mouse Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ca55954-ea77-4fbd-8266-bf1e6d3d6ea5"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=0.5)"",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Mouse Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b7bbac5e-92c2-4720-8223-9ec025f79b6c"",
                    ""path"": ""<Touchscreen>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Mouse Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db143643-6d82-450c-be04-b33673c1b8b8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab1e61dc-440a-4f70-9398-dd9175d90c92"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49347fd0-0f0e-4701-bd45-84d5c09c64ea"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e39d5778-51a7-46bd-a2d2-f172d9d99b8c"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""776a00b4-1507-49a3-a1ef-fc08df5e5bfd"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7e9e3080-148a-4d77-b06a-7c8f544c966a"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b0f3571-4929-459d-a573-5904b6ae58d1"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3028a679-d1a2-464e-a15d-66d59721846f"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45c6b01e-e953-4655-9374-bd36499caf3f"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""SecondaryUse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05fa65dc-9422-4d97-9781-439a03612fab"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""SecondaryUse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd644c75-e3d6-4012-bbb3-4094f6e14826"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Grenade"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""308e4639-3b57-4152-aeec-e3419ce8d658"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Grenade"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d9c249c-55dd-4d80-9fec-5becaa8b2695"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Equip Second Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""faf9f914-df1f-491b-bbf0-418f52f9babd"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Equip Third Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a16e9ac1-7831-424b-b4bb-5d7cb1017107"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Equip Next Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88422f24-573e-41db-9a51-c3b6731b9031"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Equip Next Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b288d5b-5b4a-4ff5-96bd-da053644e38a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Equip Previous Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb2cc340-9be2-4584-860a-44f33ea2fb3a"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Toggle Item Equip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""873c835c-00bf-4652-bbe3-13f1c6844b01"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6d47a48-8699-43ce-a976-82b55436d58f"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Toggle Perspective"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3665d24d-7c33-4861-a580-a8a4e75e9e64"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Toggle Perspective"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57e69768-186c-4ef6-a07c-ec8ef8cb4f60"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Mouse ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2bba14a8-9cbe-4b3f-a3e9-ff0c39e89a33"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Equip First Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eced5cd7-87d8-4781-ad67-1b85f91f8060"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Equip Fourth Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfc2fd42-00c6-448d-9c6f-d1c9f869d5e7"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Equip Fifth Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c496234f-96d8-4d75-b424-122f220ddb85"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Equip Sixth Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b70b3f2a-f8a7-4d0b-975e-ea359353619d"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Equip Seventh Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e4cd7bc-6a90-4e95-bf7b-2f6e7456e9b0"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Equip Eighth Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""155f75c7-7749-4067-8b28-fa726ec41709"",
                    ""path"": ""<Keyboard>/9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Equip Ninth Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb6c8e1b-f5ec-409d-9421-56a510ef72cc"",
                    ""path"": ""<Keyboard>/0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Equip Tenth Item"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d583c7bb-d42c-47ad-8b56-07fc11c45153"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Fire1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79f5173a-0664-4f29-a170-e12f2780a58a"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Fire1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5e627bca-3f7b-4a32-a486-ad2c5df04ef2"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Fire1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9d7d5b32-7105-4eb7-b7e2-e8c2f9e6e448"",
                    ""path"": ""<Touchscreen>/touch1/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mobile"",
                    ""action"": ""Fire1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed73351c-9b2c-4035-8cad-fc2caa9b9b93"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Fire2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f429cf98-73e4-43a7-96b4-21988ff8f1a9"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Fire2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""643aabd0-3384-4fb2-9ebc-907a61bbd719"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Change Speeds"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""1c29f6d2-4d3f-4660-a902-df9be863008e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Lean"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0e86a7b0-4a1d-40fd-aa2d-5381260bf527"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Lean"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""06e32736-bf7d-4b66-8111-cdbe422d8821"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Lean"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""133752d0-f910-4520-ba45-592fb599f6ec"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Open Panel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""152ae6bf-088e-4b90-a7b8-adf4da6a4b5d"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Open Panel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5528d75f-484e-4c4c-9711-28bad0a512ad"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close Panel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef669c9b-520d-4cfa-9d97-78acf6da308b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close Panel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3491cc89-4350-46e2-9d5e-88b90337dcdc"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2fce1f70-8fe2-4fd4-914d-5f4dfab5f867"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Next"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9d315d5-f652-4a5a-9e79-50d25167043e"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Previous"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""007db4b2-dd60-4baf-ade1-e7574a527adb"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Previous"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""fe2698be-1995-441e-9bb0-e9a32ba0f524"",
            ""actions"": [
                {
                    ""name"": ""TrackedDeviceOrientation"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e00b285b-2d0e-44ad-acf6-f6d7d17a8641"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TrackedDevicePosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7f08dbb8-bbc9-43fb-a9f7-a9b718154899"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""27f7bb34-9e9f-4bc8-acb4-2fd738ae1422"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MiddleClick"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b0bb90bd-d645-43ac-8a82-5c101aba8cfc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ScrollWheel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ff1366a6-3e9e-4804-8086-a8829f7bf758"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d8769cb6-5714-4dd8-82c8-1e4b3749d112"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Point"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7d0dcbbb-c998-444e-8497-93f5b883ecd3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6423d408-e2aa-4add-aecd-b2234406bd22"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""PassThrough"",
                    ""id"": ""dfc8041a-02b4-44ed-a688-d2f11d9a6ef1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""PassThrough"",
                    ""id"": ""09a456b2-56e6-48e7-b0f1-551758090963"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""541722a9-e699-4c2f-bbfb-24ce4c4d0350"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e0316274-a95d-40bf-836d-5bb57ad78b79"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""814bf6d9-b844-4447-bd81-f2ecd7af9317"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""38d7a0a4-fb7a-45f1-bfb1-4a6f1652d61e"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""69aefef0-3db8-4bb2-8200-833f8ed8bac1"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9e62102f-52cd-46ba-893e-f9479228f5de"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7d3758e0-4348-4c4e-841a-b5e33825047d"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f321a057-89c5-46f5-9322-8bfe4bbb2b99"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e8d0c80c-f86f-498a-9179-f715eaa363e2"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""526d88f4-a994-4259-aa1b-402c64c31fe6"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Gamepad"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""856ed720-bef2-47ee-9ab8-1a959f2cad26"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""218f3e32-6672-49d8-9c96-8d7fd8929edf"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9519e038-82de-4c9e-9ae4-b55fcc5ecbcf"",
                    ""path"": ""<Joystick>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4d32357f-e9c8-40b6-94d0-0679f70c81ca"",
                    ""path"": ""<Joystick>/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d82847ad-3ed9-46a0-b400-e634a1ace96a"",
                    ""path"": ""<Joystick>/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""6b8b8b17-7d11-4918-96b6-f9daad25115d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""46c0b439-6c94-4d71-85ec-3bdb59431ed1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d837a82e-53b6-4d4b-bb6d-551b8b75e11a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c69c16a8-cd8f-4334-9ba0-c2df66f1f8c3"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4379eda2-93cf-4aec-9e41-8a91d9213581"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d08df731-b304-4a03-885e-8742764f866c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f559ec8d-261e-4871-b8a8-1fcf91ba108f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2c369738-30f5-4a19-a8c3-9bcd65fc7aef"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""89c9aeb6-c844-4d98-84d3-9be6cf8361c8"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""37ae6a58-62c3-4f09-aa0a-2584223cd5f8"",
                    ""path"": ""*/{Submit}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d498fad5-fe92-4cb7-8a3b-a7087f650b7a"",
                    ""path"": ""*/{Cancel}"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c5b9120-ec5d-4a78-8b48-ea694d345235"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad3e84f0-d04b-4814-892e-8d1309574ad7"",
                    ""path"": ""<Pen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard&Mouse"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9057791c-38bf-44a2-ac57-7b3f360c8bc7"",
                    ""path"": ""<Touchscreen>/touch*/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Point"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b267b95-4b34-450a-9479-af20e30ec52a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2378e123-6d42-4ec4-8bbc-d5d797e8d304"",
                    ""path"": ""<Pen>/tip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5be873b6-8b0f-4e37-b399-6f5f48f00d71"",
                    ""path"": ""<Touchscreen>/touch*/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Touch"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58f184e5-62d8-45fb-8990-5ce6667372f7"",
                    ""path"": ""<XRController>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad4a69ce-a7b7-4f57-b83d-102c47c5024f"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""ScrollWheel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""400f6ecd-efaa-405e-98bb-28cd9388549c"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""MiddleClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""813db114-eaa8-40a0-b077-8c6f3577dc5a"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": "";Keyboard&Mouse"",
                    ""action"": ""RightClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3822bd7d-fd1f-48e9-896e-34b85062a99f"",
                    ""path"": ""<XRController>/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDevicePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54183e35-807c-465c-b883-557a445a62a3"",
                    ""path"": ""<XRController>/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XR"",
                    ""action"": ""TrackedDeviceOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Mobile"",
            ""bindingGroup"": ""Mobile"",
            ""devices"": [
                {
                    ""devicePath"": ""<Touchscreen>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Horizontal = m_Gameplay.FindAction("Horizontal", throwIfNotFound: true);
        m_Gameplay_Vertical = m_Gameplay.FindAction("Vertical", throwIfNotFound: true);
        m_Gameplay_MouseX = m_Gameplay.FindAction("Mouse X", throwIfNotFound: true);
        m_Gameplay_MouseY = m_Gameplay.FindAction("Mouse Y", throwIfNotFound: true);
        m_Gameplay_Fire1 = m_Gameplay.FindAction("Fire1", throwIfNotFound: true);
        m_Gameplay_Fire2 = m_Gameplay.FindAction("Fire2", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Reload = m_Gameplay.FindAction("Reload", throwIfNotFound: true);
        m_Gameplay_ChangeSpeeds = m_Gameplay.FindAction("Change Speeds", throwIfNotFound: true);
        m_Gameplay_Crouch = m_Gameplay.FindAction("Crouch", throwIfNotFound: true);
        m_Gameplay_Action = m_Gameplay.FindAction("Action", throwIfNotFound: true);
        m_Gameplay_SecondaryUse = m_Gameplay.FindAction("SecondaryUse", throwIfNotFound: true);
        m_Gameplay_Grenade = m_Gameplay.FindAction("Grenade", throwIfNotFound: true);
        m_Gameplay_EquipFirstItem = m_Gameplay.FindAction("Equip First Item", throwIfNotFound: true);
        m_Gameplay_EquipSecondItem = m_Gameplay.FindAction("Equip Second Item", throwIfNotFound: true);
        m_Gameplay_EquipThirdItem = m_Gameplay.FindAction("Equip Third Item", throwIfNotFound: true);
        m_Gameplay_EquipFourthItem = m_Gameplay.FindAction("Equip Fourth Item", throwIfNotFound: true);
        m_Gameplay_EquipFifthItem = m_Gameplay.FindAction("Equip Fifth Item", throwIfNotFound: true);
        m_Gameplay_EquipSixthItem = m_Gameplay.FindAction("Equip Sixth Item", throwIfNotFound: true);
        m_Gameplay_EquipSeventhItem = m_Gameplay.FindAction("Equip Seventh Item", throwIfNotFound: true);
        m_Gameplay_EquipEighthItem = m_Gameplay.FindAction("Equip Eighth Item", throwIfNotFound: true);
        m_Gameplay_EquipNinthItem = m_Gameplay.FindAction("Equip Ninth Item", throwIfNotFound: true);
        m_Gameplay_EquipNextItem = m_Gameplay.FindAction("Equip Next Item", throwIfNotFound: true);
        m_Gameplay_EquipTenthItem = m_Gameplay.FindAction("Equip Tenth Item", throwIfNotFound: true);
        m_Gameplay_EquipPreviousItem = m_Gameplay.FindAction("Equip Previous Item", throwIfNotFound: true);
        m_Gameplay_ToggleItemEquip = m_Gameplay.FindAction("Toggle Item Equip", throwIfNotFound: true);
        m_Gameplay_Drop = m_Gameplay.FindAction("Drop", throwIfNotFound: true);
        m_Gameplay_TogglePerspective = m_Gameplay.FindAction("Toggle Perspective", throwIfNotFound: true);
        m_Gameplay_MouseScrollWheel = m_Gameplay.FindAction("Mouse ScrollWheel", throwIfNotFound: true);
        m_Gameplay_Lean = m_Gameplay.FindAction("Lean", throwIfNotFound: true);
        m_Gameplay_OpenPanel = m_Gameplay.FindAction("Open Panel", throwIfNotFound: true);
        m_Gameplay_ClosePanel = m_Gameplay.FindAction("Close Panel", throwIfNotFound: true);
        m_Gameplay_Next = m_Gameplay.FindAction("Next", throwIfNotFound: true);
        m_Gameplay_Previous = m_Gameplay.FindAction("Previous", throwIfNotFound: true);
        // UI
        m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
        m_UI_TrackedDeviceOrientation = m_UI.FindAction("TrackedDeviceOrientation", throwIfNotFound: true);
        m_UI_TrackedDevicePosition = m_UI.FindAction("TrackedDevicePosition", throwIfNotFound: true);
        m_UI_RightClick = m_UI.FindAction("RightClick", throwIfNotFound: true);
        m_UI_MiddleClick = m_UI.FindAction("MiddleClick", throwIfNotFound: true);
        m_UI_ScrollWheel = m_UI.FindAction("ScrollWheel", throwIfNotFound: true);
        m_UI_Click = m_UI.FindAction("Click", throwIfNotFound: true);
        m_UI_Point = m_UI.FindAction("Point", throwIfNotFound: true);
        m_UI_Cancel = m_UI.FindAction("Cancel", throwIfNotFound: true);
        m_UI_Submit = m_UI.FindAction("Submit", throwIfNotFound: true);
        m_UI_Navigate = m_UI.FindAction("Navigate", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Horizontal;
    private readonly InputAction m_Gameplay_Vertical;
    private readonly InputAction m_Gameplay_MouseX;
    private readonly InputAction m_Gameplay_MouseY;
    private readonly InputAction m_Gameplay_Fire1;
    private readonly InputAction m_Gameplay_Fire2;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Reload;
    private readonly InputAction m_Gameplay_ChangeSpeeds;
    private readonly InputAction m_Gameplay_Crouch;
    private readonly InputAction m_Gameplay_Action;
    private readonly InputAction m_Gameplay_SecondaryUse;
    private readonly InputAction m_Gameplay_Grenade;
    private readonly InputAction m_Gameplay_EquipFirstItem;
    private readonly InputAction m_Gameplay_EquipSecondItem;
    private readonly InputAction m_Gameplay_EquipThirdItem;
    private readonly InputAction m_Gameplay_EquipFourthItem;
    private readonly InputAction m_Gameplay_EquipFifthItem;
    private readonly InputAction m_Gameplay_EquipSixthItem;
    private readonly InputAction m_Gameplay_EquipSeventhItem;
    private readonly InputAction m_Gameplay_EquipEighthItem;
    private readonly InputAction m_Gameplay_EquipNinthItem;
    private readonly InputAction m_Gameplay_EquipNextItem;
    private readonly InputAction m_Gameplay_EquipTenthItem;
    private readonly InputAction m_Gameplay_EquipPreviousItem;
    private readonly InputAction m_Gameplay_ToggleItemEquip;
    private readonly InputAction m_Gameplay_Drop;
    private readonly InputAction m_Gameplay_TogglePerspective;
    private readonly InputAction m_Gameplay_MouseScrollWheel;
    private readonly InputAction m_Gameplay_Lean;
    private readonly InputAction m_Gameplay_OpenPanel;
    private readonly InputAction m_Gameplay_ClosePanel;
    private readonly InputAction m_Gameplay_Next;
    private readonly InputAction m_Gameplay_Previous;
    public struct GameplayActions
    {
        private @CharacterInput m_Wrapper;
        public GameplayActions(@CharacterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_Gameplay_Horizontal;
        public InputAction @Vertical => m_Wrapper.m_Gameplay_Vertical;
        public InputAction @MouseX => m_Wrapper.m_Gameplay_MouseX;
        public InputAction @MouseY => m_Wrapper.m_Gameplay_MouseY;
        public InputAction @Fire1 => m_Wrapper.m_Gameplay_Fire1;
        public InputAction @Fire2 => m_Wrapper.m_Gameplay_Fire2;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Reload => m_Wrapper.m_Gameplay_Reload;
        public InputAction @ChangeSpeeds => m_Wrapper.m_Gameplay_ChangeSpeeds;
        public InputAction @Crouch => m_Wrapper.m_Gameplay_Crouch;
        public InputAction @Action => m_Wrapper.m_Gameplay_Action;
        public InputAction @SecondaryUse => m_Wrapper.m_Gameplay_SecondaryUse;
        public InputAction @Grenade => m_Wrapper.m_Gameplay_Grenade;
        public InputAction @EquipFirstItem => m_Wrapper.m_Gameplay_EquipFirstItem;
        public InputAction @EquipSecondItem => m_Wrapper.m_Gameplay_EquipSecondItem;
        public InputAction @EquipThirdItem => m_Wrapper.m_Gameplay_EquipThirdItem;
        public InputAction @EquipFourthItem => m_Wrapper.m_Gameplay_EquipFourthItem;
        public InputAction @EquipFifthItem => m_Wrapper.m_Gameplay_EquipFifthItem;
        public InputAction @EquipSixthItem => m_Wrapper.m_Gameplay_EquipSixthItem;
        public InputAction @EquipSeventhItem => m_Wrapper.m_Gameplay_EquipSeventhItem;
        public InputAction @EquipEighthItem => m_Wrapper.m_Gameplay_EquipEighthItem;
        public InputAction @EquipNinthItem => m_Wrapper.m_Gameplay_EquipNinthItem;
        public InputAction @EquipNextItem => m_Wrapper.m_Gameplay_EquipNextItem;
        public InputAction @EquipTenthItem => m_Wrapper.m_Gameplay_EquipTenthItem;
        public InputAction @EquipPreviousItem => m_Wrapper.m_Gameplay_EquipPreviousItem;
        public InputAction @ToggleItemEquip => m_Wrapper.m_Gameplay_ToggleItemEquip;
        public InputAction @Drop => m_Wrapper.m_Gameplay_Drop;
        public InputAction @TogglePerspective => m_Wrapper.m_Gameplay_TogglePerspective;
        public InputAction @MouseScrollWheel => m_Wrapper.m_Gameplay_MouseScrollWheel;
        public InputAction @Lean => m_Wrapper.m_Gameplay_Lean;
        public InputAction @OpenPanel => m_Wrapper.m_Gameplay_OpenPanel;
        public InputAction @ClosePanel => m_Wrapper.m_Gameplay_ClosePanel;
        public InputAction @Next => m_Wrapper.m_Gameplay_Next;
        public InputAction @Previous => m_Wrapper.m_Gameplay_Previous;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Horizontal.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHorizontal;
                @Vertical.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnVertical;
                @Vertical.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnVertical;
                @Vertical.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnVertical;
                @MouseX.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseX;
                @MouseX.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseX;
                @MouseX.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseX;
                @MouseY.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseY;
                @MouseY.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseY;
                @MouseY.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseY;
                @Fire1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire1;
                @Fire1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire1;
                @Fire1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire1;
                @Fire2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire2;
                @Fire2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire2;
                @Fire2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFire2;
                @Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                @Reload.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnReload;
                @ChangeSpeeds.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeSpeeds;
                @ChangeSpeeds.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeSpeeds;
                @ChangeSpeeds.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnChangeSpeeds;
                @Crouch.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCrouch;
                @Action.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAction;
                @SecondaryUse.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryUse;
                @SecondaryUse.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryUse;
                @SecondaryUse.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondaryUse;
                @Grenade.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrenade;
                @Grenade.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrenade;
                @Grenade.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrenade;
                @EquipFirstItem.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipFirstItem;
                @EquipFirstItem.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipFirstItem;
                @EquipFirstItem.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipFirstItem;
                @EquipSecondItem.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipSecondItem;
                @EquipSecondItem.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipSecondItem;
                @EquipSecondItem.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipSecondItem;
                @EquipThirdItem.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipThirdItem;
                @EquipThirdItem.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipThirdItem;
                @EquipThirdItem.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipThirdItem;
                @EquipFourthItem.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipFourthItem;
                @EquipFourthItem.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipFourthItem;
                @EquipFourthItem.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipFourthItem;
                @EquipFifthItem.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipFifthItem;
                @EquipFifthItem.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipFifthItem;
                @EquipFifthItem.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipFifthItem;
                @EquipSixthItem.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipSixthItem;
                @EquipSixthItem.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipSixthItem;
                @EquipSixthItem.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipSixthItem;
                @EquipSeventhItem.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipSeventhItem;
                @EquipSeventhItem.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipSeventhItem;
                @EquipSeventhItem.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipSeventhItem;
                @EquipEighthItem.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipEighthItem;
                @EquipEighthItem.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipEighthItem;
                @EquipEighthItem.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipEighthItem;
                @EquipNinthItem.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipNinthItem;
                @EquipNinthItem.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipNinthItem;
                @EquipNinthItem.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipNinthItem;
                @EquipNextItem.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipNextItem;
                @EquipNextItem.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipNextItem;
                @EquipNextItem.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipNextItem;
                @EquipTenthItem.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipTenthItem;
                @EquipTenthItem.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipTenthItem;
                @EquipTenthItem.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipTenthItem;
                @EquipPreviousItem.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipPreviousItem;
                @EquipPreviousItem.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipPreviousItem;
                @EquipPreviousItem.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquipPreviousItem;
                @ToggleItemEquip.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToggleItemEquip;
                @ToggleItemEquip.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToggleItemEquip;
                @ToggleItemEquip.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToggleItemEquip;
                @Drop.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                @TogglePerspective.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTogglePerspective;
                @TogglePerspective.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTogglePerspective;
                @TogglePerspective.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnTogglePerspective;
                @MouseScrollWheel.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseScrollWheel;
                @MouseScrollWheel.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseScrollWheel;
                @MouseScrollWheel.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMouseScrollWheel;
                @Lean.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLean;
                @Lean.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLean;
                @Lean.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLean;
                @OpenPanel.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenPanel;
                @OpenPanel.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenPanel;
                @OpenPanel.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnOpenPanel;
                @ClosePanel.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClosePanel;
                @ClosePanel.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClosePanel;
                @ClosePanel.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClosePanel;
                @Next.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNext;
                @Next.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNext;
                @Next.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnNext;
                @Previous.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrevious;
                @Previous.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrevious;
                @Previous.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPrevious;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Vertical.started += instance.OnVertical;
                @Vertical.performed += instance.OnVertical;
                @Vertical.canceled += instance.OnVertical;
                @MouseX.started += instance.OnMouseX;
                @MouseX.performed += instance.OnMouseX;
                @MouseX.canceled += instance.OnMouseX;
                @MouseY.started += instance.OnMouseY;
                @MouseY.performed += instance.OnMouseY;
                @MouseY.canceled += instance.OnMouseY;
                @Fire1.started += instance.OnFire1;
                @Fire1.performed += instance.OnFire1;
                @Fire1.canceled += instance.OnFire1;
                @Fire2.started += instance.OnFire2;
                @Fire2.performed += instance.OnFire2;
                @Fire2.canceled += instance.OnFire2;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @ChangeSpeeds.started += instance.OnChangeSpeeds;
                @ChangeSpeeds.performed += instance.OnChangeSpeeds;
                @ChangeSpeeds.canceled += instance.OnChangeSpeeds;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @SecondaryUse.started += instance.OnSecondaryUse;
                @SecondaryUse.performed += instance.OnSecondaryUse;
                @SecondaryUse.canceled += instance.OnSecondaryUse;
                @Grenade.started += instance.OnGrenade;
                @Grenade.performed += instance.OnGrenade;
                @Grenade.canceled += instance.OnGrenade;
                @EquipFirstItem.started += instance.OnEquipFirstItem;
                @EquipFirstItem.performed += instance.OnEquipFirstItem;
                @EquipFirstItem.canceled += instance.OnEquipFirstItem;
                @EquipSecondItem.started += instance.OnEquipSecondItem;
                @EquipSecondItem.performed += instance.OnEquipSecondItem;
                @EquipSecondItem.canceled += instance.OnEquipSecondItem;
                @EquipThirdItem.started += instance.OnEquipThirdItem;
                @EquipThirdItem.performed += instance.OnEquipThirdItem;
                @EquipThirdItem.canceled += instance.OnEquipThirdItem;
                @EquipFourthItem.started += instance.OnEquipFourthItem;
                @EquipFourthItem.performed += instance.OnEquipFourthItem;
                @EquipFourthItem.canceled += instance.OnEquipFourthItem;
                @EquipFifthItem.started += instance.OnEquipFifthItem;
                @EquipFifthItem.performed += instance.OnEquipFifthItem;
                @EquipFifthItem.canceled += instance.OnEquipFifthItem;
                @EquipSixthItem.started += instance.OnEquipSixthItem;
                @EquipSixthItem.performed += instance.OnEquipSixthItem;
                @EquipSixthItem.canceled += instance.OnEquipSixthItem;
                @EquipSeventhItem.started += instance.OnEquipSeventhItem;
                @EquipSeventhItem.performed += instance.OnEquipSeventhItem;
                @EquipSeventhItem.canceled += instance.OnEquipSeventhItem;
                @EquipEighthItem.started += instance.OnEquipEighthItem;
                @EquipEighthItem.performed += instance.OnEquipEighthItem;
                @EquipEighthItem.canceled += instance.OnEquipEighthItem;
                @EquipNinthItem.started += instance.OnEquipNinthItem;
                @EquipNinthItem.performed += instance.OnEquipNinthItem;
                @EquipNinthItem.canceled += instance.OnEquipNinthItem;
                @EquipNextItem.started += instance.OnEquipNextItem;
                @EquipNextItem.performed += instance.OnEquipNextItem;
                @EquipNextItem.canceled += instance.OnEquipNextItem;
                @EquipTenthItem.started += instance.OnEquipTenthItem;
                @EquipTenthItem.performed += instance.OnEquipTenthItem;
                @EquipTenthItem.canceled += instance.OnEquipTenthItem;
                @EquipPreviousItem.started += instance.OnEquipPreviousItem;
                @EquipPreviousItem.performed += instance.OnEquipPreviousItem;
                @EquipPreviousItem.canceled += instance.OnEquipPreviousItem;
                @ToggleItemEquip.started += instance.OnToggleItemEquip;
                @ToggleItemEquip.performed += instance.OnToggleItemEquip;
                @ToggleItemEquip.canceled += instance.OnToggleItemEquip;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
                @TogglePerspective.started += instance.OnTogglePerspective;
                @TogglePerspective.performed += instance.OnTogglePerspective;
                @TogglePerspective.canceled += instance.OnTogglePerspective;
                @MouseScrollWheel.started += instance.OnMouseScrollWheel;
                @MouseScrollWheel.performed += instance.OnMouseScrollWheel;
                @MouseScrollWheel.canceled += instance.OnMouseScrollWheel;
                @Lean.started += instance.OnLean;
                @Lean.performed += instance.OnLean;
                @Lean.canceled += instance.OnLean;
                @OpenPanel.started += instance.OnOpenPanel;
                @OpenPanel.performed += instance.OnOpenPanel;
                @OpenPanel.canceled += instance.OnOpenPanel;
                @ClosePanel.started += instance.OnClosePanel;
                @ClosePanel.performed += instance.OnClosePanel;
                @ClosePanel.canceled += instance.OnClosePanel;
                @Next.started += instance.OnNext;
                @Next.performed += instance.OnNext;
                @Next.canceled += instance.OnNext;
                @Previous.started += instance.OnPrevious;
                @Previous.performed += instance.OnPrevious;
                @Previous.canceled += instance.OnPrevious;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // UI
    private readonly InputActionMap m_UI;
    private IUIActions m_UIActionsCallbackInterface;
    private readonly InputAction m_UI_TrackedDeviceOrientation;
    private readonly InputAction m_UI_TrackedDevicePosition;
    private readonly InputAction m_UI_RightClick;
    private readonly InputAction m_UI_MiddleClick;
    private readonly InputAction m_UI_ScrollWheel;
    private readonly InputAction m_UI_Click;
    private readonly InputAction m_UI_Point;
    private readonly InputAction m_UI_Cancel;
    private readonly InputAction m_UI_Submit;
    private readonly InputAction m_UI_Navigate;
    public struct UIActions
    {
        private @CharacterInput m_Wrapper;
        public UIActions(@CharacterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @TrackedDeviceOrientation => m_Wrapper.m_UI_TrackedDeviceOrientation;
        public InputAction @TrackedDevicePosition => m_Wrapper.m_UI_TrackedDevicePosition;
        public InputAction @RightClick => m_Wrapper.m_UI_RightClick;
        public InputAction @MiddleClick => m_Wrapper.m_UI_MiddleClick;
        public InputAction @ScrollWheel => m_Wrapper.m_UI_ScrollWheel;
        public InputAction @Click => m_Wrapper.m_UI_Click;
        public InputAction @Point => m_Wrapper.m_UI_Point;
        public InputAction @Cancel => m_Wrapper.m_UI_Cancel;
        public InputAction @Submit => m_Wrapper.m_UI_Submit;
        public InputAction @Navigate => m_Wrapper.m_UI_Navigate;
        public InputActionMap Get() { return m_Wrapper.m_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
        public void SetCallbacks(IUIActions instance)
        {
            if (m_Wrapper.m_UIActionsCallbackInterface != null)
            {
                @TrackedDeviceOrientation.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDeviceOrientation;
                @TrackedDevicePosition.started -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnTrackedDevicePosition;
                @RightClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @RightClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnRightClick;
                @MiddleClick.started -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @MiddleClick.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnMiddleClick;
                @ScrollWheel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @ScrollWheel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnScrollWheel;
                @Click.started -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnClick;
                @Point.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Point.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPoint;
                @Cancel.started -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnCancel;
                @Submit.started -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Submit.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnSubmit;
                @Navigate.started -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnNavigate;
            }
            m_Wrapper.m_UIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TrackedDeviceOrientation.started += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.performed += instance.OnTrackedDeviceOrientation;
                @TrackedDeviceOrientation.canceled += instance.OnTrackedDeviceOrientation;
                @TrackedDevicePosition.started += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.performed += instance.OnTrackedDevicePosition;
                @TrackedDevicePosition.canceled += instance.OnTrackedDevicePosition;
                @RightClick.started += instance.OnRightClick;
                @RightClick.performed += instance.OnRightClick;
                @RightClick.canceled += instance.OnRightClick;
                @MiddleClick.started += instance.OnMiddleClick;
                @MiddleClick.performed += instance.OnMiddleClick;
                @MiddleClick.canceled += instance.OnMiddleClick;
                @ScrollWheel.started += instance.OnScrollWheel;
                @ScrollWheel.performed += instance.OnScrollWheel;
                @ScrollWheel.canceled += instance.OnScrollWheel;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @Point.started += instance.OnPoint;
                @Point.performed += instance.OnPoint;
                @Point.canceled += instance.OnPoint;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Submit.started += instance.OnSubmit;
                @Submit.performed += instance.OnSubmit;
                @Submit.canceled += instance.OnSubmit;
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
            }
        }
    }
    public UIActions @UI => new UIActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_MobileSchemeIndex = -1;
    public InputControlScheme MobileScheme
    {
        get
        {
            if (m_MobileSchemeIndex == -1) m_MobileSchemeIndex = asset.FindControlSchemeIndex("Mobile");
            return asset.controlSchemes[m_MobileSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnVertical(InputAction.CallbackContext context);
        void OnMouseX(InputAction.CallbackContext context);
        void OnMouseY(InputAction.CallbackContext context);
        void OnFire1(InputAction.CallbackContext context);
        void OnFire2(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnChangeSpeeds(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
        void OnSecondaryUse(InputAction.CallbackContext context);
        void OnGrenade(InputAction.CallbackContext context);
        void OnEquipFirstItem(InputAction.CallbackContext context);
        void OnEquipSecondItem(InputAction.CallbackContext context);
        void OnEquipThirdItem(InputAction.CallbackContext context);
        void OnEquipFourthItem(InputAction.CallbackContext context);
        void OnEquipFifthItem(InputAction.CallbackContext context);
        void OnEquipSixthItem(InputAction.CallbackContext context);
        void OnEquipSeventhItem(InputAction.CallbackContext context);
        void OnEquipEighthItem(InputAction.CallbackContext context);
        void OnEquipNinthItem(InputAction.CallbackContext context);
        void OnEquipNextItem(InputAction.CallbackContext context);
        void OnEquipTenthItem(InputAction.CallbackContext context);
        void OnEquipPreviousItem(InputAction.CallbackContext context);
        void OnToggleItemEquip(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnTogglePerspective(InputAction.CallbackContext context);
        void OnMouseScrollWheel(InputAction.CallbackContext context);
        void OnLean(InputAction.CallbackContext context);
        void OnOpenPanel(InputAction.CallbackContext context);
        void OnClosePanel(InputAction.CallbackContext context);
        void OnNext(InputAction.CallbackContext context);
        void OnPrevious(InputAction.CallbackContext context);
    }
    public interface IUIActions
    {
        void OnTrackedDeviceOrientation(InputAction.CallbackContext context);
        void OnTrackedDevicePosition(InputAction.CallbackContext context);
        void OnRightClick(InputAction.CallbackContext context);
        void OnMiddleClick(InputAction.CallbackContext context);
        void OnScrollWheel(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnPoint(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
        void OnNavigate(InputAction.CallbackContext context);
    }
}
