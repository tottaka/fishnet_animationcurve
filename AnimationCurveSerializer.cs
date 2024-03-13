using FishNet.Serializing;
using UnityEngine;

public static class AnimationCurveSerializer
{
    public static void WriteAnimationCurve(this Writer writer, AnimationCurve value)
    {
        writer.WriteInt32((int)value.postWrapMode);
        writer.WriteInt32((int)value.preWrapMode);
        writer.WriteKeyframes(value.keys);
    }

    public static AnimationCurve ReadAnimationCurve(this Reader reader)
    {
        WrapMode _postWrapMode = (WrapMode)reader.ReadInt32();
        WrapMode _preWrapMode = (WrapMode)reader.ReadInt32();
        return new AnimationCurve {
            postWrapMode = _postWrapMode,
            preWrapMode = _preWrapMode,
            keys = reader.ReadKeyframes()
        };
    }
}
