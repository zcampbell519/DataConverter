public static class AttributeFactory
{
    public static Attribute GetAttributeType(string db){
        switch(db){
            case "SRF":
            case "WRF":
                return new RFAccessFieldAttribute(0);
            case "WDL":
                return new WDLAccessFieldAttribute(0);
            case "RIP":
                return new RIPAccessFieldAttribute(0);
            default:
                throw new NotImplementedException();
        }
    }
}