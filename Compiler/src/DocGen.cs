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
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
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
            throw new ArgumentOutOfRangeException("something bad happened");
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

            using (WordprocessingDocument myDocument =
                            WordprocessingDocument.Create(fullfilename, WordprocessingDocumentType.Document))
            {
                // Add a main part.   
                MainDocumentPart mainPart = myDocument.AddMainDocumentPart();
                AddStyles(myDocument);

                // Create the document structure.  
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());

                Paragraph p = appendParagraph(body, documentTitle);
                setStype(p, "DocumentTitle");

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
        }

        private string BuildFileName(string basefilename, string documentTitle)
        {
            if (!Directory.Exists(basefilename))
            {
                throw new Exception("The output parameter must be the name of an existing directory");
            }
            //if (!basefilename.EndsWith(Path.PathSeparator)) basefilename += Path.PathSeparator;
            string result = basefilename + documentTitle + ".docx";
            result.Replace('\t', ' ');
            return result;
        }

        private void AddStyles(WordprocessingDocument doc)
        {
            // Get the Styles part for this document.
            StyleDefinitionsPart styleDefPart =
                doc.MainDocumentPart.StyleDefinitionsPart;

            // If the Styles part does not exist, add it and then add the style.
            if (styleDefPart == null)
            {
                styleDefPart = AddStylesPartToPackage(doc);
            }
            CreateAndAddParagraphStyle(styleDefPart, "DocumentTitle", "Document Title", new FontSize() { Val = "64" }, new Bold());
            CreateAndAddParagraphStyle(styleDefPart, "PackageTitle", "Package Title", new FontSize() { Val = "32" }, new Bold());
            CreateAndAddParagraphStyle(styleDefPart, "NoContent", "No-Content Paragraphs", new Italic());
            CreateAndAddParagraphStyle(styleDefPart, "RecDecl", "Requirement", new Indentation() { FirstLine = "0", Hanging = "300" });
        }

        private void MarkAsVisited(XElement node)
        {
            node.SetAttributeValue("visited", "true");
        }

        private void AddPackage(Body body, XElement packageRef)
        {
            PackageNumber++;
            RelativeReqNumber = 0;
            string myPackageNumber = GetPackageNumberString();
            string packageName = packageRef.Attribute("ID_STR").Value;
            Paragraph title = appendParagraph(body, myPackageNumber + " " + packageName);
            setStype(title, "PackageTitle");


            XElement root = packageRef.Document.Root;
            var packageNodes =
                from AnyElement in root.Descendants()
                where (
                    (AnyElement.NodeType == XmlNodeType.Element)
                    && (((XElement)AnyElement).Name.Equals(XName.Get("package")))
                    && (((XElement)AnyElement).Attribute("name").Value.Equals(packageName))
                    )
                select AnyElement;

            List<XElement> reqDeclNodes = new List<XElement>();
            foreach (XElement packageNode in packageNodes)
            {
                var children = packageNode.DescendantNodes();
                foreach (XElement child in children)
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
                Paragraph p = appendParagraph(body, "No content.");
                setStype(p, "NoContent");
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
            Paragraph p = appendParagraph(body, reqIDLabel + "\t" + plainText);
            //append(p, plainText);
            setStype(p, "RecDecl");
        }

        private void append(Paragraph p, string plainText)
        {
            p.AppendChild(new Run(new Text(plainText) { Space = SpaceProcessingModeValues.Preserve }));
        }

        private string GetPlainTextFromReqDecl(XElement reqDeclNode)
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

        private Paragraph appendParagraph(Body body, string text)
        {
            Paragraph p = new Paragraph(new Run(new Text(text) { Space = SpaceProcessingModeValues.Preserve }));
            body.AppendChild(p);
            return p;
        }

        private void setStype(Paragraph p, string styleid)
        {
            // If the paragraph has no ParagraphProperties object, create one.
            if (p.Elements<ParagraphProperties>().Count() == 0)
            {
                p.PrependChild<ParagraphProperties>(new ParagraphProperties());
            }

            // Get a reference to the ParagraphProperties object.
            ParagraphProperties pPr = p.ParagraphProperties;

            // If a ParagraphStyleId object does not exist, create one.
            if (pPr.ParagraphStyleId == null)
                pPr.ParagraphStyleId = new ParagraphStyleId();

            // Set the style of the paragraph.
            pPr.ParagraphStyleId.Val = styleid;
        }

        public void CreateAndAddParagraphStyle(StyleDefinitionsPart styleDefinitionsPart,
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
            Style style = new Style()
            {
                Type = StyleValues.Paragraph,
                StyleId = styleid,
                CustomStyle = true,
                Default = false
            };

            // Create and add the child elements (properties of the style).
            AutoRedefine autoredefine1 = new AutoRedefine() { Val = OnOffOnlyValues.Off };
            //BasedOn basedon1 = new BasedOn() { Val = basedOn };
            Locked locked1 = new Locked() { Val = OnOffOnlyValues.Off };
            PrimaryStyle primarystyle1 = new PrimaryStyle() { Val = OnOffOnlyValues.On };
            StyleHidden stylehidden1 = new StyleHidden() { Val = OnOffOnlyValues.Off };
            SemiHidden semihidden1 = new SemiHidden() { Val = OnOffOnlyValues.Off };
            StyleName styleName1 = new StyleName() { Val = stylename };
            NextParagraphStyle nextParagraphStyle1 = new NextParagraphStyle() { Val = "Normal" };
            UIPriority uipriority1 = new UIPriority() { Val = 1 };
            UnhideWhenUsed unhidewhenused1 = new UnhideWhenUsed() { Val = OnOffOnlyValues.On };

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
            StyleRunProperties styleRunProperties = new StyleRunProperties();
            // Bold bold1 = new Bold();
            // Color color1 = new Color() { ThemeColor = ThemeColorValues.Accent2 };
            // RunFonts font1 = new RunFonts() { Ascii = "Lucida Console" };
            // Italic italic1 = new Italic();
            // // Specify a 12 point size.
            // FontSize fontSize1 = new FontSize() { Val = "24" };
            // styleRunProperties1.Append(bold1);
            // styleRunProperties1.Append(color1);
            // styleRunProperties1.Append(font1);
            // styleRunProperties1.Append(fontSize1);
            // styleRunProperties1.Append(italic1);

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
        public StyleDefinitionsPart AddStylesPartToPackage(WordprocessingDocument doc)
        {
            StyleDefinitionsPart part;
            part = doc.MainDocumentPart.AddNewPart<StyleDefinitionsPart>();
            Styles root = new Styles();
            root.Save(part);
            return part;
        }
    }
}