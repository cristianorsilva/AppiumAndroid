namespace AppiumAndroid;

public class PixSteps
{
    PixScreen pixScreen = new PixScreen();

    public void TransferirComPix()
    {
        pixScreen.TapElement(pixScreen.BtnTransferirComPix);
    }

    public void MinhasChaves()
    {
        pixScreen.TapElement(pixScreen.BtnMinhasChaves);
    }
}
