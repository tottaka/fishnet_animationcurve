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

    public static void WriteAnimationCurves(this Writer writer, AnimationCurve[] values)
    {
        writer.WriteInt32(values.Length);
        for (int i = 0; i < values.Length; i++)
            writer.WriteAnimationCurve(values[i]);
    }

    public static AnimationCurve[] ReadAnimationCurves(this Reader reader)
    {
        int curveCount = reader.ReadInt32();
        AnimationCurve[] curves = new AnimationCurve[curveCount];

        for (int i = 0; i < curveCount; i++)
            curves[i] = ReadAnimationCurve(reader);

        return curves;
    }
}
