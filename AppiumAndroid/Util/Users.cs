namespace AppiumAndroid;

public enum UserProperty
{
    Referencia,
    NomeCompleto,
    NomeAbreviado,
    CPF_CNPJ,
    Banco,
    Agencia,
    Conta,
    TipoConta,
    Senha6Digitos,
    Senha4Digitos,
    Tarifa,
    Telefone,
    ValorTransferencia,
    CPF_Protegido
}
public class Users
{
    public required User[] User { get; set; }
}
public class User
{
    public required string Referencia { get; set; }
    public required string NomeCompleto { get; set; }
    public required string NomeAbreviado { get; set; }
    public required string CPF_CNPJ { get; set; }
    public required string Banco { get; set; }
    public required string Agencia { get; set; }
    public required string Conta { get; set; }
    public required string TipoConta { get; set; }
    public required string Senha6digitos { get; set; }
    public required string Senha4digitos { get; set; }
    public required string Tarifa { get; set; }
    public required string Telefone { get; set; }
    public required string ValorTransferencia { get; set; }
    public required string CPF_protegido { get; set; }
}
