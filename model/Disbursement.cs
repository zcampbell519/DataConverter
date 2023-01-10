using System.ComponentModel.DataAnnotations;
using System.Data.Odbc;
using System.Reflection;

public class Disbursement :ILasModel<Disbursement>{
    public string TableName => "disbursement";
    [Key]
    public int Id { get; set; }
    [RFAccessField(0)]
    [RIPAccessField(0)]
    [WDLAccessField(0)]
    public string LoanNumber { get; set; }

    [LasSqlField("disbursement_number")]
    [LasIdentifierField]
    [RFAccessField(1)]
    [RIPAccessField(1)]
    [WDLAccessField(1)]
    public int DisbursementNumber { get; set; }

    [LasSqlField("disbursed_date")]
    [RFAccessField(2)]
    [RIPAccessField(2)]
    [WDLAccessField(2)]
    public DateTime DisbursedDate { get; set; }
    [RIPAccessField(3)]
    [WDLAccessField(3)]
    public int DocCd { get; set; }
    [RIPAccessField(4)]
    [WDLAccessField(4)]
    public string DocNo { get; set; }
    [LasSqlField("sabhrs_document_number")]
    [RIPAccessField(5)]
    [WDLAccessField(5)]
    public int DocumentNumber { get; set; }
    [RIPAccessField(6)]
    [WDLAccessField(6)]
    public DateTime WrntDt { get; set; }
    [LasSqlField("disbursed_amount")]
    [RFAccessField(4)]
    [RIPAccessField(7)]
    [WDLAccessField(7)]
    public decimal DisbursementAmount { get; set; }
    [LasSqlField("loan_id")]
    [LasIdentifierField]
    public int LoanId { get; set; }
    
    [LasSqlField("disbursed_by")]
    public string DisbursedBy { get; set; }
    
    [LasSqlField("entered_date")]
    public DateTime EnteredDate { get; set; }
    

    public Disbursement(OdbcDataReader reader, string database)
    {
        EnteredDate = DateTime.Now;
        Attribute attrType = AttributeFactory.GetAttributeType(database); 
        var props = typeof(Disbursement).GetProperties().Where(p => Attribute.IsDefined(p, attrType.GetType()));
        foreach(var p in props){
            AccessFieldAttribute a = (AccessFieldAttribute)(p.GetCustomAttribute(attrType.GetType()));
            this.GetType().GetProperty(p.Name).SetValue(this, reader.ConvertValueOrDefault(a.Position, p.PropertyType));
        }
    }

}