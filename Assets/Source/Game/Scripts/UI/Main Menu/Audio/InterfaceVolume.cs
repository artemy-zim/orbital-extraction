public class InterfaceVolume : VolumeSlider
{
    protected override string GetParameter()
    {
        return AudioMixerData.Params.InterfaceVolume;
    }
}
