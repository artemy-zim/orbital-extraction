public class MasterVolume : VolumeButton
{
    protected override string GetParameter()
    {
        return AudioMixerData.Params.MasterVolume;
    }
}
