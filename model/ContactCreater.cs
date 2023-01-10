public class ContactCreater
{
    public ContactCreater(string firstName, string lastName, string attnNm)
    {
        ContFrstNm = firstName;
        ContLastNm = lastName;
        AttnNm = attnNm;
    }

    public ContactCreater(string applCont){
        ContFrstNm = applCont;
        ContLastNm = "";
        AttnNm = "";
    }

    public string ContFrstNm { get; set; }
    public string ContLastNm { get; set; }
    public string AttnNm { get; set; }

    public Contact GetContact()
    {
        return new Contact(ContFrstNm.Contains(' ') ? ContFrstNm.Split(' ')[0] : ContFrstNm, "", ContFrstNm.Contains(' ') ? ContFrstNm.Split(' ')[1] : ContLastNm, "");
    }

    public CustomerContact GetCustomerContact()
    {
        string attnNm = AttnNm.ToUpper();
        string salutation = attnNm.Contains("MR. ") || attnNm.Contains("MR ") ? "MR." : attnNm.Contains("MRS") || attnNm.Contains("MRS. ") ? "MRS." : attnNm.Contains("MS ") || attnNm.Contains("MS. ") ? "MS." : "";
        string title = ContFrstNm.Contains(' ') ? ContLastNm : "";
        return new CustomerContact(salutation, title);
    }
}