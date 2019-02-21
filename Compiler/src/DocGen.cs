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
        public static void GenerateDocuments(XDocument doc, string basefilename)
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

        private static void GenerateDocument(XElement docDecl, string basefilename)
        {
            string documentTitle = docDecl.Attribute("ID_STR").Value;
            string fullfilename = basefilename + "." + documentTitle + ".docx";

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

        private static void AddStyles(WordprocessingDocument doc)
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
        }

        private static void MarkAsVisited(XElement node)
        {
            node.SetAttributeValue("visited", "true");
        }

        private static void AddPackage(Body body, XElement packageRef)
        {
            string packageName = packageRef.Attribute("ID_STR").Value;
            Paragraph title = appendParagraph(body, packageName);
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

                Paragraph p = appendParagraph(body, reqDeclNodes.Count + " requirement definitions.");
                setStype(p, "Normal");
                // continue here
                // foreach(XElement reqDeclNode in reqDeclNodes)
                // {
                //     AddReqDecl(body, reqDeclNode);
                // }  
            }
        }

        private static Paragraph appendParagraph(Body body, string text)
        {
            Paragraph p = new Paragraph(new Run(new Text(text) { Space = SpaceProcessingModeValues.Preserve }));
            body.AppendChild(p);
            return p;
        }

        private static void setStype(Paragraph p, string styleid)
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
        public static StyleDefinitionsPart AddStylesPartToPackage(WordprocessingDocument doc)
        {
            StyleDefinitionsPart part;
            part = doc.MainDocumentPart.AddNewPart<StyleDefinitionsPart>();
            Styles root = new Styles();
            root.Save(part);
            return part;
        }
    }
}