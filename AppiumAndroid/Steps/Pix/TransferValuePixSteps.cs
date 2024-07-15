namespace AppiumAndroid;

public class TransferValuePixSteps
{
    TransferValuePixScreen transferValuePixScreen = new TransferValuePixScreen();

    public void InformarValorTransferencia(string nomeReferenciaUsuario)
    {
        string valorTransferencia = transferValuePixScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaUsuario, UserProperty.ValorTransferencia);
        transferValuePixScreen.TapElement(transferValuePixScreen.TxtValor);
        transferValuePixScreen.TxtValor.SendKeys(valorTransferencia);
    }

    public void TapAvancar()
    {
        transferValuePixScreen.TapElement(transferValuePixScreen.BtnSetaDireita);
    }
}
