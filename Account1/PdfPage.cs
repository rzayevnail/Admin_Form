using iTextSharp.text.pdf;
using System.IO;

namespace Account1
{
    internal class PdfPage
    {
        public void ConvertFormToPdf(string formFilePath, string outputFilePath)
        {
            // Load the form
            var reader = new PdfReader(formFilePath);
            var output = new FileStream(outputFilePath, FileMode.Create);
            var stamper = new PdfStamper(reader, output);
            var form = stamper.AcroFields;

            // Modify the form fields as needed
            form.SetField("FieldName1", "Value1");
            form.SetField("FieldName2", "Value2");
            // Add more fields as necessary

            // Flatten the form (optional)
            stamper.FormFlattening = true;

            // Close the stamper and reader
            stamper.Close();
            reader.Close();
        }
    }
}