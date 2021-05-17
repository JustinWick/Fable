// Implementation file for parser generated by fsyacc
module internal FSharp.Compiler.PPParser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Compiler
open Internal.Utilities.Text.Lexing
open Internal.Utilities.Text.Parsing.ParseHelpers
//# 3 "../../../src/fsharp/pppars.fsy"

open FSharp.Compiler.ErrorLogger
open FSharp.Compiler.ParseHelpers
open FSharp.Compiler.Syntax

let dummy       = IfdefId("DUMMY")

let doNothing _ dflt=
    dflt

let fail (ps : Internal.Utilities.Text.Parsing.IParseState) i e =
    let f,t = ps.InputRange i
    let m   = mkSynRange f t
    errorR(Error(e,m))
    dummy

//# 24 "pppars.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | OP_NOT
  | OP_AND
  | OP_OR
  | LPAREN
  | RPAREN
  | PRELUDE
  | EOF
  | ID of (string)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_OP_NOT
    | TOKEN_OP_AND
    | TOKEN_OP_OR
    | TOKEN_LPAREN
    | TOKEN_RPAREN
    | TOKEN_PRELUDE
    | TOKEN_EOF
    | TOKEN_ID
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_Recover
    | NONTERM_Full
    | NONTERM_Expr

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | OP_NOT  -> 0 
  | OP_AND  -> 1 
  | OP_OR  -> 2 
  | LPAREN  -> 3 
  | RPAREN  -> 4 
  | PRELUDE  -> 5 
  | EOF  -> 6 
  | ID _ -> 7 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_OP_NOT 
  | 1 -> TOKEN_OP_AND 
  | 2 -> TOKEN_OP_OR 
  | 3 -> TOKEN_LPAREN 
  | 4 -> TOKEN_RPAREN 
  | 5 -> TOKEN_PRELUDE 
  | 6 -> TOKEN_EOF 
  | 7 -> TOKEN_ID 
  | 10 -> TOKEN_end_of_input
  | 8 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startstart 
    | 1 -> NONTERM_start 
    | 2 -> NONTERM_Recover 
    | 3 -> NONTERM_Full 
    | 4 -> NONTERM_Full 
    | 5 -> NONTERM_Expr 
    | 6 -> NONTERM_Expr 
    | 7 -> NONTERM_Expr 
    | 8 -> NONTERM_Expr 
    | 9 -> NONTERM_Expr 
    | 10 -> NONTERM_Expr 
    | 11 -> NONTERM_Expr 
    | 12 -> NONTERM_Expr 
    | 13 -> NONTERM_Expr 
    | 14 -> NONTERM_Expr 
    | 15 -> NONTERM_Expr 
    | 16 -> NONTERM_Expr 
    | 17 -> NONTERM_Expr 
    | 18 -> NONTERM_Expr 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 10 
let _fsyacc_tagOfErrorTerminal = 8

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | OP_NOT  -> "OP_NOT" 
  | OP_AND  -> "OP_AND" 
  | OP_OR  -> "OP_OR" 
  | LPAREN  -> "LPAREN" 
  | RPAREN  -> "RPAREN" 
  | PRELUDE  -> "PRELUDE" 
  | EOF  -> "EOF" 
  | ID _ -> "ID" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | OP_NOT  -> (null : System.Object) 
  | OP_AND  -> (null : System.Object) 
  | OP_OR  -> (null : System.Object) 
  | LPAREN  -> (null : System.Object) 
  | RPAREN  -> (null : System.Object) 
  | PRELUDE  -> (null : System.Object) 
  | EOF  -> (null : System.Object) 
  | ID _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 11us; 65535us; 0us; 8us; 6us; 29us; 9us; 26us; 10us; 25us; 13us; 23us; 14us; 29us; 15us; 29us; 16us; 29us; 19us; 20us; 21us; 22us; 27us; 28us; 1us; 65535us; 0us; 2us; 5us; 65535us; 5us; 6us; 9us; 10us; 13us; 14us; 17us; 15us; 18us; 16us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 15us; 17us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 1us; 1us; 1us; 2us; 2us; 2us; 13us; 1us; 3us; 4us; 3us; 8us; 9us; 17us; 1us; 3us; 1us; 4us; 4us; 5us; 13us; 14us; 15us; 5us; 5us; 8us; 9us; 14us; 17us; 1us; 5us; 1us; 6us; 2us; 7us; 12us; 4us; 7us; 8us; 9us; 17us; 4us; 8us; 8us; 9us; 17us; 4us; 8us; 9us; 9us; 17us; 1us; 8us; 1us; 9us; 1us; 10us; 1us; 10us; 1us; 11us; 1us; 11us; 1us; 12us; 1us; 13us; 2us; 14us; 17us; 1us; 15us; 1us; 16us; 1us; 16us; 1us; 17us; 1us; 18us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 6us; 8us; 11us; 13us; 18us; 20us; 22us; 27us; 33us; 35us; 37us; 40us; 45us; 50us; 55us; 57us; 59us; 61us; 63us; 65us; 67us; 69us; 71us; 74us; 76us; 78us; 80us; 82us; |]
