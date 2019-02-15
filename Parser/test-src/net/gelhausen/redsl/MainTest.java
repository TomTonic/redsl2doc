package net.gelhausen.redsl;

import static org.junit.jupiter.api.Assertions.*;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.tree.*;


class MainTest {

    private ReDSLParser getParser(String stringToParse) {
        CharStream cs = CharStreams.fromString(stringToParse);
        ReDSLLexer lexer = new ReDSLLexer(cs);
        CommonTokenStream tokens = new CommonTokenStream(lexer);
        ReDSLParser parser = new ReDSLParser(tokens);
        return parser;
    }

    private int getSyntaxErrorsInString(String s) {
        ReDSLParser p = getParser(s);
        ParseTree tree = p.parse();
        int numSyntaxErr = p.getNumberOfSyntaxErrors();
        return numSyntaxErr;
    }

    @org.junit.jupiter.api.BeforeEach
    void setUp() {
    }

    @org.junit.jupiter.api.Test
    void testEmptyString() {
        String test = "";
        assertEquals(0, getSyntaxErrorsInString(test));
    }

    @org.junit.jupiter.api.Test
    void testOnlyWS() {
        String test = " \r\n\r\n  \t\r\n";
        assertEquals(0, getSyntaxErrorsInString(test));
    }

    /*
     * Basic Tests for file Blocks
     */
    @org.junit.jupiter.api.Test
    void testEmptyFileBlock() {
        String test = "file \"x\" {}";
        assertEquals(0, getSyntaxErrorsInString(test));
    }

    @org.junit.jupiter.api.Test
    void testEmptyFileBlockEmptyPath() {
        String test = "file \"\" {}";
        assertEquals(0, getSyntaxErrorsInString(test));
    }

    @org.junit.jupiter.api.Test
    void testEmptyFileBlockNoPath() {
        String test = "file {}"; // invalid - no path expression!
        assertEquals(1, getSyntaxErrorsInString(test));
    }

    @org.junit.jupiter.api.Test
    void testEmptyFileBlockWS() {
        String test = "file \"x\" { }";
        assertEquals(0, getSyntaxErrorsInString(test));
    }

    @org.junit.jupiter.api.Test
    void testEmptyFileBlockMultiWS() {
        String test = "file \"x\" { \r \n \t   }";
        assertEquals(0, getSyntaxErrorsInString(test));
    }

    /*
     * Basic tests for requirement declarations
     */
    @org.junit.jupiter.api.Test
    void testEmptyAnonymousReqDecl() {
        String test = "§_{}";
        assertEquals(0, getSyntaxErrorsInString(test));
    }

    @org.junit.jupiter.api.Test
    void testEmptyReqDecl() {
        String test = "§abc{}";
        assertEquals(0, getSyntaxErrorsInString(test));
    }

    @org.junit.jupiter.api.Test
    void testEmptyReqDeclIdWithDigits() {
        String test = "§1abc2{}";
        assertEquals(0, getSyntaxErrorsInString(test));
    }

    @org.junit.jupiter.api.Test
    void testEmptyReqDeclIdOnlyDigits() {
        String test = "§1.2{}";
        assertEquals(0, getSyntaxErrorsInString(test));
    }

    @org.junit.jupiter.api.Test
    void testEmptyReqDeclWS() {
        String test = "§abc \t\r\n{ \r\n\r\n  \r\n\t\n\t}   ";
        assertEquals(0, getSyntaxErrorsInString(test));
    }

    /*
     * Package declaration
     */
    @org.junit.jupiter.api.Test
    void testPackageDecl() {
        String test = "package \"abc\"";
        assertEquals(0, getSyntaxErrorsInString(test));
    }

    /*
     * Package and requirement declarations in file block
     */

    @org.junit.jupiter.api.Test
    void testFileBlockWithPackageAndReq() {
        String test = "file \"x\" { package \"a\" §2{}  }";
        assertEquals(0, getSyntaxErrorsInString(test));
    }

    @org.junit.jupiter.api.Test
    void testFileBlockWithPackagesOnly() {
        String test = "file \"x\" { package \"a\" \n\r\n\r package \"b\" package \"c\"  }";
        assertEquals(0, getSyntaxErrorsInString(test));
    }

    @org.junit.jupiter.api.Test
    void testFileBlockWithReqOnly() {
        String test = "file \"x\" { §1{}\n\r\n\r\t§2{}§3{}  }";
        assertEquals(0, getSyntaxErrorsInString(test));
    }

    @org.junit.jupiter.api.Test
    void testMixedLevelInvalid() {
        String test = "file \"x\" { §1{} } §2{}";
        assertEquals(0, getSyntaxErrorsInString(test));
    }
}