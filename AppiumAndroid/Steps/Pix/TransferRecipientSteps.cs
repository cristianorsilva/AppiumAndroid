namespace AppiumAndroid;

public class TransferRecipientSteps
{
    TransferRecipientScreen transferRecipientScreen = new TransferRecipientScreen();

    public void InformarChavePixTipoCPFCPNJ(string nomeReferenciaUsuario)
    {
        string chavePixCPFCNPJ = transferRecipientScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaUsuario, UserProperty.CPF_CNPJ);
        transferRecipientScreen.TapElement(transferRecipientScreen.BtnCPFCNPJ);
        transferRecipientScreen.TapElement(transferRecipientScreen.TxtChavePix);
        transferRecipientScreen.TxtChavePix.SendKeys(chavePixCPFCNPJ);
    }

    public void TapAvancar()
    {
        transferRecipientScreen.TapElement(transferRecipientScreen.BtnSetaDireita);
    }
}
