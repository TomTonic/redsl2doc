using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace org.redsl.Compiler
{
    public class DocGen
    {
        private int IDcounter = 0;

        private int DocumentNumber = 0;
        private int PackageNumber = 0;
        private int RelativeReqNumber = 0;

        private string GetID()
        {
            string result = "DocID" + IDcounter.ToString("X8");
            IDcounter++;
            return result;
        }

        private string GetDocumentNumberString()
        {
            string result = ToRoman(DocumentNumber) + ".";
            return result;
        }

        private string GetPackageNumberString()
        {
            string result = PackageNumber + ".";
            return result;
        }

        private string GetRelativeReqNumberString()
        {
            string result = "§\u202F" + GetDocumentNumberString() + GetPackageNumberString() + RelativeReqNumber + ".";
            return result;
        }

        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("number parameter value was "+number+", must be between 1 and 3999 (inclusively)");
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            // number must be <1
            return string.Empty;
        }

        public void GenerateDocuments(XDocument doc, string basefilename)
        {
            Util.CheckGen(doc, "1.0", "3");
            var docdeclNodes =
                from AnyElement in doc.Descendants()
                where (
                    (AnyElement.NodeType == XmlNodeType.Element)
                    && (((XElement)AnyElement).Name.Equals(XName.Get("DocumentDecl")))
                    )
                select AnyElement;

            foreach (XElement docDecl in docdeclNodes)
            {
                GenerateDocument(docDecl, basefilename);
            }
        }

        private void GenerateDocument(XElement docDecl, string basefilename)
        {
            DocumentNumber++;
            string myDocumentNumber = GetDocumentNumberString();
            string documentTitle = myDocumentNumber + "\t" + docDecl.Attribute("ID_STR").Value;
            string fullfilename = BuildFileName(basefilename, documentTitle);
            PackageNumber = 0;

            using WordprocessingDocument myDocument =
                            WordprocessingDocument.Create(fullfilename, WordprocessingDocumentType.Document);
            // Add a main part
            MainDocumentPart mainPart = myDocument.AddMainDocumentPart();
            AddStyles(myDocument);

            // Create the document structure
            mainPart.Document = new Document();
            Body body = mainPart.Document.AppendChild(new Body());

            Paragraph p = AppendParagraph(body, documentTitle);
            SetStype(p, "DocumentTitle");

            var docdeclNodes =
                from AnyElement in docDecl.Descendants()
                where (
                    (AnyElement.NodeType == XmlNodeType.Element)
                    && (((XElement)AnyElement).Name.Equals(XName.Get("PackageRef")))
                    )
                select AnyElement;

            foreach (XElement packageRef in docdeclNodes)
            {
                AddPackage(body, packageRef);
            }

            MarkAsVisited(docDecl);
        }

        private static string BuildFileName(string basefilename, string documentTitle)
        {
            if (!Directory.Exists(basefilename))
            {
                throw new Exception("The output parameter must be the name of an existing directory");
            }
            //if (!basefilename.EndsWith(Path.PathSeparator)) basefilename += Path.PathSeparator;
            string result = basefilename + documentTitle + ".docx";
            return result;
        }

        private static void AddStyles(WordprocessingDocument doc)
        {
            // Get the Styles part for this document.
            StyleDefinitionsPart styleDefPart =
                doc.MainDocumentPart.StyleDefinitionsPart;

            // If the Styles part does not exist, add it and then add the style.
            styleDefPart ??= AddStylesPartToPackage(doc);
            CreateAndAddParagraphStyle(styleDefPart, "DocumentTitle", "Document Title", new FontSize() { Val = "64" }, new Bold());
            CreateAndAddParagraphStyle(styleDefPart, "PackageTitle", "Package Title", new FontSize() { Val = "32" }, new Bold());
            CreateAndAddParagraphStyle(styleDefPart, "NoContent", "No-Content Paragraphs", new Italic());
            CreateAndAddParagraphStyle(styleDefPart, "RecDecl", "Requirement");
        }

        private static void MarkAsVisited(XElement node)
        {
            node.SetAttributeValue("visited", "true");
        }

        private void AddPackage(Body body, XElement packageRef)
        {
            PackageNumber++;
            RelativeReqNumber = 0;
            string myPackageNumber = GetPackageNumberString();
            string packageName = packageRef.Attribute("ID_STR").Value;
            Paragraph title = AppendParagraph(body, myPackageNumber + "\t" + packageName);
            SetStype(title, "PackageTitle");

            XElement root = packageRef.Document.Root;
            var packageNodes =
                from AnyElement in root.Descendants()
                where (
                    (AnyElement.NodeType == XmlNodeType.Element)
                    && (((XElement)AnyElement).Name.Equals(XName.Get("package")))
                    && (((XElement)AnyElement).Attribute("name").Value.Equals(packageName))
                    )
                select AnyElement;

            List<XElement> reqDeclNodes = [];
            foreach (XElement packageNode in packageNodes)
            {
                var children = packageNode.DescendantNodes();
                foreach (XElement child in children.Cast<XElement>())
                {
                    if (child.Name.Equals(XName.Get("RequirementDecl")))
                    {
                        reqDeclNodes.Add(child);
                    }
                }
                MarkAsVisited(packageNode);
            }
            if (reqDeclNodes.Count == 0)
            {
                Paragraph p = AppendParagraph(body, "No content.");
                SetStype(p, "NoContent");
            }
            else
            {
                // Paragraph p = appendParagraph(body, reqDeclNodes.Count + " requirement definitions.");
                // setStype(p, "Normal");
                // continue here
                foreach (XElement reqDeclNode in reqDeclNodes)
                {
                    AddReqDecl(body, reqDeclNode);
                }
            }
        }

        private void AddReqDecl(Body body, XElement reqDeclNode)
        {
            RelativeReqNumber++;
            string reqIDLabel = GetRelativeReqNumberString();
            string plainText = GetPlainTextFromReqDecl(reqDeclNode);
            Paragraph p = AppendParagraph(body, reqIDLabel + "\t" + plainText);
            //append(p, plainText);
            SetStype(p, "RecDecl");
        }

        private static void Append(Paragraph p, string plainText)
        {
            p.AppendChild(new Run(new Text(plainText) { Space = SpaceProcessingModeValues.Preserve }));
        }

        private static string GetPlainTextFromReqDecl(XElement reqDeclNode)
        {
            var textBlocks =
                    from AnyElement in reqDeclNode.Descendants()
                    where (
                        (AnyElement.NodeType == XmlNodeType.Element)
                        && (((XElement)AnyElement).Name.Equals(XName.Get("RunningText")))
                        )
                    select AnyElement;
            string result = "";
            foreach (var textBlock in textBlocks)
            {
                foreach (XElement child in textBlock.Descendants())
                {
                    result += child.Attribute("value").Value;
                }
                result += "\r\r";
            }
            return result;
        }

        private static Paragraph AppendParagraph(Body body, string text)
        {
            Paragraph p = new(new Run(new Text(text) { Space = SpaceProcessingModeValues.Preserve }));
            body.AppendChild(p);
            return p;
        }

        private static void SetStype(Paragraph p, string styleid)
        {
            // If the paragraph has no ParagraphProperties object, create one.
            if (!p.Elements<ParagraphProperties>().Any())
            {
                p.PrependChild<ParagraphProperties>(new ParagraphProperties());
            }

            // Get a reference to the ParagraphProperties object.
            ParagraphProperties pPr = p.ParagraphProperties;

            pPr.Justification = new Justification() { Val = JustificationValues.Both };
            pPr.Indentation = new Indentation() { FirstLine = "0", Hanging = "750" };

            // If a ParagraphStyleId object does not exist, create one.
            pPr.ParagraphStyleId ??= new ParagraphStyleId();

            // Set the style of the paragraph.
            pPr.ParagraphStyleId.Val = styleid;
        }

        public static void CreateAndAddParagraphStyle(StyleDefinitionsPart styleDefinitionsPart,
           string styleid, string stylename, params OpenXmlElement[] styleElements)
        {
            // Access the root element of the styles part.
            Styles styles = styleDefinitionsPart.Styles;
            if (styles == null)
            {
                styleDefinitionsPart.Styles = new Styles();
                styleDefinitionsPart.Styles.Save();
            }

            // Create a new paragraph style element and specify some of the attributes.
            Style style = new()
            {
                Type = StyleValues.Paragraph,
                StyleId = styleid,
                CustomStyle = true,
                Default = false
            };

            // Create and add the child elements (properties of the style).
            AutoRedefine autoredefine1 = new() { Val = OnOffOnlyValues.Off };
            //BasedOn basedon1 = new BasedOn() { Val = basedOn };
            Locked locked1 = new() { Val = OnOffOnlyValues.Off };
            PrimaryStyle primarystyle1 = new() { Val = OnOffOnlyValues.On };
            StyleHidden stylehidden1 = new() { Val = OnOffOnlyValues.Off };
            SemiHidden semihidden1 = new() { Val = OnOffOnlyValues.Off };
            StyleName styleName1 = new() { Val = stylename };
            NextParagraphStyle nextParagraphStyle1 = new() { Val = "Normal" };
            UIPriority uipriority1 = new() { Val = 1 };
            UnhideWhenUsed unhidewhenused1 = new() { Val = OnOffOnlyValues.On };

            style.Append(autoredefine1);
            //style.Append(basedon1);
            style.Append(locked1);
            style.Append(primarystyle1);
            style.Append(stylehidden1);
            style.Append(semihidden1);
            style.Append(styleName1);
            style.Append(nextParagraphStyle1);
            style.Append(uipriority1);
            style.Append(unhidewhenused1);

            // Create the StyleRunProperties object and specify some of the run properties.
            StyleRunProperties styleRunProperties = new();
            foreach (var styleElement in styleElements)
            {
                styleRunProperties.Append(styleElement);
            }

            // Add the run properties to the style.
            style.Append(styleRunProperties);

            // Add the style to the styles part.
            styles.Append(style);
        }

        // Add a StylesDefinitionsPart to the document.  Returns a reference to it.
        public static StyleDefinitionsPart AddStylesPartToPackage(WordprocessingDocument doc)
        {
            StyleDefinitionsPart part;
            part = doc.MainDocumentPart.AddNewPart<StyleDefinitionsPart>();
            Styles root = new();
            root.Save(part);
            return part;
        }
    }
}