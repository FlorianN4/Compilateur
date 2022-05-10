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
           ;



exprd: ID                                           #RightExprID
    | ENTIER                                        #RightExprENTIER
    | STRINGLITTERAL                                #RightExprSTRING
    | LPAR exprd RPAR                               #RightEpxrBetweenPAR
    | ID LPAR (exprd (COMMA exprd)*)? RPAR          #RightExprPARAM
    | exprd op=(DIV|MUL|MODULO) exprd               #RightExprDIVMULMOD
    | exprd op=(PLUS|MINUS) exprd                   #RightExprPLUSMIN
    | exprd op=(PLUSPLUS|MINUSMINUS)                #RightExprPLUSPLUSMINMIN
    | exprd op=(OR|AND|XOR) exprd                   #RightExprORANDXORRightExpr
    | exprd op=(SHIFTD|SHIFTG) exprd                #RightExprSHIFTDGRightExpr
    | NOT exprd                                     #RightExprNOT
    ;

exprg: ID                                            
    ;

fctdecl: TYPE ID LPAR (vardecl (COMMA vardecl) * )? RPAR LBRACE (instruction)* RETURN exprd RBRACE
        ;

vardecl: TYPE ID (EQUAL (NUMBER | BIT8 | BIT16 | HEXA8 | HEXA16 | STRINGLITTERAL))?
        | (BYTE|WORD|STRING) ID EQUAL (NUMBER | BIT8 | BIT16 | HEXA8 | HEXA16 | STRINGLITTERAL)
       ;

constdecl: CONST ID (ENTIER|STRINGLITTERAL)
        ;