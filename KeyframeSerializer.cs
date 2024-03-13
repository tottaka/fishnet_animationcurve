using FishNet.Serializing;
using UnityEngine;

public static class KeyframeSerializer
{
    public static void WriteKeyframe(this Writer writer, Keyframe value)
    {
        writer.WriteSingle(value.inTangent);
        writer.WriteSingle(value.inWeight);
        writer.WriteSingle(value.outTangent);
        writer.WriteSingle(value.outWeight);
        writer.WriteSingle(value.time);
        writer.WriteSingle(value.value);
        writer.WriteInt32((int)value.weightedMode);
    }

    public static Keyframe ReadKeyframe(this Reader reader) => new Keyframe
    {
        inTangent = reader.ReadSingle(),
        inWeight = reader.ReadSingle(),
        outTangent = reader.ReadSingle(),
        outWeight = reader.ReadSingle(),
        time = reader.ReadSingle(),
        value = reader.ReadSingle(),
        weightedMode = (WeightedMode)reader.ReadInt32()
    };

    public static void WriteKeyframes(this Writer writer, Keyframe[] values)
    {
        writer.WriteInt32(values.Length);
        for (int i = 0; i < values.Length; i++)
            writer.WriteKeyframe(values[i]);
    }

    public static Keyframe[] ReadKeyframes(this Reader reader)
    {
        int keyframeLength = reader.ReadInt32();
        Keyframe[] keyframes = new Keyframe[keyframeLength];

        for(int i = 0; i < keyframeLength; i++)
            keyframes[i] = ReadKeyframe(reader);

        return keyframes;
    }
}
