using System.Xml;
namespace QLBV.DungChung
{
    public class XML
    {
        public static void createNode(string pID, string pName, string pPrice, XmlTextWriter writer)
        {
            writer.WriteStartElement("product");
            writer.WriteStartElement("product_id");
            writer.WriteString(pID);
            writer.WriteEndElement();
            writer.WriteStartElement("product_name");
            writer.WriteString(pName);
            writer.WriteEndElement();
            writer.WriteStartElement("product_price");
            writer.WriteString(pPrice);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