let _fsyacc_action_rows = 31
let _fsyacc_actionTableElements = [|2us; 32768us; 5us; 5us; 8us; 3us; 0us; 49152us; 0us; 16385us; 0us; 16386us; 1us; 16386us; 4us; 24us; 7us; 32768us; 0us; 13us; 1us; 19us; 2us; 21us; 3us; 9us; 4us; 27us; 6us; 30us; 7us; 12us; 4us; 32768us; 1us; 17us; 2us; 18us; 6us; 7us; 8us; 3us; 0us; 16387us; 0us; 16388us; 8us; 32768us; 0us; 13us; 1us; 19us; 2us; 21us; 3us; 9us; 4us; 27us; 6us; 30us; 7us; 12us; 8us; 4us; 4us; 32768us; 1us; 17us; 2us; 18us; 4us; 11us; 8us; 3us; 0us; 16389us; 0us; 16390us; 8us; 32768us; 0us; 13us; 1us; 19us; 2us; 21us; 3us; 9us; 4us; 27us; 6us; 30us; 7us; 12us; 8us; 3us; 1us; 16391us; 8us; 3us; 1us; 16392us; 8us; 3us; 2us; 16393us; 1us; 17us; 8us; 3us; 7us; 32768us; 0us; 13us; 1us; 19us; 2us; 21us; 3us; 9us; 4us; 27us; 6us; 30us; 7us; 12us; 7us; 32768us; 0us; 13us; 1us; 19us; 2us; 21us; 3us; 9us; 4us; 27us; 6us; 30us; 7us; 12us; 1us; 32768us; 8us; 3us; 0us; 16394us; 1us; 32768us; 8us; 3us; 0us; 16395us; 0us; 16396us; 0us; 16397us; 0us; 16398us; 0us; 16399us; 1us; 32768us; 8us; 3us; 0us; 16400us; 0us; 16401us; 0us; 16402us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 3us; 4us; 5us; 6us; 8us; 16us; 21us; 22us; 23us; 32us; 37us; 38us; 39us; 48us; 50us; 52us; 55us; 63us; 71us; 73us; 74us; 76us; 77us; 78us; 79us; 80us; 81us; 83us; 84us; 85us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 1us; 1us; 3us; 1us; 3us; 1us; 2us; 3us; 3us; 2us; 2us; 2us; 3us; 3us; 2us; 2us; 2us; 1us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 3us; 3us; 4us; 4us; 4us; 4us; 4us; 4us; 4us; 4us; 4us; 4us; 4us; 4us; 4us; 4us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 16385us; 16386us; 65535us; 65535us; 65535us; 16387us; 16388us; 65535us; 65535us; 16389us; 16390us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16394us; 65535us; 16395us; 16396us; 16397us; 65535us; 16399us; 65535us; 16400us; 16401us; 16402us; |]
let _fsyacc_reductions ()  =    [| 
//# 143 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data :  LexerIfdefExpression )) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Internal.Utilities.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startstart));
//# 152 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Full)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 38 "../../../src/fsharp/pppars.fsy"
                                   _1 
                   )
//# 38 "../../../src/fsharp/pppars.fsy"
                 :  LexerIfdefExpression ));
//# 163 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 41 "../../../src/fsharp/pppars.fsy"
                                                   doNothing parseState ()                                         
                   )
//# 41 "../../../src/fsharp/pppars.fsy"
                 : 'Recover));
//# 173 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 44 "../../../src/fsharp/pppars.fsy"
                                                   _2                                                            
                   )
