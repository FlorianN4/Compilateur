grammar KIWI;

import KiwiWords;

// Program
kiwi: BEGIN 
        (vardecl | constdecl | fctdecl)*
        instruction+
      END                  
      ;

instruction: PRINT LPAR exprd RPAR          #InstPrint
           | NOP                            #InstNOP
           | exprd                          #InstRightExpr
           | exprg EQUAL exprd              #InstLeftEqualRight
           | ID op=(PLUSPLUS|MINUSMINUS)     #InstIncDec 
           ;


exprd: ID                                           #RightExprID
    | (NUMBER | BINARY8 | BINARY16 | HEXA8 | HEXA16)          #RightExprENTIER
    | STRINGLITTERAL                                #RightExprSTRING
    | LPAR exprd RPAR                               #RightEpxrBetweenPAR
    | ID LPAR (exprd (COMMA exprd)*)? RPAR          #RightExprPARAM
    | exprd op=(DIV|MUL|MODULO) exprd               #RightExprDIVMULMOD
    | exprd op=(PLUS|MINUS) exprd                   #RightExprPLUSMIN
    | exprd op=(OR|AND|XOR) exprd                   #RightExprORANDXORRightExpr
    | exprd op=(SHIFTD|SHIFTG) exprd                #RightExprSHIFTDGRightExpr
    | NOT exprd                                     #RightExprNOT
    ;

exprg: ID                                           #LeftExprID 
    ;
paramdecl: (BYTE|WORD) ID
        ;

fctdecl: (BYTE|WORD) ID LPAR (paramdecl (COMMA paramdecl) * )? RPAR LBRACE (instruction)* RETURN exprd RBRACE
        ;

vardecl: (BYTE|WORD|STRING) ID (EQUAL (NUMBER| BIT8 | BIT16 | HEXA8 | HEXA16 | STRINGLITTERAL))?
       ;

constdecl: CONST ID (NUMBER | BIT8 | BIT16 | HEXA8 | HEXA16|STRINGLITTERAL)
        ;

