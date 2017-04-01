namespace XInput2Key.Service
{
    public interface ISendKeysService
    {
        void SendKeys(INPUT[] inputs);
    }

    public class SendKeysService : ISendKeysService
    {
        public void SendKeys(INPUT[] inputs)
        {
            if (inputs != null && inputs.Length > 0)
                NativeApi.SendInput((uint)inputs.Length, inputs, INPUT.Size);
        }
    }
}