//# 44 "../../../src/fsharp/pppars.fsy"
                 : 'Full));
//# 184 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Recover)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 45 "../../../src/fsharp/pppars.fsy"
                                                   fail parseState 1 (FSComp.SR.ppparsMissingToken("#if/#elif")) 
                   )
//# 45 "../../../src/fsharp/pppars.fsy"
                 : 'Full));
//# 195 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 48 "../../../src/fsharp/pppars.fsy"
                                                   _2                                                            
                   )
//# 48 "../../../src/fsharp/pppars.fsy"
                 : 'Expr));
//# 206 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 49 "../../../src/fsharp/pppars.fsy"
                                                   IfdefId(_1)                                                   
                   )
//# 49 "../../../src/fsharp/pppars.fsy"
                 : 'Expr));
//# 217 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 50 "../../../src/fsharp/pppars.fsy"
                                                   IfdefNot(_2)                                                  
                   )
//# 50 "../../../src/fsharp/pppars.fsy"
                 : 'Expr));
//# 228 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 51 "../../../src/fsharp/pppars.fsy"
                                                   IfdefAnd(_1,_3)                                               
                   )
//# 51 "../../../src/fsharp/pppars.fsy"
                 : 'Expr));
//# 240 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 52 "../../../src/fsharp/pppars.fsy"
                                                   IfdefOr(_1,_3)                                                
                   )
//# 52 "../../../src/fsharp/pppars.fsy"
                 : 'Expr));
//# 252 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Recover)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 54 "../../../src/fsharp/pppars.fsy"
                                                   fail parseState 1 (FSComp.SR.ppparsUnexpectedToken("&&"))     
                   )
//# 54 "../../../src/fsharp/pppars.fsy"
                 : 'Expr));
//# 263 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Recover)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 55 "../../../src/fsharp/pppars.fsy"
                                                   fail parseState 1 (FSComp.SR.ppparsUnexpectedToken("||"))     
                   )
//# 55 "../../../src/fsharp/pppars.fsy"
                 : 'Expr));
//# 274 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Recover)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 56 "../../../src/fsharp/pppars.fsy"
                                                   fail parseState 1 (FSComp.SR.ppparsUnexpectedToken("!"))      
                   )
//# 56 "../../../src/fsharp/pppars.fsy"
                 : 'Expr));
//# 285 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 57 "../../../src/fsharp/pppars.fsy"
                                                   doNothing parseState dummy                                    
                   )
//# 57 "../../../src/fsharp/pppars.fsy"
                 : 'Expr));
//# 295 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Recover)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 58 "../../../src/fsharp/pppars.fsy"
                                                   fail parseState 3 (FSComp.SR.ppparsMissingToken(")"))         
                   )
//# 58 "../../../src/fsharp/pppars.fsy"
                 : 'Expr));
//# 307 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Recover)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 59 "../../../src/fsharp/pppars.fsy"
                                                   fail parseState 2 (FSComp.SR.ppparsIncompleteExpression())    
                   )
//# 59 "../../../src/fsharp/pppars.fsy"
                 : 'Expr));
//# 318 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Recover)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 60 "../../../src/fsharp/pppars.fsy"
                                                   fail parseState 1 (FSComp.SR.ppparsUnexpectedToken(")"))      
                   )
//# 60 "../../../src/fsharp/pppars.fsy"
                 : 'Expr));
//# 329 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Recover)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 61 "../../../src/fsharp/pppars.fsy"
                                                   fail parseState 2 (FSComp.SR.ppparsIncompleteExpression())    
                   )
//# 61 "../../../src/fsharp/pppars.fsy"
                 : 'Expr));
//# 341 "pppars.fs"
        (fun (parseState : Internal.Utilities.Text.Parsing.IParseState) ->
            Microsoft.FSharp.Core.Operators.box
                (
                   (
//# 62 "../../../src/fsharp/pppars.fsy"
                                                   fail parseState 1 (FSComp.SR.ppparsIncompleteExpression())    
                   )
//# 62 "../../../src/fsharp/pppars.fsy"
                 : 'Expr));
|]
//# 352 "pppars.fs"
let tables () : Internal.Utilities.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:Internal.Utilities.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 11;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let start lexer lexbuf :  LexerIfdefExpression  =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
