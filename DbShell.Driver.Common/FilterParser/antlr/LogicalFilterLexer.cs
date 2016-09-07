// $ANTLR 3.2 Sep 23, 2009 12:02:23 LogicalFilter.g 2016-09-07 21:54:36

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


public partial class LogicalFilterLexer : Lexer {
    public const int EOF = -1;
    public const int Q_STRING = 33;
    public const int DIGIT_0 = 29;
    public const int DIGIT_1 = 30;
    public const int COMMA = 17;
    public const int T_NULL = 11;
    public const int T_TRUE = 7;
    public const int EQ = 14;
    public const int DOT = 5;
    public const int NE = 13;
    public const int D = 36;
    public const int E = 25;
    public const int F = 26;
    public const int G = 37;
    public const int A = 27;
    public const int SQL_VARIABLE = 6;
    public const int B = 34;
    public const int NE2 = 16;
    public const int C = 35;
    public const int L = 21;
    public const int M = 42;
    public const int N = 19;
    public const int O = 22;
    public const int H = 38;
    public const int I = 39;
    public const int J = 40;
    public const int K = 41;
    public const int U = 20;
    public const int T = 23;
    public const int W = 46;
    public const int WHITESPACE = 31;
    public const int V = 45;
    public const int Q = 44;
    public const int P = 43;
    public const int S = 28;
    public const int R = 24;
    public const int Y = 48;
    public const int X = 47;
    public const int EQ2 = 15;
    public const int SQL_LITERAL = 4;
    public const int Z = 49;
    public const int T_FALSE = 8;
    public const int T_1 = 9;
    public const int T_0 = 10;
    public const int A_STRING = 32;
    public const int ENDLINE = 18;
    public const int T_NOT = 12;

    // delegates
    // delegators

