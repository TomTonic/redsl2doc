using System;
using System.IO;
using Antlr4.Runtime.Misc;
using org.redsl.antlr;

namespace org.redsl.ANTLRReader
{
    public class XMLBuildingVisitor:ReDSLParserBaseVisitor<object>
    {
        StreamWriter sw = null;

        public XMLBuildingVisitor()
        {
            sw = new StreamWriter(Console.OpenStandardOutput());
            sw.AutoFlush = true;
            Console.SetOut(sw);
        }

        public override object VisitBoolParamDecl([NotNull] ReDSLParser.BoolParamDeclContext context)
        {
            return base.VisitBoolParamDecl(context);
        }

        public override object VisitExampleDecl([NotNull] ReDSLParser.ExampleDeclContext context)
        {
            return base.VisitExampleDecl(context);
        }

        public override object VisitFileBlock([NotNull] ReDSLParser.FileBlockContext context)
        {
            return base.VisitFileBlock(context);
        }

        public override object VisitIdListParamDecl([NotNull] ReDSLParser.IdListParamDeclContext context)
        {
            return base.VisitIdListParamDecl(context);
        }

        public override object VisitIdParamDecl([NotNull] ReDSLParser.IdParamDeclContext context)
        {
            return base.VisitIdParamDecl(context);
        }

        public override object VisitMathModeExpression([NotNull] ReDSLParser.MathModeExpressionContext context)
        {
            return base.VisitMathModeExpression(context);
        }

        public override object VisitNumericParamDecl([NotNull] ReDSLParser.NumericParamDeclContext context)
        {
            return base.VisitNumericParamDecl(context);
        }

        public override object VisitPackageDecl([NotNull] ReDSLParser.PackageDeclContext context)
        {
            return base.VisitPackageDecl(context);
        }

        public override object VisitParamDecl([NotNull] ReDSLParser.ParamDeclContext context)
        {
            return base.VisitParamDecl(context);
        }

        public override object VisitParameterBlock([NotNull] ReDSLParser.ParameterBlockContext context)
        {
            return base.VisitParameterBlock(context);
        }

        public override object VisitParse([NotNull] ReDSLParser.ParseContext context)
        {
            return base.VisitParse(context);
        }

        public override object VisitRationaleDecl([NotNull] ReDSLParser.RationaleDeclContext context)
        {
            return base.VisitRationaleDecl(context);
        }

        public override object VisitReferenceDecl([NotNull] ReDSLParser.ReferenceDeclContext context)
        {
            return base.VisitReferenceDecl(context);
        }

        public override object VisitRequirementDecl([NotNull] ReDSLParser.RequirementDeclContext context)
        {
            return base.VisitRequirementDecl(context);
        }

        public override object VisitRunningText([NotNull] ReDSLParser.RunningTextContext context)
        {
            return base.VisitRunningText(context);
        }

        public override object VisitStringParamDecl([NotNull] ReDSLParser.StringParamDeclContext context)
        {
            return base.VisitStringParamDecl(context);
        }

        public override object VisitTextBlock([NotNull] ReDSLParser.TextBlockContext context)
        {
            return base.VisitTextBlock(context);
        }

        public override object VisitTextBlockContentFirst([NotNull] ReDSLParser.TextBlockContentFirstContext context)
        {
            return base.VisitTextBlockContentFirst(context);
        }

        public override object VisitTextBlockContentNext([NotNull] ReDSLParser.TextBlockContentNextContext context)
        {
            return base.VisitTextBlockContentNext(context);
        }
    }
}
