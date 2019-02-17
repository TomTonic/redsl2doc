// Generated from /Users/tom/git/ReDSL/Parser/antlr/ReDSLParser.g4 by ANTLR 4.7.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class ReDSLParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		FILE_KEYWORD=1, FILE_BLOCK_START=2, FILE_BLOCK_END=3, PACKAGE_KEYWORD=4, 
		ID_STR=5, ID_STR_ESC_SEQ=6, WS=7, REQ_DEF=8, PARAM_START=9, TEXT_START=10, 
		REQ_DEF_WS=11, TEXT_CLOSE=12, TEXT_COMMENT=13, TEXT_WS=14, TEXT_LINE_BREAK=15, 
		TEXT_NEXT_PARA=16, TEXT_EXAMPLE_MARKER=17, TEXT_RATIO_MARKER=18, TEXT_REF_MARKER=19, 
		TEXT_RE_ID_REF=20, TEXT_URI=21, TEXT_TERM_REF=22, TEXT_START_MATH=23, 
		TEXT_ESC_SEQ=24, TEXT_CONTENT=25, PARAM_CLOSE=26, PARAM_ID=27, PARAM_EQUALS=28, 
		PARAM_STRING=29, PARAM_ID_LIST_START=30, PARAM_ID_LIST_SEP=31, PARAM_ID_LIST_END=32, 
		PARAM_BOOL=33, PARAM_NUMBER=34, PARAM_WS=35, MATH_CLOSE=36, MATH_ESC_SEQ=37, 
		MATH_CONTENT=38;
	public static final int
		RULE_parse = 0, RULE_fileBlock = 1, RULE_packageDecl = 2, RULE_requirementDecl = 3, 
		RULE_textBlock = 4, RULE_textBlockContentFirst = 5, RULE_textBlockContentNext = 6, 
		RULE_exampleDecl = 7, RULE_rationaleDecl = 8, RULE_referenceDecl = 9, 
		RULE_runningText = 10, RULE_parameterBlock = 11, RULE_paramDecl = 12, 
		RULE_stringParamDecl = 13, RULE_idParamDecl = 14, RULE_numericParamDecl = 15, 
		RULE_boolParamDecl = 16, RULE_idListParamDecl = 17, RULE_mathModeExpression = 18;
	public static final String[] ruleNames = {
		"parse", "fileBlock", "packageDecl", "requirementDecl", "textBlock", "textBlockContentFirst", 
		"textBlockContentNext", "exampleDecl", "rationaleDecl", "referenceDecl", 
		"runningText", "parameterBlock", "paramDecl", "stringParamDecl", "idParamDecl", 
		"numericParamDecl", "boolParamDecl", "idListParamDecl", "mathModeExpression"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "'file'", null, null, "'package'", null, null, null, null, "'['", 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, "']'", null, "'='", null, null, "','"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "FILE_KEYWORD", "FILE_BLOCK_START", "FILE_BLOCK_END", "PACKAGE_KEYWORD", 
		"ID_STR", "ID_STR_ESC_SEQ", "WS", "REQ_DEF", "PARAM_START", "TEXT_START", 
		"REQ_DEF_WS", "TEXT_CLOSE", "TEXT_COMMENT", "TEXT_WS", "TEXT_LINE_BREAK", 
		"TEXT_NEXT_PARA", "TEXT_EXAMPLE_MARKER", "TEXT_RATIO_MARKER", "TEXT_REF_MARKER", 
		"TEXT_RE_ID_REF", "TEXT_URI", "TEXT_TERM_REF", "TEXT_START_MATH", "TEXT_ESC_SEQ", 
		"TEXT_CONTENT", "PARAM_CLOSE", "PARAM_ID", "PARAM_EQUALS", "PARAM_STRING", 
		"PARAM_ID_LIST_START", "PARAM_ID_LIST_SEP", "PARAM_ID_LIST_END", "PARAM_BOOL", 
		"PARAM_NUMBER", "PARAM_WS", "MATH_CLOSE", "MATH_ESC_SEQ", "MATH_CONTENT"
	};
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "ReDSLParser.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public ReDSLParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}
	public static class ParseContext extends ParserRuleContext {
		public List<FileBlockContext> fileBlock() {
			return getRuleContexts(FileBlockContext.class);
		}
		public FileBlockContext fileBlock(int i) {
			return getRuleContext(FileBlockContext.class,i);
		}
		public List<PackageDeclContext> packageDecl() {
			return getRuleContexts(PackageDeclContext.class);
		}
		public PackageDeclContext packageDecl(int i) {
			return getRuleContext(PackageDeclContext.class,i);
		}
		public List<RequirementDeclContext> requirementDecl() {
			return getRuleContexts(RequirementDeclContext.class);
		}
		public RequirementDeclContext requirementDecl(int i) {
			return getRuleContext(RequirementDeclContext.class,i);
		}
		public ParseContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parse; }
	}

	public final ParseContext parse() throws RecognitionException {
		ParseContext _localctx = new ParseContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_parse);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(49);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case FILE_KEYWORD:
				{
				setState(39); 
				_errHandler.sync(this);
				_la = _input.LA(1);
				do {
					{
					{
					setState(38);
					fileBlock();
					}
					}
					setState(41); 
					_errHandler.sync(this);
					_la = _input.LA(1);
				} while ( _la==FILE_KEYWORD );
				}
				break;
			case PACKAGE_KEYWORD:
			case REQ_DEF:
				{
				setState(45); 
				_errHandler.sync(this);
				_la = _input.LA(1);
				do {
					{
					setState(45);
					_errHandler.sync(this);
					switch (_input.LA(1)) {
					case PACKAGE_KEYWORD:
						{
						setState(43);
						packageDecl();
						}
						break;
					case REQ_DEF:
						{
						setState(44);
						requirementDecl();
						}
						break;
					default:
						throw new NoViableAltException(this);
					}
					}
					setState(47); 
					_errHandler.sync(this);
					_la = _input.LA(1);
				} while ( _la==PACKAGE_KEYWORD || _la==REQ_DEF );
				}
				break;
			case EOF:
				break;
			default:
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FileBlockContext extends ParserRuleContext {
		public TerminalNode FILE_KEYWORD() { return getToken(ReDSLParser.FILE_KEYWORD, 0); }
		public TerminalNode ID_STR() { return getToken(ReDSLParser.ID_STR, 0); }
		public TerminalNode FILE_BLOCK_START() { return getToken(ReDSLParser.FILE_BLOCK_START, 0); }
		public TerminalNode FILE_BLOCK_END() { return getToken(ReDSLParser.FILE_BLOCK_END, 0); }
		public List<PackageDeclContext> packageDecl() {
			return getRuleContexts(PackageDeclContext.class);
		}
		public PackageDeclContext packageDecl(int i) {
			return getRuleContext(PackageDeclContext.class,i);
		}
		public List<RequirementDeclContext> requirementDecl() {
			return getRuleContexts(RequirementDeclContext.class);
		}
		public RequirementDeclContext requirementDecl(int i) {
			return getRuleContext(RequirementDeclContext.class,i);
		}
		public FileBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_fileBlock; }
	}

	public final FileBlockContext fileBlock() throws RecognitionException {
		FileBlockContext _localctx = new FileBlockContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_fileBlock);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(51);
			match(FILE_KEYWORD);
			setState(52);
			match(ID_STR);
			setState(53);
			match(FILE_BLOCK_START);
			setState(58);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==PACKAGE_KEYWORD || _la==REQ_DEF) {
				{
				setState(56);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case PACKAGE_KEYWORD:
					{
					setState(54);
					packageDecl();
					}
					break;
				case REQ_DEF:
					{
					setState(55);
					requirementDecl();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(60);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(61);
			match(FILE_BLOCK_END);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PackageDeclContext extends ParserRuleContext {
		public TerminalNode PACKAGE_KEYWORD() { return getToken(ReDSLParser.PACKAGE_KEYWORD, 0); }
		public TerminalNode ID_STR() { return getToken(ReDSLParser.ID_STR, 0); }
		public PackageDeclContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_packageDecl; }
	}

	public final PackageDeclContext packageDecl() throws RecognitionException {
		PackageDeclContext _localctx = new PackageDeclContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_packageDecl);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(63);
			match(PACKAGE_KEYWORD);
			setState(64);
			match(ID_STR);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class RequirementDeclContext extends ParserRuleContext {
		public TerminalNode REQ_DEF() { return getToken(ReDSLParser.REQ_DEF, 0); }
		public TextBlockContext textBlock() {
			return getRuleContext(TextBlockContext.class,0);
		}
		public ParameterBlockContext parameterBlock() {
			return getRuleContext(ParameterBlockContext.class,0);
		}
		public RequirementDeclContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_requirementDecl; }
	}

	public final RequirementDeclContext requirementDecl() throws RecognitionException {
		RequirementDeclContext _localctx = new RequirementDeclContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_requirementDecl);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(66);
			match(REQ_DEF);
			setState(68);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==PARAM_START) {
				{
				setState(67);
				parameterBlock();
				}
			}

			setState(70);
			textBlock();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TextBlockContext extends ParserRuleContext {
		public TerminalNode TEXT_START() { return getToken(ReDSLParser.TEXT_START, 0); }
		public TerminalNode TEXT_CLOSE() { return getToken(ReDSLParser.TEXT_CLOSE, 0); }
		public TextBlockContentFirstContext textBlockContentFirst() {
			return getRuleContext(TextBlockContentFirstContext.class,0);
		}
		public TerminalNode TEXT_NEXT_PARA() { return getToken(ReDSLParser.TEXT_NEXT_PARA, 0); }
		public List<TextBlockContentNextContext> textBlockContentNext() {
			return getRuleContexts(TextBlockContentNextContext.class);
		}
		public TextBlockContentNextContext textBlockContentNext(int i) {
			return getRuleContext(TextBlockContentNextContext.class,i);
		}
		public TextBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_textBlock; }
	}

	public final TextBlockContext textBlock() throws RecognitionException {
		TextBlockContext _localctx = new TextBlockContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_textBlock);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(72);
			match(TEXT_START);
			setState(80);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,8,_ctx) ) {
			case 1:
				{
				setState(73);
				textBlockContentFirst();
				setState(77);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,7,_ctx);
				while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
					if ( _alt==1 ) {
						{
						{
						setState(74);
						textBlockContentNext();
						}
						} 
					}
					setState(79);
					_errHandler.sync(this);
					_alt = getInterpreter().adaptivePredict(_input,7,_ctx);
				}
				}
				break;
			}
			setState(83);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TEXT_NEXT_PARA) {
				{
				setState(82);
				match(TEXT_NEXT_PARA);
				}
			}

			setState(85);
			match(TEXT_CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TextBlockContentFirstContext extends ParserRuleContext {
		public RunningTextContext runningText() {
			return getRuleContext(RunningTextContext.class,0);
		}
		public TerminalNode TEXT_NEXT_PARA() { return getToken(ReDSLParser.TEXT_NEXT_PARA, 0); }
		public TextBlockContentFirstContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_textBlockContentFirst; }
	}

	public final TextBlockContentFirstContext textBlockContentFirst() throws RecognitionException {
		TextBlockContentFirstContext _localctx = new TextBlockContentFirstContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_textBlockContentFirst);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(88);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==TEXT_NEXT_PARA) {
				{
				setState(87);
				match(TEXT_NEXT_PARA);
				}
			}

			setState(90);
			runningText();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class TextBlockContentNextContext extends ParserRuleContext {
		public ExampleDeclContext exampleDecl() {
			return getRuleContext(ExampleDeclContext.class,0);
		}
		public RationaleDeclContext rationaleDecl() {
			return getRuleContext(RationaleDeclContext.class,0);
		}
		public ReferenceDeclContext referenceDecl() {
			return getRuleContext(ReferenceDeclContext.class,0);
		}
		public TerminalNode TEXT_NEXT_PARA() { return getToken(ReDSLParser.TEXT_NEXT_PARA, 0); }
		public RunningTextContext runningText() {
			return getRuleContext(RunningTextContext.class,0);
		}
		public TextBlockContentNextContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_textBlockContentNext; }
	}

	public final TextBlockContentNextContext textBlockContentNext() throws RecognitionException {
		TextBlockContentNextContext _localctx = new TextBlockContentNextContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_textBlockContentNext);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(97);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case TEXT_EXAMPLE_MARKER:
				{
				setState(92);
				exampleDecl();
				}
				break;
			case TEXT_RATIO_MARKER:
				{
				setState(93);
				rationaleDecl();
				}
				break;
			case TEXT_REF_MARKER:
				{
				setState(94);
				referenceDecl();
				}
				break;
			case TEXT_NEXT_PARA:
				{
				{
				setState(95);
				match(TEXT_NEXT_PARA);
				setState(96);
				runningText();
				}
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExampleDeclContext extends ParserRuleContext {
		public TerminalNode TEXT_EXAMPLE_MARKER() { return getToken(ReDSLParser.TEXT_EXAMPLE_MARKER, 0); }
		public RunningTextContext runningText() {
			return getRuleContext(RunningTextContext.class,0);
		}
		public ExampleDeclContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_exampleDecl; }
	}

	public final ExampleDeclContext exampleDecl() throws RecognitionException {
		ExampleDeclContext _localctx = new ExampleDeclContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_exampleDecl);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(99);
			match(TEXT_EXAMPLE_MARKER);
			setState(100);
			runningText();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class RationaleDeclContext extends ParserRuleContext {
		public TerminalNode TEXT_RATIO_MARKER() { return getToken(ReDSLParser.TEXT_RATIO_MARKER, 0); }
		public RunningTextContext runningText() {
			return getRuleContext(RunningTextContext.class,0);
		}
		public RationaleDeclContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_rationaleDecl; }
	}

	public final RationaleDeclContext rationaleDecl() throws RecognitionException {
		RationaleDeclContext _localctx = new RationaleDeclContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_rationaleDecl);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(102);
			match(TEXT_RATIO_MARKER);
			setState(103);
			runningText();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ReferenceDeclContext extends ParserRuleContext {
		public TerminalNode TEXT_REF_MARKER() { return getToken(ReDSLParser.TEXT_REF_MARKER, 0); }
		public RunningTextContext runningText() {
			return getRuleContext(RunningTextContext.class,0);
		}
		public ReferenceDeclContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_referenceDecl; }
	}

	public final ReferenceDeclContext referenceDecl() throws RecognitionException {
		ReferenceDeclContext _localctx = new ReferenceDeclContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_referenceDecl);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(105);
			match(TEXT_REF_MARKER);
			setState(106);
			runningText();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class RunningTextContext extends ParserRuleContext {
		public List<TerminalNode> TEXT_CONTENT() { return getTokens(ReDSLParser.TEXT_CONTENT); }
		public TerminalNode TEXT_CONTENT(int i) {
			return getToken(ReDSLParser.TEXT_CONTENT, i);
		}
		public List<TerminalNode> TEXT_ESC_SEQ() { return getTokens(ReDSLParser.TEXT_ESC_SEQ); }
		public TerminalNode TEXT_ESC_SEQ(int i) {
			return getToken(ReDSLParser.TEXT_ESC_SEQ, i);
		}
		public List<TerminalNode> TEXT_RE_ID_REF() { return getTokens(ReDSLParser.TEXT_RE_ID_REF); }
		public TerminalNode TEXT_RE_ID_REF(int i) {
			return getToken(ReDSLParser.TEXT_RE_ID_REF, i);
		}
		public List<TerminalNode> TEXT_TERM_REF() { return getTokens(ReDSLParser.TEXT_TERM_REF); }
		public TerminalNode TEXT_TERM_REF(int i) {
			return getToken(ReDSLParser.TEXT_TERM_REF, i);
		}
		public List<TerminalNode> TEXT_COMMENT() { return getTokens(ReDSLParser.TEXT_COMMENT); }
		public TerminalNode TEXT_COMMENT(int i) {
			return getToken(ReDSLParser.TEXT_COMMENT, i);
		}
		public List<TerminalNode> TEXT_URI() { return getTokens(ReDSLParser.TEXT_URI); }
		public TerminalNode TEXT_URI(int i) {
			return getToken(ReDSLParser.TEXT_URI, i);
		}
		public List<MathModeExpressionContext> mathModeExpression() {
			return getRuleContexts(MathModeExpressionContext.class);
		}
		public MathModeExpressionContext mathModeExpression(int i) {
			return getRuleContext(MathModeExpressionContext.class,i);
		}
		public RunningTextContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_runningText; }
	}

	public final RunningTextContext runningText() throws RecognitionException {
		RunningTextContext _localctx = new RunningTextContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_runningText);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(115); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				setState(115);
				_errHandler.sync(this);
				switch (_input.LA(1)) {
				case TEXT_CONTENT:
					{
					setState(108);
					match(TEXT_CONTENT);
					}
					break;
				case TEXT_ESC_SEQ:
					{
					setState(109);
					match(TEXT_ESC_SEQ);
					}
					break;
				case TEXT_RE_ID_REF:
					{
					setState(110);
					match(TEXT_RE_ID_REF);
					}
					break;
				case TEXT_TERM_REF:
					{
					setState(111);
					match(TEXT_TERM_REF);
					}
					break;
				case TEXT_COMMENT:
					{
					setState(112);
					match(TEXT_COMMENT);
					}
					break;
				case TEXT_URI:
					{
					setState(113);
					match(TEXT_URI);
					}
					break;
				case TEXT_START_MATH:
					{
					setState(114);
					mathModeExpression();
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				}
				setState(117); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( (((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << TEXT_COMMENT) | (1L << TEXT_RE_ID_REF) | (1L << TEXT_URI) | (1L << TEXT_TERM_REF) | (1L << TEXT_START_MATH) | (1L << TEXT_ESC_SEQ) | (1L << TEXT_CONTENT))) != 0) );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ParameterBlockContext extends ParserRuleContext {
		public TerminalNode PARAM_START() { return getToken(ReDSLParser.PARAM_START, 0); }
		public TerminalNode PARAM_CLOSE() { return getToken(ReDSLParser.PARAM_CLOSE, 0); }
		public List<ParamDeclContext> paramDecl() {
			return getRuleContexts(ParamDeclContext.class);
		}
		public ParamDeclContext paramDecl(int i) {
			return getRuleContext(ParamDeclContext.class,i);
		}
		public ParameterBlockContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_parameterBlock; }
	}

	public final ParameterBlockContext parameterBlock() throws RecognitionException {
		ParameterBlockContext _localctx = new ParameterBlockContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_parameterBlock);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(119);
			match(PARAM_START);
			setState(123);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==PARAM_ID) {
				{
				{
				setState(120);
				paramDecl();
				}
				}
				setState(125);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(126);
			match(PARAM_CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ParamDeclContext extends ParserRuleContext {
		public StringParamDeclContext stringParamDecl() {
			return getRuleContext(StringParamDeclContext.class,0);
		}
		public IdParamDeclContext idParamDecl() {
			return getRuleContext(IdParamDeclContext.class,0);
		}
		public NumericParamDeclContext numericParamDecl() {
			return getRuleContext(NumericParamDeclContext.class,0);
		}
		public BoolParamDeclContext boolParamDecl() {
			return getRuleContext(BoolParamDeclContext.class,0);
		}
		public IdListParamDeclContext idListParamDecl() {
			return getRuleContext(IdListParamDeclContext.class,0);
		}
		public ParamDeclContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_paramDecl; }
	}

	public final ParamDeclContext paramDecl() throws RecognitionException {
		ParamDeclContext _localctx = new ParamDeclContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_paramDecl);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(133);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
			case 1:
				{
				setState(128);
				stringParamDecl();
				}
				break;
			case 2:
				{
				setState(129);
				idParamDecl();
				}
				break;
			case 3:
				{
				setState(130);
				numericParamDecl();
				}
				break;
			case 4:
				{
				setState(131);
				boolParamDecl();
				}
				break;
			case 5:
				{
				setState(132);
				idListParamDecl();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class StringParamDeclContext extends ParserRuleContext {
		public TerminalNode PARAM_ID() { return getToken(ReDSLParser.PARAM_ID, 0); }
		public TerminalNode PARAM_EQUALS() { return getToken(ReDSLParser.PARAM_EQUALS, 0); }
		public TerminalNode PARAM_STRING() { return getToken(ReDSLParser.PARAM_STRING, 0); }
		public StringParamDeclContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stringParamDecl; }
	}

	public final StringParamDeclContext stringParamDecl() throws RecognitionException {
		StringParamDeclContext _localctx = new StringParamDeclContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_stringParamDecl);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(135);
			match(PARAM_ID);
			setState(136);
			match(PARAM_EQUALS);
			setState(137);
			match(PARAM_STRING);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IdParamDeclContext extends ParserRuleContext {
		public List<TerminalNode> PARAM_ID() { return getTokens(ReDSLParser.PARAM_ID); }
		public TerminalNode PARAM_ID(int i) {
			return getToken(ReDSLParser.PARAM_ID, i);
		}
		public TerminalNode PARAM_EQUALS() { return getToken(ReDSLParser.PARAM_EQUALS, 0); }
		public IdParamDeclContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_idParamDecl; }
	}

	public final IdParamDeclContext idParamDecl() throws RecognitionException {
		IdParamDeclContext _localctx = new IdParamDeclContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_idParamDecl);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(139);
			match(PARAM_ID);
			setState(140);
			match(PARAM_EQUALS);
			setState(141);
			match(PARAM_ID);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class NumericParamDeclContext extends ParserRuleContext {
		public TerminalNode PARAM_ID() { return getToken(ReDSLParser.PARAM_ID, 0); }
		public TerminalNode PARAM_EQUALS() { return getToken(ReDSLParser.PARAM_EQUALS, 0); }
		public TerminalNode PARAM_NUMBER() { return getToken(ReDSLParser.PARAM_NUMBER, 0); }
		public NumericParamDeclContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_numericParamDecl; }
	}

	public final NumericParamDeclContext numericParamDecl() throws RecognitionException {
		NumericParamDeclContext _localctx = new NumericParamDeclContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_numericParamDecl);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(143);
			match(PARAM_ID);
			setState(144);
			match(PARAM_EQUALS);
			setState(145);
			match(PARAM_NUMBER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class BoolParamDeclContext extends ParserRuleContext {
		public TerminalNode PARAM_ID() { return getToken(ReDSLParser.PARAM_ID, 0); }
		public TerminalNode PARAM_EQUALS() { return getToken(ReDSLParser.PARAM_EQUALS, 0); }
		public TerminalNode PARAM_BOOL() { return getToken(ReDSLParser.PARAM_BOOL, 0); }
		public BoolParamDeclContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_boolParamDecl; }
	}

	public final BoolParamDeclContext boolParamDecl() throws RecognitionException {
		BoolParamDeclContext _localctx = new BoolParamDeclContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_boolParamDecl);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(147);
			match(PARAM_ID);
			setState(150);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==PARAM_EQUALS) {
				{
				setState(148);
				match(PARAM_EQUALS);
				setState(149);
				match(PARAM_BOOL);
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class IdListParamDeclContext extends ParserRuleContext {
		public List<TerminalNode> PARAM_ID() { return getTokens(ReDSLParser.PARAM_ID); }
		public TerminalNode PARAM_ID(int i) {
			return getToken(ReDSLParser.PARAM_ID, i);
		}
		public TerminalNode PARAM_EQUALS() { return getToken(ReDSLParser.PARAM_EQUALS, 0); }
		public TerminalNode PARAM_ID_LIST_START() { return getToken(ReDSLParser.PARAM_ID_LIST_START, 0); }
		public TerminalNode PARAM_ID_LIST_END() { return getToken(ReDSLParser.PARAM_ID_LIST_END, 0); }
		public List<TerminalNode> PARAM_ID_LIST_SEP() { return getTokens(ReDSLParser.PARAM_ID_LIST_SEP); }
		public TerminalNode PARAM_ID_LIST_SEP(int i) {
			return getToken(ReDSLParser.PARAM_ID_LIST_SEP, i);
		}
		public IdListParamDeclContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_idListParamDecl; }
	}

	public final IdListParamDeclContext idListParamDecl() throws RecognitionException {
		IdListParamDeclContext _localctx = new IdListParamDeclContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_idListParamDecl);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(152);
			match(PARAM_ID);
			setState(153);
			match(PARAM_EQUALS);
			{
			setState(154);
			match(PARAM_ID_LIST_START);
			setState(155);
			match(PARAM_ID);
			setState(160);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==PARAM_ID_LIST_SEP) {
				{
				{
				setState(156);
				match(PARAM_ID_LIST_SEP);
				setState(157);
				match(PARAM_ID);
				}
				}
				setState(162);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(163);
			match(PARAM_ID_LIST_END);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class MathModeExpressionContext extends ParserRuleContext {
		public TerminalNode TEXT_START_MATH() { return getToken(ReDSLParser.TEXT_START_MATH, 0); }
		public TerminalNode MATH_CLOSE() { return getToken(ReDSLParser.MATH_CLOSE, 0); }
		public List<TerminalNode> MATH_ESC_SEQ() { return getTokens(ReDSLParser.MATH_ESC_SEQ); }
		public TerminalNode MATH_ESC_SEQ(int i) {
			return getToken(ReDSLParser.MATH_ESC_SEQ, i);
		}
		public List<TerminalNode> MATH_CONTENT() { return getTokens(ReDSLParser.MATH_CONTENT); }
		public TerminalNode MATH_CONTENT(int i) {
			return getToken(ReDSLParser.MATH_CONTENT, i);
		}
		public MathModeExpressionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_mathModeExpression; }
	}

	public final MathModeExpressionContext mathModeExpression() throws RecognitionException {
		MathModeExpressionContext _localctx = new MathModeExpressionContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_mathModeExpression);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(165);
			match(TEXT_START_MATH);
			setState(169);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==MATH_ESC_SEQ || _la==MATH_CONTENT) {
				{
				{
				setState(166);
				_la = _input.LA(1);
				if ( !(_la==MATH_ESC_SEQ || _la==MATH_CONTENT) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
				}
				setState(171);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(172);
			match(MATH_CLOSE);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3(\u00b1\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\3\2\6\2*\n\2\r\2\16\2+\3\2\3\2\6\2\60\n\2\r\2\16"+
		"\2\61\5\2\64\n\2\3\3\3\3\3\3\3\3\3\3\7\3;\n\3\f\3\16\3>\13\3\3\3\3\3\3"+
		"\4\3\4\3\4\3\5\3\5\5\5G\n\5\3\5\3\5\3\6\3\6\3\6\7\6N\n\6\f\6\16\6Q\13"+
		"\6\5\6S\n\6\3\6\5\6V\n\6\3\6\3\6\3\7\5\7[\n\7\3\7\3\7\3\b\3\b\3\b\3\b"+
		"\3\b\5\bd\n\b\3\t\3\t\3\t\3\n\3\n\3\n\3\13\3\13\3\13\3\f\3\f\3\f\3\f\3"+
		"\f\3\f\3\f\6\fv\n\f\r\f\16\fw\3\r\3\r\7\r|\n\r\f\r\16\r\177\13\r\3\r\3"+
		"\r\3\16\3\16\3\16\3\16\3\16\5\16\u0088\n\16\3\17\3\17\3\17\3\17\3\20\3"+
		"\20\3\20\3\20\3\21\3\21\3\21\3\21\3\22\3\22\3\22\5\22\u0099\n\22\3\23"+
		"\3\23\3\23\3\23\3\23\3\23\7\23\u00a1\n\23\f\23\16\23\u00a4\13\23\3\23"+
		"\3\23\3\24\3\24\7\24\u00aa\n\24\f\24\16\24\u00ad\13\24\3\24\3\24\3\24"+
		"\2\2\25\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&\2\3\3\2\'(\2\u00bb"+
		"\2\63\3\2\2\2\4\65\3\2\2\2\6A\3\2\2\2\bD\3\2\2\2\nJ\3\2\2\2\fZ\3\2\2\2"+
		"\16c\3\2\2\2\20e\3\2\2\2\22h\3\2\2\2\24k\3\2\2\2\26u\3\2\2\2\30y\3\2\2"+
		"\2\32\u0087\3\2\2\2\34\u0089\3\2\2\2\36\u008d\3\2\2\2 \u0091\3\2\2\2\""+
		"\u0095\3\2\2\2$\u009a\3\2\2\2&\u00a7\3\2\2\2(*\5\4\3\2)(\3\2\2\2*+\3\2"+
		"\2\2+)\3\2\2\2+,\3\2\2\2,\64\3\2\2\2-\60\5\6\4\2.\60\5\b\5\2/-\3\2\2\2"+
		"/.\3\2\2\2\60\61\3\2\2\2\61/\3\2\2\2\61\62\3\2\2\2\62\64\3\2\2\2\63)\3"+
		"\2\2\2\63/\3\2\2\2\63\64\3\2\2\2\64\3\3\2\2\2\65\66\7\3\2\2\66\67\7\7"+
		"\2\2\67<\7\4\2\28;\5\6\4\29;\5\b\5\2:8\3\2\2\2:9\3\2\2\2;>\3\2\2\2<:\3"+
		"\2\2\2<=\3\2\2\2=?\3\2\2\2><\3\2\2\2?@\7\5\2\2@\5\3\2\2\2AB\7\6\2\2BC"+
		"\7\7\2\2C\7\3\2\2\2DF\7\n\2\2EG\5\30\r\2FE\3\2\2\2FG\3\2\2\2GH\3\2\2\2"+
		"HI\5\n\6\2I\t\3\2\2\2JR\7\f\2\2KO\5\f\7\2LN\5\16\b\2ML\3\2\2\2NQ\3\2\2"+
		"\2OM\3\2\2\2OP\3\2\2\2PS\3\2\2\2QO\3\2\2\2RK\3\2\2\2RS\3\2\2\2SU\3\2\2"+
		"\2TV\7\22\2\2UT\3\2\2\2UV\3\2\2\2VW\3\2\2\2WX\7\16\2\2X\13\3\2\2\2Y[\7"+
		"\22\2\2ZY\3\2\2\2Z[\3\2\2\2[\\\3\2\2\2\\]\5\26\f\2]\r\3\2\2\2^d\5\20\t"+
		"\2_d\5\22\n\2`d\5\24\13\2ab\7\22\2\2bd\5\26\f\2c^\3\2\2\2c_\3\2\2\2c`"+
		"\3\2\2\2ca\3\2\2\2d\17\3\2\2\2ef\7\23\2\2fg\5\26\f\2g\21\3\2\2\2hi\7\24"+
		"\2\2ij\5\26\f\2j\23\3\2\2\2kl\7\25\2\2lm\5\26\f\2m\25\3\2\2\2nv\7\33\2"+
		"\2ov\7\32\2\2pv\7\26\2\2qv\7\30\2\2rv\7\17\2\2sv\7\27\2\2tv\5&\24\2un"+
		"\3\2\2\2uo\3\2\2\2up\3\2\2\2uq\3\2\2\2ur\3\2\2\2us\3\2\2\2ut\3\2\2\2v"+
		"w\3\2\2\2wu\3\2\2\2wx\3\2\2\2x\27\3\2\2\2y}\7\13\2\2z|\5\32\16\2{z\3\2"+
		"\2\2|\177\3\2\2\2}{\3\2\2\2}~\3\2\2\2~\u0080\3\2\2\2\177}\3\2\2\2\u0080"+
		"\u0081\7\34\2\2\u0081\31\3\2\2\2\u0082\u0088\5\34\17\2\u0083\u0088\5\36"+
		"\20\2\u0084\u0088\5 \21\2\u0085\u0088\5\"\22\2\u0086\u0088\5$\23\2\u0087"+
		"\u0082\3\2\2\2\u0087\u0083\3\2\2\2\u0087\u0084\3\2\2\2\u0087\u0085\3\2"+
		"\2\2\u0087\u0086\3\2\2\2\u0088\33\3\2\2\2\u0089\u008a\7\35\2\2\u008a\u008b"+
		"\7\36\2\2\u008b\u008c\7\37\2\2\u008c\35\3\2\2\2\u008d\u008e\7\35\2\2\u008e"+
		"\u008f\7\36\2\2\u008f\u0090\7\35\2\2\u0090\37\3\2\2\2\u0091\u0092\7\35"+
		"\2\2\u0092\u0093\7\36\2\2\u0093\u0094\7$\2\2\u0094!\3\2\2\2\u0095\u0098"+
		"\7\35\2\2\u0096\u0097\7\36\2\2\u0097\u0099\7#\2\2\u0098\u0096\3\2\2\2"+
		"\u0098\u0099\3\2\2\2\u0099#\3\2\2\2\u009a\u009b\7\35\2\2\u009b\u009c\7"+
		"\36\2\2\u009c\u009d\7 \2\2\u009d\u00a2\7\35\2\2\u009e\u009f\7!\2\2\u009f"+
		"\u00a1\7\35\2\2\u00a0\u009e\3\2\2\2\u00a1\u00a4\3\2\2\2\u00a2\u00a0\3"+
		"\2\2\2\u00a2\u00a3\3\2\2\2\u00a3\u00a5\3\2\2\2\u00a4\u00a2\3\2\2\2\u00a5"+
		"\u00a6\7\"\2\2\u00a6%\3\2\2\2\u00a7\u00ab\7\31\2\2\u00a8\u00aa\t\2\2\2"+
		"\u00a9\u00a8\3\2\2\2\u00aa\u00ad\3\2\2\2\u00ab\u00a9\3\2\2\2\u00ab\u00ac"+
		"\3\2\2\2\u00ac\u00ae\3\2\2\2\u00ad\u00ab\3\2\2\2\u00ae\u00af\7&\2\2\u00af"+
		"\'\3\2\2\2\25+/\61\63:<FORUZcuw}\u0087\u0098\u00a2\u00ab";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}