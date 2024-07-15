namespace AppiumAndroid;

public class PixTest : BaseTest
{
    LoginSteps loginSteps = new();
    HomeSteps homeSteps = new();
    PixSteps pixSteps = new();
    TransferValuePixSteps transferValuePixSteps = new();
    TransferRecipientSteps transferRecipientSteps = new();
    TransferReviewSteps transferReviewSteps = new();
    TransferReceiptSteps transferReceiptSteps = new();

    [Test, Order(1)]
    public void ValidarDadosDestinatario()
    {
        //Efetua o login
        loginSteps.InformarUsuarioSenha("USUÁRIO A");
        loginSteps.EfetuarLogin();
        loginSteps.PermitirLocalizacao();

        //Seleciona a opção Pix
        homeSteps.SelecionarPix();

        //Seleciona a opção Transferir com Pix
        pixSteps.TransferirComPix();

        //Informa o valor a ser Transferido
        transferValuePixSteps.InformarValorTransferencia("USUÁRIO A");
        transferValuePixSteps.TapAvancar();

        //Informa a chave pix do destinatário
        transferRecipientSteps.InformarChavePixTipoCPFCPNJ("USUÁRIO B");
        transferRecipientSteps.TapAvancar();

        //Valida dados da tela de revisão de transferência
        transferReviewSteps.ValidarDadosTransferencia("USUÁRIO A", "USUÁRIO B");

    }

    [Test, Order(1)]
    public void TransferenciaPixChaveCPFComSucesso()
    {
        //Efetua o login
        loginSteps.InformarUsuarioSenha("USUÁRIO A");
        loginSteps.EfetuarLogin();
        loginSteps.PermitirLocalizacao();

        //Seleciona a opção Pix
        homeSteps.SelecionarPix();

        //Seleciona a opção Transferir com Pix
        pixSteps.TransferirComPix();

        //Informa o valor a ser Transferido
        transferValuePixSteps.InformarValorTransferencia("USUÁRIO A");
        transferValuePixSteps.TapAvancar();

        //Informa a chave pix do destinatário
        transferRecipientSteps.InformarChavePixTipoCPFCPNJ("USUÁRIO B");
        transferRecipientSteps.TapAvancar();

        //Confirma a transferência
        transferReviewSteps.TapTransferir();

        //Valida dados do Comprovante de Transferência
        transferReceiptSteps.AguardarComprovanteNaTela();
        transferReceiptSteps.ValidarDadosComprovante("USUÁRIO A", "USUÁRIO B");
    }
}

//https://www.browserstack.com/docs/app-automate/appium/set-up-tests/mark-tests-as-pass-fail