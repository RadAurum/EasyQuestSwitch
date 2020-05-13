#if UNITY_EDITOR && (VRC_SDK_VRCSDK2 || VRC_SDK_VRCSDK3)
using UnityEditor;
using UnityEngine;
#if VRC_SDK_VRCSDK2
using VRCSDK2;
#endif
#if VRC_SDK_VRCSDK3
using VRC.SDK3.Components;
#endif
using EasyQuestSwitch.Fields;


namespace EasyQuestSwitch.Types
{
    public class Type_VRC_MirrorReflection : Type_Behaviour
    {
        [System.NonSerialized]
#if VRC_SDK_VRCSDK2
        private VRC_MirrorReflection type;
#elif VRC_SDK_VRCSDK3
        private VRCMirrorReflection type;
#endif

        public SharedBool DisablePixelLights = new SharedBool();
        public SharedBool TurnOffMirrorOcclusion = new SharedBool();
        public SharedLayerMask ReflectLayers = new SharedLayerMask();

        public override void Setup(Object type)
        {
            base.Setup(type);
#if VRC_SDK_VRCSDK2
            VRC_MirrorReflection component = (VRC_MirrorReflection)type;
#elif VRC_SDK_VRCSDK3
            VRCMirrorReflection component = (VRCMirrorReflection)type;
#endif
            DisablePixelLights.Setup(component.m_DisablePixelLights);
            TurnOffMirrorOcclusion.Setup(component.TurnOffMirrorOcclusion);
            ReflectLayers.Setup(component.m_ReflectLayers);
        }

        public override void Process(Object type, BuildTarget buildTarget)
        {
            base.Process(type, buildTarget);
#if VRC_SDK_VRCSDK2
            VRC_MirrorReflection component = (VRC_MirrorReflection)type;
#elif VRC_SDK_VRCSDK3
            VRCMirrorReflection component = (VRCMirrorReflection)type;
#endif
            switch (buildTarget)
            {
                case BuildTarget.StandaloneWindows64:
                    component.m_DisablePixelLights = DisablePixelLights.PC;
                    component.TurnOffMirrorOcclusion = TurnOffMirrorOcclusion.PC;
                    component.m_ReflectLayers = ReflectLayers.PC;
                    break;
                case BuildTarget.Android:
                    component.m_DisablePixelLights = DisablePixelLights.Quest;
                    component.TurnOffMirrorOcclusion = TurnOffMirrorOcclusion.Quest;
                    component.m_ReflectLayers = ReflectLayers.Quest;
                    break;
                default:
                    break;
            }
        }
    }
}
#endif
