public class EffectsVolume : VolumeSlider
{
    protected override string GetParameter()
    {
        return AudioMixerData.Params.EffectsVolume;
    }
}