    public LogicalFilterLexer() 
    {
		InitializeCyclicDFAs();
    }
    public LogicalFilterLexer(ICharStream input)
		: this(input, null) {
    }
    public LogicalFilterLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "LogicalFilter.g";} 
    }

    // $ANTLR start "T_NULL"
    public void mT_NULL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_NULL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:46:7: ( N U L L )
            // LogicalFilter.g:46:9: N U L L
            {
            	mN(); 
            	mU(); 
            	mL(); 
            	mL(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_NULL"

    // $ANTLR start "T_NOT"
    public void mT_NOT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_NOT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:47:6: ( N O T )
            // LogicalFilter.g:47:8: N O T
            {
            	mN(); 
            	mO(); 
            	mT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_NOT"

    // $ANTLR start "T_TRUE"
    public void mT_TRUE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_TRUE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:48:7: ( T R U E )
            // LogicalFilter.g:48:9: T R U E
            {
            	mT(); 
            	mR(); 
            	mU(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_TRUE"

    // $ANTLR start "T_FALSE"
    public void mT_FALSE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_FALSE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:49:8: ( F A L S E )
            // LogicalFilter.g:49:10: F A L S E
            {
            	mF(); 
            	mA(); 
            	mL(); 
            	mS(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_FALSE"

    // $ANTLR start "T_0"
    public void mT_0() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_0;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:50:4: ( DIGIT_0 )
            // LogicalFilter.g:50:6: DIGIT_0
            {
            	mDIGIT_0(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_0"

    // $ANTLR start "T_1"
    public void mT_1() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_1;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:51:4: ( DIGIT_1 )
            // LogicalFilter.g:51:6: DIGIT_1
            {
            	mDIGIT_1(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_1"

    // $ANTLR start "NE"
    public void mNE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:53:3: ( '<>' )
            // LogicalFilter.g:53:6: '<>'
            {
            	Match("<>"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NE"

    // $ANTLR start "EQ"
    public void mEQ() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = EQ;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:54:3: ( '=' )
            // LogicalFilter.g:54:6: '='
            {
            	Match('='); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "EQ"

    // $ANTLR start "COMMA"
    public void mCOMMA() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COMMA;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:55:6: ( ',' )
            // LogicalFilter.g:55:8: ','
            {
            	Match(','); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "COMMA"

    // $ANTLR start "DOT"
    public void mDOT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DOT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:56:4: ( '.' )
            // LogicalFilter.g:56:6: '.'
            {
            	Match('.'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DOT"

    // $ANTLR start "EQ2"
    public void mEQ2() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = EQ2;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:57:4: ( '==' )
            // LogicalFilter.g:57:7: '=='
            {
            	Match("=="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "EQ2"

    // $ANTLR start "NE2"
    public void mNE2() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NE2;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:58:4: ( '!=' )
            // LogicalFilter.g:58:7: '!='
            {
            	Match("!="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NE2"

    // $ANTLR start "WHITESPACE"
    public void mWHITESPACE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WHITESPACE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:60:12: ( ( '\\t' | ' ' | '\\u000C' )+ )
            // LogicalFilter.g:60:14: ( '\\t' | ' ' | '\\u000C' )+
            {
            	// LogicalFilter.g:60:14: ( '\\t' | ' ' | '\\u000C' )+
            	int cnt1 = 0;
            	do 
            	{
            	    int alt1 = 2;
            	    int LA1_0 = input.LA(1);

            	    if ( (LA1_0 == '\t' || LA1_0 == '\f' || LA1_0 == ' ') )
            	    {
            	        alt1 = 1;
            	    }


            	    switch (alt1) 
            		{
            			case 1 :
            			    // LogicalFilter.g:
            			    {
            			    	if ( input.LA(1) == '\t' || input.LA(1) == '\f' || input.LA(1) == ' ' ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    if ( cnt1 >= 1 ) goto loop1;
            		            EarlyExitException eee1 =
            		                new EarlyExitException(1, input);
            		            throw eee1;
            	    }
            	    cnt1++;
            	} while (true);

            	loop1:
            		;	// Stops C# compiler whining that label 'loop1' has no statements

            	 _channel = HIDDEN; 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WHITESPACE"

    // $ANTLR start "ENDLINE"
    public void mENDLINE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ENDLINE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:61:8: ( ( '\\r' | '\\n' )+ )
            // LogicalFilter.g:61:10: ( '\\r' | '\\n' )+
            {
            	// LogicalFilter.g:61:10: ( '\\r' | '\\n' )+
            	int cnt2 = 0;
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( (LA2_0 == '\n' || LA2_0 == '\r') )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // LogicalFilter.g:
            			    {
            			    	if ( input.LA(1) == '\n' || input.LA(1) == '\r' ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    if ( cnt2 >= 1 ) goto loop2;
            		            EarlyExitException eee2 =
            		                new EarlyExitException(2, input);
            		            throw eee2;
            	    }
            	    cnt2++;
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ENDLINE"

    // $ANTLR start "SQL_LITERAL"
    public void mSQL_LITERAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SQL_LITERAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:63:12: ( ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' ) )
            // LogicalFilter.g:64:4: ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' )
            {
            	// LogicalFilter.g:64:4: ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' )
            	// LogicalFilter.g:64:5: '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']'
            	{
            		Match('['); 
            		// LogicalFilter.g:65:5: ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )*
            		do 
            		{
            		    int alt3 = 2;
            		    int LA3_0 = input.LA(1);

            		    if ( ((LA3_0 >= '\u0000' && LA3_0 <= '\t') || (LA3_0 >= '\u000B' && LA3_0 <= '\f') || (LA3_0 >= '\u000E' && LA3_0 <= '\\') || (LA3_0 >= '^' && LA3_0 <= '\uFFFF')) )
            		    {
            		        alt3 = 1;
            		    }


            		    switch (alt3) 
            			{
            				case 1 :
            				    // LogicalFilter.g:66:31: ~ ( ']' | '\\r' | '\\n' )
            				    {
            				    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '\\') || (input.LA(1) >= '^' && input.LA(1) <= '\uFFFF') ) 
            				    	{
            				    	    input.Consume();

            				    	}
            				    	else 
            				    	{
            				    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            				    	    Recover(mse);
            				    	    throw mse;}


            				    }
            				    break;

            				default:
            				    goto loop3;
            		    }
            		} while (true);

            		loop3:
            			;	// Stops C# compiler whining that label 'loop3' has no statements

            		Match(']'); 

            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SQL_LITERAL"

    // $ANTLR start "SQL_VARIABLE"
    public void mSQL_VARIABLE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SQL_VARIABLE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:71:13: ( ( '@' ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( options {greedy=true; } : ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' ) )* ) )
            // LogicalFilter.g:72:5: ( '@' ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( options {greedy=true; } : ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' ) )* )
            {
            	// LogicalFilter.g:72:5: ( '@' ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( options {greedy=true; } : ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' ) )* )
            	// LogicalFilter.g:72:6: '@' ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( options {greedy=true; } : ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' ) )*
            	{
            		Match('@'); 
            		if ( (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            		{
            		    input.Consume();

            		}
            		else 
            		{
            		    MismatchedSetException mse = new MismatchedSetException(null,input);
            		    Recover(mse);
            		    throw mse;}

            		// LogicalFilter.g:74:9: ( options {greedy=true; } : ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' ) )*
            		do 
            		{
            		    int alt4 = 2;
            		    int LA4_0 = input.LA(1);

            		    if ( ((LA4_0 >= '0' && LA4_0 <= '9') || (LA4_0 >= 'A' && LA4_0 <= 'Z') || LA4_0 == '_' || (LA4_0 >= 'a' && LA4_0 <= 'z')) )
            		    {
            		        alt4 = 1;
            		    }


            		    switch (alt4) 
            			{
            				case 1 :
            				    // LogicalFilter.g:74:34: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' )
            				    {
            				    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            				    	{
            				    	    input.Consume();

            				    	}
            				    	else 
            				    	{
            				    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            				    	    Recover(mse);
            				    	    throw mse;}


            				    }
            				    break;

            				default:
            				    goto loop4;
            		    }
            		} while (true);

            		loop4:
            			;	// Stops C# compiler whining that label 'loop4' has no statements


            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SQL_VARIABLE"

    // $ANTLR start "A_STRING"
    public void mA_STRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = A_STRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:79:9: ( ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' ) )
            // LogicalFilter.g:80:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            {
            	// LogicalFilter.g:80:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            	// LogicalFilter.g:80:5: '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\''
            	{
            		Match('\''); 
            		// LogicalFilter.g:81:5: ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )*
            		do 
            		{
            		    int alt5 = 3;
            		    int LA5_0 = input.LA(1);

            		    if ( (LA5_0 == '\'') )
            		    {
            		        int LA5_1 = input.LA(2);

            		        if ( (LA5_1 == '\'') )
            		        {
            		            alt5 = 2;
            		        }


            		    }
            		    else if ( ((LA5_0 >= '\u0000' && LA5_0 <= '\t') || (LA5_0 >= '\u000B' && LA5_0 <= '\f') || (LA5_0 >= '\u000E' && LA5_0 <= '&') || (LA5_0 >= '(' && LA5_0 <= '\uFFFF')) )
            		    {
            		        alt5 = 1;
            		    }


            		    switch (alt5) 
            			{
            				case 1 :
            				    // LogicalFilter.g:82:31: ~ ( '\\'' | '\\r' | '\\n' )
            				    {
            				    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '&') || (input.LA(1) >= '(' && input.LA(1) <= '\uFFFF') ) 
            				    	{
            				    	    input.Consume();

            				    	}
            				    	else 
            				    	{
            				    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            				    	    Recover(mse);
            				    	    throw mse;}


            				    }
            				    break;
            				case 2 :
            				    // LogicalFilter.g:82:56: '\\'' '\\''
            				    {
            				    	Match('\''); 
            				    	Match('\''); 

            				    }
            				    break;

            				default:
            				    goto loop5;
            		    }
            		} while (true);

            		loop5:
            			;	// Stops C# compiler whining that label 'loop5' has no statements

            		Match('\''); 

            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "A_STRING"

    // $ANTLR start "Q_STRING"
    public void mQ_STRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Q_STRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:87:9: ( ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' ) )
            // LogicalFilter.g:88:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            {
            	// LogicalFilter.g:88:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            	// LogicalFilter.g:88:5: '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"'
            	{
            		Match('\"'); 
            		// LogicalFilter.g:89:5: ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )*
            		do 
            		{
            		    int alt6 = 3;
            		    int LA6_0 = input.LA(1);

            		    if ( (LA6_0 == '\"') )
            		    {
            		        int LA6_1 = input.LA(2);

            		        if ( (LA6_1 == '\"') )
            		        {
            		            alt6 = 2;
            		        }


            		    }
            		    else if ( ((LA6_0 >= '\u0000' && LA6_0 <= '\t') || (LA6_0 >= '\u000B' && LA6_0 <= '\f') || (LA6_0 >= '\u000E' && LA6_0 <= '!') || (LA6_0 >= '#' && LA6_0 <= '\uFFFF')) )
            		    {
            		        alt6 = 1;
            		    }


            		    switch (alt6) 
            			{
            				case 1 :
            				    // LogicalFilter.g:90:31: ~ ( '\\\"' | '\\r' | '\\n' )
            				    {
            				    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '!') || (input.LA(1) >= '#' && input.LA(1) <= '\uFFFF') ) 
            				    	{
            				    	    input.Consume();

            				    	}
            				    	else 
            				    	{
            				    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            				    	    Recover(mse);
            				    	    throw mse;}


            				    }
            				    break;
            				case 2 :
            				    // LogicalFilter.g:90:56: '\\\"' '\\\"'
            				    {
            				    	Match('\"'); 
            				    	Match('\"'); 

            				    }
            				    break;

            				default:
            				    goto loop6;
            		    }
            		} while (true);

            		loop6:
            			;	// Stops C# compiler whining that label 'loop6' has no statements

            		Match('\"'); 

            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Q_STRING"

    // $ANTLR start "DIGIT_0"
    public void mDIGIT_0() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:95:19: ( '0' )
            // LogicalFilter.g:95:21: '0'
            {
            	Match('0'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "DIGIT_0"

    // $ANTLR start "DIGIT_1"
    public void mDIGIT_1() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:96:19: ( '1' )
            // LogicalFilter.g:96:21: '1'
            {
            	Match('1'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "DIGIT_1"

    // $ANTLR start "A"
    public void mA() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:98:11: ( 'A' )
            // LogicalFilter.g:98:13: 'A'
            {
            	Match('A'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "A"

    // $ANTLR start "B"
    public void mB() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:99:11: ( 'B' )
            // LogicalFilter.g:99:13: 'B'
            {
            	Match('B'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "B"

    // $ANTLR start "C"
    public void mC() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:100:11: ( 'C' )
            // LogicalFilter.g:100:13: 'C'
            {
            	Match('C'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "C"

    // $ANTLR start "D"
    public void mD() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:101:11: ( 'D' )
            // LogicalFilter.g:101:13: 'D'
            {
            	Match('D'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "D"

    // $ANTLR start "E"
    public void mE() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:102:11: ( 'E' )
            // LogicalFilter.g:102:13: 'E'
            {
            	Match('E'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "E"

    // $ANTLR start "F"
    public void mF() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:103:11: ( 'F' )
            // LogicalFilter.g:103:13: 'F'
            {
            	Match('F'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "F"

    // $ANTLR start "G"
    public void mG() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:104:11: ( 'G' )
            // LogicalFilter.g:104:13: 'G'
            {
            	Match('G'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "G"

    // $ANTLR start "H"
    public void mH() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:105:11: ( 'H' )
            // LogicalFilter.g:105:13: 'H'
            {
            	Match('H'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "H"

    // $ANTLR start "I"
    public void mI() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:106:11: ( 'I' )
            // LogicalFilter.g:106:13: 'I'
            {
            	Match('I'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "I"

    // $ANTLR start "J"
    public void mJ() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:107:11: ( 'J' )
            // LogicalFilter.g:107:13: 'J'
            {
            	Match('J'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "J"

    // $ANTLR start "K"
    public void mK() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:108:11: ( 'K' )
            // LogicalFilter.g:108:13: 'K'
            {
            	Match('K'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "K"

    // $ANTLR start "L"
    public void mL() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:109:11: ( 'L' )
            // LogicalFilter.g:109:13: 'L'
            {
            	Match('L'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "L"

    // $ANTLR start "M"
    public void mM() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:110:11: ( 'M' )
            // LogicalFilter.g:110:13: 'M'
            {
            	Match('M'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "M"

    // $ANTLR start "N"
    public void mN() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:111:11: ( 'N' )
            // LogicalFilter.g:111:13: 'N'
            {
            	Match('N'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "N"

    // $ANTLR start "O"
    public void mO() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:112:11: ( 'O' )
            // LogicalFilter.g:112:13: 'O'
            {
            	Match('O'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "O"

    // $ANTLR start "P"
    public void mP() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:113:11: ( 'P' )
            // LogicalFilter.g:113:13: 'P'
            {
            	Match('P'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "P"

    // $ANTLR start "Q"
    public void mQ() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:114:11: ( 'Q' )
            // LogicalFilter.g:114:13: 'Q'
            {
            	Match('Q'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "Q"

    // $ANTLR start "R"
    public void mR() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:115:11: ( 'R' )
            // LogicalFilter.g:115:13: 'R'
            {
            	Match('R'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "R"

    // $ANTLR start "S"
    public void mS() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:116:11: ( 'S' )
            // LogicalFilter.g:116:13: 'S'
            {
            	Match('S'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "S"

    // $ANTLR start "T"
    public void mT() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:117:11: ( 'T' )
            // LogicalFilter.g:117:13: 'T'
            {
            	Match('T'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "T"

    // $ANTLR start "U"
    public void mU() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:118:11: ( 'U' )
            // LogicalFilter.g:118:13: 'U'
            {
            	Match('U'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "U"

    // $ANTLR start "V"
    public void mV() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:119:11: ( 'V' )
            // LogicalFilter.g:119:13: 'V'
            {
            	Match('V'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "V"

    // $ANTLR start "W"
    public void mW() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:120:11: ( 'W' )
            // LogicalFilter.g:120:13: 'W'
            {
            	Match('W'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "W"

    // $ANTLR start "X"
    public void mX() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:121:11: ( 'X' )
            // LogicalFilter.g:121:13: 'X'
            {
            	Match('X'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "X"

    // $ANTLR start "Y"
    public void mY() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:122:11: ( 'Y' )
            // LogicalFilter.g:122:13: 'Y'
            {
            	Match('Y'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "Y"

    // $ANTLR start "Z"
    public void mZ() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:123:11: ( 'Z' )
            // LogicalFilter.g:123:13: 'Z'
            {
            	Match('Z'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "Z"

    override public void mTokens() // throws RecognitionException 
    {
        // LogicalFilter.g:1:8: ( T_NULL | T_NOT | T_TRUE | T_FALSE | T_0 | T_1 | NE | EQ | COMMA | DOT | EQ2 | NE2 | WHITESPACE | ENDLINE | SQL_LITERAL | SQL_VARIABLE | A_STRING | Q_STRING )
        int alt7 = 18;
        alt7 = dfa7.Predict(input);
        switch (alt7) 
        {
            case 1 :
                // LogicalFilter.g:1:10: T_NULL
                {
                	mT_NULL(); 

                }
                break;
            case 2 :
                // LogicalFilter.g:1:17: T_NOT
                {
                	mT_NOT(); 

                }
                break;
            case 3 :
                // LogicalFilter.g:1:23: T_TRUE
                {
                	mT_TRUE(); 

                }
                break;
            case 4 :
                // LogicalFilter.g:1:30: T_FALSE
                {
                	mT_FALSE(); 

                }
                break;
            case 5 :
                // LogicalFilter.g:1:38: T_0
                {
                	mT_0(); 

                }
                break;
            case 6 :
                // LogicalFilter.g:1:42: T_1
                {
                	mT_1(); 

                }
                break;
            case 7 :
                // LogicalFilter.g:1:46: NE
                {
                	mNE(); 

                }
                break;
            case 8 :
                // LogicalFilter.g:1:49: EQ
                {
                	mEQ(); 

                }
                break;
            case 9 :
                // LogicalFilter.g:1:52: COMMA
                {
                	mCOMMA(); 

                }
                break;
            case 10 :
                // LogicalFilter.g:1:58: DOT
                {
                	mDOT(); 

                }
                break;
            case 11 :
                // LogicalFilter.g:1:62: EQ2
                {
                	mEQ2(); 

                }
                break;
            case 12 :
                // LogicalFilter.g:1:66: NE2
                {
                	mNE2(); 

                }
                break;
            case 13 :
                // LogicalFilter.g:1:70: WHITESPACE
                {
                	mWHITESPACE(); 

                }
                break;
            case 14 :
                // LogicalFilter.g:1:81: ENDLINE
                {
                	mENDLINE(); 

                }
                break;
            case 15 :
                // LogicalFilter.g:1:89: SQL_LITERAL
                {
                	mSQL_LITERAL(); 

                }
                break;
            case 16 :
                // LogicalFilter.g:1:101: SQL_VARIABLE
                {
                	mSQL_VARIABLE(); 

                }
                break;
            case 17 :
                // LogicalFilter.g:1:114: A_STRING
                {
                	mA_STRING(); 

                }
                break;
            case 18 :
                // LogicalFilter.g:1:123: Q_STRING
                {
                	mQ_STRING(); 

                }
                break;

        }

    }


    protected DFA7 dfa7;
	private void InitializeCyclicDFAs()
	{
	    this.dfa7 = new DFA7(this);
	}

    const string DFA7_eotS =
        "\x07\uffff\x01\x14\x0d\uffff";
    const string DFA7_eofS =
        "\x15\uffff";
    const string DFA7_minS =
        "\x01\x09\x01\x4f\x05\uffff\x01\x3d\x0d\uffff";
    const string DFA7_maxS =
        "\x01\x5b\x01\x55\x05\uffff\x01\x3d\x0d\uffff";
    const string DFA7_acceptS =
        "\x02\uffff\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x01\uffff\x01"+
        "\x09\x01\x0a\x01\x0c\x01\x0d\x01\x0e\x01\x0f\x01\x10\x01\x11\x01"+
        "\x12\x01\x01\x01\x02\x01\x0b\x01\x08";
    const string DFA7_specialS =
        "\x15\uffff}>";
    static readonly string[] DFA7_transitionS = {
            "\x01\x0b\x01\x0c\x01\uffff\x01\x0b\x01\x0c\x12\uffff\x01\x0b"+
            "\x01\x0a\x01\x10\x04\uffff\x01\x0f\x04\uffff\x01\x08\x01\uffff"+
            "\x01\x09\x01\uffff\x01\x04\x01\x05\x0a\uffff\x01\x06\x01\x07"+
            "\x02\uffff\x01\x0e\x05\uffff\x01\x03\x07\uffff\x01\x01\x05\uffff"+
            "\x01\x02\x06\uffff\x01\x0d",
            "\x01\x12\x05\uffff\x01\x11",
            "",
            "",
            "",
            "",
            "",
            "\x01\x13",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA7_eot = DFA.UnpackEncodedString(DFA7_eotS);
    static readonly short[] DFA7_eof = DFA.UnpackEncodedString(DFA7_eofS);
    static readonly char[] DFA7_min = DFA.UnpackEncodedStringToUnsignedChars(DFA7_minS);
    static readonly char[] DFA7_max = DFA.UnpackEncodedStringToUnsignedChars(DFA7_maxS);
    static readonly short[] DFA7_accept = DFA.UnpackEncodedString(DFA7_acceptS);
    static readonly short[] DFA7_special = DFA.UnpackEncodedString(DFA7_specialS);
    static readonly short[][] DFA7_transition = DFA.UnpackEncodedStringArray(DFA7_transitionS);

    protected class DFA7 : DFA
    {
        public DFA7(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 7;
            this.eot = DFA7_eot;
            this.eof = DFA7_eof;
            this.min = DFA7_min;
            this.max = DFA7_max;
            this.accept = DFA7_accept;
            this.special = DFA7_special;
            this.transition = DFA7_transition;

        }

        override public string Description
        {
            get { return "1:1: Tokens : ( T_NULL | T_NOT | T_TRUE | T_FALSE | T_0 | T_1 | NE | EQ | COMMA | DOT | EQ2 | NE2 | WHITESPACE | ENDLINE | SQL_LITERAL | SQL_VARIABLE | A_STRING | Q_STRING );"; }
        }

    }

 
    
}
