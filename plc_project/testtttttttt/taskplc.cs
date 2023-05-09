
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF              =  0, // (EOF)
        SYMBOL_ERROR            =  1, // (Error)
        SYMBOL_WHITESPACE       =  2, // Whitespace
        SYMBOL_MINUS            =  3, // '-'
        SYMBOL_MINUSMINUS       =  4, // '--'
        SYMBOL_EXCLAMEQ         =  5, // '!='
        SYMBOL_PERCENT          =  6, // '%'
        SYMBOL_LPAREN           =  7, // '('
        SYMBOL_RPAREN           =  8, // ')'
        SYMBOL_TIMES            =  9, // '*'
        SYMBOL_TIMESTIMES       = 10, // '**'
        SYMBOL_COMMA            = 11, // ','
        SYMBOL_DIV              = 12, // '/'
        SYMBOL_COLON            = 13, // ':'
        SYMBOL_SEMI             = 14, // ';'
        SYMBOL_LBRACE           = 15, // '{'
        SYMBOL_RBRACE           = 16, // '}'
        SYMBOL_PLUS             = 17, // '+'
        SYMBOL_PLUSPLUS         = 18, // '++'
        SYMBOL_LT               = 19, // '<'
        SYMBOL_LTGT             = 20, // '<>'
        SYMBOL_EQ               = 21, // '='
        SYMBOL_EQEQ             = 22, // '=='
        SYMBOL_GT               = 23, // '>'
        SYMBOL_BOOL             = 24, // bool
        SYMBOL_BREAK            = 25, // break
        SYMBOL_CASE             = 26, // case
        SYMBOL_CHAR             = 27, // char
        SYMBOL_DIGIT            = 28, // Digit
        SYMBOL_DO               = 29, // do
        SYMBOL_DOUBLE           = 30, // double
        SYMBOL_ELSE             = 31, // else
        SYMBOL_END              = 32, // End
        SYMBOL_FLOAT            = 33, // float
        SYMBOL_FOR              = 34, // for
        SYMBOL_ID               = 35, // Id
        SYMBOL_IF               = 36, // if
        SYMBOL_INT              = 37, // int
        SYMBOL_LETTER           = 38, // Letter
        SYMBOL_RETURN           = 39, // return
        SYMBOL_START            = 40, // Start
        SYMBOL_STRING           = 41, // string
        SYMBOL_SWITCH           = 42, // switch
        SYMBOL_VOID             = 43, // void
        SYMBOL_WHILE            = 44, // while
        SYMBOL_ARGUMENTS        = 45, // <arguments>
        SYMBOL_ASSIGN           = 46, // <assign>
        SYMBOL_CASE_LIST        = 47, // <case_list>
        SYMBOL_CASE_STATEMENT   = 48, // <case_statement>
        SYMBOL_CONCEPT          = 49, // <concept>
        SYMBOL_COND             = 50, // <cond>
        SYMBOL_DECLARATION      = 51, // <declaration>
        SYMBOL_DIGIT2           = 52, // <digit>
        SYMBOL_DOMINUSWHILE     = 53, // <do-while>
        SYMBOL_EXP              = 54, // <exp>
        SYMBOL_EXPR             = 55, // <expr>
        SYMBOL_FACTOR           = 56, // <factor>
        SYMBOL_FOR_STMT         = 57, // <for_stmt>
        SYMBOL_FUNCTION         = 58, // <function>
        SYMBOL_FUNCTION_CALL    = 59, // <function_call>
        SYMBOL_FUNCTION_HEADER  = 60, // <function_header>
        SYMBOL_ID2              = 61, // <id>
        SYMBOL_IDENTIFIER       = 62, // <identifier>
        SYMBOL_IF_STMT          = 63, // <if_stmt>
        SYMBOL_OP               = 64, // <op>
        SYMBOL_PARAMETER        = 65, // <parameter>
        SYMBOL_PARAMETERS       = 66, // <parameters>
        SYMBOL_PROGRAM          = 67, // <program>
        SYMBOL_RETURN_STATEMENT = 68, // <return_statement>
        SYMBOL_RETURN_TYPE      = 69, // <return_type>
        SYMBOL_STEP             = 70, // <step>
        SYMBOL_STMT_LIST        = 71, // <stmt_list>
        SYMBOL_SWITCH_STATEMENT = 72, // <switch_statement>
        SYMBOL_TERM             = 73, // <term>
        SYMBOL_TYPE             = 74, // <type>
        SYMBOL_VALUE            = 75, // <value>
        SYMBOL_WHILE2           = 76  // <while>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_START_END                                   =  0, // <program> ::= Start <stmt_list> End
        RULE_STMT_LIST                                           =  1, // <stmt_list> ::= <concept>
        RULE_STMT_LIST2                                          =  2, // <stmt_list> ::= <concept> <stmt_list>
        RULE_CONCEPT                                             =  3, // <concept> ::= <declaration>
        RULE_CONCEPT2                                            =  4, // <concept> ::= <assign>
        RULE_CONCEPT3                                            =  5, // <concept> ::= <if_stmt>
        RULE_CONCEPT4                                            =  6, // <concept> ::= <for_stmt>
        RULE_CONCEPT5                                            =  7, // <concept> ::= <switch_statement>
        RULE_CONCEPT6                                            =  8, // <concept> ::= <while>
        RULE_CONCEPT7                                            =  9, // <concept> ::= <do-while>
        RULE_CONCEPT8                                            = 10, // <concept> ::= <function_call>
        RULE_CONCEPT9                                            = 11, // <concept> ::= <return_statement>
        RULE_CONCEPT10                                           = 12, // <concept> ::= <function>
        RULE_DECLARATION                                         = 13, // <declaration> ::= <type> <identifier>
        RULE_TYPE_INT                                            = 14, // <type> ::= int
        RULE_TYPE_FLOAT                                          = 15, // <type> ::= float
        RULE_TYPE_DOUBLE                                         = 16, // <type> ::= double
        RULE_TYPE_CHAR                                           = 17, // <type> ::= char
        RULE_TYPE_BOOL                                           = 18, // <type> ::= bool
        RULE_TYPE_STRING                                         = 19, // <type> ::= string
        RULE_IDENTIFIER_ID                                       = 20, // <identifier> ::= Id
        RULE_ASSIGN_EQ                                           = 21, // <assign> ::= <id> '=' <expr>
        RULE_ID_ID                                               = 22, // <id> ::= Id
        RULE_EXPR_PLUS                                           = 23, // <expr> ::= <expr> '+' <term>
        RULE_EXPR_MINUS                                          = 24, // <expr> ::= <expr> '-' <term>
        RULE_EXPR                                                = 25, // <expr> ::= <term>
        RULE_TERM_TIMES                                          = 26, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                            = 27, // <term> ::= <term> '/' <factor>
        RULE_TERM_PERCENT                                        = 28, // <term> ::= <term> '%' <factor>
        RULE_TERM                                                = 29, // <term> ::= <factor>
        RULE_FACTOR_TIMESTIMES                                   = 30, // <factor> ::= <factor> '**' <exp>
        RULE_FACTOR                                              = 31, // <factor> ::= <exp>
        RULE_EXP_LPAREN_RPAREN                                   = 32, // <exp> ::= '(' <expr> ')'
        RULE_EXP                                                 = 33, // <exp> ::= <id>
        RULE_EXP2                                                = 34, // <exp> ::= <digit>
        RULE_DIGIT_DIGIT                                         = 35, // <digit> ::= Digit
        RULE_IF_STMT_IF_LPAREN_RPAREN_START_END                  = 36, // <if_stmt> ::= if '(' <cond> ')' Start <stmt_list> End
        RULE_IF_STMT_IF_LPAREN_RPAREN_START_END_ELSE             = 37, // <if_stmt> ::= if '(' <cond> ')' Start <stmt_list> End else <stmt_list>
        RULE_COND                                                = 38, // <cond> ::= <expr> <op> <expr>
        RULE_OP_LT                                               = 39, // <op> ::= '<'
        RULE_OP_GT                                               = 40, // <op> ::= '>'
        RULE_OP_EQEQ                                             = 41, // <op> ::= '=='
        RULE_OP_LTGT                                             = 42, // <op> ::= '<>'
        RULE_OP_EXCLAMEQ                                         = 43, // <op> ::= '!='
        RULE_FOR_STMT_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE  = 44, // <for_stmt> ::= for '(' <type> <assign> ';' <cond> ';' <step> ')' '{' <stmt_list> '}'
        RULE_STEP_MINUSMINUS                                     = 45, // <step> ::= '--' <id>
        RULE_STEP_MINUSMINUS2                                    = 46, // <step> ::= <id> '--'
        RULE_STEP_PLUSPLUS                                       = 47, // <step> ::= '++' <id>
        RULE_STEP_PLUSPLUS2                                      = 48, // <step> ::= <id> '++'
        RULE_STEP                                                = 49, // <step> ::= <assign>
        RULE_SWITCH_STATEMENT_SWITCH_LPAREN_RPAREN_LBRACE_RBRACE = 50, // <switch_statement> ::= switch '(' <identifier> ')' '{' <case_list> '}'
        RULE_CASE_LIST                                           = 51, // <case_list> ::= <case_statement>
        RULE_CASE_LIST2                                          = 52, // <case_list> ::= <case_list> <case_statement>
        RULE_CASE_STATEMENT_CASE_COLON_BREAK_SEMI                = 53, // <case_statement> ::= case <value> ':' <stmt_list> break ';'
        RULE_VALUE_LETTER                                        = 54, // <value> ::= Letter
        RULE_VALUE                                               = 55, // <value> ::= <identifier>
        RULE_DOWHILE_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN_SEMI   = 56, // <do-while> ::= <type> <assign> do '{' <stmt_list> <step> '}' while '(' <cond> ')' ';'
        RULE_WHILE_WHILE_LPAREN_RPAREN_LBRACE_RBRACE             = 57, // <while> ::= <type> <assign> while '(' <cond> ')' '{' <stmt_list> <step> '}'
        RULE_FUNCTION_LBRACE_RBRACE                              = 58, // <function> ::= <function_header> '{' <stmt_list> '}'
        RULE_FUNCTION_HEADER_LPAREN_RPAREN                       = 59, // <function_header> ::= <return_type> <identifier> '(' <parameters> ')'
        RULE_RETURN_TYPE_VOID                                    = 60, // <return_type> ::= void
        RULE_RETURN_TYPE                                         = 61, // <return_type> ::= <type>
        RULE_PARAMETERS                                          = 62, // <parameters> ::= <parameter>
        RULE_PARAMETERS_COMMA                                    = 63, // <parameters> ::= <parameter> ',' <parameters>
        RULE_PARAMETER                                           = 64, // <parameter> ::= <type> <identifier>
        RULE_FUNCTION_CALL_LPAREN_RPAREN                         = 65, // <function_call> ::= <identifier> '(' <arguments> ')'
        RULE_ARGUMENTS                                           = 66, // <arguments> ::= <expr>
        RULE_ARGUMENTS_COMMA                                     = 67, // <arguments> ::= <expr> ',' <arguments>
        RULE_RETURN_STATEMENT_RETURN_SEMI                        = 68  // <return_statement> ::= return <expr> ';'
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;
        public MyParser(string filename , ListBox lst)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            this.lst= lst;
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESTIMES :
                //'**'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTGT :
                //'<>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOL :
                //bool
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //break
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CHAR :
                //char
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOUBLE :
                //double
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //End
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FLOAT :
                //float
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LETTER :
                //Letter
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //Start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VOID :
                //void
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENTS :
                //<arguments>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE_LIST :
                //<case_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE_STATEMENT :
                //<case_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECLARATION :
                //<declaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOMINUSWHILE :
                //<do-while>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPR :
                //<expr>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR_STMT :
                //<for_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION :
                //<function>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION_CALL :
                //<function_call>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION_HEADER :
                //<function_header>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //<identifier>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STMT :
                //<if_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETER :
                //<parameter>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PARAMETERS :
                //<parameters>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN_STATEMENT :
                //<return_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN_TYPE :
                //<return_type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STMT_LIST :
                //<stmt_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH_STATEMENT :
                //<switch_statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //<type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE2 :
                //<while>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_START_END :
                //<program> ::= Start <stmt_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST :
                //<stmt_list> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STMT_LIST2 :
                //<stmt_list> ::= <concept> <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <declaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <if_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT4 :
                //<concept> ::= <for_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT5 :
                //<concept> ::= <switch_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT6 :
                //<concept> ::= <while>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT7 :
                //<concept> ::= <do-while>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT8 :
                //<concept> ::= <function_call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT9 :
                //<concept> ::= <return_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT10 :
                //<concept> ::= <function>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DECLARATION :
                //<declaration> ::= <type> <identifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_INT :
                //<type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_FLOAT :
                //<type> ::= float
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_DOUBLE :
                //<type> ::= double
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_CHAR :
                //<type> ::= char
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_BOOL :
                //<type> ::= bool
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_STRING :
                //<type> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IDENTIFIER_ID :
                //<identifier> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ :
                //<assign> ::= <id> '=' <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_PLUS :
                //<expr> ::= <expr> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR_MINUS :
                //<expr> ::= <expr> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPR :
                //<expr> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_PERCENT :
                //<term> ::= <term> '%' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_TIMESTIMES :
                //<factor> ::= <factor> '**' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN :
                //<exp> ::= '(' <expr> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<exp> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_START_END :
                //<if_stmt> ::= if '(' <cond> ')' Start <stmt_list> End
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_START_END_ELSE :
                //<if_stmt> ::= if '(' <cond> ')' Start <stmt_list> End else <stmt_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expr> <op> <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LTGT :
                //<op> ::= '<>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_STMT_FOR_LPAREN_SEMI_SEMI_RPAREN_LBRACE_RBRACE :
                //<for_stmt> ::= for '(' <type> <assign> ';' <cond> ';' <step> ')' '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS :
                //<step> ::= '--' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS2 :
                //<step> ::= <id> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS :
                //<step> ::= '++' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS2 :
                //<step> ::= <id> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP :
                //<step> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCH_STATEMENT_SWITCH_LPAREN_RPAREN_LBRACE_RBRACE :
                //<switch_statement> ::= switch '(' <identifier> ')' '{' <case_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_LIST :
                //<case_list> ::= <case_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_LIST2 :
                //<case_list> ::= <case_list> <case_statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASE_STATEMENT_CASE_COLON_BREAK_SEMI :
                //<case_statement> ::= case <value> ':' <stmt_list> break ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_LETTER :
                //<value> ::= Letter
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE :
                //<value> ::= <identifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DOWHILE_DO_LBRACE_RBRACE_WHILE_LPAREN_RPAREN_SEMI :
                //<do-while> ::= <type> <assign> do '{' <stmt_list> <step> '}' while '(' <cond> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILE_WHILE_LPAREN_RPAREN_LBRACE_RBRACE :
                //<while> ::= <type> <assign> while '(' <cond> ')' '{' <stmt_list> <step> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_LBRACE_RBRACE :
                //<function> ::= <function_header> '{' <stmt_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_HEADER_LPAREN_RPAREN :
                //<function_header> ::= <return_type> <identifier> '(' <parameters> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_TYPE_VOID :
                //<return_type> ::= void
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_TYPE :
                //<return_type> ::= <type>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS :
                //<parameters> ::= <parameter>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETERS_COMMA :
                //<parameters> ::= <parameter> ',' <parameters>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PARAMETER :
                //<parameter> ::= <type> <identifier>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTION_CALL_LPAREN_RPAREN :
                //<function_call> ::= <identifier> '(' <arguments> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTS :
                //<arguments> ::= <expr>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTS_COMMA :
                //<arguments> ::= <expr> ',' <arguments>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURN_STATEMENT_RETURN_SEMI :
                //<return_statement> ::= return <expr> ';'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"   In Line : "+args.UnexpectedToken.Location.LineNr;
            lst.Items.Add(message);
            string message2 ="Expected Token : "+args.ExpectedTokens.ToString();
            lst.Items.Add(message2);
            //todo: Report message to UI?
        }

    }
}
